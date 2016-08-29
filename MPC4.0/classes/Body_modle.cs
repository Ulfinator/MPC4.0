using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPC4.classes
{
    public class Body_modle
    {
        string modle_name;
        string modle_hit_die;
        List<Body_part> body_parts;


        public string Modle_name
        {
            get { return modle_name; }
            set { modle_name = value; }
        }

        public string Modle_hit_die
        {
            get { return modle_hit_die; }
            set { modle_hit_die = value; }
        }

        public List<Body_part> Body_parts
        {
            get { return body_parts; }
            set { body_parts = value; }
        }

        public Body_modle() { }

        public Body_modle(string i_modle_name, string i_hit_die, List<Body_part> i_parts)
        {
            modle_name = i_modle_name;
            modle_hit_die = i_hit_die;
            body_parts = i_parts;
        }

    }
}
