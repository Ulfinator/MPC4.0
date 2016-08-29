using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace MPC4.classes
{
    public class Weapon : Equipment
    {
        protected string skill_range;         //färdighet för att avfyra kasta vapnet.
        protected string skill_melee;         //färdighet för att slåss med vapnet
        protected int fire_rate_single;       //eldhastighet singel
        protected int fire_rate_burst;        //eldh salva
        protected string grip;                //fattning
        protected int initiative;             //Det initiativ som speglar vapnets reguljära användning
        protected int secondary_initiative;   //Det initiativ som speglar en möjlig sekundär användning tex pistolwhip eller kolvning (melee med ett skjutvapen). Melee vapen har ingen secondary
        protected string calibre;             //Kaliber
        protected int reliability;            //pålitlighet
        protected int range;                  //räkvidd
        protected string single_fire_damage;  //skada om enkelskott
        protected string burst_fire_damage;   //skada om eldskur
        private string melee_damage;          //Skada om använd som närstridsvapen
        private string melee_damage_type;     //skadetyp om använd som närstridsvapen
        protected int hardness;               //Tålighet
        protected double weight;              //vikt
        protected string status;              //Vapnets status
        protected Magazine mag;               //magasin
        protected string mag_type;            // typ av magasin (INTEGRATED,LOOSE)
        protected int standard_mag;           //standard storlek för magasin till pistolen, Om integrerat är det den de facto storleken.
        protected string selected_fire_rate;  //typ av eldgivning (SINGLE,BURST)
        protected string slotted_shell_type;  //Typ av ammo, Kan vara REGULAR, DUMDUM, AP, HAIL, SLUG, FLECHETTE etc...
        int min_melee_strength;               // minsta styrka att använda i närstrid
        string held_by_main_hand;               // Om vapnet hålls i huvudhanden (initiativpåverkan)
        string held_by_secondary_hand;          // Om vapnet hålls i sekundärhanden (kan hållas i båda om gevär etc)
        string in_secondary_use;              // Om vapnet används på ett annat sätt än primäranvändningen

        public string Skill_range
        {
            get { return skill_range; }
            set { skill_range = value; }
        }

        public string Skill_melee
        {
            get { return skill_melee; }
            set { skill_melee = value; }
        }

        public int Fire_rate_single
        {
            get { return fire_rate_single; }
            set { fire_rate_single = value; }
        }

        public int Fire_rate_burst
        {
            get { return fire_rate_burst; }
            set { fire_rate_burst = value; }
        }

        public string Grip
        {
            get { return grip; }
            set { grip = value; }
        }

        public int Initiative
        {
            get { return initiative; }
            set { initiative = value; }
        }

        public int Secondary_initiative
        {
            get { return secondary_initiative; }
            set { secondary_initiative = value; }
        }

        public string Calibre
        {
            get { return calibre; }
            set { calibre = value; }
        }

        public int Reliability
        {
            get { return reliability; }
            set { reliability = value; }
        }

        public int Range
        {
            get { return range; }
            set { range = value; }
        }

        public string Single_fire_damage
        {
            get { return single_fire_damage; }
            set { single_fire_damage = value; }
        }

        public string Burst_fire_damage
        {
            get { return burst_fire_damage; }
            set { burst_fire_damage = value; }
        }

        public string Melee_damage
        {
            get { return melee_damage; }
            set { melee_damage = value; }
        }

        public string Melee_damage_type
        {
            get { return melee_damage_type; }
            set { melee_damage_type = value; }
        }


        public int Hardness
        {
            get { return hardness; }
            set { hardness = value; }
        }

        public double Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        public string Status
        {
            get
            {
                if (status == null) // Status ska aldrig kunna vara null. Är den inget så är den OK.
                    status = "OK";

                    return status; 
                }
            set { status = value; }
        }

        public Magazine Magazine
        {
            get { return mag; }
            set { mag = value; }
        }

        public string Mag_type
        {
            get { return mag_type; }
            set { mag_type = value; }
        }

        public int Standard_mag
        {
            get { return standard_mag; }
            set { standard_mag = value; }
        }

        public string Selected_fire_rate
        {
            get { //Testing
                if (selected_fire_rate != null)
                    return selected_fire_rate;
                else
                    return "SINGLE";
            }
            set { selected_fire_rate = value; }
        }

        public int Projectile_count
        {
            get
            {
                if (mag == null)
                    return 0;
                else
                    return mag.Projectiles_left;
            }
        }

        public List<string> Available_fire_rates
        {
            get{
                List<string> rates = new List<string>();

                if (fire_rate_single > 0)
                    rates.Add("SINGLE");

                if (fire_rate_burst > 0)
                    rates.Add("BURST");

                return rates;
            }
        }

        public string Slotted_shell_type
        {
            get { return slotted_shell_type; }
            set { slotted_shell_type = value; }
        }

        public int Min_melee_strength
        {
            get { return min_melee_strength; }
            set { min_melee_strength = value; }
        }

        public string Held_by_main_hand
        {
            get {
                if (held_by_main_hand == "Y" || held_by_main_hand == "N")
                    return held_by_main_hand;
                else
                {
                    held_by_main_hand = "N";
                    return held_by_main_hand;
                }
            }
            set {
                if (value == "Y")
                    held_by_main_hand = value;
                else
                    held_by_main_hand = "N";
                    }
        }

        public string Held_by_secondary_hand
        {
            get
            {
                if (held_by_secondary_hand == "Y" || held_by_secondary_hand == "N")
                    return held_by_secondary_hand;
                else
                {
                    held_by_secondary_hand = "N";
                    return held_by_secondary_hand;
                }
            }
            set
            {
                if (value == "Y")
                    held_by_secondary_hand = value;
                else
                    held_by_secondary_hand = "N";
            }
        }

        public string In_secondary_use
        {
            get { return in_secondary_use; }
            set { in_secondary_use = value; }
        }

        public Weapon()
        { }

        public virtual Weapon_result Fire_weapon(int skill_roll)
        {
            Damage_handler dmgh = new Damage_handler();
            Weapon_result wr = new Weapon_result();
            Damage dm = new Damage();

            ammo_check(ref wr);                 //Check if we got ammo left

            if (wr.Status == "OUT OF AMMO")
                return wr;

            reliability_check(skill_roll);      //Check that the weapon takes the pressure and set the status

            wr.Status = status; 

            if (status == "JAMMED" || status == "BROKEN")
                return wr;

            spend_ammo(Selected_fire_rate);  //spend bullets based on fire_type


            if (Selected_fire_rate == "SINGLE")
                dm.Damage_value = dmgh.calculate_damage(single_fire_damage);
            else if (Selected_fire_rate == "BURST")
                dm.Damage_value = dmgh.calculate_damage(burst_fire_damage);
         
   
            wr.Damage.Add(dm);
            // randomize a hit area
            Random rand_area = new Random(DateTime.Now.Millisecond);
            wr.Area = rand_area.Next(1, 20);

            return wr;
        }

        protected void ammo_check(ref Weapon_result wr)
        {
            if (Magazine == null || Magazine.Projectiles_left == 0)
                wr.Status = "OUT OF AMMO";            
        }

        protected void reliability_check(int die_roll)
        {
            //If already jammed or broken then no need to check again
            if (status == "JAMMED" || status == "BROKEN")
                return;

            //Check if gun jams
            if (die_roll <= reliability)
                status = "OK";
            else
                status = "JAMMED";

            //Check if gun breaks
            if (status == "JAMMED")
            {
                Random rand_jam = new Random(DateTime.Now.Millisecond);
                int break_roll = rand_jam.Next(1, 100);
                int rel_roll = rand_jam.Next(1, 10);

                break_check(break_roll, rel_roll);
            }
        }

        private void break_check(int break_roll, int rel_roll)
        {
            if (break_roll > reliability)
            {
                if (rel_roll == 10)
                    status = "BROKEN";
                else
                    reliability -= rel_roll;
            }
        }

        protected string spend_ammo(string fire_type)
        {
            string result_fire_type ="CLICK"; // if we are out of ammo it's a click

            if (fire_type.ToUpper() == "SINGLE")
            {
                if (mag.Projectiles_left > 0)
                {
                    result_fire_type = "SINGLE";
                    mag.spend_ammo(fire_rate_single);
                }
            }
            else if (fire_type.ToUpper() == "BURST")
            {
                if (mag.Projectiles_left > fire_rate_single) //if we got more than one bullet its ok for a burst
                {
                    result_fire_type = "BURST";
                    mag.spend_ammo(fire_rate_burst);                
                }
                else if (mag.Projectiles_left > 0) //if there is only one bullet, its a single fire
                {
                    result_fire_type = "SINGLE";
                    mag.spend_ammo(fire_rate_single);                
                }
            }

            return result_fire_type;
        }

        public void un_jam()
        {
            status = "OK";
        }

        public Weapon_result strike(int skill_role, string dmg_bonus)
        {
            Weapon_result wr = new Weapon_result();
            Damage dm = new Damage();
            int bonus_damage;
            int weapon_damage;

            if (status == "BROKEN")
            {
                wr.Status = "BROKEN";
                return wr;
            }

            wr.Status = "OK";

            weapon_damage = Die_service.throw_dies(melee_damage); ;

            if (dmg_bonus == "0")
                bonus_damage = 0;
            else if (dmg_bonus == "1")
                bonus_damage = 1;
            else if (dmg_bonus == "-1")
                bonus_damage = -1;
            else
                bonus_damage = Die_service.throw_dies(dmg_bonus); ;

            dm.Damage_value = weapon_damage + bonus_damage;

            if (dm.Damage_value < 0)
                dm.Damage_value = 0;

            dm.Damage_type = melee_damage_type;

            wr.Damage.Add(dm);

            Random rand_area = new Random(DateTime.Now.Millisecond);
            wr.Area = rand_area.Next(1, 20);

            return wr;
        }

        public int parry(int dmg, string dmg_type)
        {
            int ret_int = 0;

            if (dmg <= hardness)
                ret_int = 0;
            else if (dmg > hardness)
                ret_int = dmg - hardness;

            if (dmg_type.ToUpper() != "STICK") // stab weapons do not inflict damage to parrying weapons.
            {
                if (dmg > hardness * 2) // If the damage is double the hardness the weapon takes damage.
                    hardness -= Die_service.throw_dies("1T6");
            }

            if (hardness <= 0)
                status = "BROKEN";

            return ret_int;
        }

        public override ListDictionary get_stat_summary_list()
        {
            ListDictionary list_descrip = new ListDictionary();

            string burst="";
            if(fire_rate_burst !=0)
                burst = "/" + Convert.ToString(fire_rate_burst);

            string dmg = "";
            if (burst_fire_damage != "" && burst_fire_damage !=null)
                dmg = "/" + burst_fire_damage;


            list_descrip.Add("Initiativ", initiative);
            list_descrip.Add("Sekundärt initiativ", secondary_initiative);
            list_descrip.Add("Fattning", grip);
            list_descrip.Add("Tål", Convert.ToString(hardness));
            list_descrip.Add("Vikt", Convert.ToString(weight));
            list_descrip.Add("Närstridsskada", Melee_damage);
            list_descrip.Add("Kaliber", Calibre);
            list_descrip.Add("Pål", reliability);
            list_descrip.Add("Räckvidd", range);
            list_descrip.Add("Eldhastighet", Convert.ToString(fire_rate_single) + burst);
            list_descrip.Add("Avståndsskada", single_fire_damage + dmg);
            list_descrip.Add("Beskrivning", Description);

            return list_descrip;
        }
    }
}
