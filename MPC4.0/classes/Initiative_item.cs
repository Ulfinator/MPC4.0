namespace MPC4.classes
{
    public class Initiative_item
    {
        int initiative;
        string weapon_name;

        public int Initiative
        {
            get { return initiative; }
            set { initiative = value; }
        }

        public string Weapon_name
        {
            get { return weapon_name; }
            set { weapon_name = value; }
        }

        public Initiative_item() { }

        public Initiative_item(int i_initiative, string i_weapon_name)
        {
            initiative = i_initiative;
            weapon_name = i_weapon_name;
        }
    }
}
