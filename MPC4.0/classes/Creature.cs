using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MPC4.classes
{
    public class Creature
    {
        #region Declarations

        private string name;
        private string class_type;
        private int sty_base;
        private int fys_base;
        private int sto_base;
        private int smi_base;
        private int int_base;
        private int vil_base;
        private int per_base;

        private int initiative_bonus;
        private int reaction_value;
        private int status;
        private int reputation;
        private int carry_capacity;
        private string damage_die;
        private int movement_walk;
        private int movement_run;
        private int movement_sprint;
        private int body_points;
        private int trauma_treshold;
        private string general_health;
        private int death_count = -1; //-1 is deafult for not active
        protected int tot_dmg_pen_all;
        protected int tot_dmg_pen_two_handed;
        protected int unconsious_count;
        private int mental_resonans; // PSI specific to start with but actually valid for all creatures (psychotic attacks etc)

        private List<Special_ability> special_abilities;
        private List<Skill> skills;
        private Body_modle body;
        private List<Equipment> equipment;

        private string image_path;

        private int temp_body_points;

        private int clone_index;
        private string template_path;

        private int total_move_mod_armour;
        private int total_vision_mod_armour;

        private int base_initiative;
        private List<Initiative_item> initiative_list = new List<Initiative_item>();
        private int round_actions_taken;
        private int action_initiative_mod;
        private int action_skill_mod_total;

        #endregion

        #region Properties
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Class_type
        {
            get { return class_type; }
            set { class_type = value; }
        }

        public int Sty_base
        {
            get { return sty_base; }
            set { sty_base = value; }
        }

        public int Fys_base
        {
            get { return fys_base; }
            set { fys_base = value; }
        }

        public int Sto_base
        {
            get { return sto_base; }
            set { sto_base = value; }
        }

        public int Smi_base
        {
            get { return smi_base; }
            set { smi_base = value; }
        }
        
        public int Int_base
        {
            get { return int_base; }
            set { int_base = value; }
        }
        
        public int Vil_base
        {
            get { return vil_base; }
            set { vil_base = value; }
        }
        
        public int Per_base
        {
            get { return per_base; }
            set { per_base = value; }
        }

        public int Initiative_bonus 
        { 
            get { return initiative_bonus; }
            set { initiative_bonus = value; }
        }
        public int Reaction_value { get { return reaction_value; } }
        
        public int Status
        {
            get { return status; }
            set { status = value; }
        }

        public int Reputation
        {
            get { return reputation; }
            set { reputation = value; }
        }

        public int Carry_capacity { get { return carry_capacity; } }

        public string Damage_die
        {
            get { return damage_die; }
            set { damage_die = value; }
        }

        public int Movement_walk { get { return movement_walk; } }
        public int Movement_run { get { return movement_run; } }
        public int Movement_sprint { get { return movement_sprint; } }

        public int Body_points 
        { 
            get { return body_points; }
            set { body_points = value; }  
        }

        public int Trauma_treshold { get { return trauma_treshold; } }

        public List<Special_ability> Special_abilities 
        { 
            get { return special_abilities; }
            set { special_abilities = value; }
        }

        public Body_modle Body
        {
            get { return body; }
            set { body = value; }
        }

        public List<Skill> Skills
        {
            get { return skills; }
            set { skills = value; }
        }

        public List<Equipment> Equipment
        {
            get { return equipment; }
            set { equipment = value; }
        }

        /// <summary>
        /// Gets all weapons the creature is currently packing
        /// </summary>
        public List<Weapon> Weapons
        {
            get
            {
                List<Weapon> rw = new List<Weapon>();
                List<Equipment> eql;

                eql = equipment.FindAll(o => o.Equipment_type.ToUpper().EndsWith("_WEAPON"));
                
                foreach (Equipment eq in eql)
                {
                    rw.Add((Weapon)eq);
                }

                return rw;             
            }
        }

        public string Image_path
        {
            get { return image_path; }
            set { image_path = value; }
        }

        public System.Drawing.Image Image_instance
        {
            get {return System.Drawing.Image.FromFile(Path_util.check_game_image_path(image_path));}
        }

        public int Temp_body_points
        {
            get { return temp_body_points; }
            set { temp_body_points = value; }
        }

        /// <summary>
        /// Only for Encounter use where the indexing is important
        /// </summary>
        public int Clone_index
        {
            get { return clone_index; }
            set { clone_index = value; }
        }

        //For being able to clone a creature from source
        public string Template_path
        {
            get { return template_path; }
            set { template_path = value; }
        }

        public string General_health
        {
            get { return general_health; }
            set { general_health = value; }
        }

        public int Total_damage_penalty_all
        {
            get { return tot_dmg_pen_all; }
        }

        public int Total_damage_penalty_two_handed
        {
            get { return tot_dmg_pen_two_handed; }
        }
        
        public string Death_count 
        {
            set {
                    death_count = Parse_utils.try_parse(value); }
            get {
                if (death_count > -1)
                    return Convert.ToString(death_count);
                else
                    return "-";
                    
                } 
        }

        public int Unconsious_count 
        {
            set { unconsious_count = value; }
            get { return unconsious_count; } 
        }

        public int Mental_resonans
        {
            get { return mental_resonans; }
            set { mental_resonans = value; }
        }

        public string Mental_health
        {
            get {
                if (unconsious_count == -1 || unconsious_count > 0)
                {
                    if (unconsious_count == -1)
                        return "UNCONCIOUS";
                    else
                        return "UNCONCIOUS (" + Convert.ToString(unconsious_count) + ")";
                }
                else
                    return "OK";
                }
        }

        public int Total_move_mod_armour
        {
            get { return total_move_mod_armour; }
            set { total_move_mod_armour = value; }
        }

        public int Total_vision_mod_armour
        {
            get { return total_vision_mod_armour; }
            set { total_vision_mod_armour = value; }
        }


        protected List<Resonans_effect> resonans_effects = new List<Resonans_effect>();

        /// <summary>
        /// Mostly for PSI characters, but people and robots can also get different types of resonans effects.
        /// </summary>
        public List<Resonans_effect> Resonans_effects
        {
            get { return resonans_effects; }
            set { resonans_effects = value; }
        }

        public int Base_initiative
        {
            get { return base_initiative; }
            set { base_initiative = value; }
        }

        public List<Initiative_item> Initiative_list
        {
            get { return initiative_list; }
            set { initiative_list = value; }
        }

        public int Round_actions_taken
        {
            get { return round_actions_taken; }
            set { round_actions_taken = value; }
        }

        public int Action_initiative_mod
        {
            get { return action_initiative_mod; }
            set { action_initiative_mod = value; }
        }

        public int Action_skill_mod_total
        {
            get { return action_skill_mod_total; }
            set { action_skill_mod_total = value; }
        }

        #endregion


        #region Constructors

        public Creature()
        { }

        public Creature(string i_name, int i_sty, int i_fys, int i_sto, int i_smi, int i_int, int i_vil, int i_per)
        {
            name = i_name;
            sty_base = i_sty;
            fys_base = i_fys;
            sto_base = i_sto;
            smi_base = i_smi;
            int_base = i_int;
            vil_base = i_vil;
            per_base = i_per;

            general_health = "OK";

        }


        #endregion

        #region Base calculations

        public void calculate_from_base_values()
        {
            initiative_bonus = calculate_intitative_bonus(smi_base);
            reaction_value = calculate_reaction_value(per_base);
            carry_capacity = calculate_carry_capacity(sty_base);
            calculate_damage_bonus(sty_base, sto_base);
            calculate_movement(smi_base, sto_base, ref movement_walk, ref movement_run, ref movement_sprint);
            body_points = calculate_body_points(fys_base, sto_base);
            temp_body_points = body_points;
            trauma_treshold = calculate_trauma_treshold(body_points);

        }

        private int calculate_intitative_bonus(int i_smi)
        {
            return i_smi;
        }

        private int calculate_reaction_value(int i_per)
        {
            return i_per * 5;
        }

        private int calculate_carry_capacity(int i_sty)
        {
            return i_sty;
        }

        private void calculate_damage_bonus(int i_sty, int i_sto)
        {
            int calc_val;
            int dmg_value = i_sty + i_sto;

            if (dmg_value <= 6) 
            {
                damage_die = "-2T4";
            }
            else if (dmg_value <= 10)
            {
                damage_die = "-1T6";
            }
            else if (dmg_value <= 14)
            {
                damage_die = "-1T4";
            }
            else if (dmg_value <= 16)
            {
                damage_die = "-1T3";
            }
            else if (dmg_value <= 18)
            {
                damage_die = "-1T2";
            }
            else if (dmg_value <= 20)
            {
                damage_die = "-1";
            }
            else if (dmg_value <= 23)
            {
                damage_die = "0";
            }
            else if (dmg_value <= 25)
            {
                damage_die = "1";
            }
            else if (dmg_value <= 27)
            {
                damage_die = "1T2";
            }
            else if (dmg_value <= 29)
            {
                damage_die = "1T3";            
            }
            else if (dmg_value <= 33)
            {
                damage_die = "1T4";
            }
            else if (dmg_value <= 37)
            {
                damage_die = "1T6";
            }
            else if (dmg_value <= 45)
            {
                damage_die = "2T4";
            }
            else 
            {   //from now on all goes in intervals of 12 so we can calculate with a formula of /12
                calc_val = (int)(dmg_value - 46) / 12;

                damage_die = Convert.ToString(2+calc_val)+"T6";
            }

        }

        private void calculate_movement(int i_smi, int i_sto, ref int i_walk, ref int i_run, ref int i_sprint)
        {   //on a non whole value the result will be truncated since we insert into an int, this is correct behaviour.
            i_walk = (i_smi + i_sto) / 5;
            i_run = i_smi + i_sto;
            i_sprint = (i_smi + i_sto) * 2;
        }

        private int calculate_body_points(int i_fys, int i_sto)
        {
            return i_fys + i_sto;
        }

        private int calculate_trauma_treshold(int i_body_points)
        {   //truncates non whole values as it should.
            return i_body_points / 2;
        }

        #endregion

        #region Damage and healing

        public virtual void apply_damage(string part_name, int damage, int penetration)
        {
            if (damage < 0) return;  //If no damage then no use calculating
            
            Damage_handler dmg_hand = new Damage_handler();
            penetration = dmg_hand.check_penetration(penetration);
            
            if (Convert.ToString(part_name) == "ALL") //General damage, bypassing all armour (poison etc...)
            {
                temp_body_points = temp_body_points - damage;
                general_health = dmg_hand.set_general_health(class_type, general_health, temp_body_points, fys_base, body_points);
            }
            else // specific area damage, needs armour inclusion
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
                temp_body_points = temp_body_points - final_damage; //set new body point stat values
                general_health = dmg_hand.set_general_health(class_type, general_health, temp_body_points, fys_base, body_points); //find out how the person is generally fairing

                if (general_health == "DEAD") //if dead, well bye bye
                    return;
                else //otherwise check how the body part is fairing
                {
                    //Look if its a mortal wound
                    if (final_damage > (trauma_treshold * 2))
                    {
                        bp.Status = "DESTROYED";
                        general_health = dmg_hand.set_general_health_body_part_hit(class_type, bp.Part_type, "MORTAL");
                        death_count = dmg_hand.set_mortal_death_count(class_type, bp.Part_type, fys_base, death_count);
                    }
                    else if (final_damage > trauma_treshold) //Check if its a critical wound
                    {
                        bp.Status = "WOUNDED";
                        general_health = dmg_hand.set_general_health_body_part_hit(class_type, bp.Part_type, "CRITICAL");
                        death_count = dmg_hand.set_critical_death_count(class_type, bp.Part_type, fys_base, death_count, temp_body_points);
                        unconsious_count = dmg_hand.set_unconsciousness_count(fys_base); //TODO:Check if other than head hit renders unconcious

                    }

                    if ( temp_body_points < 0)
                        unconsious_count = -1; //If below zero then unconscious until on 0

                    calculate_total_damage_penalty();
                }
            }
        }

        protected virtual void calculate_total_damage_penalty()
        {
            tot_dmg_pen_all = 0;
            tot_dmg_pen_two_handed = 0;

            foreach (Body_part bp in Body.Body_parts)
            {
                tot_dmg_pen_all += bp.Curr_mod_damage_all;
                tot_dmg_pen_two_handed += bp.Curr_mod_damage_two_hand;
            }
        }
        
        public void heal_damage(int heal_value)
        {
            if (heal_value < 0)
                return;

            temp_body_points += heal_value;

            if (temp_body_points > body_points)
                temp_body_points = body_points;

            if (temp_body_points > 0 && unconsious_count == -1)
                unconsious_count = 0;
        }

        private void bleed()
        {
            if (general_health == "BLEEDING")
            {
                death_count -= 1;

                if (death_count == 0)
                    general_health = "DEAD";
            }
        }

        private void count_down_consiousnes()
        {
            if (unconsious_count > 0)
                unconsious_count -= 1;
        }

        private void reset_action_mod()
        {
            round_actions_taken = 0;
            action_initiative_mod = 0;
            action_skill_mod_total = 0;
        }

        public void calculate_round_data()
        {
            bleed();
            count_down_consiousnes();
            reset_action_mod();
        }

        public void stop_bleeding()
        {
            death_count = -1;

            if (temp_body_points < 0)
            {
                general_health = "DOWN";
                unconsious_count = -1; // A down person, stays unconcious until he reach + in body points
            }
            else
                general_health = "OK";
        }

        public void mend_body_part(string part_name)
        {
            Body_part bp = Body.Body_parts.Find(o => o.Name == part_name);

            if(bp !=null)
                bp.Status = "OK";
        }

        public void wake_up()
        {
            unconsious_count = 0;
        }

        public void knock_out(int rounds)
        {
            if (rounds > 0)
                unconsious_count = rounds;
            else
                unconsious_count = -1;
        }


        #endregion

        #region Misc

        public void randomize_attributes()
        { 
            Random rand = new Random(DateTime.Now.Millisecond);

            sty_base = rand.Next(1, 7) + rand.Next(1, 7) + rand.Next(1, 7);
            fys_base = rand.Next(1, 7) + rand.Next(1, 7) + rand.Next(1, 7);
            sto_base = rand.Next(1, 7) + rand.Next(1, 7) + rand.Next(1, 7);
            smi_base = rand.Next(1, 7) + rand.Next(1, 7) + rand.Next(1, 7);
            int_base = rand.Next(1, 7) + rand.Next(1, 7) + rand.Next(1, 7);
            vil_base = rand.Next(1, 7) + rand.Next(1, 7) + rand.Next(1, 7);
            per_base = rand.Next(1, 7) + rand.Next(1, 7) + rand.Next(1, 7);
        }

        public void initiate_skill_base_values()
        {
            foreach (Skill sk in skills)
            { 
                switch (sk.Skill_base_attribute)
                {
                    case "SMI" :
                        sk.Skill_value = smi_base;
                        break;
                    case "INT" :
                        sk.Skill_value = int_base;
                        break;
                    case "STY" :
                        sk.Skill_value = sty_base;
                        break;
                    case "FYS" :
                        sk.Skill_value = fys_base;
                        break;
                    case "STO" :
                        sk.Skill_value = sto_base;
                        break;
                    case "VIL" :
                        sk.Skill_value = vil_base;
                        break;
                    case "PER" :
                        sk.Skill_value = per_base;
                        break;
                }
            }
        }

        public Skill_result skill_check(string skill, int misc_modifier)
        {
            set_action_mod_increase();
            Random rand = new Random(DateTime.Now.Millisecond);
            int die_roll = rand.Next(1, 100);

            return check_skill(skill, die_roll, misc_modifier);
        }

        public virtual Skill_result check_skill(string skill_name,int die_roll, int modifier)
        {
            Skill sk = skills.Find(o => o.Name.ToUpper() == skill_name.ToUpper());
            return sk.check_skill_roll(die_roll,modifier);
        }

        public void calculate_total_armour_mod()
        {
            foreach (Body_part bp in body.Body_parts)
            {
                if (bp.Armoured == "YES")
                {
                    foreach (Armour_part ap in bp.Armour_parts)
                    {
                        if (bp.Part_type == "HEAD")
                            Total_vision_mod_armour += ap.Limitation_value;
                        else
                            Total_move_mod_armour += ap.Limitation_value;
                    }
                }
            }   
        }


        public void calculate_base_initiative(ref Random rand)
        {
            int die_roll = rand.Next(1, 10);
            base_initiative = die_roll + initiative_bonus;
        }

        /// <summary>
        /// Calculates the current initiatives the creature has. 
        /// This is based on its base_initiative given earlier and earlier actions as well as weaponry and in which hand the creature is holding a weapon.
        /// </summary>
        public void calculate_round_initiative()
        {
            initiative_list = new List<Initiative_item>(); //Make sure we have a fresh list
            int base_init = base_initiative + action_initiative_mod;

            //Add one item per held weapon / per possible attack
            foreach(Weapon wp in Weapons) //TODO: Test that secondary and primary initiatives work as expected
            {
                if (wp.Held_by_main_hand == "Y") //Holding in the correct hand gives normal bonuses/penalties
                {   
                    if(wp.In_secondary_use =="Y") //Secondary use = pistolwhipping with a pistol etc
                        initiative_list.Add(new Initiative_item(base_init + wp.Secondary_initiative, wp.Name));
                    else
                        initiative_list.Add(new Initiative_item(base_init + wp.Initiative, wp.Name));
                }
                else if (wp.Held_by_secondary_hand == "Y") //Holding a weapon in the wrong hand makes a init minus
                {
                    if (wp.In_secondary_use == "Y")
                        initiative_list.Add(new Initiative_item(base_init + wp.Secondary_initiative - 5, wp.Name)); 
                    else
                        initiative_list.Add(new Initiative_item(base_init + wp.Initiative - 5, wp.Name)); 
                }
            }
        }

        /// <summary>
        /// Increases the amounts of actions taken by the creature by one. Meaning: actions taken +1, initiative mod -5 and skill mod -25
        /// </summary>
        public void set_action_mod_increase()
        {
            Round_actions_taken += 1;

            Action_initiative_mod = (-5) * Round_actions_taken;
            action_skill_mod_total = (-25) * Round_actions_taken;
        }

        public string get_current_initiative_weapon(int curr_init)
        {
            if (initiative_list.Exists(a => a.Initiative == curr_init))
            {
                string weapon_name = initiative_list.Find(a => a.Initiative == curr_init).Weapon_name;
                
                re_arrange_equipment(weapon_name);

                return weapon_name;
            }
            else
                return "-";
        }

        #endregion

        /// <summary>
        /// Re-arranges the equipment list putting any equipment with the given name at the top.
        /// </summary>
        /// <param name="equip_name"></param>
        private void re_arrange_equipment(string equip_name)
        {
            List<Equipment> eq_1 = new List<Equipment>();
            List<Equipment> eq_2 = new List<Equipment>();

            foreach(Equipment eq_base in equipment )
            {
                if (eq_base.Name == equip_name)
                    eq_1.Add(eq_base);
                else
                    eq_2.Add(eq_base);            
            }

            eq_1.AddRange(eq_2);
            equipment = eq_1;
        }

    }
}
