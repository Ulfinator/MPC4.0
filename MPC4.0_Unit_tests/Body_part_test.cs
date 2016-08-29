using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MPC4.classes;

namespace MPC4_Unit_tests
{
    /// <summary>
    /// Summary description for Body_part_test
    /// </summary>
    [TestClass]
    public class Body_part_test
    {
        public Body_part_test()
        {

        }

        private TestContext testContextInstance;

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
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void Initialize_Body_part()
        {
            Body_part bp;
    
            bp = new Body_part("HEAD","OK");
            Assert.AreEqual("OK",bp.Status);

            bp = new Body_part("HEAD", "BLURT");
            Assert.AreEqual("UNKNOWN", bp.Status);

        }

        [TestMethod]
        public void Add_Armour_part()
        {
            Body_part bp;

            bp = new Body_part("HEAD", "OK");

            Armour_part ap = new Armour_part();
            bp.add_armour_part(ap);

            Assert.AreEqual(1,bp.Armour_parts.Count);
        }
    }
}
