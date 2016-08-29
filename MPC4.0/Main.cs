using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MPC4.classes;
using System.Xml;

namespace MPC4
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            set_btn_tooltips();
        }

        private void set_btn_tooltips()
        {

            //Encounter/rund kontroller
            toolTip_control.SetToolTip(btn_manipulate, "Skapa/Editera varelser");
            toolTip_control.SetToolTip(btn_encounter, "Stridssimulering");
        }

        private void btn_manipulate_Click(object sender, EventArgs e)
        {
            Creature_manipulation cm = new Creature_manipulation();
            cm.Show();
        }

        private void btn_encounter_Click(object sender, EventArgs e)
        {
            Encounter en = new Encounter();
            en.Show();
        }
    }
}
