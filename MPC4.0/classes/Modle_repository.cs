using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Text;

namespace MPC4.classes
{
    public class Modle_repository
    {
        public List<Body_modle> get_body_modles()
        {
            List<Body_modle> modle_list = new List<Body_modle>();
            string path = Path_util.get_body_modle_path(""); 

            string[] files = Directory.GetFiles(path);
            Body_factory b_fact = new Body_factory();

            foreach (string file_path in files)
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(file_path);
                Body_modle bm = b_fact.load_base_body_modle(ref doc);
                modle_list.Add(bm);
            }

            return modle_list;
        }

        public string save_modle(Body_modle bm, string save_path)
        {
            string status = pre_save_check(bm);

            if (status == "OK")
            {
                XmlDocument xDoc = prepare_modle_for_save(bm);
                Xml_util.write_to_file(save_path, xDoc);
                return "OK";
            }
            else
                return status;
        }

        private string pre_save_check(Body_modle bm)
        {
            StringBuilder sb = new StringBuilder();

            if (bm.Modle_name == null || bm.Modle_name == "")
                sb.AppendLine("-Kroppstypen måste ha en beteckning/namn");

            if (bm.Modle_hit_die == null || bm.Modle_hit_die == "")
                sb.AppendLine("-Kroppstypen måste ha en tärningstyp");

            foreach (Body_part bp in bm.Body_parts)
            { 
                if(bp.Name == null || bp.Name == "")
                    sb.AppendLine("-Saknat namn på kroppsdel");

                if (bp.Part_type == null || bp.Part_type == "")
                    sb.AppendLine("-Saknad typ på kroppsdel");

                if (bp.Hit_die_start == 0)
                    sb.AppendLine("-Saknad tärningsstart på kroppsdel");

                if (bp.Hit_die_end == 0)
                    sb.AppendLine("-Saknad tärningsslut på kroppsdel");

                if (bp.Point_X == 0)
                    sb.AppendLine("-Saknad ritpunktsstart X på kroppsdel");

                if (bp.Point_Y == 0)
                    sb.AppendLine("-Saknad ritpunktsstart Y på kroppsdel");

                if (bp.Mod_damage_all == 0)
                    sb.AppendLine("-Saknad mod skada på kroppsdel");

                if (bp.Mod_damage_two_hand == 0)
                    sb.AppendLine("-Saknad mod tvåhands skada på kroppsdel");

            }

            if (sb.ToString() == "")
                sb.Append("OK");

            return sb.ToString();
        }

        private XmlDocument prepare_modle_for_save(Body_modle bm)
        {
            XmlDocument xDoc = new XmlDocument();
            XmlElement root = xDoc.CreateElement("creature");
            xDoc.AppendChild(root);
            root.AppendChild(create_body_xml(bm, ref xDoc));

            return xDoc;
        }

