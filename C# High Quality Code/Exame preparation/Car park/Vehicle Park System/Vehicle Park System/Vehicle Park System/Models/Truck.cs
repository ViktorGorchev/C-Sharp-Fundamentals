namespace Vehicle_Park_System.Models
{
    public class Truck : Vehicle
    {
        private const decimal DefaultTruckRegularRate = 4.75M;
        private const decimal DefaultTruckOvertimeRate = 6.2M;
        
        public Truck(string licensePlate, string owner, int reservedHours)
            : base(licensePlate, owner, DefaultTruckRegularRate, DefaultTruckOvertimeRate, reservedHours)
        {
        }
    }
}