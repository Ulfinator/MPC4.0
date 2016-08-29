using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MPC4.classes;
using System.Xml;

namespace MPC4._0_Unit_tests
{
    [TestClass]
    public class Creature_damage_test
    {
        Creature hum1;
        Creature hum2;

        private Body_modle get_base_body_modle()
        {
          
            List<Body_part> bp = new List<Body_part>();

            Body_part torso = new Body_part("Bål", "OK");
            torso.Mod_damage_all = -50;
            torso.Mod_damage_two_hand = -50;
            torso.Part_type = "TORSO";
            bp.Add(torso);

            Body_part head = new Body_part("Huvud", "OK");
            head.Mod_damage_all = -50;
            head.Mod_damage_two_hand = -50;
            head.Part_type = "HEAD";
            bp.Add(head);

            Body_part Larm = new Body_part("Vänster arm", "OK");
            Larm.Mod_damage_all = -25;
            Larm.Mod_damage_two_hand = -50;
            Larm.Part_type = "ARM";
            bp.Add(Larm);

            Body_part Lleg = new Body_part("Vänster ben", "OK");
            Lleg.Mod_damage_all = -25;
            Lleg.Mod_damage_two_hand = -25;
            Lleg.Part_type = "LEG";
            bp.Add(Lleg);

            Body_part Harm = new Body_part("Höger arm", "OK");
            Harm.Mod_damage_all = -25;
            Harm.Mod_damage_two_hand = -50;
            Harm.Part_type = "ARM";
            bp.Add(Harm);

            Body_part Hleg = new Body_part("Höger ben", "OK");
            Hleg.Mod_damage_all = -25;
            Hleg.Mod_damage_two_hand = -25;
            Hleg.Part_type = "LEG";
            bp.Add(Hleg);



            Body_modle bm = new Body_modle("Crash dummy", "T20",bp);

            return bm;
        }

 
        private void initiate_hum1()
        {
            hum1 = new Creature("Bengt Alnarsson", 15, 14, 12, 10, 11, 13, 9);
            hum1.calculate_from_base_values();
            hum1.Body = get_base_body_modle();
        }

        public void initiate_armoured_hum2()
        {

            hum2 = new Creature("Bengt Alnarsson", 15, 14, 12, 10, 11, 13, 9);
            hum2.calculate_from_base_values();
            hum2.Body = get_base_body_modle();

            hum2.Body.Body_parts.Find(o => o.Name == "Bål").Armour_parts = new List<Armour_part>();
            hum2.Body.Body_parts.Find(o => o.Name == "Bål").Armour_parts.Add(new Armour_part("Flytväst", "TORSO", "", 1, 5, "N/A", "OK"));
            hum2.Body.Body_parts.Find(o => o.Name == "Bål").Armoured = "YES";

            hum2.Body.Body_parts.Find(o => o.Name == "Vänster arm").Armour_parts = new List<Armour_part>();
            hum2.Body.Body_parts.Find(o => o.Name == "Vänster arm").Armour_parts.Add(new Armour_part("Läder", "ARM", "", 1, 5, "N/A", "OK"));
            hum2.Body.Body_parts.Find(o => o.Name == "Vänster arm").Armour_parts.Add(new Armour_part("metal", "ARM", "", 3, 5, "N/A", "OK"));
            hum2.Body.Body_parts.Find(o => o.Name == "Vänster arm").Armoured = "YES";

        }


        [TestMethod]
        public void negative_kp_damage_is_zero()
        {
            initiate_hum1();
            hum1.apply_damage("Bål", -5, 0);
            Assert.AreEqual(26, hum1.Temp_body_points); // The creature shall not have lost any body points, -5 is ignored.
        }

        [TestMethod]
        public void kp_damage_invalid_body_part()
        {
            initiate_hum1();
            hum1.apply_damage("London", 5, 0);
            Assert.AreEqual(26, hum1.Temp_body_points); // Just assert something and see we have not crashed.
        }

        [TestMethod]
        public void kp_damage_no_body_part()
        {
            initiate_hum1();
            hum1.apply_damage("ALL", 20, 0);
            Assert.AreEqual(6, hum1.Temp_body_points); // The full single_fire_damage gets applied
            Assert.AreEqual("OK", hum1.General_health);
            Assert.AreEqual("-", hum1.Death_count);


        }

