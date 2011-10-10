using Immutable;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ImmutableTest
{


    /// <summary>
    ///This is a test class for ImmutableStackTest and is intended
    ///to contain all ImmutableStackTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ImmutableStackTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        #region Additional test attributes

        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //

        #endregion


        [TestMethod]
        public void TestPush()
        {
            var stack = ImmutableStack<int>.EmptyStack.Push(5);
            Assert.AreEqual(5, stack.Peek());
        }

        [TestMethod]
        public void TestPushTwoElements()
        {
            var stack = ImmutableStack<int>.EmptyStack;
            stack = stack.Push(5);
            stack = stack.Push(10);
            Assert.AreEqual(10, stack.Peek());
            stack = stack.Pop();
            Assert.AreEqual(5, stack.Peek());
        }

        [TestMethod]
        [ExpectedException(typeof (InvalidOperationException))]
        public void PeekWithNoElementsShouldGiveException()
        {
            var stack = ImmutableStack<int>.EmptyStack;
            stack.Peek();
        }

        [TestMethod]
        [ExpectedException(typeof (InvalidOperationException))]
        public void PopWithNoElementsShouldGiveException()
        {
            var stack = ImmutableStack<int>.EmptyStack;
            stack.Pop();
        }

        [TestMethod]
        public void TestPopWithOneElement()
        {
            var stack = ImmutableStack<int>.EmptyStack.Push(5);
            stack = stack.Pop();
            Assert.AreSame(ImmutableStack<int>.EmptyStack, stack);
        }

        [TestMethod]
        public void TestIsEmptyWithEmptyStack()
        {
            var stack = ImmutableStack<int>.EmptyStack;
            Assert.IsTrue(stack.IsEmpty);
        }

        [TestMethod]
        public void TestIsEmptyWithNonEmptyStack()
        {
            var stack = ImmutableStack<int>.EmptyStack;
            stack = stack.Push(5);
            Assert.IsFalse(stack.IsEmpty);
        }
    }
}
