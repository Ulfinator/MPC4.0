using System.Collections.Generic;
namespace MPC4.classes
{
    public class Weapon_result
    {
        List<Damage> damage = new List<Damage>();
        int area;
        string status;

        public List<Damage> Damage
        {
            get { return damage; }
            set { damage = value; }
        }

        public int Area
        {
            get { return area; }
            set { area = value; }
        }
        
        public string Status
        {
            get { return status; }
            set { status = value; }
        }
    }
}
