using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MPC4.classes;
using System.Collections.Specialized;
using System.Collections;

namespace MPC4
{ 
    public partial class Encounter : Form
    {
        private System.Windows.Forms.ImageList encounter_image_list = new ImageList();
        private System.Drawing.Graphics graph;
        private Creature manipulation_creature;
        private int current_initiative;
        private int current_encounter_view_index;

        public Encounter()
        {
            InitializeComponent();
            initializeListviewAndIcons();
            graph = pic_canvas.CreateGraphics();
            set_btn_tooltips();
            
        }

        private void set_btn_tooltips()
        {

            //Encounter/rund kontroller
            toolTip_control.SetToolTip(btn_clone, "Klona");
            toolTip_control.SetToolTip(btn_delete, "Ta bort");
            toolTip_control.SetToolTip(btn_calc_initiative, "Räkna initiativ");
            toolTip_control.SetToolTip(btn_new_round, "Ny runda");

            //Helning etc
            toolTip_control.SetToolTip(btn_heal, "Hela");
            toolTip_control.SetToolTip(btn_stop_bleeding, "Stoppa blödning");
            toolTip_control.SetToolTip(btn_wake_up, "Väck");
            toolTip_control.SetToolTip(btn_sleep, "Gör medveteslös");
            toolTip_control.SetToolTip(btn_add_ms, "Addera/ta bort mental resonans");
            toolTip_control.SetToolTip(btn_mend_part, "Återställ del");

            //Skada etc
            toolTip_control.SetToolTip(btn_damage, "Applicera skada");

            //...
            toolTip_control.SetToolTip(btn_equipment, "Utrustning");
            toolTip_control.SetToolTip(btn_show_abilities, "Förmågor");
            toolTip_control.SetToolTip(btn_edit_creature, "Editera karaktär");


        }

        private void initializeListviewAndIcons()
        {
            encounter_image_list.ImageSize = new Size(50, 50);
            list_encounter.LargeImageList = encounter_image_list;
            list_encounter.View = View.LargeIcon;

            //default images
            string down = System.Configuration.ConfigurationManager.AppSettings["install_path"] + "App_images\\standard_down.bmp";
            string dead = System.Configuration.ConfigurationManager.AppSettings["install_path"] + "App_images\\standard_dead.bmp";



            encounter_image_list.Images.Add("down", System.Drawing.Image.FromFile(down));
            encounter_image_list.Images.Add("dead", System.Drawing.Image.FromFile(dead));

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (list_encounter.SelectedItems.Count > 0)
            {
                current_encounter_view_index = list_encounter.SelectedItems[0].Index;

                rinse_information();

                Encounter_list_item li = (Encounter_list_item)list_encounter.SelectedItems[0];
                manipulation_creature = li.Encounter_object;

                set_creture_info();
                set_bodypart_info(new Body_part()); //We want to blank it out
                
            }
        }

        private void set_creture_info()
        {
            //Re-order the equipment list (and set initiative item name right now)
            lbl_curr_init_weapon.Text = manipulation_creature.get_current_initiative_weapon(current_initiative);
            
            //Set the new datasources
            creatureBindingSource.DataSource = manipulation_creature;
            skillsBindingSource.DataSource = manipulation_creature.Skills;
            weaponsBindingSource.DataSource = manipulation_creature.Weapons;

            //Refresh information
            refresh_base_information();
            refresh_part_information();

            //Redraw 
            Creature_drawing_handler.draw_body(manipulation_creature.Body,BackColor,ref graph);

        }

        private void set_bodypart_info(Body_part bp)
        {
            bodypartBindingSource.DataSource = bp;
        }

        private void clear_current_creature()
        {
            manipulation_creature = new Creature_repository().create_empty_creature();
            set_creture_info();
            rinse_information();
            clear_label_information();
        }

        private void refresh_base_information()
        {
            creatureBindingSource.ResetBindings(false);
        }

        private void refresh_part_information()
        {
            bodypartBindingSource.ResetBindings(false);
        }