        [TestMethod]
        public void simple_kp_damage()
        {
            initiate_hum1();
            hum1.apply_damage("Bål", 5, 0);
            Assert.AreEqual(21, hum1.Temp_body_points); // The creature shall have lost 5 body points

            Body_part bp = hum1.Body.Body_parts.Find(o => o.Name == "Bål");
            Assert.AreEqual("OK",bp.Status); //The bodypart status shall not have changed from OK

            Assert.AreEqual("OK",hum1.General_health);  //The general health remains OK.
        }

        [TestMethod]
        public void wounding_kp_damage()
        {
            initiate_hum1();
            hum1.apply_damage("Bål", 14, 0);
            Assert.AreEqual(12, hum1.Temp_body_points); // The creature shall have lost 14 body points

            Body_part bp = hum1.Body.Body_parts.Find(o => o.Name == "Bål");
            Assert.AreEqual("WOUNDED", bp.Status); //The bodypart status shall have become WOUNDED

            Assert.AreEqual("BLEEDING", hum1.General_health);  //The general health becomes BLEEDING.

            Assert.AreEqual("312", hum1.Death_count); //The deathcount should be (remaining kp + fys) * 12 rounds, 1 minute being 12 rounds.

            Assert.AreEqual(-50,hum1.Total_damage_penalty_all); // -50 for a wound in the torso
        }

        [TestMethod]
        public void unconscious_on_wounding_head_shot()
        {
            initiate_hum1();
            hum1.apply_damage("Huvud", 14, 0);
            Assert.AreEqual(16, hum1.Unconsious_count); // The creature shall become unconscious for 16 rounds, (30-fys) rounds.

            initiate_hum1();
            hum1.Fys_base = 100;
            hum1.apply_damage("Huvud", 14, 0);
            Assert.AreEqual(1, hum1.Unconsious_count); // The creature shall become unconscious for 1 round even though FYS is high.


        }

        [TestMethod]
        public void cumulative_wound_penalty()
        {
            initiate_hum1();
            hum1.apply_damage("Vänster arm", 14, 0);

            hum1.apply_damage("Vänster ben", 14, 0);

            Assert.AreEqual(-50, hum1.Total_damage_penalty_all); // The all skills mod is 50%
            Assert.AreEqual(-75, hum1.Total_damage_penalty_two_handed); // The two hand skills mod is 75%
        
        }


        [TestMethod]
        public void destroying_kp_damage()
        {
            initiate_hum1();
            hum1.apply_damage("Bål", 27, 0);
            Assert.AreEqual(-1, hum1.Temp_body_points); // The creature shall be down on -1

            Body_part bp = hum1.Body.Body_parts.Find(o => o.Name == "Bål");
            Assert.AreEqual("DESTROYED", bp.Status); //The bodypart status shall have become DESTROYED

            Assert.AreEqual("BLEEDING", hum1.General_health);  //The general health becomes BLEEDING.

            Assert.AreEqual("14", hum1.Death_count); //The deathcount should be FYS rounds 

            Assert.AreEqual(-50, hum1.Total_damage_penalty_all); // The all skills mod is 50%            
        
            Assert.AreEqual(-50, hum1.Total_damage_penalty_two_handed); // The two hand skills mod is 50%

            Assert.AreEqual(-1, hum1.Unconsious_count);
        
        }

        [TestMethod]
        public void destroying_arm_shot()
        {
            initiate_hum1();
            hum1.apply_damage("Vänster arm", 27, 0);
            Assert.AreEqual("168", hum1.Death_count); //The deathcount should be fys * 12 rounds, 1 minute being 12 rounds. 

        }


        [TestMethod]
        public void destroying_head_shot_kills()
        {
            initiate_hum1();
            hum1.apply_damage("Huvud", 27, 0);
            Assert.AreEqual("DEAD", hum1.General_health); // A destroying head shot kills directly

        }

