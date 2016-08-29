using System;
using System.Collections.Generic;
using System.Text;

namespace MPC4.classes
{
    public class Body_part
    {
        string name;
        string part_type;
        string status;
        int hit_die_start;
        int hit_die_end;
        System.Drawing.Point die_text_point;
        int mod_damage_all;
        int mod_damage_two_hand;
        string armoured;
        List<Armour_part> amps;
        List<System.Drawing.Point> draw_points;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Part_type
        {
            get { return part_type; }
            set { part_type = value; }
        }

        public string Status
        {
            get { return status; }
            set { status = validate_status(value); }
        }

        public int Hit_die_start
        {
            get { return hit_die_start; }
            set { hit_die_start = value; }
        }

        public int Hit_die_end
        {
            get { return hit_die_end; }
            set { hit_die_end = value; }
        }

        public System.Drawing.Point Die_text_point
        {
            get { return die_text_point; }
            set { die_text_point = value; }
        }

        public int Point_X
        {
            get { return die_text_point.X; }
            set { die_text_point.X = value; }
        }

        public int Point_Y
        {
            get { return die_text_point.Y; }
            set { die_text_point.Y = value; }
        }

        public int Mod_damage_all
        {
            get { return mod_damage_all; }
            set { mod_damage_all = value; }
        }

        public int Mod_damage_two_hand
        {
            get { return mod_damage_two_hand; }
            set { mod_damage_two_hand = value; }
        }

        public int Curr_mod_damage_all
        {
            get 
            {
                if (status == "WOUNDED" || status == "DESTROYED")
                    return mod_damage_all;
                else
                    return 0;
            }
        }

        public int Curr_mod_damage_two_hand
        {
            get
            {
                if (status == "WOUNDED" || status == "DESTROYED")
                    return mod_damage_two_hand;
                else
                    return 0;
            }
        }

        public string Armoured
        {
            get { return armoured; }
            set { armoured = value; }
        }

        public List<Armour_part> Armour_parts
        {
            get { return amps; }
            set { amps = value; }
        }

        public List<System.Drawing.Point> Draw_points
        {
            get { return draw_points; }
            set { draw_points = value; }
        }

        public int Total_abs { get { return get_total_abs(); } }


        public Body_part() { }

        public Body_part(string i_name, string i_status) 
        {
            name = i_name;
            status = validate_status(i_status);
            armoured = "NO";
        }
        
        /// <summary>
        /// Checks that the status being applied is a valid one
        /// </summary>
        /// <param name="i_status"></param>
        /// <returns></returns>
        private string validate_status(string i_status)
        {
            if (i_status == "OK" || i_status == "WOUNDED" || i_status == "DESTROYED")
                return i_status;
            else
                return "UNKNOWN";
        }

        public void add_armour_part(Armour_part ap)
        {  
            if (amps == null)
                amps = new List<Armour_part>();

            amps.Add(ap);
            armoured = "YES";
        }

        private int get_total_abs()
        {
            int total_abs = 0;

            if (armoured == "YES")
            {
                foreach (Armour_part ap in amps)
                {
                    total_abs += ap.Absorption_value;
                }
            }

            return total_abs;
        }
    }
}