        private void rinse_information()
        {
            //All the text boxes
            txt_damage.Text = "";
            txt_penetration.Text = "";
            txt_heal.Text = "";
            txt_sleep.Text = "";
            txt_add_ms.Text = "";
            txt_misc_skill_mod.Text = "";
            txt_dmg_to_parry.Text = "";
            txt_fire_result.ForeColor = Color.LightSlateGray;
        }

        private void clear_label_information()
        {
            //Health info area
            
            lbl_health.Text = "-";
            lbl_death_count.Text = "-";
            lbl_psych_health.Text = "-";
            lbl_mental_resonas.Text = "-";
            lbl_total_body_points.Text = "-";

            //Skill mods
            lbl_action_skill_mod.Text = "-";
            lbl_total_damage_mod.Text = "-";
            lbl_total_damage_mod_two_hand.Text = "-";
            lbl_armour_move_mod.Text = "-";
            lbl_armour_vision_mod.Text = "-";

            //Body part area
            lbl_total_abs.Text = "-";
            lbl_part_status.Text = "-";
            lbl_interval_start.Text = "-";
            lbl_interval_end.Text = "-";
            lbl_area.Text = "-";

            //Initiative info
            lbl_nr_prev_action.Text = "-";
            lbl_prev_action_mod.Text = "-";
            lbl_curr_init_weapon.Text = "-";
        }

        private void tbtn_load_character_Click(object sender, EventArgs e)
        {
            open_FD.Title = "Add Character";
            open_FD.FileName = "";
            open_FD.Filter = "XML|*.xml";
            open_FD.InitialDirectory = Path_util.get_creature_save_path(""); 

            if (open_FD.ShowDialog() != DialogResult.Cancel)
            {
                load_character(open_FD.FileName);
            }
        }

        private void load_character(string file_path)
        {
            Creature_repository cret_rep = new Creature_repository();
            
            add_to_encounter(cret_rep.load_humanoid(file_path), file_path);
        }

        private void add_to_encounter(Creature manipulation_creature, string file_path)
        {
            Encounter_list_item enc_item = new Encounter_list_item();

            if (!encounter_image_list.Images.ContainsKey(manipulation_creature.Image_path))
                encounter_image_list.Images.Add(manipulation_creature.Image_path, manipulation_creature.Image_instance);

            enc_item.ImageIndex = encounter_image_list.Images.IndexOfKey(manipulation_creature.Image_path);
            enc_item.Encounter_object = manipulation_creature;

            int number = 1;

            for (int i = 0; i < list_encounter.Items.Count; i++)
            {
                if (list_encounter.Items[i].ImageIndex == enc_item.ImageIndex)
                    number = Convert.ToInt32(list_encounter.Items[i].Text) + 1;
            }

            manipulation_creature.Clone_index = number;
            enc_item.Text = number.ToString();
            enc_item.Name = file_path;
            list_encounter.Items.AddRange(new Encounter_list_item[] { enc_item });    
                                
        }

        private void pic_canvas_MouseDown(object sender, MouseEventArgs e)
        {
            display_hit(new Point(e.X, e.Y));
        }

        private void display_hit(Point pnt)
        {
            bool found_area = false;

            for (int i = 0; i < manipulation_creature.Body.Body_parts.Count; i++)
            {
                Point[] pp = manipulation_creature.Body.Body_parts[i].Draw_points.ToArray();

                if (Creature_drawing_handler.IsInPolygon(pp, pnt))
                {
                    found_area = true;
                    Creature_drawing_handler.draw_body(manipulation_creature.Body, BackColor, ref graph); //redraw so that we do not have 2 red areas
                    Creature_drawing_handler.fill_polygon(manipulation_creature.Body.Body_parts[i].Draw_points, new SolidBrush(Color.Red), ref graph); // mark the area clicked reds

                    set_bodypart_info(manipulation_creature.Body.Body_parts[i]);

                    break;
                }
            }

            if (!found_area)
            {
                Creature_drawing_handler.draw_body(manipulation_creature.Body, BackColor, ref graph); //no marking
                set_bodypart_info(new Body_part());
            }

            txt_damage.Focus();
        }

