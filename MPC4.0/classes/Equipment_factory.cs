using System;
using System.Xml;

namespace MPC4.classes
{
    public class Equipment_factory
    {
        public Equipment_factory()
        { }

        #region Base Equipment

        public Equipment create_base_equipment(XmlNode xNode)
        {
            Equipment eq = new Equipment();
            eq.Name = xNode["name"].InnerText;
            eq.Equipment_type = xNode["equipment_type"].InnerText;
            eq.Description = xNode["description"].InnerText;

            return eq;
        }

        #endregion

        #region Ranged weapons


        public Weapon create_weapon(XmlNode xNode)
        {
            
            Weapon rw = new Weapon();
            Spray_weapon sw = new Spray_weapon();
            Thrown_weapon tw = new Thrown_weapon();
            string weapon_type = xNode["equipment_type"].InnerText.ToUpper();
            //Do specials;
            if (weapon_type == "RANGED_WEAPON" || weapon_type == "MELEE_WEAPON")
            {
                rw.Single_fire_damage = xNode["single_fire_damage"].InnerText;

                if (xNode["burst_fire_damage"] != null) //pistols usually do not have burst fire
                    rw.Burst_fire_damage = xNode["burst_fire_damage"].InnerText;

            }
            else if (weapon_type == "SPRAY_WEAPON")
            {
                XmlNodeList xlist = xNode.SelectNodes("//single_fire_damage");
                string shell_type = "";

                foreach (XmlNode xN_single in xlist)
                {
                    shell_type = xN_single["shell_type"].InnerText;
                    XmlNode xN_dmg = xN_single["range_damage_die"];

                    foreach (XmlNode xRange in xN_dmg.ChildNodes)
                    {
                        sw.Range_damage.Add(shell_type + "_" + xRange.Name, xRange.InnerText);
                    }
                }

                //Make rw an actual spray weapon disguised as a Weapon
                rw = sw;
            }
            else if (weapon_type == "THROWN_WEAPON")
            {
                tw.Single_fire_damage = xNode["single_fire_damage"].InnerText;
                tw.Penetration = Convert.ToInt32(xNode["penetration"].InnerText);

                //Create a one shot "magazine" for the weapon, so it can be "fired"
                tw.Magazine = new Magazine("x", "x", "x", "x", 1, "x");

                rw = tw;
            }


            if (xNode["id"] != null) //when loaded from a character there is an equipment id set
                rw.Id = Convert.ToInt32(xNode["id"].InnerText);

            rw.Name = xNode["name"].InnerText;
            rw.Equipment_type = xNode["equipment_type"].InnerText;
            rw.Description = xNode["description"].InnerText;
            rw.Skill_melee = xNode["melee_skill"].InnerText;
            rw.Melee_damage = xNode["melee_damage"].InnerText;
            rw.Melee_damage_type = xNode["melee_damage_type"].InnerText;
            rw.Min_melee_strength = Convert.ToInt32(xNode["min_melee_strength"].InnerText);
            rw.Skill_range = xNode["range_skill"].InnerText;

            if (xNode["fire_rate_single"] != null)
                rw.Fire_rate_single = Convert.ToInt32(xNode["fire_rate_single"].InnerText);

            if (xNode["fire_rate_burst"] != null)
                rw.Fire_rate_burst = Convert.ToInt32(xNode["fire_rate_burst"].InnerText);

            rw.Grip = xNode["grip"].InnerText;
            rw.Initiative = Convert.ToInt32(xNode["initiative"].InnerText);
            
            if (xNode["secondary_initiative"] != null) // Melee weapons do not have a secondary initiative
                rw.Secondary_initiative = Convert.ToInt32(xNode["secondary_initiative"].InnerText);
            
            rw.Mag_type = xNode["magazine_type"].InnerText;
            rw.Standard_mag = Convert.ToInt32(xNode["standard_mag_size"].InnerText);
            rw.Calibre = xNode["calibre"].InnerText;
            rw.Reliability = Convert.ToInt32(xNode["reliability"].InnerText);
            rw.Range = Convert.ToInt32(xNode["range"].InnerText);
            rw.Hardness = Convert.ToInt32(xNode["hardness"].InnerText);
            rw.Weight = Convert.ToDouble(xNode["weight"].InnerText);
            
            if (xNode["selected_fire_rate"] != null)
                rw.Selected_fire_rate = xNode["selected_fire_rate"].InnerText;
            
            //Check and add any loaded mags
            if (xNode["loaded_magazine"] != null)
                rw.Magazine = create_loaded_gun_mag(xNode);

            //fill handheld values
            if (xNode["held_by_main_hand"] != null)
                rw.Held_by_main_hand = xNode["held_by_main_hand"].InnerText;

            if (xNode["held_by_secondary_hand"] != null)
                rw.Held_by_secondary_hand = xNode["held_by_secondary_hand"].InnerText;


            return rw;
        }

