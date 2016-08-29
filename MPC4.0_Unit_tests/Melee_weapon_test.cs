using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MPC4.classes;

namespace MPC4._0_Unit_tests
{
    [TestClass]
    public class Melee_weapon_test
    {
        private Weapon initialize_melee_weapon()
        {
            Weapon mw = new Weapon();
            mw.Melee_damage = "2T6";
            mw.Melee_damage_type = "hugg";
            mw.Description = "bla bla";
            mw.Equipment_type = "melee_weapon";
            mw.Grip = "1H";
            mw.Hardness = 10;
            mw.Id = 1;
            mw.Initiative = 5;
            mw.Min_melee_strength = 5;
            mw.Name = "Machete";
            mw.Skill_melee = "Närstrid";
            mw.Weight = 1.0;

            return mw;
        }

        [TestMethod]
        public void parry_test_no_damage()
        {
            Weapon mw = initialize_melee_weapon();
            int ret = mw.parry(8,mw.Melee_damage_type);
            Assert.AreEqual(0, ret);
        }

        [TestMethod]
        public void parry_test_damage_left()
        {
            Weapon mw = initialize_melee_weapon();
            int ret = mw.parry(14, mw.Melee_damage_type);
            Assert.AreEqual(4, ret);
        }

        [TestMethod]
        public void parry_test_damage_to_weapon()
        {
            Weapon mw = initialize_melee_weapon();
            int ret = mw.parry(24, mw.Melee_damage_type);
            Assert.AreEqual(14, ret);
            Assert.AreEqual(true, (mw.Hardness < 10)); //Hardness should be reduced due to blow weakening the weapon
        }

        [TestMethod]
        public void parry_test_no_damage_to_weapon()
        {
            Weapon mw = initialize_melee_weapon();
            mw.Melee_damage_type = "stick";
            int ret = mw.parry(24, mw.Melee_damage_type);
            Assert.AreEqual(14, ret);
            Assert.AreEqual(10,mw.Hardness);
        }

        [TestMethod]
        public void parry_test_broken_weapon()
        {
            Weapon mw = initialize_melee_weapon();
            mw.Hardness = 1;
            int ret = mw.parry(3, mw.Melee_damage_type);
            Assert.AreEqual(2, ret);
            Assert.AreEqual("BROKEN", mw.Status);
        }    
    }
}
