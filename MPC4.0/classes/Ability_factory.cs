using System;
using System.Xml;
using MPC4.classes;
using System.Collections.Generic;

namespace MPC4.classes
{
    public class Ability_factory
    {
        public Special_ability create_ability_object_from_xml(XmlNode i_xNode)
        {
            Special_ability sp = new Special_ability();
            XmlNode xNode =  Xml_util.get_detached_node(i_xNode);

            sp.Name = xNode["name"].InnerText;
            sp.Activation = xNode["activation"].InnerText;
            sp.Range = xNode["range"].InnerText;
            sp.Effect = xNode["effect"].InnerText;
            sp.Duration = xNode["duration"].InnerText;
            sp.Description = xNode["description"].InnerText;

            if (xNode["ability_skill"] != null)
            {
                XmlNodeList xlist = xNode.SelectNodes("//ability_skill");

                foreach (XmlNode xN_skill in xlist)
                {
                    Skill sk = new Skill(xN_skill["name"].InnerText, 0, xN_skill["base_attribute"].InnerText);
                    sp.Ability_skill = sk;
                }
            }

            return sp;
        }

        /// <summary>
        /// The method returns an XmlElement with the ability_xml represented in its xml format.
        /// </summary>
        /// <param name="special_list"></param>
        /// <param name="xDoc"></param>
        /// <returns></returns>
        public XmlElement create_special_ability_xml(Special_ability sp, ref XmlDocument xDoc)
        {
            XmlElement ability_xml = xDoc.CreateElement("ability");
            ability_xml.AppendChild(Xml_util.create_text_element("name", sp.Name, ref xDoc));
            ability_xml.AppendChild(Xml_util.create_text_element("activation", sp.Activation, ref xDoc));
            ability_xml.AppendChild(Xml_util.create_text_element("range", sp.Range, ref xDoc));
            ability_xml.AppendChild(Xml_util.create_text_element("effect", sp.Effect, ref xDoc));
            ability_xml.AppendChild(Xml_util.create_text_element("duration", sp.Duration, ref xDoc));
            ability_xml.AppendChild(Xml_util.create_text_element("description", sp.Description, ref xDoc));

            if (sp.Ability_skill != null)
            {
                XmlElement skill = xDoc.CreateElement("ability_skill");
                skill.AppendChild(Xml_util.create_text_element("name", sp.Ability_skill.Name, ref xDoc));
                skill.AppendChild(Xml_util.create_text_element("base_attribute", sp.Ability_skill.Skill_base_attribute, ref xDoc));

                ability_xml.AppendChild(skill);
            }

            return ability_xml;

        }


    }
}
