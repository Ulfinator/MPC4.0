using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPC4.classes
{
    public class Die_modifier
    {
        private int modifier_value;
        private string die_type;
        
        public int Modifier_value
        {
            get { return modifier_value; }
            set { modifier_value = value; }
        }
        
        public string Die_type
        {
            get { return die_type; }
            set { die_type = value; }
        }


    }
}
