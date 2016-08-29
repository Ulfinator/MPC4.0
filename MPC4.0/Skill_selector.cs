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
    public partial class Skill_selector : Form
    {
        Skill_lister all_skills = new Skill_lister();


        public Skill_selector()
        {
            InitializeComponent();

            load_all_skills();
        
        }

        private void load_all_skills()
        {
            List<Skill> natural_skills;
            List<Skill> trained_skills;

            natural_skills = MPC4.classes.List_service.get_natural_skills(); ;
            trained_skills = MPC4.classes.List_service.get_trained_skills();

            natural_skills.AddRange(trained_skills);
            all_skills.Skills = natural_skills;

            skillsBindingSource.DataSource = all_skills.Skills;       
        }

        private void grid_skills_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                string skill_name = Convert.ToString(this.grid_skills.CurrentRow.Cells[0].Value);
                Skill sk = all_skills.Skills.Find(o => o.Name == skill_name);
                DoDragDrop(sk, DragDropEffects.Copy);
            }    
        }


    }
}
