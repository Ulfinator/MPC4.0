using Microsoft.VisualStudio.TestTools.UnitTesting;
using MPC4.classes;
using System.Collections.Generic;

namespace MPC4._0_Unit_tests
{
    [TestClass]
    public class Weapon_test
    {
        Weapon rw;

        private Weapon initialize_ranged_weapon_pistol()
        {
        //    string i_skill, int i_single_fire_rate, int i_burst_fire_rate, string i_grip, int i_initiative,string i_calibre,  int i_reliability,
        //                        int i_range, string i_damage, int i_hardness, double i_weight)
            Weapon rw = new Weapon();
            rw.Skill_range = "pistol";
            rw.Fire_rate_single = 1;
            rw.Grip = "1H";
            rw.Initiative = 5;
            rw.Calibre = "9X19";
            rw.Reliability = 80;
            rw.Range = 10;
            rw.Single_fire_damage = "2T6";
            rw.Hardness = 10;
            rw.Weight = 1;

            return rw;
        }

        private Weapon_Accessor initialize_Ranged_weapon_accessor_pistol()
        {
            Weapon_Accessor rw = new Weapon_Accessor();

            rw.Skill_range = "pistol";
            rw.Fire_rate_single = 1;
            rw.Grip = "1H";
            rw.Initiative = 5;
            rw.Calibre = "9X19";
            rw.Reliability = 80;
            rw.Range = 10;
            rw.Single_fire_damage = "2T6";
            rw.Hardness = 10;
            rw.Weight = 1;

            rw.Magazine = new Magazine("", "", "", "9X19", 15, 15,"REGULAR");
            return rw;
        }

        private Weapon_Accessor initialize_Ranged_weapon_accessor_rifle()
        {
            Weapon_Accessor rw = new Weapon_Accessor();
            rw.Skill_range = "gevär";
            rw.Fire_rate_single = 1;
            rw.Fire_rate_burst = 4;
            rw.Grip = "1H";
            rw.Initiative = 5;
            rw.Calibre = "9X19";
            rw.Reliability = 80;
            rw.Range = 10;
            rw.Single_fire_damage = "2T6";
            rw.Hardness = 10;
            rw.Weight = 3;

            
            rw.Magazine = new Magazine("", "", "", "9X19", 30, 30,"REGULAR");
            return rw;
        }

        private Spray_weapon_Accessor initialize_Spray_weapon_accessor_shotgun()
        {
            Spray_weapon_Accessor rw = new Spray_weapon_Accessor();

            rw.Skill_range = "gevär";
            rw.Fire_rate_single = 1;
            rw.Grip = "1H";
            rw.Initiative = 5;
            rw.Calibre = "9X19";
            rw.Reliability = 80;
            rw.Range = 10;
            rw.Single_fire_damage = "2T6";
            rw.Hardness = 10;
            rw.Weight = 1;
            rw.Slotted_shell_type = "HAIL";
            
            rw.Range_damage.Add("HAIL_5", "6T6");
            rw.Range_damage.Add("HAIL_10", "5T6");
            rw.Range_damage.Add("HAIL_25","3T6");
            rw.Range_damage.Add("SLUG_5", "5T6");
            rw.Range_damage.Add("SLUG_10", "4T6");
            rw.Range_damage.Add("SLUG_25", "2T6");

            rw.Magazine = new Magazine("", "", "", "9X19", 30, 30,"REGULAR");
            return rw;
        }


        [TestMethod]
        public void ranged_weapon_has_damage()
        {
            
            rw = initialize_ranged_weapon_pistol();
            rw.Magazine = new Magazine("test", "magazine", "bla bla", "9X19", 15, 15, "REGULAR");
            Weapon_result wr = rw.Fire_weapon(50);
            Assert.AreEqual("OK", wr.Status);
            Assert.IsTrue(wr.Damage[0].Damage_value >0);
        }

        [TestMethod()]
        public void reliability_check_jamed()
        {
            Weapon_Accessor target = initialize_Ranged_weapon_accessor_pistol();
            target.reliability_check(90);
            Assert.AreEqual("JAMMED", target.Status);
        }