        public XmlElement create_body_xml(Body_modle b_modle, ref XmlDocument xDoc)
        {
            XmlElement body_modle = xDoc.CreateElement("body_modle");
            body_modle.AppendChild(Xml_util.create_text_element("modle_name", b_modle.Modle_name, ref xDoc));
            body_modle.AppendChild(Xml_util.create_text_element("modle_hit_die", b_modle.Modle_hit_die, ref xDoc));

            XmlElement body_parts = xDoc.CreateElement("body_parts");

            foreach (Body_part bp in b_modle.Body_parts)
            {
                XmlElement body_part = xDoc.CreateElement("body_part");
                body_part.AppendChild(Xml_util.create_text_element("name", bp.Name, ref xDoc));
                body_part.AppendChild(Xml_util.create_text_element("part_type", bp.Part_type, ref xDoc));
                body_part.AppendChild(Xml_util.create_text_element("hit_die_start", Convert.ToString(bp.Hit_die_start), ref xDoc));
                body_part.AppendChild(Xml_util.create_text_element("hit_die_end", Convert.ToString(bp.Hit_die_end), ref xDoc));
                body_part.AppendChild(Xml_util.create_text_element("die_draw_point_x", Convert.ToString(bp.Die_text_point.X), ref xDoc));
                body_part.AppendChild(Xml_util.create_text_element("die_draw_point_y", Convert.ToString(bp.Die_text_point.Y), ref xDoc));
                body_part.AppendChild(Xml_util.create_text_element("mod_damage_all", Convert.ToString(bp.Mod_damage_all), ref xDoc));
                body_part.AppendChild(Xml_util.create_text_element("mod_damage_two_hand", Convert.ToString(bp.Mod_damage_two_hand), ref xDoc));
                body_part.AppendChild(Creature_drawing_handler.create_draw_point_xml(bp.Draw_points, ref xDoc));
                body_part.AppendChild(Xml_util.create_text_element("status", bp.Status, ref xDoc));
                body_part.AppendChild(Xml_util.create_text_element("armoured", bp.Armoured, ref xDoc));

                if (bp.Armoured == "YES")
                {
                    XmlElement armour_parts = xDoc.CreateElement("armour_parts");

                    foreach (Armour_part ap in bp.Armour_parts)
                    {
                        XmlElement armour_part = xDoc.CreateElement("armour_part");
                        armour_part.AppendChild(Xml_util.create_text_element("name", ap.Name, ref xDoc));
                        armour_part.AppendChild(Xml_util.create_text_element("part_cover", ap.Part_cover, ref xDoc));
                        armour_part.AppendChild(Xml_util.create_text_element("type", ap.Type, ref xDoc));
                        armour_part.AppendChild(Xml_util.create_text_element("absorption_value", Convert.ToString(ap.Absorption_value), ref xDoc));
                        armour_part.AppendChild(Xml_util.create_text_element("limitation_area", ap.Limitation_area, ref xDoc));
                        armour_part.AppendChild(Xml_util.create_text_element("limitation_value", Convert.ToString(ap.Limitation_value), ref xDoc));
                        armour_part.AppendChild(Xml_util.create_text_element("status", ap.Status, ref xDoc));

                        armour_parts.AppendChild(armour_part);
                    }

                    body_part.AppendChild(armour_parts);
                }

                body_parts.AppendChild(body_part);
            }

            body_modle.AppendChild(body_parts);

            return body_modle;
        }

        /// <summary>
        ///Loads a base body modle to be applied to a creature. 
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        public Body_modle load_base_body_modle(ref XmlDocument doc)
        {
            Body_modle bm = new Body_modle();
            XmlNodeList nodeList;
            List<Body_part> bp_list = new List<Body_part>();


            nodeList = doc.GetElementsByTagName("modle_name");
            bm.Modle_name = nodeList.Item(0).InnerXml;

            nodeList = doc.GetElementsByTagName("modle_hit_die");
            bm.Modle_hit_die = nodeList.Item(0).InnerXml;

            nodeList = doc.GetElementsByTagName("body_part");
            foreach (XmlNode xNode in nodeList)
            {
                Body_part bp = new Body_part();
                bp.Name = xNode["name"].InnerText;
                bp.Part_type = xNode["part_type"].InnerText;
                bp.Status = "OK";
                bp.Armoured = "NO";
                bp.Hit_die_start = Convert.ToInt32(xNode["hit_die_start"].InnerText);
                bp.Hit_die_end = Convert.ToInt32(xNode["hit_die_end"].InnerText);
                bp.Die_text_point = new System.Drawing.Point(Convert.ToInt32(xNode["die_draw_point_x"].InnerText), Convert.ToInt32(xNode["die_draw_point_y"].InnerText));
                bp.Mod_damage_all = Convert.ToInt32(xNode["mod_damage_all"].InnerText);
                bp.Mod_damage_two_hand = Convert.ToInt32(xNode["mod_damage_two_hand"].InnerText);
                bp.Draw_points = get_draw_points(xNode);
                bp_list.Add(bp);
            }

            bm.Body_parts = bp_list;

            return bm;
        }

        //TODO: See if this should not be moved to the draw util in the end
        private List<System.Drawing.Point> get_draw_points(XmlNode xNode)
        {
            List<System.Drawing.Point> dPoints = new List<System.Drawing.Point>();

            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml(@"<temp></temp>");
            XmlNode copynode = xDoc.ImportNode(xNode, true);
            xDoc.DocumentElement.AppendChild(copynode);

            XmlNodeList xPoints = xDoc.GetElementsByTagName("point");

            foreach (XmlNode xPoint in xPoints)
            {
                System.Drawing.Point dp = new System.Drawing.Point();
                dp.X = Convert.ToInt32(xPoint["x"].InnerText);
                dp.Y = Convert.ToInt32(xPoint["y"].InnerText);

                dPoints.Add(dp);
            }

            return dPoints;
        }
    }
}
