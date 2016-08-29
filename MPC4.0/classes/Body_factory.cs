using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace MPC4.classes
{
    public class Body_factory
    {
        //TODO: Deprecate this whole class.
        public Body_factory() { }

        //TODO: Move all calls on this to Modle repository
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

        /// <summary>
        /// Loads a body modle instantiated on a creature and therefore changed from its base.
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        public Body_modle load_creature_body_modle(ref XmlDocument doc)
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
                bp.Hit_die_start = Convert.ToInt32(xNode["hit_die_start"].InnerText);
                bp.Hit_die_end = Convert.ToInt32(xNode["hit_die_end"].InnerText);
                bp.Die_text_point = new System.Drawing.Point(Convert.ToInt32(xNode["die_draw_point_x"].InnerText),Convert.ToInt32(xNode["die_draw_point_y"].InnerText));
                bp.Mod_damage_all = Convert.ToInt32(xNode["mod_damage_all"].InnerText);
                bp.Mod_damage_two_hand = Convert.ToInt32(xNode["mod_damage_two_hand"].InnerText);
                bp.Draw_points = get_draw_points(xNode);
                bp.Status = xNode["status"].InnerText;
                bp.Armoured = xNode["armoured"].InnerText;

                bp.Armour_parts = new List<Armour_part>();

                if(bp.Armoured == "YES")
                {
                    XmlDocument xDoc = new XmlDocument();
                    xDoc.LoadXml(@"<temp></temp>");
                    XmlNode copynode = xDoc.ImportNode(xNode, true);
                    xDoc.DocumentElement.AppendChild(copynode);

                    XmlNodeList armour = xDoc.GetElementsByTagName("armour_part");

                    foreach (XmlNode armNode in armour)
                    {
                        Armour_part ap = new Armour_part();
                        ap.Name = armNode["name"].InnerText;
                        ap.Part_cover = armNode["part_cover"].InnerText;
                        ap.Type = armNode["type"].InnerText;
                        ap.Absorption_value = Convert.ToInt32(armNode["absorption_value"].InnerText);
                        ap.Limitation_area = armNode["limitation_area"].InnerText;
                        ap.Limitation_value = Convert.ToInt32(armNode["limitation_value"].InnerText);
                        ap.Status = armNode["status"].InnerText;

                        bp.Armour_parts.Add(ap);
                    }
                }

                bp_list.Add(bp);
            }

            bm.Body_parts = bp_list;

            return bm;
        }

        //TODO: Move all calls on this to Modle repository
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
