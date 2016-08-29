using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Collections;
using System.Text;
using System.Xml;
using System.IO;

namespace MPC4.classes
{
    public class Creature_repository
    {
        #region Save functionality

        public string save_humanoid(Creature hum, string path)
        {
            string status = pre_save_check(hum);

            if (status == "OK")
            {
                XmlDocument xDoc = prepare_creature_for_save(hum);
                Xml_util.write_to_file(path, xDoc);
                return "OK";
            }
            else
                return status;
        }

        private string pre_save_check(Creature cret)
        {
            StringBuilder sb = new StringBuilder();

            if (cret.Name == null || cret.Name == "")  //Name check
                sb.AppendLine("-Varelsen måste ha ett namn");

            if(cret.Body == null)
                sb.AppendLine("-Varelsen måste ha en kroppstyp");

            if(cret.Image_path == null)
                sb.AppendLine("-Varelsen måste ha en bild");

            if (sb.ToString() == "")
                sb.Append("OK");

            return sb.ToString();
        }


        private XmlDocument prepare_creature_for_save(Creature hum)
        {
            XmlDocument xDoc = new XmlDocument();
            XmlElement root = create_creature_root("creature", xDoc, hum);
            xDoc.AppendChild(root);

            if (hum.Name == null) //Just to avoid crashing //TODO: fix a pre save checker
                hum.Name = "NO_NAME";

            if (hum.Skills.Count > 0)
                root.AppendChild(create_skill_xml(hum.Skills, ref xDoc));

            if (hum.Special_abilities.Count > 0)
                root.AppendChild(create_special_ability_xml(hum.Special_abilities, ref xDoc));

            if (hum.Body != null)
            {
                Modle_repository mod_rep = new Modle_repository();
                root.AppendChild(mod_rep.create_body_xml(hum.Body, ref xDoc));
            }

            if (hum.Equipment.Count > 0)
                root.AppendChild(create_equipment_xml(hum.Equipment, ref xDoc));

            return xDoc;
        }

        private XmlElement create_creature_root(string root_name, XmlDocument xDoc,Creature hum)
        {
            XmlElement root = xDoc.CreateElement("creature");

            root.AppendChild(Xml_util.create_text_element("name", hum.Name, ref xDoc));
            root.AppendChild(Xml_util.create_text_element("class", hum.Class_type, ref xDoc));
            root.AppendChild(Xml_util.create_text_element("image", hum.Image_path, ref xDoc));
            root.AppendChild(Xml_util.create_text_element("sty", Convert.ToString(hum.Sty_base), ref xDoc));
            root.AppendChild(Xml_util.create_text_element("fys", Convert.ToString(hum.Fys_base), ref xDoc));
            root.AppendChild(Xml_util.create_text_element("sto", Convert.ToString(hum.Sto_base), ref xDoc));
            root.AppendChild(Xml_util.create_text_element("smi", Convert.ToString(hum.Smi_base), ref xDoc));
            root.AppendChild(Xml_util.create_text_element("int", Convert.ToString(hum.Int_base), ref xDoc));
            root.AppendChild(Xml_util.create_text_element("vil", Convert.ToString(hum.Vil_base), ref xDoc));
            root.AppendChild(Xml_util.create_text_element("per", Convert.ToString(hum.Per_base), ref xDoc));
            root.AppendChild(Xml_util.create_text_element("general_health", hum.General_health, ref xDoc));
            root.AppendChild(Xml_util.create_text_element("template_path", hum.Template_path, ref xDoc));

            return root;
        }

        private XmlElement create_skill_xml(List<Skill> skill_list, ref XmlDocument xDoc)
        {
            XmlElement skills = xDoc.CreateElement("skills");

            foreach (Skill sk in skill_list)
            {
                XmlElement skill = xDoc.CreateElement("skill");
                skill.AppendChild(Xml_util.create_text_element("name", sk.Name, ref xDoc));
                skill.AppendChild(Xml_util.create_text_element("value", Convert.ToString(sk.Skill_value), ref xDoc));
                skill.AppendChild(Xml_util.create_text_element("base_attribute", sk.Skill_base_attribute, ref xDoc));

                skills.AppendChild(skill);
            }

            return skills;
        }

