using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MPC4.classes
{
    /// <summary>
    /// This class takes care of all calculations connected to creatures and things recieving damage. 
    /// It handles Penetration, ABS and damage. 
    /// </summary>
    public class Damage_handler
    {
        #region Penetration calculation

        /// <summary>
        /// Checks the send in value and assigns 0 if the value is negative.
        /// </summary>
        /// <param name="pen"></param>
        /// <returns></returns>
        public int check_penetration(int pen)
        {
            return pen >= 0 ? pen : 0;
        }

        #endregion 

        #region Absorption

        /// <summary>
        /// Absorption is dependant on the penetration value of the hit. If the penetration value
        /// is larger than the absorption value then absorption goes down to zero.
        /// </summary>
        /// <param name="abs"></param>
        /// <param name="pen"></param>
        /// <returns></returns>
        public int abs_minus_penetration(int abs, int pen)
        {
            int temp_abs = abs - pen;
            return temp_abs >= 0 ? temp_abs : 0;
        }

        #endregion

        #region damage_calculation

        public int calculate_damage(int abs, int pen, int damage)
        {
            int temp_abs = abs_minus_penetration(abs,pen);

            if (temp_abs < damage)
                return damage - temp_abs;
            else
                return 0;
        }

        public int calculate_damage(string dmg_die)
        {
            int dmg = 0;
            Random rand = new Random(DateTime.Now.Millisecond);
            int die_nr;
            int die_sides = 0;
            string[] t_split;
            string[] plus_split = null;

            Regex reg = new Regex("T");
            t_split = reg.Split(dmg_die); //split on T to get number of dies and die sides + possible + value

            die_nr = Convert.ToInt32(t_split[0]);

            if (t_split[1].Contains("+")) //if we got a + modifier we need to separate it from the die sides
            {
                Regex reg2 = new Regex(@"\+");
                plus_split = reg2.Split(t_split[1]);
                die_sides = Convert.ToInt32(plus_split[0]);
            }
            else //otherwise we just get the die sides
                die_sides = Convert.ToInt32(t_split[1]);

            for (int i = 0; i < die_nr; i++)
            {
                dmg += rand.Next(1, die_sides);
            }

            if (plus_split != null)
                dmg += Convert.ToInt32(plus_split[1]);

            return dmg;
        }

        #endregion

        #region status_methods
        
        /// <summary>
        /// Facade for all general health setting 
        /// </summary>
        public string set_general_health(string class_type, string general_health, int body_points, int fys_base, int kp_base)
        {
            if (class_type == "RBT")
            {
                general_health = set_robot_general_health(body_points,kp_base);    
            }
            else
            {
                general_health = set_default_general_health(general_health, body_points, fys_base);                    
            }
            return general_health;
        }

        public string set_robot_general_health(int body_points, int kp_base)
        {
            if (body_points <= 0)
            {
                int times = (System.Math.Abs(body_points) / kp_base)+1;
                return "SENSOR_OVERLOAD_" + Convert.ToString(25*times);
            }
            
            return "OK";
        }

        public string set_default_general_health(string general_health, int body_points, int fys_base)
        {
            if (body_points < 0 && System.Math.Abs(body_points) > fys_base)
                general_health = "DEAD";

            return general_health;
        }

        public string set_general_health_body_part_hit(string class_type, string part_type, string hit_type)
        {
            string general_health;

            general_health = set_default_general_health_bp_hit(part_type, hit_type);

            return general_health;
        }



        public string set_default_general_health_bp_hit(string part_type, string hit_type)
        {
            string general_health = "";

            if (hit_type == "MORTAL")
            {
                if (part_type == "HEAD")
                    general_health = "DEAD";
                else
                    general_health = "BLEEDING";
            }
            else if (hit_type == "CRITICAL")
            {
                general_health = "BLEEDING";
            }

            return general_health;
        }
        #endregion

        #region count setters

        public int set_mortal_death_count(string class_type, string part_type, int fys_base, int death_count)
        {
            if (class_type != "RBT") //robots do not bleed
            {
                if (part_type == "HEAD")
                    death_count = -1; //It's dead, no more counting
                else if (part_type == "TORSO")
                {
                    if (death_count == -1 || death_count > fys_base)
                        death_count = fys_base;                
                }
                else
                {
                    if (death_count == -1 || death_count > fys_base)
                        death_count = fys_base * 12;
                }
            }

            return death_count;
        }

        public int set_critical_death_count(string class_type, string part_type, int fys_base, int death_count, int temp_body_points)
        {
            if (class_type != "RBT") //robots do not bleed
            {
                int temp_death = (temp_body_points + fys_base) * 12;
                
                if (death_count == -1 || death_count > temp_death) 
                    death_count = temp_death;
            }

            return death_count;
        }

        public int set_unconsciousness_count(int fys_base)
        {
            if (fys_base >= 30)
                return 1;
            else
                return 30 - fys_base;
        }

        
        #endregion

    }
}
