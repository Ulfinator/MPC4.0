using System;
using System.Xml;
using MPC4.classes;
using System.Collections.Generic;

namespace MPC4.classes
{
    public class Ability_repository
    {
        public  List<Special_ability> get_abilities(string ability_type)
        { 
            List<Special_ability> abilities = new List<Special_ability>();
            XmlDocument doc = new XmlDocument();
            Creature hum = new Creature();
            string path = Path_util.get_application_xml_path("");
            XmlNodeList nodeList = null;


            if (ability_type == "MM" || ability_type == "MD")
            {
                path +=  "mutation_list.xml";
                doc.Load(path);
                nodeList = doc.GetElementsByTagName("mutation");
            }
            else if (ability_type == "PSI" || ability_type == "MMD")
            {
                path += "mental_mutation_list.xml";
                doc.Load(path);
                nodeList = doc.GetElementsByTagName("mental_mutation");                
            }
            else if (ability_type == "RBT")
            {
                path += "options_list.xml";
                doc.Load(path);
                nodeList = doc.GetElementsByTagName("option");            
            }
            else if (ability_type == "IMM")
            {
                path += "talents_list.xml";
                doc.Load(path);
                nodeList = doc.GetElementsByTagName("talent");
            }

            //Load up the ablilities
            if (nodeList != null)
            {
                Ability_factory abf = new Ability_factory();
                
                foreach (XmlNode xNode in nodeList)
                    abilities.Add(abf.create_ability_object_from_xml(xNode)); 
            }

            return abilities; 
        }

        public void add_update_ability(Special_ability sp, string ability_type)
        {
            List<Special_ability> lsa = get_abilities(ability_type);

            if(lsa.Find(o=>o.Name == sp.Name) != null) //Find and remove old version if there is one
                lsa.Remove(lsa.Find(o=>o.Name == sp.Name));

            lsa.Add(sp);
            lsa.Sort((a, b) =>  a.Name.CompareTo(b.Name));

            //save the entire list to file
            save_ability_list(lsa,ability_type);

        }

        public void remove_ability(Special_ability sp, string ability_type)
        {
            List<Special_ability> lsa = get_abilities(ability_type);

            if (lsa.Find(o => o.Name == sp.Name) != null) //Find and remove
                lsa.Remove(lsa.Find(o => o.Name == sp.Name));

            save_ability_list(lsa, ability_type);  //Re-save the list.
        }

        private void save_ability_list(List<Special_ability> lsa, string ability_type)
        {
            string path="";
            string root_name= "errors";     //assigning a little hard to miss text if something goes wrong
            string instance_name = "error";

            //create an xml document of the List
            XmlDocument xDoc = new XmlDocument();

            if (ability_type == "MM" || ability_type == "MD")
            {
                path = Path_util.get_application_xml_path("mutation_list.xml"); 
                root_name = "mutations";
                instance_name = "mutation";
            }
            else if (ability_type == "PSI" || ability_type == "MMD")
            {
                path = Path_util.get_application_xml_path("mental_mutation_list.xml"); 
                root_name = "mental_mutations";
                instance_name = "mental_mutation";
            }
            else if (ability_type == "RBT")
            {
                path = Path_util.get_application_xml_path("options_list.xml"); 
                root_name = "options";
                instance_name = "option";
            }
            else if (ability_type == "IMM")
            {
                path = Path_util.get_application_xml_path("talents_list.xml"); 
                root_name = "talents";
                instance_name = "talent";
            }

            XmlElement root = xDoc.CreateElement(root_name);
            xDoc.AppendChild(root);

            foreach(Special_ability sa in lsa)
            {
                XmlElement instance = xDoc.CreateElement(instance_name);

                instance.AppendChild(Xml_util.create_text_element("name", sa.Name, ref xDoc));
                instance.AppendChild(Xml_util.create_text_element("activation", sa.Activation, ref xDoc));
                instance.AppendChild(Xml_util.create_text_element("range", sa.Range, ref xDoc));
                instance.AppendChild(Xml_util.create_text_element("effect", sa.Effect, ref xDoc));
                instance.AppendChild(Xml_util.create_text_element("duration", sa.Duration, ref xDoc));
                instance.AppendChild(Xml_util.create_text_element("description", sa.Description, ref xDoc));

                //If there is a special skill attached then write that as well
                if (sa.Ability_skill != null)
                {
                    XmlElement ab_skill = xDoc.CreateElement("ability_skill");
                    ab_skill.AppendChild(Xml_util.create_text_element("name", sa.Ability_skill.Name, ref xDoc));
                    ab_skill.AppendChild(Xml_util.create_text_element("base_attribute", sa.Ability_skill.Skill_base_attribute, ref xDoc));

                    instance.AppendChild(ab_skill);
                }

                root.AppendChild(instance);
            }

            //Save the doc to disk, erasing the old one
            Xml_util.write_to_file(path, xDoc);
        }

    }
}