        private XmlElement create_special_ability_xml(List<Special_ability> special_list, ref XmlDocument xDoc)
        {
            XmlElement specials = xDoc.CreateElement("special_abilities");
            Ability_factory abf = new Ability_factory();

            foreach (Special_ability sp in special_list)
            {
                specials.AppendChild(abf.create_special_ability_xml(sp,ref xDoc));
            }

            return specials;
            
        }

        private XmlElement create_equipment_xml(List<Equipment> equipment_list, ref XmlDocument xDoc)
        {
            XmlElement equipment = xDoc.CreateElement("equipment");

            foreach (Equipment eq in equipment_list)
            {
                XmlElement item = xDoc.CreateElement("item");

                item.AppendChild(Xml_util.create_text_element("id", Convert.ToString(eq.Id), ref xDoc));
                item.AppendChild(Xml_util.create_text_element("name", eq.Name, ref xDoc));
                item.AppendChild(Xml_util.create_text_element("equipment_type", eq.Equipment_type, ref xDoc));
                item.AppendChild(Xml_util.create_text_element("description", eq.Description, ref xDoc));


                if (eq.Equipment_type.ToUpper().EndsWith("_WEAPON"))
                {
                    Weapon rw = (Weapon)eq; //Generics

                    //Start of with Melee values for when used as a melee weapon
                    item.AppendChild(Xml_util.create_text_element("melee_skill", rw.Skill_melee, ref xDoc));
                    item.AppendChild(Xml_util.create_text_element("melee_damage", rw.Melee_damage, ref xDoc));
                    item.AppendChild(Xml_util.create_text_element("melee_damage_type", rw.Melee_damage_type, ref xDoc));
                    item.AppendChild(Xml_util.create_text_element("min_melee_strength", Convert.ToString(rw.Min_melee_strength), ref xDoc));

                    //Add on Range values
                    item.AppendChild(Xml_util.create_text_element("range_skill", rw.Skill_range, ref xDoc));
                    item.AppendChild(Xml_util.create_text_element("fire_rate_single", Convert.ToString(rw.Fire_rate_single), ref xDoc));

                    if (rw.Fire_rate_burst != 0)
                        item.AppendChild(Xml_util.create_text_element("fire_rate_burst", Convert.ToString(rw.Fire_rate_burst), ref xDoc));

                    if (rw.Selected_fire_rate != null)
                        item.AppendChild(Xml_util.create_text_element("selected_fire_rate", rw.Selected_fire_rate, ref xDoc));

                    item.AppendChild(Xml_util.create_text_element("grip", rw.Grip, ref xDoc));
                    item.AppendChild(Xml_util.create_text_element("initiative", Convert.ToString(rw.Initiative), ref xDoc));

                    if (rw.Secondary_initiative != 0)
                        item.AppendChild(Xml_util.create_text_element("secondary_initiative", Convert.ToString(rw.Secondary_initiative), ref xDoc));
                        
                    item.AppendChild(Xml_util.create_text_element("magazine_type", rw.Mag_type, ref xDoc));
                    item.AppendChild(Xml_util.create_text_element("standard_mag_size", Convert.ToString(rw.Standard_mag), ref xDoc));
                    item.AppendChild(Xml_util.create_text_element("calibre", rw.Calibre, ref xDoc));
                    item.AppendChild(Xml_util.create_text_element("reliability", Convert.ToString(rw.Reliability), ref xDoc));
                    item.AppendChild(Xml_util.create_text_element("range", Convert.ToString(rw.Range), ref xDoc));
                    item.AppendChild(Xml_util.create_text_element("hardness", Convert.ToString(rw.Hardness), ref xDoc));
                    item.AppendChild(Xml_util.create_text_element("weight", Convert.ToString(rw.Weight), ref xDoc));

                    //Add on different types of damage etc depending on ranged weapon type
                    if (eq.Equipment_type == "ranged_weapon")
                    {
                        item.AppendChild(Xml_util.create_text_element("single_fire_damage", rw.Single_fire_damage, ref xDoc));

                        if (rw.Burst_fire_damage != null)
                            item.AppendChild(Xml_util.create_text_element("burst_fire_damage", rw.Burst_fire_damage, ref xDoc));
                    }
                    else if (eq.Equipment_type == "spray_weapon")
                    {
                        Spray_weapon sp = (Spray_weapon)eq;
                        
                        ListDictionary lDic;
                        lDic = sp.get_dictionary_by_shell_type("HAIL");

                        if (lDic.Count > 0)
                            item.AppendChild(create_range_damage_xml("HAIL", "single_fire_damage", lDic, ref xDoc));

                        lDic = sp.get_dictionary_by_shell_type("SLUG");

                        if (lDic.Count > 0)
                            item.AppendChild(create_range_damage_xml("SLUG", "single_fire_damage", lDic, ref xDoc));

                        lDic = sp.get_dictionary_by_shell_type("FLECHETTE");

                        if (lDic.Count > 0)
                            item.AppendChild(create_range_damage_xml("FLECHETTE", "single_fire_damage", lDic, ref xDoc));
                    }
                    else if (eq.Equipment_type == "thrown_weapon")
                    {
                        Thrown_weapon tw = (Thrown_weapon)eq;
                        item.AppendChild(Xml_util.create_text_element("single_fire_damage", rw.Single_fire_damage, ref xDoc));
                        item.AppendChild(Xml_util.create_text_element("penetration", Convert.ToString(tw.Penetration), ref xDoc));
                    }
                    else if (eq.Equipment_type == "melee_weapon")
                    {   //Can also be thrown...
                        item.AppendChild(Xml_util.create_text_element("single_fire_damage", rw.Single_fire_damage, ref xDoc));
                    }


                    //Lastly check if the weapon has a mag loaded and is held in a hand etc

                    if (rw.Magazine != null && rw.Magazine.Projectiles_left > 0)
                    {
                        XmlElement mag_item = xDoc.CreateElement("loaded_magazine");
                        item.AppendChild(mag_item);
                        append_mag_xml(ref mag_item, ref xDoc, rw.Magazine);
                    }

                    item.AppendChild(Xml_util.create_text_element("held_by_main_hand", rw.Held_by_main_hand, ref xDoc));
                    item.AppendChild(Xml_util.create_text_element("held_by_secondary_hand", rw.Held_by_secondary_hand, ref xDoc));
                    
                }
                else if (eq.Equipment_type == "magazine")
                {
                    append_mag_xml(ref item, ref xDoc, (Magazine)eq);
                }
                else if (eq.Equipment_type == "ammunition")
                {
                    Ammo_pile ap = (Ammo_pile)eq;
                    item.AppendChild(Xml_util.create_text_element("calibre", ap.Calibre, ref xDoc));
                    item.AppendChild(Xml_util.create_text_element("shell_type", ap.Shell_type, ref xDoc));
                    item.AppendChild(Xml_util.create_text_element("projectiles_left", Convert.ToString(ap.Projectiles_left), ref xDoc));
                }

                equipment.AppendChild(item);
            }

            return equipment;
        }

