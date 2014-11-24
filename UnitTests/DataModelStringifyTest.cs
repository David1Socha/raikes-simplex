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
        private StandardModel simpleModel;

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
            simpleModel = StandardModelGenerator.getSimpleModel();
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
        public void SimpleStringifyTest()
        {
            String expectedStringification = "Constraints:\n1x1 + 3x2 + 4x3 <= 10\n4x1 + 3x2 + 2x3 <= 50, \nObjective: Maximize 2x1 + 6x2 + 4x3 = 20";
            StringifyTest(simpleModel, expectedStringification);
        }

        public void StringifyTest(StandardModel modelToStringify, String expectedStringification)
        {
            String actualStringification = modelToStringify.ToString(StandardModel.OutputFormat.Original);
            Assert.AreEqual(expectedStringification, actualStringification);
        }

    }
}
