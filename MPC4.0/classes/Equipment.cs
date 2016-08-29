using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;

namespace MPC4.classes
{
    public class Equipment : ICloneable
    {
        int id;
        string name;
        string equipment_type;
        string description;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Equipment_type
        {
            get { return equipment_type; }
            set { equipment_type = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public virtual ListDictionary get_stat_summary_list()
        {
            ListDictionary list_descrip = new ListDictionary();

            list_descrip.Add("Beskrivning", description);

            return list_descrip;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
