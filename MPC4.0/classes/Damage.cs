namespace MPC4.classes
{
    public class Damage
    {
        string damage_type;
        int damage_value;

        public string Damage_type
        {
            get { return damage_type; }
            set { damage_type = value; }
        }
        
        public int Damage_value
        {
            get { return damage_value; }
            set { damage_value = value; }
        }

        public Damage()
        { }

        public Damage(string i_damage_type, int i_damage_value)
        {
            damage_type = i_damage_type;
            damage_value = i_damage_value;
        }

    }
}