        private void append_mag_xml(ref XmlElement item, ref XmlDocument xDoc, Magazine am)
        {
            item.AppendChild(Xml_util.create_text_element("calibre", am.Calibre, ref xDoc));
            item.AppendChild(Xml_util.create_text_element("shell_type", am.Shell_type, ref xDoc));
            item.AppendChild(Xml_util.create_text_element("max_projectiles", Convert.ToString(am.Max_projectiles), ref xDoc));
            item.AppendChild(Xml_util.create_text_element("projectiles_left", Convert.ToString(am.Projectiles_left), ref xDoc));
           
        }

        private XmlElement create_range_damage_xml(string shell_type, string damage_type ,ListDictionary range_dic,ref XmlDocument xDoc)
        {
            string range_h;
            string range_v;
            XmlElement range_damage = xDoc.CreateElement(damage_type);
            range_damage.AppendChild(Xml_util.create_text_element("shell_type", shell_type, ref xDoc));

            XmlElement range_damage_die = xDoc.CreateElement("range_damage_die");

            foreach (DictionaryEntry dic in range_dic)
            {
                range_h = dic.Key.ToString();
                range_h = range_h.Substring(range_h.IndexOf("_") + 1);
                range_v = dic.Value.ToString();

                range_damage_die.AppendChild(Xml_util.create_text_element(range_h, range_v, ref xDoc));
            }

            range_damage.AppendChild(range_damage_die);
            
            return range_damage;
        
        }


