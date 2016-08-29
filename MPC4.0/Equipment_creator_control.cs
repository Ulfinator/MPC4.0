using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MPC4.classes;
namespace MPC4
{
    public partial class Equipment_creator_control : UserControl
    {
        Equipment eq;

        public Equipment_creator_control()
        {
            InitializeComponent();
        }

        public Equipment_creator_control(ref Equipment eq_in)
        {
            InitializeComponent();
            eq = eq_in;
            equipmentBindingSource.DataSource = eq;
        }

    }
}
