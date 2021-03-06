using Vehicle_Park_System.Models;
// <copyright file="VehicleParkTest.cs">Copyright ©  2016</copyright>

using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vehicle_Park_System.Models.Parking;

namespace Vehicle_Park_System.Models.Parking.Tests
{
    [TestClass]
    [PexClass(typeof(VehiclePark))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class VehicleParkTest
    {

        [PexMethod]
        public string InsertCar(
            [PexAssumeUnderTest]VehiclePark target,
            Car car,
            int sector,
            int placeNumber,
            DateTime startTime
        )
        {
            string result = target.InsertCar(car, sector, placeNumber, startTime);
            return result;
            // TODO: add assertions to method VehicleParkTest.InsertCar(VehiclePark, Car, Int32, Int32, DateTime)
        }
    }
}
