using System;
using System.Text.RegularExpressions;
namespace MPC4.classes
{
    public static class Die_service
    {

        /// <summary>
        /// throw_dies takes an input string for a die combination, parses the string, makes random throws and returns an integer 
        /// number that represents the total value from the die throw +- any extra value.
        /// </summary>
        /// <param name="die_string">input string on the form [nr_of_dies]T[nr_of_die_sides][(optional)+-extra_value] 
        /// or -[nr_of_dies]T[nr_of_die_sides]
        /// Example: 3T6+2, 2T8-1, 1T20, -1T4</param>
        /// <returns></returns>
        public static int throw_dies(string die_string)
        {
            Random rand = new Random(DateTime.Now.Millisecond);
            int die_nr;
            int die_sides = 0;
            string[] t_split;
            string[] plus_split = null;
            int die_outcome = 0;
            int add_on = 0;
            bool is_negative = false;

            Regex reg = new Regex("T");
            t_split = reg.Split(die_string); //split on T to get number of dies and die sides + possible plus value

            die_nr = Convert.ToInt32(t_split[0]);

            //If a die string has a negative die roll we convert it to positive and later add the minus sign
            if (die_nr < 0)
            {
                die_nr *= -1;
                is_negative = true;
            }

            if (t_split[1].Contains("+") || t_split[1].Contains("-")) //if we got a + modifier we need to separate it from the die sides
            {
                Regex reg2;

                if (t_split[1].Contains("+"))
                {
                    reg2 = new Regex(@"\+");
                    plus_split = reg2.Split(t_split[1]);
                    add_on = Convert.ToInt32(plus_split[1]);
                }
                else
                {
                    reg2 = new Regex(@"\-");
                    plus_split = reg2.Split(t_split[1]);
                    add_on = Convert.ToInt32(plus_split[1]);
                    add_on *= -1;
                }
                
                die_sides = Convert.ToInt32(plus_split[0]);
                
            }
            else //otherwise we just get the die sides
                die_sides = Convert.ToInt32(t_split[1]);

            for (int i = 0; i < die_nr; i++)
            {
                die_outcome += rand.Next(1, die_sides);
            }

            if (is_negative)
                die_outcome *= -1;

            die_outcome += add_on;

            return die_outcome;
        }
    }
}