        [TestMethod]
        public void simple_hit_on_armoured_part()
        {
            initiate_armoured_hum2();
            hum2.apply_damage("Bål", 5, 0);
            Assert.AreEqual(22, hum2.Temp_body_points); // The creature shall have lost 4 body points due to the one armour

            hum2.apply_damage("Vänster arm", 5, 0);
            Assert.AreEqual(21, hum2.Temp_body_points); // The creature shall have lost 1 body points due to double armour

        }

        [TestMethod]
        public void penetrating_hit_on_armoured_part()
        {
            initiate_armoured_hum2();
            hum2.apply_damage("Bål", 5,1);
            Assert.AreEqual(21, hum2.Temp_body_points); // The creature shall have lost 5 body points due to pen against armour

            hum2.apply_damage("Vänster arm", 5, 3);
            Assert.AreEqual(17, hum2.Temp_body_points); // The creature shall have lost 4 body points due pen

            hum2.apply_damage("Vänster arm", 5, 10);
            Assert.AreEqual(12, hum2.Temp_body_points); // The creature shall have lost 5 body points due pen
        }

        [TestMethod]
        public void negative_penetration_has_no_effect()
        {
            initiate_armoured_hum2();
            hum2.apply_damage("Bål", 5, -10);
            Assert.AreEqual(22, hum2.Temp_body_points); // The creature shall have lost 4 body points due armour, no pen.

        }

        [TestMethod]
        public void death_count_round_simple()
        {
            initiate_hum1();
            hum1.apply_damage("Bål", 14, 0);
            Assert.AreEqual("312", hum1.Death_count);

            hum1.calculate_round_data();
            hum1.calculate_round_data();
            Assert.AreEqual("310", hum1.Death_count);
        }

        /// <summary>
        /// ATDD for changing death counts
        /// </summary>
        [TestMethod]
        public void death_count_changes()
        {
            initiate_hum1();
            hum1.apply_damage("Bål", 27, 0);
            Assert.AreEqual("14", hum1.Death_count);

            hum1.apply_damage("Bål", 14, 0);
            Assert.AreEqual("14", hum1.Death_count);

            hum1.heal_damage(30);
            hum1.stop_bleeding(); //stopping the bleeding

            hum1.apply_damage("Höger arm", 14, 0);
            Assert.AreEqual("180", hum1.Death_count); // at 15 fys the dc for wounding single_fire_damage is 180

            hum1.heal_damage(50);

            hum1.apply_damage("Bål", 27, 0);
            Assert.AreEqual("14", hum1.Death_count); //a destroying single_fire_damage brings the dc down
        }

        [TestMethod]
        public void heal_damage()
        {
            initiate_hum1();
            hum1.apply_damage("Bål",10,0);
            hum1.heal_damage(3);
            Assert.AreEqual(19, hum1.Temp_body_points);

        }

        [TestMethod]
        public void heal_does_not_add_extra_bp()
        {
            initiate_hum1();
            hum1.apply_damage("Bål", 10, 0);
            hum1.heal_damage(300);
            Assert.AreEqual(26, hum1.Temp_body_points);

        }

        [TestMethod]
        public void negative_heal_is_zero()
        {
            initiate_hum1();
            hum1.apply_damage("Bål", 10, 0);
            hum1.heal_damage(-5);
            Assert.AreEqual(16, hum1.Temp_body_points);

        }

        [TestMethod]
        public void stop_bleeding()
        {
            initiate_hum1();
            hum1.apply_damage("Bål", 14, 0);
            Assert.AreEqual("312", hum1.Death_count);
            hum1.stop_bleeding();
            Assert.AreEqual("-", hum1.Death_count);
        }

        [TestMethod]
        public void mend_body_part()
        {
            initiate_hum1();
            hum1.mend_body_part("Squelooqle"); //Should just pass over

            hum1.apply_damage("Bål", 14, 0);
            Body_part bp = hum1.Body.Body_parts.Find(o => o.Name == "Bål");
            Assert.AreEqual("WOUNDED", bp.Status); //The bodypart status shall have become WOUNDED

            hum1.mend_body_part("Bål");
            bp = hum1.Body.Body_parts.Find(o => o.Name == "Bål");
            Assert.AreEqual("OK", bp.Status); //Status shall have become OK

        }
    }
}
