using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace MPC4.classes
{
    public class Robot : Creature
    {
     
        private int sensor_load;

        public Robot() { }
        public Robot(string i_name, int i_sty, int i_fys, int i_sto, int i_smi, int i_int, int i_vil, int i_per) : base(i_name, i_sty, i_fys, i_sto, i_smi, i_int, i_vil, i_per)
        {}

        public override void apply_damage(string part_name, int damage, int penetration)
        {
            if (damage < 0) return;  //If no damage then no use calculating

            string derived_bp_health="OK";
            Damage_handler dmg_hand = new Damage_handler();
            penetration = dmg_hand.check_penetration(penetration);

            if (Convert.ToString(part_name) == "ALL") //General damage, bypassing all armour (poisons etc...)
            {
                Temp_body_points = Temp_body_points - damage;
            }
            else
            {
                int final_damage = 0;
                int total_abs = 0;
                Body_part bp = Body.Body_parts.Find(o => o.Name == part_name);

                if (bp == null) //If no body part match then no damage.
                    return;

                if (bp.Armoured == "YES") //Get the total armour value for the body part
                {
                    foreach (Armour_part ap in bp.Armour_parts)
                        total_abs += ap.Absorption_value;
                }

                final_damage = dmg_hand.calculate_damage(total_abs, penetration, damage); //calculate the modified damage depending on armour and penetration
                Temp_body_points = Temp_body_points - final_damage; //set new body point stat values


                if (final_damage > (Trauma_treshold * 2))
                {
                    bp.Status = "DESTROYED";
                    derived_bp_health = set_robot_general_health_bp_hit(bp.Part_type, "MORTAL");
                }
                else if (final_damage > Trauma_treshold) //Check if its a critical wound
                {
                    bp.Status = "WOUNDED";
                    derived_bp_health = set_robot_general_health_bp_hit(bp.Part_type, "CRITICAL");
                    unconsious_count = dmg_hand.set_unconsciousness_count(Fys_base);

                }
                calculate_total_damage_penalty();
            }

            calculate_sensor_load(Temp_body_points, Body_points);
            General_health = set_robot_general_health(Temp_body_points, derived_bp_health);
            calculate_total_damage_penalty();
        }
        protected override void calculate_total_damage_penalty()
        {
            tot_dmg_pen_all = sensor_load;
            tot_dmg_pen_two_handed = sensor_load;
        }


        private void calculate_sensor_load(int body_points, int kp_base)
        { 
            if (body_points <= 0)
            {
                int times = (System.Math.Abs(body_points) / kp_base) + 1;
                sensor_load = - 25 * times;
            }
            else
                sensor_load = 0;        
        }

        public string set_robot_general_health(int temp_body_points, string derived_bp_health)
        {
            //If hes dead already or becomes dead from head shot, then always stay dead.
            if (General_health == "DEAD" || derived_bp_health =="DEAD")
                return "DEAD";

            //if derived health or general health is helpless then return HELPLESS
            if (derived_bp_health == "HELPLESS" || General_health =="HELPLESS")
                return "HELPLESS";

            //if derived health or general health is imobilized then return imobilized
            if (derived_bp_health == "IMOBILIZED" || General_health == "IMOBILIZED")
                return "IMOBILIZED";

            if (Temp_body_points <= 0)
                return "SENSOR_OVERLOAD";

            //in all other cases return OK
            return "OK";
        }

        public string set_robot_general_health_bp_hit(string part_type, string hit_type)
        {
            string bp_derived_health = "";

            if (hit_type == "MORTAL")
            {
                if (part_type == "HEAD" || part_type == "TORSO")
                    bp_derived_health = "DEAD";
                else
                    bp_derived_health = "OK";
            }
            else if (hit_type == "CRITICAL")
            {
                if (part_type == "HEAD")
                    bp_derived_health = "HELPLESS";
                else if (part_type == "TORSO")
                    bp_derived_health = "IMOBILIZED";
                else
                    bp_derived_health = "OK";
            }

            return bp_derived_health;
        }
    }
}
