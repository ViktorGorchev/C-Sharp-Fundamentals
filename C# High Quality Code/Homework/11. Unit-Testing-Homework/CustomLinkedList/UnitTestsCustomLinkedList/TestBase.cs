namespace UnitTestsCustomLinkedList
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public abstract class TestBase
    {
        private readonly List<Action> cleanupActions = new List<Action>();

        public void AddCleanupAction(Action cleanupAction)
        {
            this.cleanupActions.Add(cleanupAction);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            Console.WriteLine("=============================== Test Cleanup ===============================");
            Console.WriteLine();

            this.CallCleanupActions();
        }

        private void CallCleanupActions()
        {
            this.cleanupActions.Reverse();
            var exceptions = new List<Exception>();

            foreach (var action in this.cleanupActions)
            {
                try
                {
                    action();
                }
                catch (Exception ex)
                {
                    exceptions.Add(ex);
                    Console.WriteLine("Cleanup action failed: " + ex);
                }
            }

            if (exceptions.Count == 0)
            {
                return;
            }

            if (exceptions.Count == 1)
            {
                throw exceptions.Single();
            }

            throw new AggregateException(
                "Multiple exceptions occured in Cleanup. See test log for more details",
                exceptions);
        }
    }
}
