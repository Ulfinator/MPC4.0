using System.Xml;
namespace MPC4.classes
{
    public static class Xml_util
    {
        /// <summary>
        /// Takes a document node and make sure its detached from its parent document by creating a copy.
        /// This because even though a node is sent away from its parent it seems to have a connection and for instance
        /// xpath expressions search the entire document when applied to the node.
        /// </summary>
        /// <param name="xNode"></param>
        /// <returns></returns>
        public static XmlNode get_detached_node(XmlNode xNode)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml(@"<temp></temp>");
            XmlNode copynode = xDoc.ImportNode(xNode, true);
            xDoc.DocumentElement.AppendChild(copynode);
            XmlNodeList xnl = xDoc.GetElementsByTagName(xNode.Name); 
            XmlNode xDetached = xnl[0];

            return xDetached;
        }


        public static XmlElement create_text_element(string element_name, string element_value, ref XmlDocument xDoc)
        {
            XmlElement elem = xDoc.CreateElement(element_name);
            elem.InnerText = element_value;
            return elem;
        }

        public static void write_to_file(string path, XmlDocument xDoc)
        {
            XmlTextWriter writer = new XmlTextWriter(path, null);
            writer.Formatting = Formatting.Indented;
            xDoc.Save(writer);
            writer.Close(); 

        }

        public static string get_field_value(string fieldName, ref XmlDocument doc)
        {
            XmlNodeList nodeList = doc.GetElementsByTagName(fieldName);
            return nodeList.Item(0).InnerXml;
        }

        public static bool node_exists(string nodeName, ref XmlDocument doc)
        {
            XmlNodeList nodeList = doc.GetElementsByTagName(nodeName);

            if (nodeList.Count > 0)
                return true;
            else
                return false;
        }

    }
}
