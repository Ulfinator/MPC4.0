using System.Collections.Generic;

namespace MPC4.classes
{
    //TODO: check if you cannot do without this class
    public class Equipment_lister
    {
        private List<Equipment> equipment;

        public List<Equipment> Equipment
        {
            get { return equipment; }
            set { equipment = value; }
        }
    }
}
