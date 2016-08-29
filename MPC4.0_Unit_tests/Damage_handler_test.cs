using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MPC4.classes;

namespace MPC4.Unit_tests
{
    [TestClass]
    public class Damage_handler_test
    {
        Damage_handler dmg_calc = new Damage_handler();

        [TestMethod]
        public void check_penetration_positive()
        {
            int pen = dmg_calc.check_penetration(5);

            Assert.AreEqual(5, pen);
        }

        [TestMethod]
        public void check_penetration_negative_is_zero()
        {
            int pen = dmg_calc.check_penetration(-3);

            Assert.AreEqual(0, pen);
        }
    
        [TestMethod]
        public void abs_minus_penetration_more_abs()
        {
            int end_abs = dmg_calc.abs_minus_penetration(5,3);

            Assert.AreEqual(2, end_abs);
        }

        [TestMethod]
        public void abs_minus_penetration_more_pen()
        {
            int end_abs = dmg_calc.abs_minus_penetration(5, 6);

            Assert.AreEqual(0, end_abs);
        }

        [TestMethod]
        public void calculate_damage_more_damage()
        {
            int end_dmg = dmg_calc.calculate_damage(5, 1,5);

            Assert.AreEqual(1, end_dmg);
        }

        [TestMethod]
        public void calculate_damage_more_abs()
        {
            int end_dmg = dmg_calc.calculate_damage(5, 1, 3);

            Assert.AreEqual(0, end_dmg);
        }


        //--
        [TestMethod]
        public void set_default_general_health_bp_hit_mortal_head()
        {
            string gen_health = dmg_calc.set_default_general_health_bp_hit("HEAD", "MORTAL");
            Assert.AreEqual("DEAD", gen_health);
        }

        [TestMethod]
        public void set_default_general_health_bp_hit_mortal_torso()
        {
            string gen_health = dmg_calc.set_default_general_health_bp_hit("TORSO", "MORTAL");
            Assert.AreEqual("BLEEDING", gen_health);
        }

        [TestMethod]
        public void set_default_general_health_bp_hit_mortal_other()
        {
            string gen_health = dmg_calc.set_default_general_health_bp_hit("ARM", "MORTAL");
            Assert.AreEqual("BLEEDING", gen_health);
        }

        [TestMethod]
        public void set_default_health_bp_hit_critical_head()
        {
            string gen_health = dmg_calc.set_default_general_health_bp_hit("HEAD", "CRITICAL");
            Assert.AreEqual("BLEEDING", gen_health);
        }

        [TestMethod]
        public void set_default_general_health_bp_hit_critical_torso()
        {
            string gen_health = dmg_calc.set_default_general_health_bp_hit("TORSO", "CRITICAL");
            Assert.AreEqual("BLEEDING", gen_health);
        }


        [TestMethod]
        public void set_death_count_head_shot()
        {
            int death_count = dmg_calc.set_mortal_death_count("IMM", "HEAD", 20, 23);
            Assert.AreEqual(-1, death_count); //death count should be -1, subject is already dead
        }

        [TestMethod]
        public void set_death_count_torso_shot_new()
        {
            int death_count = dmg_calc.set_mortal_death_count("IMM", "TORSO", 20, -1);
            Assert.AreEqual(20, death_count); //count set to fys_base
        }

        [TestMethod]
        public void set_death_count_torso_shot_old_dmg_limb()
        {
            int death_count = dmg_calc.set_mortal_death_count("IMM", "TORSO", 20, 45);
            Assert.AreEqual(20, death_count); //count set to fys_base
        }

        [TestMethod]
        public void set_death_count_torso_shot_old_dmg_no_change()
        {
            int death_count = dmg_calc.set_mortal_death_count("IMM", "TORSO", 20, 10);
            Assert.AreEqual(10, death_count); //count kept as is
        }

        [TestMethod]
        public void set_death_count_limb_shot_new()
        {
            int death_count = dmg_calc.set_mortal_death_count("IMM", "ARM", 10, -1);
            Assert.AreEqual(120, death_count); //count set to fys_base * 12
        }

        [TestMethod]
        public void set_death_count_limb_shot_old_high_value()
        {
            int death_count = dmg_calc.set_mortal_death_count("IMM", "ARM", 10, 500);
            Assert.AreEqual(120, death_count); //count set to fys_base * 12
        }

        [TestMethod]
        public void set_death_count_limb_shot_old_low_value()
        {
            int death_count = dmg_calc.set_mortal_death_count("IMM", "ARM", 10, 5);
            Assert.AreEqual(5, death_count); //count kept as is
        }

        [TestMethod]
        public void set_death_count_critical_robot()
        {
            int death_count = dmg_calc.set_critical_death_count("RBT", "ARM", 10, -1,10);
            Assert.AreEqual(-1, death_count); //do not do anything
        }

        [TestMethod]
        public void set_death_count_critical_default_new()
        {
            int death_count = dmg_calc.set_critical_death_count("IMM", "ARM", 10, -1,10);
            Assert.AreEqual(240, death_count); //count should be (kp+fys) *12
        }

        [TestMethod]
        public void set_death_count_critical_default_low_val()
        {
            int death_count = dmg_calc.set_critical_death_count("IMM", "ARM", 10, 4, 10);
            Assert.AreEqual(4, death_count); //count should stay on the old
        }

        [TestMethod]
        public void set_unconsciousness_count()
        {
            int un_count = dmg_calc.set_unconsciousness_count(10);
            Assert.AreEqual(20, un_count); //count should be 30-10 = 20
        }

        [TestMethod]
        public void set_unconsciousness_count_high_fys()
        {
            int un_count = dmg_calc.set_unconsciousness_count(50);
            Assert.AreEqual(1, un_count); //count should always be at least 1
        }
    }
}
