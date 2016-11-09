namespace Vehicle_Park_System.Models.Parking
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Vehicle_Park_System.Contracts;
    
    public class VehiclePark : IVehiclePark
    {
        private int placesPerSector;
        private int numberOfSectors;
        private IDataBase dataBase;

        public VehiclePark(int numberOfSectors, int placesPerSector, IDataBase dataBase)
        {
            this.NumberOfSectors = numberOfSectors;
            this.PlacesPerSector = placesPerSector;
            this.dataBase = dataBase;
        }

        public int PlacesPerSector
        {
            get
            {
                return this.placesPerSector;
            }

            set
            {
                if (value <= 0)
                {
                    throw new AggregateException("The number of places per sector must be positive.");
                }

                this.placesPerSector = value;
            }
        }

        public int NumberOfSectors
        {
            get
            {
                return this.numberOfSectors;
            }

            set
            {
                if (value <= 0)
                {
                    throw new AggregateException("The number of sectors must be positive.");
                }

                this.numberOfSectors = value;
            }
        }

        public string InsertVehicle(IVehicle vehicle, int sector, int placeNumber, DateTime startTime)
        {
            string validationResult = this.ValidateInputData(vehicle, sector, placeNumber);
            if (validationResult != null)
            {
                return validationResult;
            }
            
            this.dataBase.VehicleInPark[vehicle] = string.Format("({0},{1})", sector, placeNumber);
            this.dataBase.Park[string.Format("({0},{1})", sector, placeNumber)] = vehicle;
            this.dataBase.NumberPlates[vehicle.LicensePlate] = vehicle;
            this.dataBase.Time[vehicle] = startTime;
            this.dataBase.Owner[vehicle.Owner] = vehicle;
            this.dataBase.FreePlaces[sector] -= 1;

            return string.Format("{0} parked successfully at place ({1},{2})", vehicle.GetType().Name, sector, placeNumber);
        }

        public string InsertCar(Car car, int sector, int placeNumber, DateTime startTime)
        {
            var result = this.InsertVehicle(car, sector, placeNumber, startTime);

            return result;
        }

        public string InsertMotorbike(Motorbike motorbike, int sector, int placeNumber, DateTime startTime)
        {
            var result = this.InsertVehicle(motorbike, sector, placeNumber, startTime);

            return result;
        }

        public string InsertTruck(Truck truck, int sector, int placeNumber, DateTime startTime)
        {
            var result = this.InsertVehicle(truck, sector, placeNumber, startTime);

            return result;
        }

        public string ExitVehicle(string licensePlate, DateTime endTime, decimal paid)
        {
            var vehicle = this.dataBase.NumberPlates.ContainsKey(licensePlate) ? this.dataBase.NumberPlates[licensePlate] : null;
            if (vehicle == null)
            {
                return string.Format("There is no vehicle with license plate {0} in the park", licensePlate);
            }

            var startTime = this.dataBase.Time[vehicle];
            int timeParked = (int)Math.Round((endTime - startTime).TotalHours);
            var rate = vehicle.ReservedHours * vehicle.RegularRate;
            var overtimeRate = timeParked > vehicle.ReservedHours
                                   ? (timeParked - vehicle.ReservedHours) * vehicle.OvertimeRate
                                   : 0;
            var totalPrice = 
                (vehicle.ReservedHours * vehicle.RegularRate) + 
                (timeParked > vehicle.ReservedHours
                                    ? (timeParked - vehicle.ReservedHours) * vehicle.OvertimeRate
                                    : 0);
            var change = 
                paid - 
                ((vehicle.ReservedHours * vehicle.RegularRate) + 
                (timeParked > vehicle.ReservedHours
                                   ? (timeParked - vehicle.ReservedHours) * vehicle.OvertimeRate
                                   : 0));

            var ticket = new StringBuilder();
            ticket.AppendLine(new string('*', 20))
                .AppendFormat("{0}{1}", vehicle, Environment.NewLine)
                .AppendFormat("at place {0}{1}", this.dataBase.VehicleInPark[vehicle], Environment.NewLine)
                .AppendFormat("Rate: ${0:F2}{1}", rate, Environment.NewLine)
                .AppendFormat("Overtime rate: ${0:F2}{1}", overtimeRate, Environment.NewLine)
                .AppendLine(new string('-', 20))
                .AppendFormat("Total: ${0:F2}{1}", totalPrice, Environment.NewLine)
                .AppendFormat("Paid: ${0:F2}{1}", paid, Environment.NewLine)
                .AppendFormat("Change: ${0:F2}{1}", change, Environment.NewLine)
                .Append(new string('*', 20));

            this.RemoveVehicleFromDataBase(vehicle);
            
            return ticket.ToString();
        }

        public string GetStatus()
        {
            var places = this.dataBase.FreePlaces.Select(
                    p =>
                    string.Format(
                        "Sector {0}: {1} / {2} ({3}% full)",
                        p.Key,
                        this.PlacesPerSector - p.Value,
                        this.PlacesPerSector,
                        Math.Round((this.PlacesPerSector - (double)p.Value) / this.PlacesPerSector * 100)));
                
            return string.Join(Environment.NewLine, places);
        }

        public string FindVehicle(string licensePlate)
        {
            var vehicle = this.dataBase.NumberPlates.ContainsKey(licensePlate) ? this.dataBase.NumberPlates[licensePlate] : null;
            if (vehicle == null)
            {
                return string.Format("There is no vehicle with license plate {0} in the park", licensePlate);
            }

            return this.FormatFoundVehicles(new[] { vehicle });
        }

        public string FindVehiclesByOwner(string owner)
        {
            if (!this.dataBase.Park.Values.Where(v => v.Owner == owner).Any())
            {
                return string.Format("No vehicles by {0}", owner);
            }

            var found = this.dataBase.Park.Values.Where(v => v.Owner == owner).ToList();
            string result = this.FormatFoundVehicles(found);

            return result;
        }

        private string FormatFoundVehicles(IEnumerable<IVehicle> vehicles)
        {
            return string.Join(
                Environment.NewLine, 
                vehicles.Select(
                    vehicle =>
                    string.Format(
                        "{0}{1}Parked at {2}", 
                        vehicle.ToString(), 
                        Environment.NewLine, 
                        this.dataBase.VehicleInPark[vehicle])));
        }

        private void RemoveVehicleFromDataBase(IVehicle vehicle)
        {
            int sector =
                  int.Parse(
                      this.dataBase.VehicleInPark[vehicle].Split(
                          new[] { "(", ",", ")" },
                          StringSplitOptions.RemoveEmptyEntries)[0]);

            this.dataBase.Park.Remove(this.dataBase.VehicleInPark[vehicle]);
            this.dataBase.VehicleInPark.Remove(vehicle);
            this.dataBase.NumberPlates.Remove(vehicle.LicensePlate);
            this.dataBase.Time.Remove(vehicle);
            this.dataBase.Owner.Remove(vehicle.Owner);
            this.dataBase.FreePlaces[sector] += 1;
        }

        private string ValidateInputData(IVehicle vehicle, int sector, int placeNumber)
        {
            if (sector > this.NumberOfSectors || sector <= 0)
            {
                return string.Format("There is no sector {0} in the park", sector);
            }

            if (placeNumber > this.PlacesPerSector || placeNumber <= 0)
            {
                return string.Format("There is no place {0} in sector {1}", placeNumber, sector);
            }

            if (this.dataBase.Park.ContainsKey(string.Format("({0},{1})", sector, placeNumber)))
            {
                return string.Format("The place ({0},{1}) is occupied", sector, placeNumber);
            }

            if (this.dataBase.NumberPlates.ContainsKey(vehicle.LicensePlate))
            {
                return string.Format(
                    "There is already a vehicle with license plate {0} in the park",
                    vehicle.LicensePlate);
            }

            if (this.dataBase.FreePlaces[sector] == 0)
            {
                return string.Format("No free places in sector {0}!", sector);
            }

            return null;
        }
    }
}