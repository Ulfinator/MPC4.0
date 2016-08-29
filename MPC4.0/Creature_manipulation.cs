using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
using MPC4.classes;
using System.Configuration;

namespace MPC4
{
    public partial class Creature_manipulation : Form
    {
        //This objects is the handle we use for all manipulations
        //We can only manipulate one creature at a time.
        Creature manipulation_creature;

        public Creature_manipulation()
        {
            InitializeComponent();
            new_creature();
            set_btn_tooltips();
        }

        /// <summary>
        /// For quick in memory manipulation by a creature. For instance during an encounter.
        /// </summary>
        /// <param name="edit_cret"></param>
        public Creature_manipulation(ref Creature edit_cret)
        {
            InitializeComponent();
            set_btn_tooltips();
            manipulation_creature = edit_cret;
            creatureBindingSource.DataSource = manipulation_creature;

            //Disable menu buttons
            tbtn_new_cret.Enabled = false;
            tbtn_load_cret.Enabled = false;
            tbtn_save_cret.Enabled = false;
        }

        private void new_creature()
        {
            Creature_repository cret_fact = new Creature_repository();
            manipulation_creature = cret_fact.create_empty_creature();

            //starting values for ease of use
            manipulation_creature.Class_type = "IMM";  //Start with an IMM as default
            
            //Add unarmed combat since most all creatures will have this (Not pretty but speedy when making people) TODO: should go by ID or be able to change the naming in the xml file and here
            Equipment_repository eqr = new Equipment_repository();
            string equip_path = Path_util.get_euipment_path("natural_weapons.xml");
            List<Equipment> eql = eqr.get_equipment(equip_path);
            Equipment eq = eql.Find(o => o.Name == "Standard obeväpnad");
            manipulation_creature.Equipment.Add(eq);


            creatureBindingSource.DataSource = manipulation_creature;
            
            //By some reason the image stays even though we change datasource
            pic_creature.Image = null;
        }

        private void set_btn_tooltips()
        {
            toolTip_control.SetToolTip(btn_random_attributes, "Slumpa attributvärden");
            toolTip_control.SetToolTip(btn_add_image, "Varelsebild");
            toolTip_control.SetToolTip(btn_body_part_list, "Kroppstyp");
            toolTip_control.SetToolTip(btn_armour, "Rustning");
            toolTip_control.SetToolTip(btn_calculate_secondary, "Räkna ut sekundära egenskaper");
            toolTip_control.SetToolTip(btn_special_ability_list, "Specialförmågor");
            toolTip_control.SetToolTip(btn_gear, "Utrustning");
            toolTip_control.SetToolTip(btn_set_skill_base, "Räkna ut färdighetsgrundvärden");
            toolTip_control.SetToolTip(btn_skill_list, "Andra färdigheter");
        }

        private void load_creature()
        { 
            open_FD.Title = "Open Creature definition";
            open_FD.FileName = "";
            open_FD.Filter = "XML|*.xml";
            open_FD.InitialDirectory = Path_util.get_creature_save_path("");

            if (open_FD.ShowDialog() != DialogResult.Cancel)
            {
                Creature_repository cret_rep = new Creature_repository();
                string path = open_FD.FileName;
                manipulation_creature = cret_rep.load_humanoid(path);
                creatureBindingSource.DataSource = manipulation_creature;

                if (manipulation_creature.Body != null)
                    txt_body.Text = manipulation_creature.Body.Modle_name;
            }        
        }

