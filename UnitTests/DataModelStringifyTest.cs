﻿using RaikesSimplexService.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Collections.Generic;
using RaikesSimplexService.DataModel;
using RaikesSimplexService.Implementation.Extensions;
using UnitTests.Helpers;

namespace UnitTests
{


    /// <summary>
    ///This is a test class for DataModelStringify and is intended
    ///to contain all DataModelStringify Unit Tests
    ///</summary>
    [TestClass()]
    public class DataModelStringify
    {
        private TestContext testContextInstance;
        private Model testModel;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
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
        [TestInitialize()]
        public void MyTestInitialize()
        {
            testModel = ModelHelper.getTestModel();
        }
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        [TestMethod()]
        public void StringifyTest()
        {
            String expectedValue = "Constraints:\n1x1 + 3x2 + 4x3 <= 10\n4x1 + 3x2 + 2x3 >= 50, \nGoal:\nMinimize 2x1 + 6x2 + 4x3 = 20";
            String actualValue = testModel.Stringify();
            Assert.AreEqual(expectedValue, actualValue);
        }

    }
}
