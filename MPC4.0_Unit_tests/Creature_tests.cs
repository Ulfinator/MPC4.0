using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MPC4.classes;

namespace MPC4_Unit_tests
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class Creature_tests
    {
        Creature hum1;
    
        public Creature_tests()
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
        public void initialize_Humanoid()
        {
            hum1 = new Creature("Bengt Alnarsson", 15, 14, 12, 10, 11, 13, 9);
            Assert.AreEqual("Bengt Alnarsson",hum1.Name);
        }

        [TestMethod]
        public void calc_initiative()
        {
            hum1 = new Creature("Bengt Alnarsson", 15, 14, 12, 10, 11, 13, 9);
            hum1.calculate_from_base_values();
            Assert.AreEqual(10,hum1.Initiative_bonus);
        }

        [TestMethod]
        public void calc_reaction_value()
        {
            hum1 = new Creature("Bengt Alnarsson", 15, 14, 12, 10, 11, 13, 9);
            hum1.calculate_from_base_values();
            Assert.AreEqual(45, hum1.Reaction_value);
        }

        [TestMethod]
        public void calc_carry_capacity()
        {
            hum1 = new Creature("Bengt Alnarsson", 15, 14, 12, 10, 11, 13, 9);
            hum1.calculate_from_base_values();
            Assert.AreEqual(15,hum1.Carry_capacity);
        }

        [TestMethod]
        public void calc_damage_bonus()
        {
            //Die_modifier die_mod;

            //lowest possible outcome a: -2T4
            //hum1 = new Creature("Bengt Alnarsson", 2, 3, 3, 10, 11, 13, 9);
            //hum1.calculate_from_base_values();
            //die_mod = hum1.Damage_bonus_die;

            //Assert.AreEqual(-2, die_mod.Modifier_value);
            //Assert.AreEqual("T4", die_mod.Die_type);

            ////Lower formula outcome; value 19 should be -1 value and N/A as die type
            //hum1 = new Creature("Bengt Alnarsson", 9, 10, 10, 10, 11, 13, 9);
            //hum1.calculate_from_base_values();
            //die_mod = hum1.Damage_bonus_die;

            //Assert.AreEqual(-1, die_mod.Modifier_value);
            //Assert.AreEqual("N/A", die_mod.Die_type);

            ////Middle league outcome on a bordering value 27 should be 1T2
            //hum1 = new Creature("Bengt Alnarsson", 15, 10, 12, 10, 11, 13, 9);
            //hum1.calculate_from_base_values();
            //die_mod = hum1.Damage_bonus_die;

            //Assert.AreEqual(1, die_mod.Modifier_value);
            //Assert.AreEqual("T2", die_mod.Die_type);

            ////top league outcome, sty+sto = 85 should become 5T6
            //hum1 = new Creature("Bengt Alnarsson", 45, 10, 40, 10, 11, 13, 9);
            //hum1.calculate_from_base_values();
            //die_mod = hum1.Damage_bonus_die;

            //Assert.AreEqual(5, die_mod.Modifier_value);
            //Assert.AreEqual("T6", die_mod.Die_type);
        }

        [TestMethod]
        public void calc_movement()
        {
            hum1 = new Creature("Bengt Alnarsson", 15, 14, 12, 12, 11, 13, 9);
            hum1.calculate_from_base_values();
            Assert.AreEqual(4, hum1.Movement_walk);
            Assert.AreEqual(24, hum1.Movement_run);
            Assert.AreEqual(48, hum1.Movement_sprint);
        }

        [TestMethod]
        public void calc_body_points()
        {
            hum1 = new Creature("Bengt Alnarsson", 15, 14, 12, 10, 11, 13, 9);
            hum1.calculate_from_base_values();
            Assert.AreEqual(26, hum1.Body_points);
        }

        [TestMethod]
        public void calc_trauma_treshold()
        {   //body_points are fys+sto = 23 and trauma treshold is 23 / 2 always truncated.
            hum1 = new Creature("Bengt Alnarsson", 15, 14, 13, 10, 11, 13, 9);
            hum1.calculate_from_base_values();
            Assert.AreEqual(13, hum1.Trauma_treshold);
        }

        [TestMethod]
        public void add_and_retrive_special_abilitys()
        {
            hum1 = new Creature();
            Special_ability spec1 = new Special_ability();
            Special_ability spec2 = new Special_ability();

            //hum1.add_special_ability(spec1);
            //hum1.add_special_ability(spec2);
            //Assert.AreEqual(2, hum1.Special_abilities.Count);
        }

        [TestMethod]
        public void add_and_retrive_body_parts()
        {
            //hum1 = new Creature();
            //Body_part bp = new Body_part();
            
            //hum1.add_body_part(bp);
            //Assert.AreEqual(1, hum1.Body_parts.Count);
        }
    }
}
