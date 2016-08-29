using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPC4.classes
{
    public class Psi : Creature
    {

        public Psi() { }
        public Psi(string i_name, int i_sty, int i_fys, int i_sto, int i_smi, int i_int, int i_vil, int i_per)
            : base(i_name, i_sty, i_fys, i_sto, i_smi, i_int, i_vil, i_per)
        { }

        public override Skill_result check_skill(string skill_name, int die_roll, int modifier)
        {
            Skill sk = Skills.Find(o => o.Name.ToUpper() == skill_name.ToUpper());
            Skill_result sr = sk.check_skill_roll(die_roll, modifier);

            if (sr.Result == "FAIL" || sr.Result == "FUMBLE")
            {
                Mental_resonans += 1;
                check_resonas_effect(Mental_resonans);
            }
            
            return sr; 
        }

        /// <summary>
        /// Special for PSI characters. They risk suffering immediate resonans effects on a failed/fumbled skill roll 
        /// </summary>
        private void check_resonas_effect( int mental_res)
        {
            Random rand = new Random(DateTime.Now.Millisecond);
            int situational_resonans = Vil_base - (mental_res + rand.Next(1, 10));

            if (situational_resonans < 0)
            {
                Resonans_repository respos = new Resonans_repository();
                Resonans_effect res = respos.get_resonans_effect_by_val(situational_resonans);

                if (res != null)
                    resonans_effects.Add(res);
            
            }
        }

    }
}
