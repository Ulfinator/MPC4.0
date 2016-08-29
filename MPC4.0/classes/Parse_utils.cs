using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPC4.classes
{
    public static class Parse_utils
    {
        public static int try_parse(string int_string)
        {
            int ret_int;
            int.TryParse(int_string, out ret_int);
            return ret_int;
        }


    }
}
