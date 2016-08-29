using System.Windows.Forms;

namespace MPC4.classes
{
    public class Encounter_list_item : ListViewItem
    {
        private Creature encounter_object = null;

        public Creature Encounter_object
        {
            get { return encounter_object; }
            set { encounter_object = value; }
        }
    }
}
