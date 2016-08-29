using System;
using System.Collections.Generic;
using System.Xml;

namespace MPC4.classes
{
    public class Resonans_repository
    {
        public List<Resonans_effect> get_all_resonans_effects()
        {
            List<Resonans_effect> resonans_list = new List<Resonans_effect>();

            string path = Path_util.get_application_xml_path("resonans_list.xml"); 
            XmlDocument doc = new XmlDocument();
            doc.Load(path);

            XmlNodeList nodeList = doc.GetElementsByTagName("resonans_effect");

            foreach (XmlNode xNode in nodeList)
            {
                Resonans_effect re = new Resonans_effect(Convert.ToInt32(xNode["resonans_value"].InnerText),
                                                            xNode["title"].InnerText,
                                                            xNode["description"].InnerText);
                resonans_list.Add(re);
            }

            return resonans_list;
        }

        public Resonans_effect get_resonans_effect_by_val(int resonans_value)
        {
            List<Resonans_effect> resonans_list = get_all_resonans_effects();
            Resonans_effect res = null;

            if (resonans_list.Exists(a => a.Resonans_value == resonans_value))
                res = resonans_list.Find(a => a.Resonans_value == resonans_value);

            return res;
        }

    }
}
