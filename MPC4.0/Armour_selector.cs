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
    public partial class Armour_selector : Form
    {
        Creature cret;
        Armour_lister all_armour = new Armour_lister();
        string current_body_part = "";

        public Armour_selector()
        {
            InitializeComponent();
        }

        public Armour_selector(ref Creature i_cret)
        {
            InitializeComponent();
            cret = i_cret;
            load_body_modle();
            load_armour_list();
            set_abs_beg();
        }

        private void load_body_modle()
        {
            bodypartsBindingSource.DataSource = cret.Body.Body_parts;
            current_body_part = cret.Body.Body_parts[0].Name;
            armourpartBindingSource1.DataSource = cret.Body.Body_parts.Find(o => o.Name == current_body_part).Armour_parts;
        }

        private void load_armour_list()
        {
            List<Armour_part> armour = List_service.get_armour_parts();

            all_armour.Armour_parts = armour;

            armourpartBindingSource.DataSource = all_armour.Armour_parts;
        }

        private void grid_body_modle_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (grid_body_modle.SelectedRows.Count > 0)
            {
                current_body_part = Convert.ToString(grid_body_modle.SelectedRows[0].Cells[0].Value);

                Body_part bp = cret.Body.Body_parts.Find(o => o.Name == current_body_part);

                armourpartBindingSource1.DataSource = bp.Armour_parts;

                set_abs_beg();
            }
        }

        private void grid_armour_parts_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                string armour_name = Convert.ToString(this.grid_armour_parts.CurrentRow.Cells[0].Value);

                Armour_part ap = all_armour.Armour_parts.Find(o => o.Name == armour_name);

                DoDragDrop(ap, DragDropEffects.Copy);
            } 
        }

        private void grid_body_armour_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Armour_part)))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void grid_body_armour_DragDrop(object sender, DragEventArgs e)
        {
            Armour_part ap = e.Data.GetData(typeof(Armour_part)) as Armour_part;

            cret.Body.Body_parts.Find(o => o.Name == current_body_part).add_armour_part(ap);

            armourpartBindingSource1.DataSource = cret.Body.Body_parts.Find(o => o.Name == current_body_part).Armour_parts;
            armourpartBindingSource1.ResetBindings(false);

            set_abs_beg();
            
        }

        /// <summary>
        /// Calculates and shows the totals for absorption and limitations to movement/vision
        /// </summary>
        private void set_abs_beg()
        {
            int part_total_abs = 0;
            int part_total_beg = 0;
            int total_move_beg = 0;
            int total_vison_beg = 0;

            //Must set the totals based on all body parts armour
            for(int i = 0; i < cret.Body.Body_parts.Count; i++)
            {
                if(cret.Body.Body_parts[i].Armour_parts != null)
                {
                    for(int k = 0; k < cret.Body.Body_parts[i].Armour_parts.Count; k++)
                    {
                        if(cret.Body.Body_parts[i].Part_type == "HEAD")
                            total_vison_beg += cret.Body.Body_parts[i].Armour_parts[k].Limitation_value;
                        else
                            total_move_beg += cret.Body.Body_parts[i].Armour_parts[k].Limitation_value;

                        if (cret.Body.Body_parts[i].Name == current_body_part)
                        {
                            part_total_abs += cret.Body.Body_parts[i].Armour_parts[k].Absorption_value;
                            part_total_beg += cret.Body.Body_parts[i].Armour_parts[k].Limitation_value;
                        }

                    }
                }
            }

            lbl_body_part_abs.Text = Convert.ToString(part_total_abs);
            lbl_body_part_beg.Text = Convert.ToString(part_total_beg);
            lbl_total_move_beg.Text = Convert.ToString(total_move_beg);
            lbl_total_vision_beg.Text = Convert.ToString(total_vison_beg);
        }

        private void grid_body_armour_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.grid_body_armour.DoDragDrop(this.grid_body_armour.CurrentRow, DragDropEffects.Move);
            } 
        }

        private void grid_armour_parts_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(DataGridViewRow)))
            {
                e.Effect = DragDropEffects.Move;
            }        
        }

        private void grid_armour_parts_DragDrop(object sender, DragEventArgs e)
        {
            DataGridViewRow row = e.Data.GetData(typeof(DataGridViewRow)) as DataGridViewRow;

            if (row != null)
            {
                string armour_name = Convert.ToString(row.Cells[0].Value);
                Armour_part ap = cret.Body.Body_parts.Find(o => o.Name == current_body_part).Armour_parts.Find(o => o.Name == armour_name);
                cret.Body.Body_parts.Find(o => o.Name == current_body_part).Armour_parts.Remove(ap);

                armourpartBindingSource1.ResetBindings(false);

               
            }
        }


    }
}