        public void save_Encounter(List<Creature> creature_list, string path)
        {
            string save_path;

            foreach (Creature cret in creature_list)
            {
                save_path = path + cret.Name + "_" + cret.Clone_index.ToString() + ".xml";
                save_encounter_creature(cret, save_path);  
            }

        }

        public void save_encounter_creature(Creature hum, string path)
        {
            XmlDocument xDoc = prepare_creature_for_save(hum);
            
            //Apply encounter specifics 
            xDoc = prepare_encounter_creature_for_save(xDoc, hum);

            Xml_util.write_to_file(path, xDoc);
        }

        private XmlDocument prepare_encounter_creature_for_save(XmlDocument xDoc, Creature hum)
        {
            XmlNodeList nodeList = xDoc.GetElementsByTagName("creature");
            XmlElement root = (XmlElement )nodeList.Item(0);
            XmlElement temp_data = xDoc.CreateElement("temporary_data");

            temp_data.AppendChild(Xml_util.create_text_element("temp_body_points", Convert.ToString(hum.Temp_body_points), ref xDoc));
            temp_data.AppendChild(Xml_util.create_text_element("death_count", Convert.ToString(hum.Death_count), ref xDoc));
            temp_data.AppendChild(Xml_util.create_text_element("unconcious_count", Convert.ToString(hum.Unconsious_count), ref xDoc));
            temp_data.AppendChild(Xml_util.create_text_element("mental_resonans", Convert.ToString(hum.Mental_resonans), ref xDoc));

            root.AppendChild(temp_data);

            return xDoc;
        }

        #endregion

        #region Loading functionality

        public Creature load_humanoid(string path)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(path);

            Creature hum = new Creature();

            //Here we do the actual instantiation. All subclasses shall be castable to Creature
            if (Xml_util.get_field_value("class", ref xDoc) == "RBT")
                hum = new Robot();
            else if (Xml_util.get_field_value("class", ref xDoc) == "PSI")
                hum = new Psi();

            //TODO: make schema validation so that we got all things we need before we start parsing.
            
            //Get the basic data out
            hum.Name = Xml_util.get_field_value("name", ref xDoc);
            hum.Class_type = Xml_util.get_field_value("class", ref xDoc);
            hum.Image_path = Xml_util.get_field_value("image", ref xDoc);
            hum.Sty_base = Convert.ToInt32(Xml_util.get_field_value("sty", ref xDoc));
            hum.Fys_base = Convert.ToInt32(Xml_util.get_field_value("fys", ref xDoc));
            hum.Sto_base = Convert.ToInt32(Xml_util.get_field_value("sto", ref xDoc));
            hum.Smi_base = Convert.ToInt32(Xml_util.get_field_value("smi", ref xDoc));
            hum.Int_base = Convert.ToInt32(Xml_util.get_field_value("int", ref xDoc));
            hum.Vil_base = Convert.ToInt32(Xml_util.get_field_value("vil", ref xDoc));
            hum.Per_base = Convert.ToInt32(Xml_util.get_field_value("per", ref xDoc));
            hum.General_health = Xml_util.get_field_value("general_health", ref xDoc);
            hum.Template_path = Xml_util.get_field_value("template_path", ref xDoc);

            //initialize the calculations of derived values
            hum.calculate_from_base_values();

            //Get skills if ther are any
            hum.Skills = get_skills(ref xDoc);

            //Get any special abilities
            hum.Special_abilities = get_special_abilities(ref xDoc);

            //Get body parts and figure out armour mods to skills.
            hum.Body = get_body_modle(ref xDoc);
            hum.calculate_total_armour_mod();
            
            //Get equipment
            hum.Equipment = get_equipment(ref xDoc);

