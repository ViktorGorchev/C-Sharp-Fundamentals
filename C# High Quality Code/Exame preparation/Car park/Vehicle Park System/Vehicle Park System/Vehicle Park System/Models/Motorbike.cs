namespace Vehicle_Park_System.Models
{
    public class Motorbike : Vehicle
    {
        private const decimal DefaultMotorbikeRegularRate = 1.35M;
        private const decimal DefaultMotorbikeOvertimeRate = 3M;

        public Motorbike(string licensePlate, string owner, int reservedHours)
            : base(licensePlate, owner, DefaultMotorbikeRegularRate, DefaultMotorbikeOvertimeRate, reservedHours)
        {
        }
    }
}