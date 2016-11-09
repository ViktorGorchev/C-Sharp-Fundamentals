namespace DataBaseTests
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Theatre.Contracts;
    using Theatre.Core;
    using Theatre.Exceptions;

    [TestClass]
    public class DataBaseMethodsTest
    {
        private IDataBase dataBase;

        private PerformanceDatabase performanceDatabase;

        [TestInitialize]
        public void TestInitialise()
        {
            this.dataBase = new DataBase();
            this.performanceDatabase = new PerformanceDatabase(this.dataBase);
        }

        [TestCleanup]
        public void CleanupTest()
        {
        }

        [TestMethod]
        public void TestListTheatres_NoTheatresAdded_SouldReturnEmptyCollection()
        {
            const int TheatresCount = 0;

            var theatresCollection = this.performanceDatabase.ListTheatres();

            Assert.AreEqual(
                theatresCollection.Count(), 
                TheatresCount, 
                "When no theatres are added an empty collection should be returned!");
        }

        [TestMethod]
        public void TestListTheatres_OneTheatreAdded_SouldReturnOneTheatre()
        {
            List<string> theatresTest = new List<string> { "Theatre 199" };

            this.performanceDatabase.AddTheatre("Theatre 199");

            CollectionAssert.AreEqual(
                theatresTest, 
                this.performanceDatabase.ListTheatres().ToList(), 
                "The method should return collection containing one theatre!");
        }

        [TestMethod]
        public void TestListTheatres_ThreeTheatresAdded_SouldReturnThreeTheatres()
        {
            const int TheatresCount = 3;

            this.performanceDatabase.AddTheatre("Theatre 199");
            this.performanceDatabase.AddTheatre("Theatre Sofia");
            this.performanceDatabase.AddTheatre("Theatre Ivan Vazov");

            var addedTheatresCount = this.performanceDatabase.ListTheatres().Count();
            Assert.AreEqual(
                TheatresCount, 
                addedTheatresCount, 
                string.Format("The method should return collection of {0} theatres!", TheatresCount));
        }

        [TestMethod]
        public void TestListTheatres_ThreeTheatresAdded_SouldReturnThreeTheatresInSortedColection()
        {
            List<string> theatresTest = new List<string> { "Theatre 199", "Theatre Ivan Vazov", "Theatre Sofia" };
            theatresTest.Sort();

            this.performanceDatabase.AddTheatre("Theatre Ivan Vazov");
            this.performanceDatabase.AddTheatre("Theatre 199");
            this.performanceDatabase.AddTheatre("Theatre Sofia");

            CollectionAssert.AreEqual(
                theatresTest, 
                this.performanceDatabase.ListTheatres().ToList(), 
                string.Format(
                    "The method should return collection of three sorted theatres: {0}", 
                    string.Join(", ", theatresTest)));
        }

        [TestMethod]
        [ExpectedException(typeof(TheatreNotFoundException), "Theatre does not exist")]
        public void TestAddPerformances_NoTheatresAdded_ShouldThrow()
        {
            string theatreName = "Theatre Sofia";
            string performance = "Bella Donna";
            DateTime startDate = DateTime.ParseExact(
                "20.01.2015 19:30", 
                "dd.MM.yyyy HH:mm", 
                CultureInfo.InvariantCulture);
            TimeSpan duration = TimeSpan.Parse("1:00");
            decimal price = 15;
            this.performanceDatabase.AddPerformance(theatreName, performance, startDate, duration, price);
        }

        [TestMethod]
        [ExpectedException(typeof(TheatreNotFoundException), "Theatre does not exist")]
        public void TestAddPerformances_TheatreNotInDataBase_ShouldThrow()
        {
            this.performanceDatabase.AddTheatre("Theatre 199");

            string theatreName = "Theatre Sofia";
            string performance = "Bella Donna";
            DateTime startDate = DateTime.ParseExact(
                "20.01.2015 19:30", 
                "dd.MM.yyyy HH:mm", 
                CultureInfo.InvariantCulture);
            TimeSpan duration = TimeSpan.Parse("1:00");
            decimal price = 15;
            this.performanceDatabase.AddPerformance(theatreName, performance, startDate, duration, price);
        }

        [TestMethod]
        [ExpectedException(typeof(TimeDurationOverlapException), "Time/duration overlap")]
        public void TestAddPerformances_DurationOfPerformancesOverlap_ShouldThrow()
        {
            this.performanceDatabase.AddTheatre("Theatre 199");

            string theatreName = "Theatre 199";
            string performance = "Bella Donna";
            DateTime startDate = DateTime.ParseExact(
                "20.01.2015 19:30", 
                "dd.MM.yyyy HH:mm", 
                CultureInfo.InvariantCulture);
            TimeSpan duration = TimeSpan.Parse("1:00");
            decimal price = 15;
            this.performanceDatabase.AddPerformance(theatreName, performance, startDate, duration, price);

            string theatreName2 = "Theatre 199";
            string performance2 = "Bella";
            DateTime startDate2 = DateTime.ParseExact(
                "20.01.2015 19:30", 
                "dd.MM.yyyy HH:mm", 
                CultureInfo.InvariantCulture);
            TimeSpan duration2 = TimeSpan.Parse("2:00");
            decimal price2 = 15;
            this.performanceDatabase.AddPerformance(theatreName2, performance2, startDate2, duration2, price2);
        }

        [TestMethod]
        public void TestAddPerformances_AddTwoPerformancesInSameTheatre_ShouldAdd()
        {
            const string TheatreName = "Theatre 199";
            const int PerfomacesCount = 2;
            this.performanceDatabase.AddTheatre(TheatreName);

            string performance = "Bella Donna";
            DateTime startDate = DateTime.ParseExact(
                "20.01.2015 19:30", 
                "dd.MM.yyyy HH:mm", 
                CultureInfo.InvariantCulture);
            TimeSpan duration = TimeSpan.Parse("1:00");
            decimal price = 15m;
            this.performanceDatabase.AddPerformance(TheatreName, performance, startDate, duration, price);

            string performance2 = "Don Juan";
            DateTime startDate2 = DateTime.ParseExact(
                "18.01.2015 19:30", 
                "dd.MM.yyyy HH:mm", 
                CultureInfo.InvariantCulture);
            TimeSpan duration2 = TimeSpan.Parse("2:00");
            decimal price2 = 14.60m;
            this.performanceDatabase.AddPerformance(TheatreName, performance2, startDate2, duration2, price2);

            var addedPerformancesCount = this.performanceDatabase.ListPerformances(TheatreName).Count();
            Assert.AreEqual(
                addedPerformancesCount, 
                PerfomacesCount, 
                string.Format("Added performances should be {0}!", PerfomacesCount));
        }

        [TestMethod]
        public void TestAddPerformances_AddTwoPerformancesInTwoTheatre_ShouldAdd()
        {
            const string FirstTheatreName = "Theatre 199";
            const string SecondTheatreName = "Theatre Sofia";
            this.performanceDatabase.AddTheatre(FirstTheatreName);
            this.performanceDatabase.AddTheatre(SecondTheatreName);

            string performance = "Bella Donna";
            DateTime startDate = DateTime.ParseExact(
                "20.01.2015 19:30", 
                "dd.MM.yyyy HH:mm", 
                CultureInfo.InvariantCulture);
            TimeSpan duration = TimeSpan.Parse("1:00");
            decimal price = 15m;
            this.performanceDatabase.AddPerformance(FirstTheatreName, performance, startDate, duration, price);

            string performance2 = "Don Juan";
            DateTime startDate2 = DateTime.ParseExact(
                "18.01.2015 19:30", 
                "dd.MM.yyyy HH:mm", 
                CultureInfo.InvariantCulture);
            TimeSpan duration2 = TimeSpan.Parse("2:00");
            decimal price2 = 14.60m;
            this.performanceDatabase.AddPerformance(SecondTheatreName, performance2, startDate2, duration2, price2);

            var firstTheatrePerformancesCount = this.performanceDatabase.ListPerformances(FirstTheatreName).Count();
            var secondTheatrePerfomancesCount = this.performanceDatabase.ListPerformances(SecondTheatreName).Count();
            Assert.AreEqual(
                firstTheatrePerformancesCount, 
                secondTheatrePerfomancesCount, 
                "Added performances in the two theatres should be equal!");
        }

        [TestMethod]
        public void TestAddPerformances_AddTPerformances_PerformancesDataShouldCorespondToAddedData()
        {
            const string TheatreName = "Theatre 199";
            this.performanceDatabase.AddTheatre(TheatreName);

            string performance = "Bella Donna";
            DateTime startDate = DateTime.ParseExact(
                "20.01.2015 19:30", 
                "dd.MM.yyyy HH:mm", 
                CultureInfo.InvariantCulture);
            TimeSpan duration = TimeSpan.Parse("1:00");
            decimal price = 15m;

            this.performanceDatabase.AddPerformance(TheatreName, performance, startDate, duration, price);

            var performanceAdded = this.performanceDatabase.ListPerformances(TheatreName).ToList();
            Assert.AreEqual(performanceAdded[0].TheatreName, TheatreName, "Theatre name must match the added data!");
            Assert.AreEqual(performanceAdded[0].Play, performance, "Performance name must match the added data!");
            Assert.AreEqual(performanceAdded[0].Date, startDate, "Start date must match the added data!");
            Assert.AreEqual(performanceAdded[0].Duration, duration, "Duration time must match the added data!");
            Assert.AreEqual(performanceAdded[0].Price, price, "Price must match the added data!");
        }

        [TestMethod]
        [ExpectedException(typeof(TheatreNotFoundException), "Theatre does not exist")]
        public void TestListPerformances_TheatreNotAdded_ShouldThrow()
        {
            this.performanceDatabase.ListPerformances("Theatre 199");
        }

        [TestMethod]
        [ExpectedException(typeof(TheatreNotFoundException), "Theatre does not exist")]
        public void TestListPerformances_TheatreNotOneOfAddedTheatres_ShouldThrow()
        {
            this.performanceDatabase.AddTheatre("Theatre Sofia");

            this.performanceDatabase.ListPerformances("Theatre 199");
        }

        [TestMethod]
        public void TestListPerformance_NoPerformancesInTheAddedTheatre_ShouldReturnZeroPerformances()
        {
            const int PerformancesCount = 0;
            this.performanceDatabase.AddTheatre("Theatre 199");

            var addedPerformancesCoubt = this.performanceDatabase.ListPerformances("Theatre 199").Count();

            Assert.AreEqual(
                addedPerformancesCoubt, 
                PerformancesCount, 
                string.Format("Performances count should be {0}!", PerformancesCount));
        }

        [TestMethod]
        public void TestListPerformance_TwoPerformancesAdded_ShouldReturnTwoPerformances()
        {
            const string TheatreName = "Theatre 199";
            const int PerfomacesCount = 2;
            this.performanceDatabase.AddTheatre(TheatreName);

            string performance = "Bella Donna";
            DateTime startDate = DateTime.ParseExact(
                "20.01.2015 19:30", 
                "dd.MM.yyyy HH:mm", 
                CultureInfo.InvariantCulture);
            TimeSpan duration = TimeSpan.Parse("1:00");
            decimal price = 15m;
            this.performanceDatabase.AddPerformance(TheatreName, performance, startDate, duration, price);

            string performance2 = "Don Juan";
            DateTime startDate2 = DateTime.ParseExact(
                "18.01.2015 19:30", 
                "dd.MM.yyyy HH:mm", 
                CultureInfo.InvariantCulture);
            TimeSpan duration2 = TimeSpan.Parse("2:00");
            decimal price2 = 14.60m;
            this.performanceDatabase.AddPerformance(TheatreName, performance2, startDate2, duration2, price2);

            var addedPerformancesCount = this.performanceDatabase.ListPerformances(TheatreName).Count();
            Assert.AreEqual(
                addedPerformancesCount, 
                PerfomacesCount, 
                string.Format("Added performances should be {0}!", PerfomacesCount));
        }

        [TestMethod]
        public void TestListPerformance_TwoPerformancesAdded_ShouldReturnTwoSortedPerformancesByNameAndDate()
        {
            const string TheatreName = "Theatre 199";
            this.performanceDatabase.AddTheatre(TheatreName);

            string performance = "Bella Donna";
            DateTime startDate = DateTime.ParseExact(
                "20.01.2015 19:30", 
                "dd.MM.yyyy HH:mm", 
                CultureInfo.InvariantCulture);
            TimeSpan duration = TimeSpan.Parse("1:00");
            decimal price = 15m;
            this.performanceDatabase.AddPerformance(TheatreName, performance, startDate, duration, price);

            string performance2 = "Don Juan";
            DateTime startDate2 = DateTime.ParseExact(
                "18.01.2015 19:30", 
                "dd.MM.yyyy HH:mm", 
                CultureInfo.InvariantCulture);
            TimeSpan duration2 = TimeSpan.Parse("2:00");
            decimal price2 = 14.60m;
            this.performanceDatabase.AddPerformance(TheatreName, performance2, startDate2, duration2, price2);

            var addedPerformances = this.performanceDatabase.ListPerformances(TheatreName).ToList();
            Assert.AreEqual(
                performance2, 
                addedPerformances[0].Play, 
                string.Format("First performance should be {0}!", performance2));
            Assert.AreEqual(
                startDate2, 
                addedPerformances[0].Date, 
                string.Format("First performance should be {0}, with date {1}!", performance2, startDate2));
        }
    }
}