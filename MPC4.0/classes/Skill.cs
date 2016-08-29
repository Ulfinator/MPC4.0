using System;
using System.Collections.Generic;
using System.Text;

namespace MPC4.classes
{
    public class Skill
    {
        string name;
        int skill_value;
        string skill_base_attribute;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        
        public int Skill_value
        {
            get { return skill_value; }
            set { skill_value = value; }
        }

        public string Skill_base_attribute
        {
            get { return skill_base_attribute; }
            set { skill_base_attribute = value; }
        }

        public Skill() { }

        public Skill(string i_name, int i_skill,string i_base_attribute) 
        { 
            name = i_name;
            skill_value = i_skill;
            skill_base_attribute = i_base_attribute;
        }


        public Skill_result check_skill_roll(int die_roll, int skill_modification)
        {
            Skill_result sr = new Skill_result();

            sr.Die_value = die_roll;
            sr.Modified_skill_value = skill_value + skill_modification;
            sr.Skill_die_diff = sr.Modified_skill_value - sr.Die_value;

            if (sr.Die_value == 100)
                sr.Result = "FUMBLE";
            else if (sr.Die_value <= sr.Modified_skill_value)
                if (sr.Die_value <= (sr.Modified_skill_value / 10))
                    sr.Result = "PERFECT";
                else
                    sr.Result = "SUCCESS";
            else
                sr.Result = "FAIL";

            return sr;
        }


    }
}
