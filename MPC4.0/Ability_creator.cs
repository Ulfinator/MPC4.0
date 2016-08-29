using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MPC4.classes;

namespace MPC4
{
    public partial class Ability_creator : Form
    {
        Special_ability spec_ab;
        Skill ab_skill;

        public Special_ability Finalized_ability
        {
            get { return spec_ab; }
            set { spec_ab = value; }
        }

        public Ability_creator(Special_ability sa)
        {
            InitializeComponent();
            spec_ab = sa;
            specialabilityBindingSource.DataSource = spec_ab;

            if (spec_ab.Name != "" || spec_ab.Name != null)
                edit_ability();
        }

        private void edit_ability()
        {
            if (spec_ab.Ability_skill != null)
            {
                chk_gives_skill.Checked = true;
                txt_skill_name.Enabled = true;
                cmb_base_attrib.Enabled = true;
                ab_skill = spec_ab.Ability_skill;
                skillBindingSource.DataSource = ab_skill;
            }
        }

        private void chk_gives_skill_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_gives_skill.Checked)
            {
                txt_skill_name.Enabled = true;
                cmb_base_attrib.Enabled = true;
                ab_skill = new Skill();
                skillBindingSource.DataSource = ab_skill;
            }
            else
            {
                txt_skill_name.Enabled = false;
                cmb_base_attrib.Enabled = false;
                spec_ab.Ability_skill = null;
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            //Build up the ability skill if its there
            if (chk_gives_skill.Checked)
            {
                spec_ab.Ability_skill = ab_skill;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

    }
}