        private void save_creature()
        {
            string status;
            Creature_repository cret_rep = new Creature_repository();
            string save_path = Path_util.get_creature_save_path(manipulation_creature.Name + ".xml");
            manipulation_creature.Template_path = manipulation_creature.Name + ".xml";
            status = cret_rep.save_humanoid(manipulation_creature,save_path);

            if (status != "OK")
            {
                MessageBox.Show(status,"Saknad info",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void cmb_class_SelectedIndexChanged(object sender, EventArgs e)
        {
                manipulation_creature.Class_type = Convert.ToString(cmb_class.SelectedItem).Trim();
        }

        private void btn_random_attributes_Click(object sender, EventArgs e)
        {
            manipulation_creature.randomize_attributes();
            creatureBindingSource.ResetItem(0);
        }

        private void btn_calculate_secondary_Click(object sender, EventArgs e)
        {
            manipulation_creature.calculate_from_base_values();
            creatureBindingSource.ResetItem(0);
        }

        private void btn_skill_list_Click(object sender, EventArgs e)
        {
            Skill_selector ss = new Skill_selector();
            ss.Show();
        }

        private void grid_skills_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Skill)))
                e.Effect = DragDropEffects.Copy;
        }

        private void grid_skills_DragDrop(object sender, DragEventArgs e)
        {
            Skill sk = e.Data.GetData(typeof(Skill)) as Skill;
            manipulation_creature.Skills.Add(sk);
            creatureBindingSource.ResetBindings(false);
        }

        private void btn_set_skill_base_Click(object sender, EventArgs e)
        {
            manipulation_creature.initiate_skill_base_values();
            creatureBindingSource.ResetItem(0);
        }

        private void btn_special_ability_list_Click(object sender, EventArgs e)
        {
            Special_ability_selector sas = new Special_ability_selector(manipulation_creature.Class_type.Trim());
            sas.Show();
        }

