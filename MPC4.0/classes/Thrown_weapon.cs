using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;

namespace MPC4.classes
{
    public class Thrown_weapon : Weapon
    {
        int penetration;

        public int Penetration
        {
            get { return penetration; }
            set { penetration = value; }
        }

        public Thrown_weapon() : base() { }

        public override ListDictionary get_stat_summary_list()
        {
            ListDictionary list_descrip = new ListDictionary();


            list_descrip.Add("Initiativ", initiative);
            list_descrip.Add("Sekundärt initiativ", secondary_initiative);
            list_descrip.Add("Fattning", grip);
            list_descrip.Add("Tål", Convert.ToString(hardness));
            list_descrip.Add("Vikt", Convert.ToString(weight));
            list_descrip.Add("Närstridsskada", Melee_damage);
            list_descrip.Add("Kaliber", Calibre);
            list_descrip.Add("Pål", reliability);
            list_descrip.Add("Räckvidd", range);
            list_descrip.Add("Eldhastighet", Convert.ToString(fire_rate_single));
            list_descrip.Add("Avståndsskada", single_fire_damage);
            list_descrip.Add("Penetration", penetration);
            list_descrip.Add("Beskrivning", Description);


            return list_descrip;
        }

    }
}
