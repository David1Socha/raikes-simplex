﻿using RaikesSimplexService.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Collections.Generic;
using RaikesSimplexService.DataModel;
using RaikesSimplexService.Implementation.Extensions;

namespace UnitTests
{
    
    
    /// <summary>
    ///This is a test class for SolverTest and is intended
    ///to contain all SolverTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SolverTest
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
            testModel = new Model
            {
                Constraints = new List<LinearConstraint>
                { 
                    new LinearConstraint{
                        Coefficients = new double[]{1, 3, 4},
                        Relationship = Relationship.LessThanOrEquals,
                        Value = 10,
                    },
                    new LinearConstraint{
                        Coefficients = new double[]{4, 3, 2},
                        Relationship = Relationship.GreaterThanOrEquals,
                        Value = 50,
                    }
                },
                Goal = new Goal
                {
                    Coefficients = new double[] { 2, 6, 4 },
                    ConstantTerm = 20
                },
                GoalKind = GoalKind.Minimize,
            };
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
        public void PrintTest()
        {
            Console.WriteLine(testModel.Stringify());
        }

        [TestMethod()]
        public void StandardizeTest()
        {
            var solver = new Solver();
            var actualCount = testModel.Constraints.First().Coefficients.Count();
            var slackCount = testModel.Constraints.Count(s => s.Relationship != Relationship.Equals);
            var model = solver.Standardize(testModel);
            Console.WriteLine(model.Stringify(actualCount, slackCount));
        }

        [TestMethod()]
        public void MatrixifyTest()
        {
            var solver = new Solver();
            var actualCount = testModel.Constraints.First().Coefficients.Count();
            var slackCount = testModel.Constraints.Count(s => s.Relationship != Relationship.Equals);
            var model = solver.Standardize(testModel);
            Console.WriteLine(model.Matrixify());
        }
        /// <summary>
        ///A test for Solve
        ///</summary>
        [TestMethod()]
        public void ExampleSolveTest()
        {
            #region Arrange
            var target = new Solver();            

            var lc1 = new LinearConstraint()
            {
                Coefficients = new double[2] { 8, 12 },
                Relationship = Relationship.GreaterThanOrEquals,
                Value = 24
            };

            var lc2 = new LinearConstraint()
            {
                Coefficients = new double[2] { 12, 12 },
                Relationship = Relationship.GreaterThanOrEquals,
                Value = 36
            };

            var lc3 = new LinearConstraint()
            {
                Coefficients = new double[2] { 2, 1 },
                Relationship = Relationship.GreaterThanOrEquals,
                Value = 4
            };

            var lc4 = new LinearConstraint()
            {
                Coefficients = new double[2] { 1, 1 },
                Relationship = Relationship.LessThanOrEquals,
                Value = 5
            };

            var constraints = new List<LinearConstraint>() {lc1, lc2, lc3, lc4};

            var goal = new Goal() 
            { 
                Coefficients = new double[2] { 0.2, 0.3 },
                ConstantTerm = 0
            };           

            var model = new Model()
            {
                Constraints = constraints,
                Goal = goal,
                GoalKind = GoalKind.Minimize
            };
            
            var expected = new Solution()
            {
                Decisions = new double[2] { 3, 0 },
                Quality = SolutionQuality.Optimal,
                AlternateSolutionsExist = false,
                OptimalValue = 0.6
            };
            #endregion

            //Act
            var actual = target.Solve(model);

            //Assert
            CollectionAssert.AreEqual(expected.Decisions, actual.Decisions);
            Assert.AreEqual(expected.Quality, actual.Quality);
            Assert.AreEqual(expected.AlternateSolutionsExist, actual.AlternateSolutionsExist);
        }
    }
}
