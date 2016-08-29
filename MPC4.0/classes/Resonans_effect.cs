using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using System.Text.RegularExpressions;

namespace MPC4.classes
{
    public class Resonans_effect
    {
        int resonans_value;
        string title;
        string description;
        
        public int Resonans_value
        {
            get { return resonans_value; }
            set { resonans_value = value; }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }


        public Resonans_effect(int i_resonans_value, string i_title, string i_description)
        {
            resonans_value = i_resonans_value;
            title = i_title;
            description = i_description;

        }


        public ListDictionary get_stat_summary_list()
        {
            ListDictionary list_descrip = new ListDictionary();

            list_descrip.Add("Resonans nivå", Resonans_value);
            list_descrip.Add("Titel", Title);
            list_descrip.Add("Beskrivning", Description);
            
            return list_descrip;
        }
    }
}
