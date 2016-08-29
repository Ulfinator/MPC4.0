using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MPC4.classes;

namespace MPC4_Unit_tests
{
    /// <summary>
    /// Summary description for Skill_test
    /// </summary>
    [TestClass]
    public class Skill_test
    {
        public Skill_test()
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

        private Creature initialize_creature()
        {
            Creature cret = new Creature();
            cret.Skills = new List<Skill>();
            
            return cret;

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
        public void Initialize_skill()
        {
            Skill sk = new Skill("Akrobatik",45,"SMI");
            Assert.AreEqual(45, sk.Skill_value);
        }


        [TestMethod]
        public void successful_die_roll()
        {
            Creature cret = initialize_creature();
            cret.Skills.Add(new Skill("AAA",70,"STY"));
            
            Skill_result sr =  cret.check_skill("AAA",20,-25);
            Assert.AreEqual(20, sr.Die_value);
            Assert.AreEqual(45, sr.Modified_skill_value);
            Assert.AreEqual("SUCCESS",sr.Result);
        }

        [TestMethod]
        public void failed_die_roll()
        {
            Creature cret = initialize_creature();
            cret.Skills.Add(new Skill("AAA", 70, "STY"));

            Skill_result sr = cret.check_skill("AAA", 80, 5);
            Assert.AreEqual(80, sr.Die_value);
            Assert.AreEqual(75, sr.Modified_skill_value);
            Assert.AreEqual("FAIL", sr.Result);
        }

        [TestMethod]
        public void perfect_die_roll()
        {
            Creature cret = initialize_creature();
            cret.Skills.Add(new Skill("AAA", 50, "STY"));
            Skill_result sr = cret.check_skill("AAA", 5, 0);
            Assert.AreEqual("PERFECT", sr.Result);
        }

        [TestMethod]
        public void fumbled_die_roll()
        {
            Creature cret = initialize_creature();
            cret.Skills.Add(new Skill("AAA", 120, "STY"));
            Skill_result sr = cret.check_skill("AAA", 100, 0);
            Assert.AreEqual("FUMBLE", sr.Result);
        }

    }
}
