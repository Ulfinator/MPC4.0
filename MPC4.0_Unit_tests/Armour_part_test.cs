using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MPC4.classes;

namespace MPC4._0_Unit_tests
{
    /// <summary>
    /// Summary description for Armour_part_test
    /// </summary>
    [TestClass]
    public class Armour_part_test
    {
        public Armour_part_test()
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
        public void Initialize_Armour_part()
        {
            Armour_part amp;
            amp = new Armour_part("Blandrustning","ANY","Ihopplockad rustning av olika material", 4, 4, "VISION", "OK");
            Assert.AreEqual("VISION", amp.Limitation_area);
            Assert.AreEqual("OK", amp.Status);

            amp = new Armour_part("Blandrustning", "ANY", "Ihopplockad rustning av olika material", 4, 4, "PER_PART", "BROKEN");
            Assert.AreEqual("UNKNOWN", amp.Limitation_area);
            Assert.AreEqual("UNKNOWN", amp.Status);
        }


    }
}
