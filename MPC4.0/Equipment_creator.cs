using System;
using System.Collections.Generic;
using System.Collections;
using System.Windows.Forms;
using MPC4.classes;

namespace MPC4
{
    public partial class Equipment_creator : Form
    {
        List<Equipment> eql = new List<Equipment>();
        Equipment_repository eqr = new Equipment_repository();
        Hashtable equip = new Hashtable();

        public Equipment_creator()
        {
            InitializeComponent();
            fill_equipment_list();

        }

        private void fill_equipment_list()
        {
            equip = eqr.get_equipment_index();

            foreach (DictionaryEntry entry in equip)
            {
                cmb_equip_type.Items.Add(entry.Key);
            }

            cmb_equip_type.SelectedIndex = 0;

            show_description();
        }

        private void show_description()
        {
            if (grid_equip.SelectedRows.Count > 0)
            {
                grp_equip_data.Controls.Clear();
                object ob = eql.Find(o => o.Name == Convert.ToString(grid_equip.SelectedRows[0].Cells[0].Value));
                Equipment eq = (Equipment)ob;

                Equipment_creator_control ecc = new Equipment_creator_control(ref eq);
                ecc.Dock = DockStyle.Fill;

                grp_equip_data.Controls.Add(ecc);
                grp_equip_data.Refresh();
            }
        }

        private void cmb_equip_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            eql = eqr.get_equipment(Convert.ToString(equip[cmb_equip_type.SelectedItem]));
            equipmentBindingSource.DataSource = eql;
            equipmentBindingSource.ResetBindings(false);

            show_description();
        }

        private void grid_equip_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            show_description();
        }

        private void btn_save_all_changes_Click(object sender, EventArgs e)
        {
            save_changes();
        }

        private void save_changes()
        {
            eqr.save_equipment_list(eql, Convert.ToString(cmb_equip_type.SelectedItem), Convert.ToString(equip[cmb_equip_type.SelectedItem]));
        }

    }
}
