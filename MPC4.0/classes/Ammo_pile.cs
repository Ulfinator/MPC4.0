using System.Collections.Specialized;
namespace MPC4.classes
{
    public class Ammo_pile : Equipment
    {
        string calibre;
        int projectiles_left;
        string shell_type;

        public string Calibre
        {
            get { return calibre; }
            set { calibre = value; }
        }

        public int Projectiles_left
        {
            get { return projectiles_left; }
            set { projectiles_left = value; }
        }

        public string Shell_type
        {
            get { return shell_type; }
            set { shell_type = value; }
        }

        public Ammo_pile() { }

        public Ammo_pile(string i_name, string i_eq_type, string i_descrip, string i_calibre, int i_projectiles_left,string i_shell_type)
        {
            base.Name = i_name;
            base.Equipment_type = i_eq_type;
            base.Description = i_descrip;
            calibre = i_calibre;
            projectiles_left = i_projectiles_left;
            shell_type = i_shell_type;
        }

        public override ListDictionary get_stat_summary_list()
        {
            ListDictionary list_descrip = new ListDictionary();

            list_descrip.Add("Kaliber", Calibre);
            list_descrip.Add("Projektiler", Projectiles_left);
            list_descrip.Add("Ammo typ", shell_type);
            list_descrip.Add("Beskrivning", Description);

            return list_descrip;
        }

    }
}
