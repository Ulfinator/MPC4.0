using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MPC4.classes;

namespace MPC4
{
    public partial class Equipment_selector : Form
    {
        Equipment_repository eqr = new Equipment_repository();
        Equipment_lister eql = new Equipment_lister();
        Hashtable equip = new Hashtable();

        public Equipment_selector()
        {
            InitializeComponent();
            fill_equipment_list();

        }

        public Equipment_selector(List<Equipment> equ)
        {
            InitializeComponent();
            cmb_equip_type.Enabled = false;
            eql.Equipment = equ;
            equipmentBindingSource.DataSource = eql.Equipment;
            equipmentBindingSource.ResetBindings(false);
            show_description();
        }

        private void fill_equipment_list()
        {
            equip = eqr.get_equipment_index();

            foreach(DictionaryEntry entry in equip)
            {
                cmb_equip_type.Items.Add(entry.Key);
            }

            cmb_equip_type.SelectedIndex = 0;

            show_description();
        }

        private void cmb_equip_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            eql.Equipment = eqr.get_equipment(Convert.ToString(equip[cmb_equip_type.SelectedItem]));
            equipmentBindingSource.DataSource = eql.Equipment;
            equipmentBindingSource.ResetBindings(false);

            show_description();
        }

        private void grid_equip_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                string item_name = Convert.ToString(this.grid_equip.CurrentRow.Cells[0].Value);
                Equipment eq = eql.Equipment.Find(o => o.Name == item_name);
                Equipment eq_clone = (Equipment)eq.Clone();
                DoDragDrop(eq_clone, DragDropEffects.Copy);
            } 
        }

        private void grid_equip_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            show_description();
        }

        private void show_description()
        {
            if (grid_equip.SelectedRows.Count > 0)
            {
                rtxt_description.Clear();
                object ob = eql.Equipment.Find(o => o.Name == Convert.ToString(grid_equip.SelectedRows[0].Cells[0].Value));

                Equipment eq = (Equipment)ob;

                write_txt_line_from_dictionary(eq.get_stat_summary_list());
            }        
        }

        private void write_txt_line(string line)
        {
            rtxt_description.AppendText(line);
            rtxt_description.AppendText(Environment.NewLine);
        }

        private void write_txt_line_from_dictionary(ListDictionary l_descrip)
        {
            foreach (DictionaryEntry de in l_descrip)
            {
                rtxt_description.AppendText(de.Key + ": " + de.Value);
                rtxt_description.AppendText(Environment.NewLine);
            }
        }

        private void btn_create_new_equip_Click(object sender, EventArgs e)
        {
            Equipment_creator epq = new Equipment_creator();
            epq.ShowDialog();
        }

    }
}
