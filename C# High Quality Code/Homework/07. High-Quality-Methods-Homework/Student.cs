namespace Methods
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Threading;

    public class Student
    {
        private string firstName;
        private string lastName;

        public Student(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new AggregateException("Firs name can't be null or empty string!");
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new AggregateException("Last name can't be null or empty string!");
                }

                this.lastName = value;
            }
        }

        public string AdditionalInfo { get; set; }
        
        public bool IsOlderThan(Student other)
        {
            try
            {
                DateTime thisStudentDateOfBirth = this.GetDateOfBirth(this.AdditionalInfo);
                DateTime otherStudentDateOfBirth = other.GetDateOfBirth(other.AdditionalInfo);
                return thisStudentDateOfBirth < otherStudentDateOfBirth;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new ArgumentException("One or both students do not have valid date of birth information provided.");
            }
        }

        public DateTime GetDateOfBirth(string info)
        {
            string[] paramArgs = info.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            string dateInfo = paramArgs.Last().Substring(8).Trim();

            if (!IsValidBulgarianFormatDate(dateInfo))
            {
                throw new FormatException("Invalid date format.");
            }

            DateTime date = DateTime.Parse(dateInfo);

            return date;
        }

        private static bool IsValidBulgarianFormatDate(string dateInfo)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("bg-BG");
            DateTime date;
            bool isValiDate = DateTime.TryParse(dateInfo, out date);

            return isValiDate;
        }
    }
}
