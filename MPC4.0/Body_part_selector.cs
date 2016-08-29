using System;
using System.Windows.Forms;
using MPC4.classes;

namespace MPC4
{
    public partial class Body_part_selector : Form
    {
        Modle_repository mod_rep = new Modle_repository();
        Body_modle_lister modle_list = new Body_modle_lister();
        private System.Drawing.Graphics graph;

        public Body_part_selector()
        {
            InitializeComponent();
            graph = pic_canvas.CreateGraphics();
            load_body_types();
       
        }

        private void load_body_types()
        {
            modle_list.Modle_list = mod_rep.get_body_modles();
            bodymodlelisterBindingSource.DataSource = modle_list;
        }

        private void grid_body_types_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                string modle_name = Convert.ToString(this.grid_body_types.CurrentRow.Cells[0].Value);
 
                Body_modle bm = modle_list.Modle_list.Find(o => o.Modle_name == modle_name);

                //Draw the modle
                Creature_drawing_handler.draw_body(bm, BackColor, ref graph);

                DoDragDrop(bm, DragDropEffects.Copy);             
            } 
        }

        private void btn_create_new_modle_Click(object sender, EventArgs e)
        {
            Hit_modle_creator hmc = new Hit_modle_creator();
            hmc.Show();
        }


    }
}
