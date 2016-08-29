using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;

namespace MPC4.classes
{
    //TODO further develop this one    
    public class Special_ability
    {
        #region Declarations

        private string name;
        private string activation;
        private string range;
        private string effect;
        private string duration;
        private string description;
        private Skill ability_skill;

        #endregion

        #region Properties
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Activation
        {
            get { return activation; }
            set { activation = value; }
        }

        public string Range
        {
            get { return range; }
            set { range = value; }
        }

        public string Effect
        {
            get { return effect; }
            set { effect = value; }
        }

        public string Duration
        {
            get { return duration; }
            set { duration = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        /// <summary>
        /// If the ability_xml is a special skill, this is retrievable from here.
        /// </summary>
        public Skill Ability_skill
        {
            get { return ability_skill; }
            set { ability_skill = value; }
        }

        #endregion

        #region Constructors

        public Special_ability()
        {}

        public Special_ability(string i_name, string i_activation, string i_range, string i_effect, string i_duration, string i_description)
        {
            name = i_name;
            activation = i_activation;
            range = i_range;
            effect = i_effect;
            duration = i_duration;
            description = i_description;
        }

        #endregion
    }
}
