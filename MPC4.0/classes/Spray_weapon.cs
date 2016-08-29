using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Collections;
using System.Text;
using System.Text.RegularExpressions;

namespace MPC4.classes
{
    public class Spray_weapon : Weapon
    {
        ListDictionary range_damage = new ListDictionary();

        public ListDictionary Range_damage
        {
            get { return range_damage; }
            set { range_damage = value; }
        }

        public Spray_weapon() : base()
        { }


        public override Weapon_result Fire_weapon(int skill_roll)
        {
            Weapon_result wr = new Weapon_result();
            
            ammo_check(ref wr);                 //Check if we got ammo left

            if (wr.Status == "OUT OF AMMO")
                return wr;

            reliability_check(skill_roll);      //Check that the weapon takes the pressure and set the status

            wr.Status = status;

            if (status == "JAMMED" || status == "BROKEN")
                return wr;

            spend_ammo(Selected_fire_rate);  //spend bullets based on fire_type

            wr.Damage = calculate_spray_damage();
            // randomize a hit area
            Random rand_area = new Random(DateTime.Now.Millisecond);
            wr.Area = rand_area.Next(1, 20);

            return wr;
        }

        private List<Damage> calculate_spray_damage()
        {
            List<Damage> dml = new List<Damage>();
            Regex reg = new Regex(@"" + slotted_shell_type + @"_\w+");
            Damage_handler dmgh = new Damage_handler();
            
            foreach (DictionaryEntry dic in range_damage)
            {
                if (reg.IsMatch(dic.Key.ToString()))
                {
                    dml.Add(new Damage(dic.Key.ToString(), dmgh.calculate_damage(dic.Value.ToString())));
                }
            }

            return dml;
        }

        public override ListDictionary get_stat_summary_list()
        {
            ListDictionary list_descrip = new ListDictionary();

            string burst = "";
            if (fire_rate_burst != 0)
                burst = "/" + Convert.ToString(fire_rate_burst);

            string dmg = "";
            if (burst_fire_damage != "")
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
            list_descrip.Add("Avståndsskada", "");

            foreach (DictionaryEntry dic in range_damage)
            {
                list_descrip.Add(dic.Key, dic.Value);
            }

            list_descrip.Add("Beskrivning", Description);

            return list_descrip;
        }

        public ListDictionary get_dictionary_by_shell_type(string sType)
        {
            ListDictionary retDic = new ListDictionary();
            Regex reg = new Regex(@""+sType.ToUpper() + "_");

            foreach (DictionaryEntry dic in range_damage)
            {
                if (reg.IsMatch(dic.Key.ToString()))
                    retDic.Add(dic.Key,dic.Value);
            }

            return retDic;
        }
    }
}