        [TestMethod()]
        public void reliability_check_ok()
        {
            Weapon_Accessor target = initialize_Ranged_weapon_accessor_pistol();
            target.reliability_check(80);
            Assert.AreEqual("OK", target.Status);
        }

        [TestMethod()]
        public void reliability_check_already_broken()
        {
            Weapon_Accessor target = initialize_Ranged_weapon_accessor_pistol();
            target.Status = "BROKEN";
            target.reliability_check(50); // Under reliability inget ska hända, men vapnet är redan trasigt.
            Assert.AreEqual("BROKEN", target.Status);
            Assert.AreEqual(80, target.Reliability);

        }

        [TestMethod()]
        public void break_check_Broken()
        {
            Weapon_Accessor target = initialize_Ranged_weapon_accessor_pistol();
            target.break_check(90, 10); //Över PÅL och en 10 på check slaget = Trasigt vapen
            Assert.AreEqual("BROKEN", target.Status);
            
        }
        [TestMethod()]
        public void break_check_lowered_reliability()
        {
            Weapon_Accessor target = initialize_Ranged_weapon_accessor_pistol();
            target.break_check(90, 9); //Över PÅL men ingen 10a = OK men sänkt PÅL
            Assert.AreEqual("OK", target.Status);
            Assert.AreEqual(71, target.Reliability);

        }

        [TestMethod()]
        public void break_check_ok()
        {

            Weapon_Accessor target = initialize_Ranged_weapon_accessor_pistol();
            target.break_check(50, 10); // Under PÅL inget händer.
            Assert.AreEqual("OK", target.Status);
            Assert.AreEqual(80, target.Reliability);

        }

        [TestMethod()]
        public void weapon_spend_ammo_confirm_single_fire()
        {
            Weapon_Accessor target = initialize_Ranged_weapon_accessor_rifle();
            string res_fire = target.spend_ammo("single"); //send in lower case to check if its converted right
            Assert.AreEqual("SINGLE", res_fire);
            Assert.AreEqual(29,target.Magazine.Projectiles_left);
        }

        [TestMethod()]
        public void weapon_spend_ammo_confirm_burst_fire()
        {
            Weapon_Accessor target = initialize_Ranged_weapon_accessor_rifle();
            string res_fire = target.spend_ammo("burst"); //send in lower case to check if its converted right
            Assert.AreEqual("BURST", res_fire);
            Assert.AreEqual(26, target.Magazine.Projectiles_left);
        }

        [TestMethod()]
        public void weapon_spend_ammo_confirm_end_burst_fire()
        {
            Weapon_Accessor target = initialize_Ranged_weapon_accessor_rifle();
            target.Magazine.Projectiles_left = 2;
            string res_fire = target.spend_ammo("BURST"); 
            Assert.AreEqual("BURST", res_fire);
            Assert.AreEqual(0, target.Magazine.Projectiles_left);
        }

        [TestMethod()]
        public void weapon_spend_ammo_confirm_burst_fire_to_single()
        {
            Weapon_Accessor target = initialize_Ranged_weapon_accessor_rifle();
            target.Magazine.Projectiles_left = 1;
            string res_fire = target.spend_ammo("BURST");
            Assert.AreEqual("SINGLE", res_fire);
            Assert.AreEqual(0, target.Magazine.Projectiles_left);
        }

        [TestMethod()]
        public void weapon_spend_ammo_confirm_click()
        {
            Weapon_Accessor target = initialize_Ranged_weapon_accessor_rifle();
            target.Magazine.Projectiles_left = 0;
            string res_fire = target.spend_ammo("BURST");
            Assert.AreEqual("CLICK", res_fire);
            Assert.AreEqual(0, target.Magazine.Projectiles_left);
        }

        [TestMethod()]
        public void calculate_spray_weapon_damage()
        {
            Spray_weapon_Accessor swa = initialize_Spray_weapon_accessor_shotgun();
            List<Damage> dmg= swa.calculate_spray_damage();
            Assert.AreEqual(true, (dmg.Count > 0));
            Assert.AreEqual("HAIL_5", dmg[0].Damage_type);
        }
    }
}