        private void grid_special_abilities_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Special_ability)))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void grid_special_abilities_DragDrop_1(object sender, DragEventArgs e)
        {
            Special_ability sa = e.Data.GetData(typeof(Special_ability)) as Special_ability;
            manipulation_creature.Special_abilities.Add(sa);

            if (sa.Ability_skill != null)
                manipulation_creature.Skills.Add(sa.Ability_skill);

            creatureBindingSource.ResetBindings(false);
        }

        private void btn_body_part_list_Click(object sender, EventArgs e)
        {
            Body_part_selector bps = new Body_part_selector();
            //bps.Show();

            if (bps.ShowDialog() == DialogResult.OK) {
                manipulation_creature.Body = bps.currModle;
                txt_body.Text = manipulation_creature.Body.Modle_name;
            }
        }

        private void btn_armour_Click(object sender, EventArgs e)
        {
            if (manipulation_creature.Body !=null)
            {
                Armour_selector ams = new Armour_selector(ref manipulation_creature);
                ams.Show();
            }
        }

        private void btn_gear_Click(object sender, EventArgs e)
        {
            Equipment_selector eqs = new Equipment_selector();
            eqs.Show();
        }

        private void grid_equipment_DragEnter(object sender, DragEventArgs e)
        {
            if (
                e.Data.GetDataPresent(typeof(Equipment)) || e.Data.GetDataPresent(typeof(Weapon)) ||
                e.Data.GetDataPresent(typeof(Magazine)) ||
                e.Data.GetDataPresent(typeof(Ammo_pile)) || e.Data.GetDataPresent(typeof(Spray_weapon)) ||
                e.Data.GetDataPresent(typeof(Thrown_weapon))
                )
                e.Effect = DragDropEffects.Copy;
        }

        private void grid_equipment_DragDrop(object sender, DragEventArgs e)
        {
            Equipment_factory eqp = new Equipment_factory();
            Equipment eq = eqp.cast_object_to_correct_equipment(e);

            manipulation_creature.Equipment.Add(eq);

            for (int i = 0; i < manipulation_creature.Equipment.Count; i++)
            {
                manipulation_creature.Equipment[i].Id = i + 1;
            }

            creatureBindingSource.ResetBindings(false);            
        }

        private void tbtn_new_cret_Click(object sender, EventArgs e)
        {
            new_creature();
        }

        private void tbtn_load_cret_Click(object sender, EventArgs e)
        {
            load_creature();
        }

        private void tbtn_save_cret_Click(object sender, EventArgs e)
        {   
            save_creature();
        }

        private void grid_special_abilities_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                string name = Convert.ToString(this.grid_special_abilities.CurrentRow.Cells[0].Value);
                Special_ability sp = manipulation_creature.Special_abilities.Find(o => o.Name == name);
                DoDragDrop(sp, DragDropEffects.Move);
            } 
        }

        private void grid_equipment_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                string name = Convert.ToString(this.grid_equipment.CurrentRow.Cells[0].Value);
                Equipment sp = manipulation_creature.Equipment.Find(o => o.Name == name);
                DoDragDrop(sp, DragDropEffects.Move);
            }
        }

        private void grid_skills_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                string name = Convert.ToString(this.grid_skills.CurrentRow.Cells[0].Value);
                Skill sp = manipulation_creature.Skills.Find(o => o.Name == name);
                DoDragDrop(sp, DragDropEffects.Move);
            }
        }

        private void pnl_garbage_DragEnter(object sender, DragEventArgs e)
        {
                e.Effect = DragDropEffects.Move;
        }

        private void pnl_garbage_DragDrop(object sender, DragEventArgs e)
        {
            creatureBindingSource.ResetBindings(false);

            if (e.Data.GetDataPresent(typeof(Special_ability)))
            {
                Special_ability sp = e.Data.GetData(typeof(Special_ability)) as Special_ability;

                if (sp.Ability_skill != null) //If there is an associated skill we remove that as well from the skill list.
                {
                    manipulation_creature.Skills.Remove(manipulation_creature.Skills.Find(o => o.Name == sp.Ability_skill.Name));
                }

                manipulation_creature.Special_abilities.Remove(sp);
            }
            else if (e.Data.GetDataPresent(typeof(Equipment)))
            {
                Equipment eq = e.Data.GetData(typeof(Equipment)) as Equipment;
                manipulation_creature.Equipment.Remove(eq);
            }
            else if (e.Data.GetDataPresent(typeof(Weapon)))
            {
                Weapon rw = e.Data.GetData(typeof(Weapon)) as Weapon;
                manipulation_creature.Equipment.Remove(rw);
            }
            else if (e.Data.GetDataPresent(typeof(Spray_weapon)))
            {
                Spray_weapon sw = e.Data.GetData(typeof(Spray_weapon)) as Spray_weapon;
                manipulation_creature.Equipment.Remove(sw);
            }
            else if (e.Data.GetDataPresent(typeof(Thrown_weapon)))
            {
                Thrown_weapon tw = e.Data.GetData(typeof(Thrown_weapon)) as Thrown_weapon;
                manipulation_creature.Equipment.Remove(tw);
            }
            else if (e.Data.GetDataPresent(typeof(Magazine)))
            {
                Magazine mg = e.Data.GetData(typeof(Magazine)) as Magazine;
                manipulation_creature.Equipment.Remove(mg);
            }
            else if (e.Data.GetDataPresent(typeof(Ammo_pile)))
            {
                Ammo_pile am = e.Data.GetData(typeof(Ammo_pile)) as Ammo_pile;
                manipulation_creature.Equipment.Remove(am);
            }
            else if (e.Data.GetDataPresent(typeof(Skill)))
            {
                Skill sk = e.Data.GetData(typeof(Skill)) as Skill;
                manipulation_creature.Skills.Remove(sk);
            }

            creatureBindingSource.ResetBindings(false);
        }

        private void btn_add_image_Click(object sender, EventArgs e)
        {
            open_FD.Title = "Open Image";
            open_FD.FileName = "";
            open_FD.Filter = "All files (*.*)|*.*";
            open_FD.InitialDirectory = Path_util.get_game_image_path("");

            if (open_FD.ShowDialog() != DialogResult.Cancel)
            {
                manipulation_creature.Image_path = open_FD.SafeFileName;
                creatureBindingSource.ResetBindings(false);
            } 
        }

    }
}