        private void btn_damage_Click(object sender, EventArgs e)
        {
            int damage = Parse_utils.try_parse(txt_damage.Text);
            int pen = Parse_utils.try_parse(txt_penetration.Text);
            string area;

            if (manipulation_creature == null)
                return;

            if (Convert.ToString(lbl_area.Text) == "" || Convert.ToString(lbl_area.Text) == "-")
                area = "ALL";
            else
                area = lbl_area.Text;

            //Apply the single_fire_damage
            manipulation_creature.apply_damage(area, damage, pen);

            //Remove and refresh to avoid errors and to speed up.
            txt_damage.Text = "";       
            txt_penetration.Text = "";
            refresh_base_information();
            refresh_part_information();
            refresh_base_information();  

            Encounter_list_item li = (Encounter_list_item)list_encounter.Items[current_encounter_view_index];
            refresh_list_item_image(li);
            
        }

        private void txt_damage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if(txt_damage.Text.Length > 0)
                btn_damage.PerformClick();
            }

        }

        private void btn_heal_Click(object sender, EventArgs e)
        {
            if (manipulation_creature != null)
            {
                int heal = Parse_utils.try_parse(txt_heal.Text);
                manipulation_creature.heal_damage(heal);
                refresh_base_information();
            }
        }

        private void btn_new_round_Click(object sender, EventArgs e)
        {
            lbl_round.Text = Convert.ToString(Convert.ToInt32(lbl_round.Text)+1);
            make_round_end_calculations();
            refresh_base_information();
            current_initiative = 0;
            lst_initiative.SelectedIndices.Clear();
            recalc_initiative_list();
            update_encounter_list_initiative_color();
        }

        /// <summary>
        /// This method loops all loaded creatures and make them apply end of turn logic like bleeding,etc.
        /// </summary>
        private void make_round_end_calculations()
        {
            //loop all creatures in the list and do the round end calculations 
            foreach (Encounter_list_item li in list_encounter.Items)
            {
                li.Encounter_object.calculate_round_data();
                refresh_list_item_image(li);
            }
        }

        /// <summary>
        /// This method stops all bleeding and dying
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_stop_bleeding_Click(object sender, EventArgs e)
        {
            if (manipulation_creature != null)
            {
                manipulation_creature.stop_bleeding();
                refresh_base_information();
            }
        }

        private void refresh_list_item_image(Encounter_list_item li)
        {
            if (li.Encounter_object.General_health == "DEAD")
                li.ImageIndex = encounter_image_list.Images.IndexOfKey("dead");    
            else if( li.Encounter_object.Temp_body_points < 0)
                li.ImageIndex = encounter_image_list.Images.IndexOfKey("down");
            else
                li.ImageIndex = encounter_image_list.Images.IndexOfKey(li.Encounter_object.Image_path); 
        }

        private void btn_mend_part_Click(object sender, EventArgs e)
        {
            if (manipulation_creature != null)
            {
                manipulation_creature.mend_body_part(lbl_area.Text);
                refresh_base_information();
                refresh_part_information();
            }
        }

        private void btn_clone_Click(object sender, EventArgs e)
        {
            if (list_encounter.SelectedItems.Count > 0)
            {
                Encounter_list_item li = (Encounter_list_item)list_encounter.SelectedItems[0];
                Creature manipulation_creature = li.Encounter_object;
                string path = Path_util.check_creature_save_path(manipulation_creature.Template_path);
                if(path !="")
                    load_character(path);

                //otherwise do nothing for now
                    
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (list_encounter.SelectedItems.Count > 0)
            {
                list_encounter.SelectedItems[0].Remove();
            }
        }



        private void reload_weapon(int weapon_id)
        {
            string s;
            int index = -1;
            Weapon rw = manipulation_creature.Weapons.Find(o => o.Id == weapon_id);

            //Just a precaution so that we do not try to reload a non reloadable weapon.
            if (rw.Equipment_type.ToUpper() == "THROWN_WEAPON")
                return;

            foreach( Equipment eq in manipulation_creature.Equipment)
            {
                index += 1;
                s = eq.GetType().ToString();
                if (rw.Mag_type.ToUpper() == "LOOSE")
                {
                    if (eq.Equipment_type.ToUpper() == "MAGAZINE")
                    {
                        Magazine mg = (Magazine)eq;

                        if (mg.Calibre == rw.Calibre)
                        {
                            //load it into the weapon
                            rw.Magazine = mg;
                            rw.Slotted_shell_type = mg.Shell_type;

                            manipulation_creature.Equipment.RemoveAt(index);

                            break;
                        }
                    }
                }
                else //Right now the only alternative is an integrated magazine
                {
                    if (eq.Equipment_type.ToUpper() == "AMMUNITION")
                    { 
                        Ammo_pile ap = (Ammo_pile) eq;

                        if (rw.Calibre == ap.Calibre)
                        {
                            Magazine mg = new Magazine();
                            mg.Name = "Fill_mag";
                            mg.Equipment_type = "ammunition";
                            mg.Description = "autogenerated";
                            mg.Calibre = rw.Calibre;
                            mg.Max_projectiles = rw.Standard_mag;
                            mg.Shell_type = ap.Shell_type;

                            if (rw.Standard_mag > ap.Projectiles_left)
                            {
                                mg.Projectiles_left = ap.Projectiles_left;
                                ap.Projectiles_left -= ap.Projectiles_left;
                            }
                            else
                            {
                                mg.Projectiles_left = rw.Standard_mag;
                                ap.Projectiles_left -= rw.Standard_mag;
                            }

                            rw.Magazine = mg;
                            rw.Slotted_shell_type = mg.Shell_type;

                            //If the pile is empty then remove it
                            if (ap.Projectiles_left == 0)
                                manipulation_creature.Equipment.RemoveAt(index);

                            break;
                        }
                    }
                }
            }

            //This is an action, increase the modifications and refresh creature
            manipulation_creature.set_action_mod_increase();
            refresh_base_information();
        }

        private void un_jam_weapon(Weapon ranged_w)
        {
            ranged_w.un_jam();
            txt_fire_result.Text = "Un jammed";

            //This is an action, increase the modifications and refresh creature
            manipulation_creature.set_action_mod_increase();
            refresh_base_information();
        }

        private void fire_weapon(Weapon ranged_w)
        {
            //Get the skill modification 
            int modifier = Parse_utils.try_parse(txt_misc_skill_mod.Text);
            StringBuilder res_string = new StringBuilder();

            Skill_result sr = check_skill(ranged_w.Skill_range, modifier);
            Weapon_result wr = ranged_w.Fire_weapon(sr.Die_value);

            show_result(sr,wr);

            if (ranged_w.Equipment_type == "thrown_weapon")  //If it's a thrown weapon it's gone after a throw
                remove_from_equipment_list(ranged_w.Id);

        }

        private void remove_from_equipment_list(int equip_id)
        {
            int index;
            for (int i = 0; i < manipulation_creature.Equipment.Count; i++)
            {
                index = i;

                if (manipulation_creature.Equipment[i].Id == equip_id)
                {
                    manipulation_creature.Equipment.RemoveAt(index);
                    grid_weapons.Rows.Remove(grid_weapons.SelectedRows[0]);
                }
            }        
        }


        private void cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = sender as ComboBox;
            string fire_rate = cmb.SelectedItem.ToString();
            string weapon_name = grid_weapons.SelectedRows[0].Cells[1].Value.ToString();

            manipulation_creature.Weapons.Find(o=> o.Name == weapon_name).Selected_fire_rate = fire_rate;
        }

        private void Encounter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                tbtn_load_character_Click(this, e);
        }

        private void Encounter_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Encounter_KeyDown);
        }

        private void melee_attack(Weapon mw)
        {
            int modifier = Parse_utils.try_parse(txt_misc_skill_mod.Text);
            StringBuilder res_string = new StringBuilder();

            Skill_result sr = check_skill(mw.Skill_melee, modifier);

            Weapon_result wr = mw.strike(sr.Die_value, manipulation_creature.Damage_die);

            show_result(sr, wr);
        }

        private void parry_blow(Weapon mw)
        {
            int modifier = Parse_utils.try_parse(txt_misc_skill_mod.Text);
            int dmg_to_parry = Parse_utils.try_parse(txt_dmg_to_parry.Text);
            string dmg_type;
            int rem_dmg;
            string res_string = "";
            Skill_result sr;

            if (lst_parry_dmg_type.SelectedItem == null)
            {
                txt_fire_result.Text = "Ingen skadetyp vald";
                return;
            }
            else
                dmg_type = lst_parry_dmg_type.SelectedItem.ToString();

            sr = check_skill(mw.Skill_melee, modifier);

            if (sr.Result == "FAIL")
            {
                res_string = "Misslyckad parering" + Environment.NewLine;
                res_string += "Skada: " + Convert.ToString(dmg_to_parry);
                txt_fire_result.Text = res_string;
                return;
            }

            res_string = "Lyckad parering" + Environment.NewLine;

            rem_dmg = mw.parry(dmg_to_parry, dmg_type);

            if (mw.Status == "BROKEN")
                res_string = "Trasigt vapen" + Environment.NewLine;

            res_string += "Oparerad skada: " + Convert.ToString(rem_dmg);

            txt_fire_result.Text = res_string;
        }

        private void grid_skills_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Skill sk = (Skill)grid_skills.SelectedRows[0].DataBoundItem;

            if (e.ColumnIndex == grid_skills.Columns["use"].Index)
                use_skill(sk);
        }

        //Single point for skill check on a creature
        private Skill_result check_skill(string skillName, int modifier)
        {
            Skill_result sr = manipulation_creature.skill_check(skillName, modifier);
            refresh_base_information();
            recalc_initiative_list(); 
            update_encounter_list_initiative_color();
            return sr;
        }

        //Direct usage of skill
        private void use_skill(Skill sk)
        {
            int modifier = Parse_utils.try_parse(txt_misc_skill_mod.Text);
            Skill_result sr = check_skill(sk.Name, modifier);
            refresh_base_information();
            show_result(sr,null);
        }

        private void show_result(Skill_result sr, Weapon_result wr)
        { 
            StringBuilder ret_string = new StringBuilder();

            if (wr != null && wr.Status == "BROKEN")
                ret_string.Append("Vapnet sönder");
            else
            {
                ret_string.Append("Resultat: ");

                switch (sr.Result)
                {
                    case "SUCCESS":
                        ret_string.Append("LYCKAT");
                        break;
                    case "FAIL":
                        ret_string.Append("MISSLYCKAT");
                        break;
                    case "PERFECT":
                        ret_string.Append("PERFEKT");
                        break;
                    case "FUMBLE":
                        ret_string.Append("FUMMEL");
                        break;
                }

                ret_string.Append(" " + sr.Die_value.ToString() + "/" + sr.Modified_skill_value.ToString() + " (" + sr.Skill_die_diff.ToString() + ")");

                if (wr != null)
                {
                    ret_string.Append(Environment.NewLine);

                    ret_string.Append("Område: " + Convert.ToString(wr.Area) + Environment.NewLine);

                    foreach (Damage dm in wr.Damage)
                    {
                        ret_string.Append("Skada: " + dm.Damage_type + " " + dm.Damage_value + Environment.NewLine);
                    }
                }
                
            }

            txt_fire_result.ForeColor = Color.Black;

            txt_fire_result.Text = ret_string.ToString();
        }

        private void btn_show_abilities_Click(object sender, EventArgs e)
        {
            if (manipulation_creature != null)
            {
                Special_ability_selector sas = new Special_ability_selector(manipulation_creature.Special_abilities);
                sas.Show();
            }
        }

        private void btn_equipment_Click(object sender, EventArgs e)
        {
            if (manipulation_creature != null)
            {
                Equipment_selector eqs = new Equipment_selector(manipulation_creature.Equipment);
                eqs.Show();
            }
        }

        private void tbtn_save_encounter_Click(object sender, EventArgs e)
        {
            Creature_repository c_rep = new Creature_repository();
            List<Creature> cret_list = new List<Creature>();
            string base_path = Path_util.get_encounter_save_path(""); 
            FolderBrowserDialog esd = new FolderBrowserDialog();
            esd.SelectedPath = base_path;
            
            foreach (Encounter_list_item e_item in list_encounter.Items)
            {
                cret_list.Add(e_item.Encounter_object);
            }

            if (esd.ShowDialog() != DialogResult.Cancel)
                c_rep.save_Encounter(cret_list, esd.SelectedPath + "\\");
                        
        }

        private void tbtn_load_encounter_Click(object sender, EventArgs e)
        {
            Creature_repository c_rep = new Creature_repository();
            List<Creature> cret_list = new List<Creature>();
            string base_path = Path_util.get_encounter_save_path(""); 
            string encounter_name = "";
            FolderBrowserDialog eld = new FolderBrowserDialog();
            eld.SelectedPath = base_path;

            if (eld.ShowDialog() != DialogResult.Cancel)
                encounter_name = eld.SelectedPath;

            cret_list = c_rep.load_encounter(encounter_name);

            foreach (Creature c in cret_list)
            {
                add_to_encounter(c, eld.SelectedPath + "\\" +c.Name + ".xml");
            }

        }

        private void txt_heal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txt_heal.Text.Length > 0)
                    btn_heal.PerformClick();
            }
        }

        private void btn_wake_up_Click(object sender, EventArgs e)
        {
            if (manipulation_creature != null)
            {
                manipulation_creature.wake_up();
                refresh_base_information();
            }
        }

        private void btn_sleep_Click(object sender, EventArgs e)
        {
            if (manipulation_creature != null)
            {
                manipulation_creature.knock_out(Parse_utils.try_parse(txt_sleep.Text));
                refresh_base_information();
            }
        }

        private void btn_add_ms_Click(object sender, EventArgs e)
        {
            if (manipulation_creature != null)
            {
                manipulation_creature.Mental_resonans += Parse_utils.try_parse(txt_add_ms.Text);
                refresh_base_information();
            }
        }

        private void grid_resonans_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Resonans_effect re = (Resonans_effect)grid_resonans.SelectedRows[0].DataBoundItem;

            if (e.ColumnIndex == grid_resonans.Columns["extra_info"].Index)
            {
                write_txt_line_from_dictionary(re.get_stat_summary_list());
            }
        }

        private void write_txt_line_from_dictionary(ListDictionary l_descrip)
        {
            txt_fire_result.Text = "";

            foreach (DictionaryEntry de in l_descrip)
            {
                txt_fire_result.AppendText(de.Key + ": " + de.Value);
                txt_fire_result.AppendText(Environment.NewLine);
            }
        }
        
        private void btn_calc_initiative_Click(object sender, EventArgs e)
        {
            //First of make all creatures get a base initiative
            Random rand = new Random();

            foreach (Encounter_list_item li in list_encounter.Items)
            { 
                li.Encounter_object.calculate_base_initiative(ref rand);
            }
            //Then do the final calculations
            recalc_initiative_list();

        }

        private void grid_weapons_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Weapon rw = (Weapon)grid_weapons.SelectedRows[0].DataBoundItem;

            if (e.ColumnIndex == grid_weapons.Columns["range_fire"].Index)
            {
                fire_weapon((Weapon)grid_weapons.SelectedRows[0].DataBoundItem);
            }
            else if (e.ColumnIndex == grid_weapons.Columns["weapon_reload"].Index)
            {
                reload_weapon(Convert.ToInt32(grid_weapons.SelectedRows[0].Cells[0].Value));
            }
            else if (e.ColumnIndex == grid_weapons.Columns["weapon_mend"].Index)
            {
                un_jam_weapon((Weapon)grid_weapons.SelectedRows[0].DataBoundItem);
            }
            else if (e.ColumnIndex == grid_weapons.Columns["melee_fire"].Index)
            {
                melee_attack((Weapon)grid_weapons.SelectedRows[0].DataBoundItem);
            }
            else if (e.ColumnIndex == grid_weapons.Columns["weapon_parry"].Index)
            {
                parry_blow((Weapon)grid_weapons.SelectedRows[0].DataBoundItem);
            }
            else if (e.ColumnIndex == grid_weapons.Columns["Held_by_main_hand"].Index)
            {
                if (rw.Held_by_main_hand == "N")
                    rw.Held_by_main_hand = "Y";
                else
                    rw.Held_by_main_hand = "N";

                recalc_initiative_list();
            }
            else if (e.ColumnIndex == grid_weapons.Columns["Held_by_secondary_hand"].Index)
            {
                if (rw.Held_by_secondary_hand == "N")
                    rw.Held_by_secondary_hand = "Y";
                else
                    rw.Held_by_secondary_hand = "N";
                
                recalc_initiative_list();
            }
            else if (e.ColumnIndex == grid_weapons.Columns["In_secondary_use"].Index)
            {
                if (rw.In_secondary_use == "N")
                    rw.In_secondary_use = "Y";
                else
                    rw.In_secondary_use = "N";

                recalc_initiative_list();
            }
            weaponsBindingSource.ResetBindings(false);
            grid_weapons.Refresh();
        }
        
        private void grid_weapons_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            ComboBox cmb = e.Control as ComboBox;

            cmb.SelectedIndexChanged -= new EventHandler(cmb_SelectedIndexChanged);
            cmb.SelectedIndexChanged += new EventHandler(cmb_SelectedIndexChanged);

            string weapon_name = grid_weapons.SelectedRows[0].Cells[1].Value.ToString();

            //Below makes sure that we only have the correct fire rates in the combobox for the selected weapon. - A bit awkward yes but can be changed later.
            cmb.Items.Clear();

            foreach (string fire_rate in manipulation_creature.Weapons.Find(o => o.Name == weapon_name).Available_fire_rates)
            {
                cmb.Items.Add(fire_rate);
            }

            cmb.SelectedItem = manipulation_creature.Weapons.Find(o => o.Name == weapon_name).Selected_fire_rate;
        }

        private void lst_initiative_SelectedIndexChanged(object sender, EventArgs e)
        {
            current_initiative = Convert.ToInt32(lst_initiative.SelectedItem);
            clear_current_creature();
            list_encounter.SelectedIndices.Clear();
            update_encounter_list_initiative_color();
        }

        private void recalc_initiative_list()
        {
            lst_initiative.Items.Clear(); //clear out the old initiatives
            List<int> init_list = new List<int>();

            foreach (Encounter_list_item li in list_encounter.Items) //for every creature in the list
            {
                li.Encounter_object.calculate_round_initiative(); // Calculate the creatures initiative(s)

                foreach (Initiative_item ii in li.Encounter_object.Initiative_list) //Go trough the initiatives
                {
                    if (!init_list.Contains(ii.Initiative)) //add any non existing initiatives in the init list
                        init_list.Add(ii.Initiative);

                    refresh_list_item_image(li);
                }
            }

            init_list.Sort((a, b) => -1 * a.CompareTo(b));  //sort descending all initiatives

            foreach (int ini in init_list)
                lst_initiative.Items.Add(ini);
        }

        private void update_encounter_list_initiative_color()
        {
            int initiative = current_initiative; // Set to current so that we can keep color encoding.

            for (int i = 0; i < list_encounter.Items.Count; i++)
            {
                Creature cret = ((Encounter_list_item)list_encounter.Items[i]).Encounter_object;

                if (cret.Initiative_list.Exists(a => a.Initiative == initiative))
                {
                    if (cret.Round_actions_taken == 0)
                        list_encounter.Items[i].BackColor = Color.Green;
                    else if (cret.Round_actions_taken == 1)
                        list_encounter.Items[i].BackColor = Color.Blue;
                    else if (cret.Round_actions_taken == 2)
                        list_encounter.Items[i].BackColor = Color.Yellow;
                    else if (cret.Round_actions_taken == 3)
                        list_encounter.Items[i].BackColor = Color.Red;
                    else if (cret.Round_actions_taken > 3)
                        list_encounter.Items[i].BackColor = Color.Gray;
                }
                else
                {
                    if (cret.Round_actions_taken > 3)
                        list_encounter.Items[i].BackColor = Color.Gray;  //So we can see that more and more reach their end of attacks
                    else
                        list_encounter.Items[i].BackColor = Color.White;
                }
                    
            }        
        }

        private void btn_edit_creature_Click(object sender, EventArgs e)
        {
            if (manipulation_creature != null)
            {
                Creature_manipulation edit_cret = new Creature_manipulation(ref manipulation_creature);

                edit_cret.ShowDialog(); //Show and wait for finish 

                set_creture_info(); //Update the creature so the changes shows
            }
        }

    }
}
