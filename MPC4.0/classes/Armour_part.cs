using System;
using System.Collections.Generic;
using System.Text;

namespace MPC4.classes
{
    public class Armour_part
    {
        string name;
        string part_cover;
        string type;
        int absorption_value;
        int limitation_value;
        string limitation_area;
        string status;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Part_cover
        {
            get { return part_cover; }
            set { part_cover = value; }
        }  
      
        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        
        public int Absorption_value
        {
            get { return absorption_value; }
            set { absorption_value = value; }
        }
        
        public int Limitation_value
        {
            get { return limitation_value; }
            set { limitation_value = value; }
        }
        
        public string Limitation_area
        {
            get { return limitation_area; }
            set { limitation_area = validate_limitation_area(value); }
        }

        public string Status
        {
            get { return status; }
            set { status = validate_status(value); }
        }

        public Armour_part() { }

        public Armour_part(string i_name, string i_part_cover, string i_type, int i_abs, int i_limit_val, string i_limit_area, string i_status) 
        {
            name = i_name;
            part_cover = i_part_cover;
            type = i_type;
            absorption_value = i_abs;
            limitation_value = i_limit_val;
            limitation_area = validate_limitation_area(i_limit_area);
            status = validate_status(i_status);
        }

        private string validate_status(string i_status)
        {
            if (i_status == "OK" || i_status == "DAMAGED")
                return i_status;
            else
                return "UNKNOWN";
        }

        private string validate_limitation_area(string i_part)
        {
            if (i_part == "VISION" || i_part == "MOVEMENT")
                return i_part;
            else
                return "UNKNOWN";    
        }
    }
}
