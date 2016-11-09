using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_HumanStudentAndWorker
{
    class HumansArchive
    {
        static void Main()
        {
            List<Student> studentsArchive = new List<Student>
            {
                new Student("Saho", "Goshev", "12345G"),
                new Student("Spas","Goshev","12345F"),
                new Student("Ilia","Iliev","12345P"),
                new Student("Stamat", "Petrov","12345Y"),
                new Student("Pavel","Ighatov","12345U"),
                new Student("Kiro","Ivanov","12345K"),
                new Student("Ignat","Petrov","12345Q"),
                new Student("Anatoli","Petrov","12345A"),
                new Student("Boris","Nikolov","12345B"),
                new Student("Nikola","Kolev","12345C"),
            };
            
            var sortStudents =
                    from student in studentsArchive
                    orderby student.FacultyNumber
                    select student; 
            
            foreach (var item in sortStudents)
            {
                Console.WriteLine(item.FacultyNumber + " --> Name: "+ item.FirstName + " " + item.LastName);

            }
            Console.WriteLine();

            List<Worker> workerArchive = new List<Worker>
            {
                new Worker("Gosho", "Goshev", 220m, 5),
                new Worker("Ivan","Goshev",300m, 5),
                new Worker("Sasho","Iliev",150m, 3),
                new Worker("Gosho", "Petrov",700m, 8),
                new Worker("Iavor","Ighatov",240m, 5),
                new Worker("Ivan","Ivanov",900m, 13),
                new Worker("Igor","Petrov",805m, 8),
                new Worker("Petur","Petrov",500m, 9),
                new Worker("Atanas","Nikolov",600m,7),
                new Worker("Nikola","Kolev",300m,11),
                
            };

            var sortWorkers =
                    from worker in workerArchive
                    orderby worker.MoneyPerHour() descending
                    select worker;

            foreach (var item in sortWorkers)
            {
                Console.WriteLine("Money per hour: {0}", item.MoneyPerHour() + Environment.NewLine +
                    " Name: " + item.FirstName + " " + item.LastName + 
                    " Week salary: " + item.WeekSalary + " Hours of work per week: " + item.WorkHoursPerDay);
            }
            Console.WriteLine();

            List<Human> studentsAndWorkers = new List<Human>();
            studentsAndWorkers.AddRange(studentsArchive);
            studentsAndWorkers.AddRange(workerArchive);
            
            studentsAndWorkers = studentsAndWorkers.OrderBy(p => p.FirstName).ThenBy(p => p.LastName).ToList();

            foreach (var item in studentsAndWorkers)
            {
                Console.WriteLine("Name: " + item.FirstName + " " + item.LastName);
            }


        }
    }
}