            //If its an encounter get temporary data 
            if (Xml_util.node_exists("temporary_data", ref xDoc))
                fill_temporary_data(ref xDoc, ref hum);

            return hum;
        }


        /// <summary>
        /// Gets any defined skills from the xml document.
        /// </summary>
        /// <param name="doc"></param>
        /// <returns>A list of skill objects. List can be empty</returns>
        private List<Skill> get_skills(ref XmlDocument doc)
        {
            List<Skill> skills = new List<Skill>();

            if (Xml_util.node_exists("skills", ref doc))
            {
                XmlNodeList nodeList = doc.GetElementsByTagName("skill");

                foreach (XmlNode xNode in nodeList)
                {
                    Skill sk = new Skill();
                    sk.Name = xNode["name"].InnerText;
                    sk.Skill_value = Convert.ToInt32(xNode["value"].InnerXml);
                    sk.Skill_base_attribute = xNode["base_attribute"].InnerXml;
                    skills.Add(sk);
                }
            }
            return skills;
        }

        private List<Special_ability> get_special_abilities(ref XmlDocument doc)
        {
            List<Special_ability> specials = new List<Special_ability>();
            if (Xml_util.node_exists("special_abilities", ref doc))
            {
                XmlNodeList nodeList = doc.GetElementsByTagName("ability");
                Ability_factory abf = new Ability_factory();

                foreach (XmlNode xNode in nodeList)
                    specials.Add(abf.create_ability_object_from_xml(xNode));
            }
            return specials;

        }

        private Body_modle get_body_modle(ref XmlDocument doc)
        {
            Body_factory body_fact = new Body_factory();
            Body_modle bmod = body_fact.load_creature_body_modle(ref doc);
            
            return bmod;
        }

        private List<Equipment> get_equipment(ref XmlDocument doc)
        {
            List<Equipment> equipment_list = new List<Equipment>();
            if (Xml_util.node_exists("equipment", ref doc))
            {
                XmlNodeList nodeList = doc.GetElementsByTagName("item");
                Equipment_factory eqf = new Equipment_factory();
                XmlNode xNode;

                foreach (XmlNode xN in nodeList)
                {
                    xNode = Xml_util.get_detached_node(xN);

                    if (xNode["equipment_type"].InnerXml.ToUpper().EndsWith("_WEAPON"))
                        equipment_list.Add(eqf.create_weapon(xNode));
                    else if (xNode["equipment_type"].InnerXml == "magazine")
                        equipment_list.Add(eqf.create_mag(xNode));
                    else if (xNode["equipment_type"].InnerXml == "ammunition")
                        equipment_list.Add(eqf.create_ammo_pile(xNode));
                    else
                        equipment_list.Add(eqf.create_base_equipment(xNode));
                }



            }
            return equipment_list;
        }

        private void fill_temporary_data(ref XmlDocument xDoc, ref Creature hum)
        {
            hum.Temp_body_points = Convert.ToInt32(Xml_util.get_field_value("temp_body_points", ref xDoc));
            hum.Death_count = Xml_util.get_field_value("death_count", ref xDoc);
            hum.Unconsious_count = Convert.ToInt32(Xml_util.get_field_value("unconcious_count", ref xDoc));
            hum.Mental_resonans = Convert.ToInt32(Xml_util.get_field_value("mental_resonans", ref xDoc));
        }

        public List<Creature> load_encounter(string encounter_folder)
        {
            List<Creature> c_list = new List<Creature>();

            if (encounter_folder != "")
            {

                string[] enc_files = Directory.GetFiles(encounter_folder);


                for (int i = 0; i < enc_files.Length; i++)
                {
                    c_list.Add(load_humanoid(enc_files[i]));
                }
            }
            return c_list;
        }

        #endregion

        #region New creation functionality

        public Creature create_empty_creature()
        {
            //Make a new empty creature
            Creature cret = new Creature();

            //Add the natural skills
            List<Skill> skills = new List<Skill>();

            skills = List_service.get_natural_skills();

            cret.Skills = skills;

            //Add an empty special abilities list
            cret.Special_abilities = new List<Special_ability>();

            cret.Equipment = new List<Equipment>();

            return cret;
        }

        #endregion
    }
}
