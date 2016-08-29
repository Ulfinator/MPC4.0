using System;
using System.Windows.Forms;
using MPC4.classes;
using System.Drawing;

namespace MPC4
{
    public partial class Body_part_selector : Form
    {
        Modle_repository mod_rep = new Modle_repository();
        Body_modle_lister modle_list = new Body_modle_lister();
        
        private Body_modle currMod = null;

        public Body_modle currModle { get { return currMod; }  }

        public Body_part_selector()
        {
            InitializeComponent();
            
            load_body_types();
       
        }

        private void load_body_types()
        {
            modle_list.Modle_list = mod_rep.get_body_modles();
            bodymodlelisterBindingSource.DataSource = modle_list;
 
        }

        private void btn_create_new_modle_Click(object sender, EventArgs e)
        {
            Hit_modle_creator hmc = new Hit_modle_creator();
            hmc.Show();
        }

        private void btn_choose_Click(object sender, EventArgs e)
        {
            string modle_name = Convert.ToString(this.grid_body_types.CurrentRow.Cells[0].Value);

            currMod = modle_list.Modle_list.Find(o => o.Modle_name == modle_name);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void draw_body(Body_modle bm) {
            
            //Get a graphics handle
            Graphics graph = pic_canvas.CreateGraphics();

            //Draw the modle
            Creature_drawing_handler.draw_body(bm, BackColor, ref graph);
        }

        private void grid_body_types_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string modle_name = Convert.ToString(this.grid_body_types.CurrentRow.Cells[0].Value);

            Body_modle bm = modle_list.Modle_list.Find(o => o.Modle_name == modle_name);

            draw_body(bm);
        }

        private void pic_canvas_Paint(object sender, PaintEventArgs e)
        {
            //On form load we tap into the paint event of the canvas and if there is something in the
            //modle list we paint the first object since its choosen as a default.
            if (modle_list.Modle_list.Count > 0)
            {
                Graphics g = e.Graphics;
                Body_modle bm = modle_list.Modle_list[0];
                Creature_drawing_handler.draw_body(bm, BackColor, ref g);
            }
        }
    }
}
