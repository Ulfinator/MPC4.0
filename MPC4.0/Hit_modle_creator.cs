using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MPC4.classes;
using System.Xml;

namespace MPC4
{
    public partial class Hit_modle_creator : Form
    {
        Body_modle curr_body_modle;
        Body_part curr_body_part;
        private System.Drawing.Graphics graph;
        private System.Drawing.Graphics trace;

        public Hit_modle_creator()
        {
            InitializeComponent();
            graph = pic_hit_modle.CreateGraphics();
            trace = pic_tracer.CreateGraphics();
            reset_modle_data();
        }

        private void  reset_modle_data()
        {
            curr_body_modle = new Body_modle();
            curr_body_modle.Body_parts = new List<Body_part>();

        }


        private void btn_load_tracer_img_Click(object sender, EventArgs e)
        {
            open_FD.Title = "Open Image";
            open_FD.FileName = "";
            open_FD.Filter = "All files (*.*)|*.*";
            open_FD.InitialDirectory = Path_util.get_game_image_path("");

            if (open_FD.ShowDialog() != DialogResult.Cancel)
            {
                pic_tracer.BackgroundImage = Image.FromFile(open_FD.FileName);
            } 
        }

        private void pic_tracer_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                curr_body_modle.Body_parts.Add(curr_body_part);
                curr_body_part = null;

                Creature_drawing_handler.draw_body(curr_body_modle, BackColor, ref graph);
            }
            else if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (curr_body_part == null)
                {
                    curr_body_part = new Body_part();
                    curr_body_part.Draw_points = new List<Point>();
                }

                Point p = new Point(e.X, e.Y);
                SolidBrush sb = new SolidBrush(Color.Red);
                Size sz = new Size(6, 6);

                curr_body_part.Draw_points.Add(p);

                //centering the dot
                p.X = p.X - 3;
                p.Y = p.Y - 3;

                Creature_drawing_handler.fill_circle(p, sb, ref trace, sz);
            }


        }

        private void pic_hit_modle_MouseDown(object sender, MouseEventArgs e)
        {
            display_body_part(new Point(e.X, e.Y));
        }

        private void display_body_part(Point pnt)
        {
            bool found_area = false;

            for (int i = 0; i < curr_body_modle.Body_parts.Count; i++)
            {
                Point[] pp = curr_body_modle.Body_parts[i].Draw_points.ToArray();

                if (Creature_drawing_handler.IsInPolygon(pp, pnt))
                {
                    found_area = true;
                    Creature_drawing_handler.draw_body(curr_body_modle, BackColor, ref graph); //redraw so that we do not have 2 red areas
                    Creature_drawing_handler.fill_polygon(curr_body_modle.Body_parts[i].Draw_points, new SolidBrush(Color.LightGray), ref graph); // mark the area clicked reds

                    set_bodypart_info(curr_body_modle.Body_parts[i]);

                    break;
                }
            }

            if (!found_area)
            {
                Creature_drawing_handler.draw_body(curr_body_modle, BackColor, ref graph); //no marking
                set_bodypart_info(new Body_part());
            }
        }

        private void set_bodypart_info(Body_part bp)
        {
            bodypartBindingSource.DataSource = bp;
        }

        private void btn_save_modle_Click(object sender, EventArgs e)
        {
            save_model();
        }

        private void save_model()
        {
            string status;
            Modle_repository mod_rep = new Modle_repository();
            string save_path = Path_util.get_body_modle_path(curr_body_modle.Modle_name + ".xml"); 
            status = mod_rep.save_modle(curr_body_modle, save_path);

            if (status != "OK")
            {
                MessageBox.Show(status, "Saknad info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_scrap_modle_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Är du säker du vill skrota denna model?", "Skrota model", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) != DialogResult.Cancel)
            {
                //killing of the modle and its graph
                reset_modle_data();
                Creature_drawing_handler.draw_body(curr_body_modle, BackColor, ref graph);

                //Reload trace image
                pic_tracer.Invalidate();

            }
        }

        private void btn_scrap_body_part_Click(object sender, EventArgs e)
        {
            //Kill the body part from the Body modle
            curr_body_modle.Body_parts.Remove(curr_body_modle.Body_parts.Find(i => i.Name == txt_name.Text));

            //redraw the hitmodel box
            Creature_drawing_handler.draw_body(curr_body_modle, BackColor, ref graph);
            
            //redraw the tracer box with only valid trace points
            pic_tracer.Refresh();

            SolidBrush sb = new SolidBrush(Color.Red);
            Size sz = new Size(6, 6);

            
            foreach (Body_part bp in curr_body_modle.Body_parts)
            {
                Point[] pp = bp.Draw_points.ToArray();

                foreach (Point p in pp)
                {
                    Creature_drawing_handler.fill_circle(p, sb, ref trace, sz);
                }
            }

        }

        private void btn_load_modle_Click(object sender, EventArgs e)
        {
            open_FD.Title = "Open Modle";
            open_FD.FileName = "";
            open_FD.Filter = "All files (*.*)|*.*";
            open_FD.InitialDirectory = Path_util.get_body_modle_path(""); 

            if (open_FD.ShowDialog() != DialogResult.Cancel)
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(open_FD.FileName);
                Modle_repository mod_rep = new Modle_repository();
                curr_body_modle = mod_rep.load_base_body_modle(ref xDoc);

                bodymodleBindingSource.DataSource = curr_body_modle;
                bodymodleBindingSource.ResetBindings(false);

                Creature_drawing_handler.draw_body(curr_body_modle, BackColor, ref graph);   
            } 

        }

        private void btn_add_tracer_points_Click(object sender, EventArgs e)
        {
            if (curr_body_modle != null)
            {
                SolidBrush sb = new SolidBrush(Color.Red);
                Size sz = new Size(6, 6);
                Point adjusted_point;

                foreach(Body_part bp in curr_body_modle.Body_parts)
                {
                    foreach (Point p in bp.Draw_points)
                    {
                        adjusted_point = p;
                        adjusted_point.X -= 3;
                        adjusted_point.Y -= 3;
                        Creature_drawing_handler.fill_circle(adjusted_point, sb, ref trace, sz);
                    }
                }
            }

        }


        private void txt_draw_point_x_KeyUp(object sender, KeyEventArgs e)
        {
                Creature_drawing_handler.draw_body(curr_body_modle, BackColor, ref graph);
        }

        private void txt_draw_point_y_KeyUp(object sender, KeyEventArgs e)
        {
            Creature_drawing_handler.draw_body(curr_body_modle, BackColor, ref graph);
        }

        private void txt_die_start_KeyUp(object sender, KeyEventArgs e)
        {
            Creature_drawing_handler.draw_body(curr_body_modle, BackColor, ref graph);
        }

        private void txt_die_end_KeyUp(object sender, KeyEventArgs e)
        {
            Creature_drawing_handler.draw_body(curr_body_modle, BackColor, ref graph);
        }

        private void pic_tracer_MouseMove(object sender, MouseEventArgs e)
        {
            lbl_X.Text = e.X.ToString();
            lbl_Y.Text = e.Y.ToString();
        }

        private void pic_tracer_MouseLeave(object sender, EventArgs e)
        {
            lbl_X.Text = "-";
            lbl_Y.Text = "-";
        }



    }
}
