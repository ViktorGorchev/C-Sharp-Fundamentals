namespace Vehicle_Park_System.Models
{
    public class Car : Vehicle
    {
        private const decimal DefaultCarRegularRate = 2M;
        private const decimal DefaultCarOvertimeRate = 3.5M;

        public Car(string licensePlate, string owner, int reservedHours)
            : base(licensePlate, owner, DefaultCarRegularRate, DefaultCarOvertimeRate, reservedHours)
        {
        }
    }
}