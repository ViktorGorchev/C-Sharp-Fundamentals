namespace UnitTestsCustomLinkedList
{
    using System;
    using CustomLinkedList;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TestCustomLinkedList : TestBase
    {
        private static DynamicList<string> dynamicList;
      
        [ClassInitialize]
        public static void DynamicListTestsInitialize(TestContext testContext)
        {
            dynamicList = new DynamicList<string>();
        }

        [TestInitialize]
        public void ResetDynamicListObject()
        {
            dynamicList = new DynamicList<string>();
        }

        [TestMethod]
        public void Count_TestCountOnNewListCreation_ShouldPassTest()
        {
            int initialCount = dynamicList.Count;
            Assert.AreEqual(0, initialCount, "A newly created list should have a count of 0.");
        }

        [TestMethod]
        public void Count_TestCountAfterAddingOneElement_ShouldPassTest()
        {
            dynamicList.Add("one");
            this.AddCleanupAction(() => dynamicList.Remove("one"));

            int count = dynamicList.Count;
            Assert.AreEqual(1, count, "After adding one element the count of the list should be 1.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Indexer_TestWithEmptyDynamicList_ShouldThrowArgumentOutOfRangeException()
        {
            string value = dynamicList[0];
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Indexer_TestWithNegativeIndex_ShouldThrowArgumentOutOfRangeException()
        {
            string value = dynamicList[-1];
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Indexer_TestWithIndexBeyondListCount_ShouldThrowArgumentOutOfRangeException()
        {
            dynamicList.Add("one");
            this.AddCleanupAction(() => dynamicList.Remove("one"));

            string actual = dynamicList[1];
        }

        [TestMethod]
        public void Indexer_TestWithValidIndex_ShouldPassTest()
        {
            dynamicList.Add("one");
            this.AddCleanupAction(() => dynamicList.Remove("one"));

            string value = dynamicList[0];
        }

        [TestMethod]
        public void Add_TestAddedElementValue_ShouldPassTest()
        {
            dynamicList.Add("one");
            this.AddCleanupAction(() => dynamicList.Remove("one"));

            string value = dynamicList[0];
            Assert.AreEqual("one", value, "The value at index 0 should be equal to the value entered.");
        }

        [TestMethod]
        public void Elements_TestPositionsOfElementsAddedInSequence_ShouldPassTest()
        {
            dynamicList.Add("first");
            dynamicList.Add("second");
            this.AddCleanupAction(() => dynamicList.Remove("first"));
            this.AddCleanupAction(() => dynamicList.Remove("second"));

            string firstElement = dynamicList[0];
            string secondElement = dynamicList[1];

            Assert.AreEqual(
                "first", 
                firstElement, 
                "The element at index 0 should be the first element added to the list.");
            Assert.AreEqual(
                "second", 
                secondElement, 
                "The element at index 1 should be the second element added to the list.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Set_TestAtNegativeIndex_ShouldThrowArgumentOutOfRangeException()
        {
            dynamicList[-1] = "one";
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Set_TestAtIndexBeyondListCount1_ShouldThrowArgumentOutOfRangeException()
        {
            dynamicList.Add("one");
            this.AddCleanupAction(() => dynamicList.Remove("one"));

            dynamicList[1] = "two";
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Set_TestAtIndexBeyondListCount2_ShouldThrowArgumentOutOfRangeException()
        {
            dynamicList[0] = "one";
        }

        [TestMethod]
        public void Set_TestAtValidIndex_ShouldPassTest()
        {
            dynamicList.Add("initial");
            dynamicList[0] = "changed";
            this.AddCleanupAction(() => dynamicList.Remove("changed"));

            string newValue = dynamicList[0];
            Assert.AreEqual("changed", newValue, "The value at index 0 should be changed through the indexer.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Remove_TestAtNegativeIndex_ShouldThrowArgumentOutOfRangeException()
        {
            dynamicList.RemoveAt(-1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Remove_TestAtIndexBeyondListCount_ShouldThrowArgumentOutOfRangeException()
        {
            dynamicList.Add("first");
            dynamicList.Add("second");
            this.AddCleanupAction(() => dynamicList.Remove("first"));
            this.AddCleanupAction(() => dynamicList.Remove("second"));

            dynamicList.RemoveAt(2);
        }

        [TestMethod]
        public void Count_TestListCountAfterRemoveAt_ShouldPassTest()
        {
            dynamicList.Add("one");
            dynamicList.RemoveAt(0);

            int count = dynamicList.Count;
            Assert.AreEqual(0, count);
        }

        [TestMethod]
        public void RemoveAt_TestRemainingElementsPositionsAfterRemoveAt_ShouldPassTest()
        {
            dynamicList.Add("one");
            dynamicList.Add("two");
            dynamicList.Add("three");
            this.AddCleanupAction(() => dynamicList.Remove("one"));
            this.AddCleanupAction(() => dynamicList.Remove("three"));

            dynamicList.RemoveAt(1);

            string first = dynamicList[0];
            string second = dynamicList[1];

            Assert.AreEqual("one", first, "The string entered first should be at position 0.");
            Assert.AreEqual("three", second, "The entered third should be at position 1 after the removal at 1.");
        }

        [TestMethod]
        public void Count_TestAfterRemovingNonExistingElementFromList_ShouldPassTest()
        {
            dynamicList.Add("one");
            dynamicList.Add("two");
            this.AddCleanupAction(() => dynamicList.Remove("one"));
            this.AddCleanupAction(() => dynamicList.Remove("two"));

            dynamicList.Remove("three");

            int count = dynamicList.Count;

            Assert.AreEqual(
                2, 
                count, 
                "The count of the list should remain unchanged after trying to remove a non-existing element.");
        }

        [TestMethod]
        public void Remove_TestReturnValueAfterRemovingNonExistingElementFromList_ShouldPassTest()
        {
            dynamicList.Add("one");
            dynamicList.Add("two");
            this.AddCleanupAction(() => dynamicList.Remove("one"));
            this.AddCleanupAction(() => dynamicList.Remove("two"));

            int index = dynamicList.Remove("three");

            Assert.AreEqual(-1, index, "The returned index of a non-existing element should be -1.");
        }

        [TestMethod]
        public void Count_TestAfterRemovingElementFromList_ShouldPassTest()
        {
            dynamicList.Add("first");
            dynamicList.Add("second");
            dynamicList.Add("third");
            this.AddCleanupAction(() => dynamicList.Remove("first"));
            this.AddCleanupAction(() => dynamicList.Remove("third"));

            dynamicList.Remove("second");
            int count = dynamicList.Count;

            Assert.AreEqual(2, count, "The count of elements of the list should be 2 after removing an element.");
        }

        [TestMethod]
        public void Remove_TestReturnValueAfterRemovingElementFromList_ShouldPassTest()
        {
            dynamicList.Add("first");
            dynamicList.Add("second");
            dynamicList.Add("third");
            this.AddCleanupAction(() => dynamicList.Remove("first"));
            this.AddCleanupAction(() => dynamicList.Remove("third"));

            int index = dynamicList.Remove("second");

            Assert.AreEqual(1, index, "The index of the removed element should be 1.");
        }

        [TestMethod]
        public void Remove_TestRemainingElementsPositionsAfterRemove_ShouldPassTest()
        {
            dynamicList.Add("first");
            dynamicList.Add("second");
            dynamicList.Add("third");
            this.AddCleanupAction(() => dynamicList.Remove("first"));
            this.AddCleanupAction(() => dynamicList.Remove("third"));

            dynamicList.Remove("second");
            string first = dynamicList[0];
            string second = dynamicList[1];

            Assert.AreEqual("first", first, "The first element of the list should be the first one entered.");
            Assert.AreEqual(
                "third", 
                second, 
                "The second element in the list should be the third one entered after removing the second element.");
        }

        [TestMethod]
        public void IndexOf_TestOnNonExistingElement_ShouldPassTest()
        {
            dynamicList.Add("first");
            dynamicList.Add("second");
            this.AddCleanupAction(() => dynamicList.Remove("first"));
            this.AddCleanupAction(() => dynamicList.Remove("second"));

            int index = dynamicList.IndexOf("third");

            Assert.AreEqual(-1, index, "The return value when searching for a non-existing element should be -1.");
        }

        [TestMethod]
        public void IndexOf_TestOnExistingElement_ShouldPassTest()
        {
            dynamicList.Add("first");
            dynamicList.Add("second");
            this.AddCleanupAction(() => dynamicList.Remove("first"));
            this.AddCleanupAction(() => dynamicList.Remove("second"));

            int index = dynamicList.IndexOf("second");

            Assert.AreEqual(1, index, "The index of the searched element should be 1.");
        }

        [TestMethod]
        public void Contains_TestOnNonExisingElement_ShouldPassTest()
        {
            dynamicList.Add("first");
            dynamicList.Add("second");
            this.AddCleanupAction(() => dynamicList.Remove("first"));
            this.AddCleanupAction(() => dynamicList.Remove("second"));

            bool isFound = dynamicList.Contains("third");

            Assert.IsFalse(isFound, "The element is not in the list and Contains should return false.");
        }

        [TestMethod]
        public void Contains_TestOnExisingElement_ShouldPassTest()
        {
            dynamicList.Add("first");
            dynamicList.Add("second");
            this.AddCleanupAction(() => dynamicList.Remove("first"));
            this.AddCleanupAction(() => dynamicList.Remove("second"));

            bool isFound = dynamicList.Contains("second");

            Assert.IsTrue(isFound, "The element is in the list and Contains should return true.");
        }

        [TestCleanup]
        public void Cleanup()
        {
            this.TestCleanup();
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            dynamicList.Clear();
        }
    }
}