namespace TestUniversityBangalore
{
    using System;
    using BangaloreUniversityLearningSystem.Utilities;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class MoqTestAddLecture
    {

        private Mock<Lecture> lecture1;
        private Mock<Lecture> lecture2;
        private readonly Mock<Course> course = new Mock<Course>("C# Moq");
        
        [TestCleanup]
        public void CleanupTest()
        {
            this.lecture1 = null;
            this.lecture2 = null;
        }

        [TestMethod]
        public void TestAddLecture_AddOneLecture_LecturesCountOne()
        {
            const int LecturesCount = 1;
            this.lecture1 = new Mock<Lecture>("Mocking in C#");

            this.course.Object.AddLecture(this.lecture1.Object);

            Assert.AreEqual(
                LecturesCount, 
                this.course.Object.Lectures.Count, 
                string.Format("The lecture saved should be {0}!", LecturesCount));
        }

        [TestMethod]
        public void TestAddLecture_AddTwoLectures_LecturesCountTwo()
        {
            const int LecturesCount = 2;
            this.lecture1 = new Mock<Lecture>("Mocking in C#");
            this.lecture2 = new Mock<Lecture>("OOP in C#");

            this.course.Object.AddLecture(this.lecture1.Object);
            this.course.Object.AddLecture(this.lecture2.Object);

            Assert.AreEqual(
                LecturesCount,
                this.course.Object.Lectures.Count,
                string.Format("The lecture saved should be {0}!", LecturesCount));
        }

        [TestMethod]
        public void TestAddLecture_AddOneLecture_LectureSavedShouldBeEqualWithTheAddedOne()
        {
            this.lecture1 = new Mock<Lecture>("Mocking in C#");

            this.course.Object.AddLecture(this.lecture1.Object);

            Assert.AreEqual(
                this.lecture1.Object, this.course.Object.Lectures[0], "The lecture saved should be the sames as added one!");
        }
    }
}
