using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MPC4.classes;
using System.Xml;

namespace MPC4.Unit_tests
{
    [TestClass]
    public class Robot_tests
    {
        Robot rbt;

        private void initialize_robot()
        {
            rbt = new Robot("Big_boy", 30, 15, 15, 8, 11, 13, 9);
            rbt.calculate_from_base_values();
            rbt.Body = get_base_body_modle();
        }

        [TestInitialize()]
        public void MyTestInitialize() 
        {
            initialize_robot();
        }

        private Body_modle get_base_body_modle()
        {
            XmlDocument doc = new XmlDocument();
            Body_factory b_fact = new Body_factory();
            doc.Load(Path_util.get_body_modle_path("basic_humanoid.xml"));
            Body_modle bm = b_fact.load_base_body_modle(ref doc);

            return bm;
        }





        [TestMethod]
        public void set_robot_general_health_positive_bp()
        {
            rbt.apply_damage("ALL", 29, 0);
            Assert.AreEqual(0, rbt.Total_damage_penalty_all);
            Assert.AreEqual(0, rbt.Total_damage_penalty_two_handed);
        }

        [TestMethod]
        public void set_robot_general_health_negative_bp_25()
        {
            rbt.apply_damage("ALL", 30,0);
            Assert.AreEqual(-25, rbt.Total_damage_penalty_all);
            Assert.AreEqual(-25, rbt.Total_damage_penalty_two_handed);
        }

        [TestMethod]
        public void set_robot_general_health_negative_bp_50()
        {
            rbt.apply_damage("ALL", 61, 0);
            Assert.AreEqual(-50, rbt.Total_damage_penalty_all);
            Assert.AreEqual(-50, rbt.Total_damage_penalty_two_handed);
        }

        [TestMethod]
        public void set_robot_general_health_negative_bp_75()
        {
            rbt.apply_damage("ALL", 91, 0);
            Assert.AreEqual(-75, rbt.Total_damage_penalty_all);
            Assert.AreEqual(-75, rbt.Total_damage_penalty_two_handed);

        }

        [TestMethod]
        public void set_robot_general_health_bp_hit_mortal_head()
        {
            string gen_health = rbt.set_robot_general_health_bp_hit("HEAD", "MORTAL");
            Assert.AreEqual("DEAD", gen_health);
        }

        [TestMethod]
        public void set_robot_general_health_bp_hit_mortal_torso()
        {
            string gen_health = rbt.set_robot_general_health_bp_hit("TORSO", "MORTAL");
            Assert.AreEqual("DEAD", gen_health);
        }

        [TestMethod]
        public void set_robot_general_health_bp_hit_mortal_other()
        {
            string gen_health = rbt.set_robot_general_health_bp_hit("ARM", "MORTAL");
            Assert.AreEqual("OK", gen_health);
        }

        [TestMethod]
        public void set_robot_general_health_bp_hit_critical_head()
        {
            string gen_health = rbt.set_robot_general_health_bp_hit("HEAD", "CRITICAL");
            Assert.AreEqual("HELPLESS", gen_health);
        }

        [TestMethod]
        public void set_robot_general_health_bp_hit_critical_torso()
        {
            string gen_health = rbt.set_robot_general_health_bp_hit("TORSO", "CRITICAL");
            Assert.AreEqual("IMOBILIZED", gen_health);
        }

        [TestMethod]
        public void set_robot_general_health_bp_hit_critical_other()
        {
            string gen_health = rbt.set_robot_general_health_bp_hit("ARM", "CRITICAL");
            Assert.AreEqual("OK", gen_health);
        }

        [TestMethod]
        public void dead_robot_stays_dead()
        {
            rbt.apply_damage("Huvud", 40, 0);
            Assert.AreEqual("DEAD", rbt.General_health);
            rbt.apply_damage("Höger arm", 2, 0);
            Assert.AreEqual("DEAD", rbt.General_health);
        }

        [TestMethod]
        public void helpless_robot_stays_helpless()
        {
            rbt.apply_damage("Huvud", 20, 0);
            Assert.AreEqual("HELPLESS", rbt.General_health);
            rbt.apply_damage("Höger arm", 2, 0);
            Assert.AreEqual("HELPLESS", rbt.General_health);
        }

        [TestMethod]
        public void imobilized_robot_stays_imobilized()
        {
            rbt.apply_damage("Bål", 20, 0);
            Assert.AreEqual("IMOBILIZED", rbt.General_health);
            rbt.apply_damage("Höger arm", 2, 0);
            Assert.AreEqual("IMOBILIZED", rbt.General_health);
        }

        [TestMethod]
        public void sensor_overload_robot_stays_overloaded()
        {
            rbt.apply_damage("Bål", 14, 0);
            rbt.apply_damage("Bål", 14, 0);
            rbt.apply_damage("Bål", 14, 0);

            Assert.AreEqual("SENSOR_OVERLOAD", rbt.General_health);
            rbt.apply_damage("Höger arm", 2, 0);
            Assert.AreEqual("SENSOR_OVERLOAD", rbt.General_health);
        }

        [TestMethod]
        public void never_a_death_count_on_robots()
        {
            rbt.apply_damage("Bål", 40, 0);
            Assert.AreEqual("-", rbt.Death_count); 
        }

    }
}