        public Magazine create_mag(XmlNode xNode)
        {
            Magazine am = new Magazine();
            
            if (xNode["id"] != null) //when loaded from a character there is an equipment id set
                am.Id = Convert.ToInt32(xNode["id"].InnerText);

            am.Name = xNode["name"].InnerText;
            am.Equipment_type = xNode["equipment_type"].InnerText;
            am.Description = xNode["description"].InnerText;
            am.Calibre = xNode["calibre"].InnerText;
            am.Shell_type = xNode["shell_type"].InnerText;
            if (xNode["max_projectiles"] != null)
                am.Max_projectiles = Convert.ToInt32(xNode["max_projectiles"].InnerText);

            if (xNode["projectiles_left"] != null)
                am.Projectiles_left = Convert.ToInt32(xNode["projectiles_left"].InnerText);
            else
                am.Projectiles_left = Convert.ToInt32(xNode["max_projectiles"].InnerText);
            
            return am;
            
        }

        public Ammo_pile create_ammo_pile(XmlNode xNode)
        {
            Ammo_pile ap = new Ammo_pile();

            if (xNode["id"] != null) //when loaded from a character there is an equipment id set
                ap.Id = Convert.ToInt32(xNode["id"].InnerText);

            ap.Name = xNode["name"].InnerText;
            ap.Equipment_type = xNode["equipment_type"].InnerText;
            ap.Description = xNode["description"].InnerText;
            ap.Calibre = xNode["calibre"].InnerText;
            ap.Shell_type = xNode["shell_type"].InnerText;

            //Depending on if its a base load from the list or a character load 
            if (xNode["max_projectiles"] != null)
                ap.Projectiles_left = Convert.ToInt32(xNode["max_projectiles"].InnerText);

            if (xNode["projectiles_left"] != null)
                ap.Projectiles_left = Convert.ToInt32(xNode["projectiles_left"].InnerText);


            return ap;
        }

        private Magazine create_loaded_gun_mag(XmlNode xNode)
        {
            XmlNode xNode2 = Xml_util.get_detached_node(xNode["loaded_magazine"]);
            string calibre = xNode2["calibre"].InnerText;
            int max_proj = Convert.ToInt32(xNode2["max_projectiles"].InnerText);
            int left_proj = Convert.ToInt32(xNode2["projectiles_left"].InnerText);
            string shell = xNode2["shell_type"].InnerText;
            return new Magazine("x", "magazine", "x", calibre, max_proj, left_proj, shell);
        }

        #endregion

        
        #region Util

        /// <summary>
        /// This method takes a serialized and objectified Equipment class or sub class. Finds the right subclass gets all data in place
        /// and then casts everything to an Equipment class that can be stored or manipulated at will.
        /// </summary>
        /// <returns></returns>
        public Equipment cast_object_to_correct_equipment(System.Windows.Forms.DragEventArgs e)
        {
            Equipment eq;

            if (e.Data.GetDataPresent(typeof(Weapon)))
            {
                Weapon rw = e.Data.GetData(typeof(Weapon)) as Weapon;
                eq = (Equipment)rw;
            }
            else if (e.Data.GetDataPresent(typeof(Spray_weapon)))
            {
                Spray_weapon sw = e.Data.GetData(typeof(Spray_weapon)) as Spray_weapon;
                eq = (Equipment)sw;
            }
            else if (e.Data.GetDataPresent(typeof(Thrown_weapon)))
            {
                Thrown_weapon tw = e.Data.GetData(typeof(Thrown_weapon)) as Thrown_weapon;
                eq = (Equipment)tw;
            }
            else if (e.Data.GetDataPresent(typeof(Magazine)))
            {
                Magazine mw = e.Data.GetData(typeof(Magazine)) as Magazine;
                eq = (Equipment)mw;
            }
            else if (e.Data.GetDataPresent(typeof(Ammo_pile)))
            {
                Ammo_pile ap = e.Data.GetData(typeof(Ammo_pile)) as Ammo_pile;
                eq = (Equipment)ap;
            }
            else
            {
                Equipment equ = e.Data.GetData(typeof(Equipment)) as Equipment;
                eq = (Equipment)equ;
            }
            
            return eq;
        }


        #endregion

    }
}
