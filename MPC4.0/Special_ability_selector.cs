using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MPC4.classes;

namespace MPC4
{
    public partial class Special_ability_selector : Form
    {
        Ability_lister all_abilities = new Ability_lister();
        string name_ability_type;
        Ability_repository arep = new Ability_repository();

        public Special_ability_selector(string ability_type)
        {
            InitializeComponent();
            load_all_abilities(ability_type);
            name_ability_type = ability_type;
            set_btn_tooltips();
        }

        private void set_btn_tooltips()
        {
            toolTip_control.SetToolTip(btn_remove_ability, "Ta bort förmåga");
            toolTip_control.SetToolTip(btn_edit_ability, "Ändra förmåga");
            toolTip_control.SetToolTip(btn_new_ability, "Ny förmåga");
        }

        public Special_ability_selector(List<Special_ability> spa)
        {
            InitializeComponent();
            all_abilities.Special_abilities = spa;
            specialabilitiesBindingSource.DataSource = all_abilities.Special_abilities;
        }

        private void load_all_abilities(string ability_type)
        {
            all_abilities.Special_abilities = arep.get_abilities(ability_type);
            specialabilitiesBindingSource.DataSource = all_abilities.Special_abilities;
        }

        private void grid_special_abilities_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                string ability_name = Convert.ToString(this.grid_special_abilities.CurrentRow.Cells[0].Value);

                Special_ability sa = all_abilities.Special_abilities.Find(o => o.Name == ability_name);

                DoDragDrop(sa, DragDropEffects.Copy);

            } 
        }

        private void grid_special_abilities_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (grid_special_abilities.SelectedRows.Count > 0)
            {
                rtxt_description.Clear();
                rtxt_description.AppendText("Aktivering: " + Convert.ToString(grid_special_abilities.SelectedRows[0].Cells[1].Value));
                rtxt_description.AppendText(Environment.NewLine);
                rtxt_description.AppendText("Räckvidd: " + Convert.ToString(grid_special_abilities.SelectedRows[0].Cells[2].Value));
                rtxt_description.AppendText(Environment.NewLine);
                rtxt_description.AppendText("Effekt: " + Convert.ToString(grid_special_abilities.SelectedRows[0].Cells[3].Value));
                rtxt_description.AppendText(Environment.NewLine);
                rtxt_description.AppendText("Varaktighet: " + Convert.ToString(grid_special_abilities.SelectedRows[0].Cells[4].Value));
                rtxt_description.AppendText(Environment.NewLine);
                rtxt_description.AppendText("Beskrivning: " + Environment.NewLine);
                rtxt_description.AppendText(Convert.ToString(grid_special_abilities.SelectedRows[0].Cells[5].Value));
            }
        }


        private void add_edit_ability(Special_ability sa)
        {
            Ability_creator ac = new Ability_creator(sa);

            if (ac.ShowDialog() != DialogResult.Cancel)
            {
                Special_ability finalized = ac.Finalized_ability;
                arep.add_update_ability(finalized,name_ability_type);
                load_all_abilities(name_ability_type);
            }
            
            
        }


        private void btn_new_ability_Click(object sender, EventArgs e)
        {
            add_edit_ability(new Special_ability());
        }

        private void btn_edit_ability_Click(object sender, EventArgs e)
        {
            string ability_name = Convert.ToString(this.grid_special_abilities.CurrentRow.Cells[0].Value);

            Special_ability sa = all_abilities.Special_abilities.Find(o => o.Name == ability_name);

            add_edit_ability(sa);
        }

        private void btn_remove_ability_Click(object sender, EventArgs e)
        {
            string ability_name = Convert.ToString(this.grid_special_abilities.CurrentRow.Cells[0].Value);

            Special_ability sa = all_abilities.Special_abilities.Find(o => o.Name == ability_name);

            arep.remove_ability(sa, name_ability_type);

            load_all_abilities(name_ability_type);
        }


    }
}
