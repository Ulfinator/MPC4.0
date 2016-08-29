using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MPC4.classes;

namespace MPC4.classes
{
    public class Ability_lister
    {
        private List<Special_ability> specials;

        public List<Special_ability> Special_abilities
        {
            get { return specials; }
            set { specials = value; }
        }
    }
}
