namespace Vehicle_Park_System.Contracts
{
    using System;

    using Vehicle_Park_System.Models;

    /// <summary>
    /// Defines methods for working with the database.
    /// </summary>
    public interface IVehiclePark
    {
        /// <summary>
        /// Adds a car to the database.
        /// </summary>
        /// <param name="car">Object of type car.</param>
        /// <param name="sector">Sector in which to park.</param>
        /// <param name="placeNumber">Place number in which to park.</param>
        /// <param name="startTime">Time the vehicle had entered.</param>
        /// <returns>String result of the vehicle adding.</returns>
        string InsertCar(Car car, int sector, int placeNumber, DateTime startTime);

        /// <summary>
        /// Adds a motorbike to the database.
        /// </summary>
        /// <param name="motorbike">Object of type motorbike.</param>
        /// <param name="sector">Sector in which to park.</param>
        /// <param name="placeNumber">Place number in which to park.</param>
        /// <param name="startTime">Time the vehicle had entered.</param>
        /// <returns>String result of the vehicle adding.</returns>
        string InsertMotorbike(Motorbike motorbike, int sector, int placeNumber, DateTime startTime);

        /// <summary>
        /// Adds a truck to the database.
        /// </summary>
        /// <param name="truck">Object of type truck.</param>
        /// <param name="sector">Sector in which to park.</param>
        /// <param name="placeNumber">Place number in which to park.</param>
        /// <param name="startTime">Time the vehicle had entered.</param>
        /// <returns>String result of the vehicle adding.</returns>
        string InsertTruck(Truck truck, int sector, int placeNumber, DateTime startTime);

        /// <summary>
        /// Creates a ticket and removes the vehicle from the database.
        /// </summary>
        /// <param name="licensePlate">License plate of the vehicle.</param>
        /// <param name="endTime">Time of park exiting.</param>
        /// <param name="paid">Amount of money given from the customer.</param>
        /// <returns>String ticket.</returns>
        string ExitVehicle(string licensePlate, DateTime endTime, decimal paid);

        /// <summary>
        /// Gets the status of the vehicle park.
        /// </summary>
        /// <returns>String with places occupied in each sector and how full is the vehicle park in each sector. </returns>
        string GetStatus();

        /// <summary>
        /// Finds a vehicle in the database by it's license plate.
        /// </summary>
        /// <param name="licensePlate">License plate of the vehicle.</param>
        /// <returns>String containing vehicle type, license plate and owner.</returns>
        string FindVehicle(string licensePlate);

        /// <summary>
        /// Finds all the vehicles in the database with the same owner.
        /// </summary>
        /// <param name="owner">Owner name.</param>
        /// <returns>String containing all the vehicles in park which have the given owner.</returns>
        string FindVehiclesByOwner(string owner);
    }
}