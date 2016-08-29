using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Xml;
using System.IO;
using System.Reflection;

namespace MPC4.classes
{
    public static class List_service
    {

        public static List<Skill> get_natural_skills()
        {
            string path = Path_util.get_application_xml_path("skill_list.xml"); 

            List<Skill> skills = new List<Skill>();
            XmlDocument doc = new XmlDocument();
            
            doc.Load(path);

            XmlNodeList nodeList = doc.GetElementsByTagName("skill");

            foreach (XmlNode xNode in nodeList)
            {
                if (xNode["type"].InnerText == "NATURAL")
                {
                    Skill sk = new Skill(xNode["name"].InnerText, 0, xNode["base_attribute"].InnerText);
                    skills.Add(sk);
                }
            }

            return skills;
        }

        public static List<Skill> get_trained_skills()
        {
            string path = Path_util.get_application_xml_path("skill_list.xml"); 

            List<Skill> skills = new List<Skill>();
            XmlDocument doc = new XmlDocument();
            
            doc.Load(path);

            XmlNodeList nodeList = doc.GetElementsByTagName("skill");

            foreach (XmlNode xNode in nodeList)
            {
                if (xNode.ChildNodes[2].InnerXml == "TRAINED")
                {
                    Skill sk = new Skill(xNode["name"].InnerText, 0, xNode["base_attribute"].InnerText);
                    skills.Add(sk);
                }
            }

            return skills;
        }
        
        public static List<Armour_part> get_armour_parts()
        {
            List<Armour_part> armour_list = new List<Armour_part>();
            string path = Path_util.get_armour_path("armour_list.xml"); 

            XmlDocument doc = new XmlDocument();
            doc.Load(path);

            XmlNodeList nodeList = doc.GetElementsByTagName("armour_part");

            foreach (XmlNode xNode in nodeList)
            {
                Armour_part ap = new Armour_part(xNode["name"].InnerText, 
                                                    xNode["part_cover"].InnerText,
                                                    xNode["type"].InnerText, 
                                                    Convert.ToInt32(xNode["absorption_value"].InnerText),
                                                    Convert.ToInt32(xNode["limitation_value"].InnerText), 
                                                    "N/A", 
                                                    "OK");
                
                
                armour_list.Add(ap);
                
            }

            return armour_list;
        }




    }
}
