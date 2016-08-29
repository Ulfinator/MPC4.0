using System;
using System.Xml;
using System.Collections.Generic;
using System.Collections;
using System.IO;

namespace MPC4.classes
{
    public class Equipment_repository
    {

        public Equipment_repository()
        { }

        /// <summary>
        /// Retrieves equipment lists based on the send in path of a equipment_file
        /// </summary>
        /// <param name="category">category description: eg "field_gear"</param>
        /// <returns></returns>
        public List<Equipment> get_equipment(string equipment_file_path)
        {
            List<Equipment> equipment_list = new List<Equipment>();
            XmlDocument doc = new XmlDocument();
            doc.Load(equipment_file_path);
            XmlNodeList nodeList = doc.GetElementsByTagName("item");
            Equipment_factory eqf = new Equipment_factory();

            foreach (XmlNode xNode in nodeList)
            {
                string eqType = xNode["equipment_type"].InnerXml;

                if (eqType.ToUpper().EndsWith("_WEAPON"))
                    equipment_list.Add(eqf.create_weapon(xNode));
                else if (eqType == "ammunition")
                    equipment_list.Add(eqf.create_ammo_pile(xNode));
                else if (eqType == "magazine")
                    equipment_list.Add(eqf.create_mag(xNode));
                else
                    equipment_list.Add(eqf.create_base_equipment(xNode));
            }

            return equipment_list;
        }

        public Hashtable get_equipment_index()
        {
            XmlDocument doc = new XmlDocument();

            XmlNodeList nodeList; // = doc.GetElementsByTagName("category");
            XmlNode xCategory;
            string equip_path = Path_util.get_euipment_path(""); 
            
            Hashtable equip_hash = new Hashtable();


            foreach (string temp_path in Directory.GetFiles(equip_path))
            {
                doc = new XmlDocument();
                doc.Load(temp_path);
                nodeList = doc.GetElementsByTagName("category");
                xCategory = nodeList[0];
                equip_hash.Add(xCategory.InnerXml, temp_path);
            }


            return equip_hash;
        }

        public void save_equipment_list(List<Equipment> equip, string category, string path)
        {
            string root_name = "equipment";
            string instance_name = "item";

            //create an xml document of the List
            XmlDocument xDoc = new XmlDocument();

            XmlElement root = xDoc.CreateElement(root_name);
            xDoc.AppendChild(root);

            root.AppendChild(Xml_util.create_text_element("category", category, ref xDoc));


            foreach (Equipment eq in equip)
            {
                XmlElement item = xDoc.CreateElement(instance_name);


                item.AppendChild(Xml_util.create_text_element("name", eq.Name, ref xDoc));
                item.AppendChild(Xml_util.create_text_element("equipment_type", eq.Equipment_type, ref xDoc));
                item.AppendChild(Xml_util.create_text_element("description", eq.Description, ref xDoc));

                root.AppendChild(item);
            }

            //Save the doc to disk, erasing the old one
            Xml_util.write_to_file(path, xDoc);
        }
    }
}
