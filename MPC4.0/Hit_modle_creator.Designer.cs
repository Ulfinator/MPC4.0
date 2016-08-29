namespace MPC4
{
    partial class Hit_modle_creator
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Hit_modle_creator));
            this.pic_tracer = new System.Windows.Forms.PictureBox();
            this.pic_hit_modle = new System.Windows.Forms.PictureBox();
            this.btn_load_tracer_img = new System.Windows.Forms.Button();
            this.open_FD = new System.Windows.Forms.OpenFileDialog();
            this.lbl_name = new System.Windows.Forms.Label();
            this.lbl_part_type = new System.Windows.Forms.Label();
            this.lbl_hit_die_start = new System.Windows.Forms.Label();
            this.lbl_hit_die_end = new System.Windows.Forms.Label();
            this.lbl_drawpoint_x = new System.Windows.Forms.Label();
            this.lbl_drawpoint_y = new System.Windows.Forms.Label();
            this.lbl_mod_damage_all = new System.Windows.Forms.Label();
            this.lbl_mod_damage_two_hand = new System.Windows.Forms.Label();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.txt_die_start = new System.Windows.Forms.TextBox();
            this.txt_die_end = new System.Windows.Forms.TextBox();
            this.txt_draw_point_x = new System.Windows.Forms.TextBox();
            this.txt_draw_point_y = new System.Windows.Forms.TextBox();
            this.txt_mod_dmg_all = new System.Windows.Forms.TextBox();
            this.txt_mod_dmg_two_hand = new System.Windows.Forms.TextBox();
            this.btn_save_modle = new System.Windows.Forms.Button();
            this.btn_add_tracer_points = new System.Windows.Forms.Button();
            this.btn_scrap_modle = new System.Windows.Forms.Button();
            this.btn_load_modle = new System.Windows.Forms.Button();
            this.grp_area_description = new System.Windows.Forms.GroupBox();
            this.btn_scrap_body_part = new System.Windows.Forms.Button();
            this.cmb_part_type = new System.Windows.Forms.ComboBox();
            this.grp_modle_data = new System.Windows.Forms.GroupBox();
            this.cmb_modle_die = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_modle_name = new System.Windows.Forms.Label();
            this.txt_model_name = new System.Windows.Forms.TextBox();
            this.lbl_X_head = new System.Windows.Forms.Label();
            this.lbl_Y_head = new System.Windows.Forms.Label();
            this.lbl_X = new System.Windows.Forms.Label();
            this.lbl_Y = new System.Windows.Forms.Label();
            this.grid_draw_points = new System.Windows.Forms.DataGridView();
            this.drawpointsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.bodypartBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.xDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bodymodleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pic_tracer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_hit_modle)).BeginInit();
            this.grp_area_description.SuspendLayout();
            this.grp_modle_data.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_draw_points)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.drawpointsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bodypartBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bodymodleBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // pic_tracer
            // 
            this.pic_tracer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pic_tracer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pic_tracer.Cursor = System.Windows.Forms.Cursors.Default;
            this.pic_tracer.Location = new System.Drawing.Point(12, 12);
            this.pic_tracer.Name = "pic_tracer";
            this.pic_tracer.Size = new System.Drawing.Size(240, 395);
            this.pic_tracer.TabIndex = 0;
            this.pic_tracer.TabStop = false;
            this.pic_tracer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pic_tracer_MouseDown);
            this.pic_tracer.MouseLeave += new System.EventHandler(this.pic_tracer_MouseLeave);
            this.pic_tracer.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pic_tracer_MouseMove);
            // 
            // pic_hit_modle
            // 
            this.pic_hit_modle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pic_hit_modle.Location = new System.Drawing.Point(258, 12);
            this.pic_hit_modle.Name = "pic_hit_modle";
            this.pic_hit_modle.Size = new System.Drawing.Size(240, 395);
            this.pic_hit_modle.TabIndex = 1;
            this.pic_hit_modle.TabStop = false;
            this.pic_hit_modle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pic_hit_modle_MouseDown);
            // 
            // btn_load_tracer_img
            // 
            this.btn_load_tracer_img.Image = ((System.Drawing.Image)(resources.GetObject("btn_load_tracer_img.Image")));
            this.btn_load_tracer_img.Location = new System.Drawing.Point(132, 413);
            this.btn_load_tracer_img.Name = "btn_load_tracer_img";
            this.btn_load_tracer_img.Size = new System.Drawing.Size(57, 42);
            this.btn_load_tracer_img.TabIndex = 2;
            this.btn_load_tracer_img.UseVisualStyleBackColor = true;
            this.btn_load_tracer_img.Click += new System.EventHandler(this.btn_load_tracer_img_Click);
            // 
            // open_FD
            // 
            this.open_FD.FileName = "openFileDialog1";
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_name.Location = new System.Drawing.Point(515, 33);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(43, 13);
            this.lbl_name.TabIndex = 3;
            this.lbl_name.Text = "Namn:";
            // 
            // lbl_part_type
            // 
            this.lbl_part_type.AutoSize = true;
            this.lbl_part_type.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_part_type.Location = new System.Drawing.Point(515, 58);
            this.lbl_part_type.Name = "lbl_part_type";
            this.lbl_part_type.Size = new System.Drawing.Size(77, 13);
            this.lbl_part_type.TabIndex = 3;
            this.lbl_part_type.Text = "Områdestyp:";
            // 
            // lbl_hit_die_start
            // 
            this.lbl_hit_die_start.AutoSize = true;
            this.lbl_hit_die_start.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_hit_die_start.Location = new System.Drawing.Point(515, 84);
            this.lbl_hit_die_start.Name = "lbl_hit_die_start";
            this.lbl_hit_die_start.Size = new System.Drawing.Size(85, 13);
            this.lbl_hit_die_start.TabIndex = 3;
            this.lbl_hit_die_start.Text = "Tärningsstart:";
            // 
            // lbl_hit_die_end
            // 
            this.lbl_hit_die_end.AutoSize = true;
            this.lbl_hit_die_end.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_hit_die_end.Location = new System.Drawing.Point(515, 111);
            this.lbl_hit_die_end.Name = "lbl_hit_die_end";
            this.lbl_hit_die_end.Size = new System.Drawing.Size(80, 13);
            this.lbl_hit_die_end.TabIndex = 3;
            this.lbl_hit_die_end.Text = "Tärningsslut:";
            // 
            // lbl_drawpoint_x
            // 
            this.lbl_drawpoint_x.AutoSize = true;
            this.lbl_drawpoint_x.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_drawpoint_x.Location = new System.Drawing.Point(515, 137);
            this.lbl_drawpoint_x.Name = "lbl_drawpoint_x";
            this.lbl_drawpoint_x.Size = new System.Drawing.Size(110, 13);
            this.lbl_drawpoint_x.TabIndex = 3;
            this.lbl_drawpoint_x.Text = "Ritpunkt täning X:";
            // 
            // lbl_drawpoint_y
            // 
            this.lbl_drawpoint_y.AutoSize = true;
            this.lbl_drawpoint_y.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_drawpoint_y.Location = new System.Drawing.Point(515, 167);
            this.lbl_drawpoint_y.Name = "lbl_drawpoint_y";
            this.lbl_drawpoint_y.Size = new System.Drawing.Size(114, 13);
            this.lbl_drawpoint_y.TabIndex = 3;
            this.lbl_drawpoint_y.Text = "Ritpunkt tärning Y:";
            // 
            // lbl_mod_damage_all
            // 
            this.lbl_mod_damage_all.AutoSize = true;
            this.lbl_mod_damage_all.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_mod_damage_all.Location = new System.Drawing.Point(515, 193);
            this.lbl_mod_damage_all.Name = "lbl_mod_damage_all";
            this.lbl_mod_damage_all.Size = new System.Drawing.Size(100, 13);
            this.lbl_mod_damage_all.TabIndex = 3;
            this.lbl_mod_damage_all.Text = "Mod damage all:";
            // 
            // lbl_mod_damage_two_hand
            // 
            this.lbl_mod_damage_two_hand.AutoSize = true;
            this.lbl_mod_damage_two_hand.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_mod_damage_two_hand.Location = new System.Drawing.Point(515, 223);
            this.lbl_mod_damage_two_hand.Name = "lbl_mod_damage_two_hand";
            this.lbl_mod_damage_two_hand.Size = new System.Drawing.Size(139, 13);
            this.lbl_mod_damage_two_hand.TabIndex = 3;
            this.lbl_mod_damage_two_hand.Text = "Mod damage two hand:";
            // 
            // txt_name
            // 
            this.txt_name.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bodypartBindingSource, "Name", true));
            this.txt_name.Location = new System.Drawing.Point(659, 28);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(100, 20);
            this.txt_name.TabIndex = 4;
            // 
            // txt_die_start
            // 
            this.txt_die_start.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bodypartBindingSource, "Hit_die_start", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txt_die_start.Location = new System.Drawing.Point(702, 81);
            this.txt_die_start.Name = "txt_die_start";
            this.txt_die_start.Size = new System.Drawing.Size(57, 20);
            this.txt_die_start.TabIndex = 6;
            this.txt_die_start.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_die_start_KeyUp);
            // 
            // txt_die_end
            // 
            this.txt_die_end.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bodypartBindingSource, "Hit_die_end", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txt_die_end.Location = new System.Drawing.Point(702, 107);
            this.txt_die_end.Name = "txt_die_end";
            this.txt_die_end.Size = new System.Drawing.Size(57, 20);
            this.txt_die_end.TabIndex = 7;
            this.txt_die_end.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_die_end_KeyUp);
            // 
            // txt_draw_point_x
            // 
            this.txt_draw_point_x.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bodypartBindingSource, "Point_X", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txt_draw_point_x.Location = new System.Drawing.Point(702, 134);
            this.txt_draw_point_x.Name = "txt_draw_point_x";
            this.txt_draw_point_x.Size = new System.Drawing.Size(57, 20);
            this.txt_draw_point_x.TabIndex = 8;
            this.txt_draw_point_x.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_draw_point_x_KeyUp);
            // 
            // txt_draw_point_y
            // 
            this.txt_draw_point_y.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bodypartBindingSource, "Point_Y", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txt_draw_point_y.Location = new System.Drawing.Point(702, 164);
            this.txt_draw_point_y.Name = "txt_draw_point_y";
            this.txt_draw_point_y.Size = new System.Drawing.Size(57, 20);
            this.txt_draw_point_y.TabIndex = 9;
            this.txt_draw_point_y.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_draw_point_y_KeyUp);
            // 
            // txt_mod_dmg_all
            // 
            this.txt_mod_dmg_all.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bodypartBindingSource, "Mod_damage_all", true));
            this.txt_mod_dmg_all.Location = new System.Drawing.Point(702, 190);
            this.txt_mod_dmg_all.Name = "txt_mod_dmg_all";
            this.txt_mod_dmg_all.Size = new System.Drawing.Size(57, 20);
            this.txt_mod_dmg_all.TabIndex = 10;
            // 
            // txt_mod_dmg_two_hand
            // 
            this.txt_mod_dmg_two_hand.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bodypartBindingSource, "Mod_damage_two_hand", true));
            this.txt_mod_dmg_two_hand.Location = new System.Drawing.Point(702, 219);
            this.txt_mod_dmg_two_hand.Name = "txt_mod_dmg_two_hand";
            this.txt_mod_dmg_two_hand.Size = new System.Drawing.Size(57, 20);
            this.txt_mod_dmg_two_hand.TabIndex = 11;
            // 
            // btn_save_modle
            // 
            this.btn_save_modle.Image = ((System.Drawing.Image)(resources.GetObject("btn_save_modle.Image")));
            this.btn_save_modle.Location = new System.Drawing.Point(175, 80);
            this.btn_save_modle.Name = "btn_save_modle";
            this.btn_save_modle.Size = new System.Drawing.Size(57, 42);
            this.btn_save_modle.TabIndex = 12;
            this.btn_save_modle.Text = "Spara";
            this.btn_save_modle.UseVisualStyleBackColor = true;
            this.btn_save_modle.Click += new System.EventHandler(this.btn_save_modle_Click);
            // 
            // btn_add_tracer_points
            // 
            this.btn_add_tracer_points.Image = ((System.Drawing.Image)(resources.GetObject("btn_add_tracer_points.Image")));
            this.btn_add_tracer_points.Location = new System.Drawing.Point(195, 413);
            this.btn_add_tracer_points.Name = "btn_add_tracer_points";
            this.btn_add_tracer_points.Size = new System.Drawing.Size(57, 42);
            this.btn_add_tracer_points.TabIndex = 2;
            this.btn_add_tracer_points.UseVisualStyleBackColor = true;
            this.btn_add_tracer_points.Click += new System.EventHandler(this.btn_add_tracer_points_Click);
            // 
            // btn_scrap_modle
            // 
            this.btn_scrap_modle.Image = ((System.Drawing.Image)(resources.GetObject("btn_scrap_modle.Image")));
            this.btn_scrap_modle.Location = new System.Drawing.Point(9, 80);
            this.btn_scrap_modle.Name = "btn_scrap_modle";
            this.btn_scrap_modle.Size = new System.Drawing.Size(57, 42);
            this.btn_scrap_modle.TabIndex = 13;
            this.btn_scrap_modle.UseVisualStyleBackColor = true;
            this.btn_scrap_modle.Click += new System.EventHandler(this.btn_scrap_modle_Click);
            // 
            // btn_load_modle
            // 
            this.btn_load_modle.Image = ((System.Drawing.Image)(resources.GetObject("btn_load_modle.Image")));
            this.btn_load_modle.Location = new System.Drawing.Point(94, 80);
            this.btn_load_modle.Name = "btn_load_modle";
            this.btn_load_modle.Size = new System.Drawing.Size(57, 42);
            this.btn_load_modle.TabIndex = 14;
            this.btn_load_modle.UseVisualStyleBackColor = true;
            this.btn_load_modle.Click += new System.EventHandler(this.btn_load_modle_Click);
            // 
            // grp_area_description
            // 
            this.grp_area_description.Controls.Add(this.grid_draw_points);
            this.grp_area_description.Controls.Add(this.btn_scrap_body_part);
            this.grp_area_description.Controls.Add(this.cmb_part_type);
            this.grp_area_description.Location = new System.Drawing.Point(504, 12);
            this.grp_area_description.Name = "grp_area_description";
            this.grp_area_description.Size = new System.Drawing.Size(411, 279);
            this.grp_area_description.TabIndex = 15;
            this.grp_area_description.TabStop = false;
            this.grp_area_description.Text = "Områdesdata";
            // 
            // btn_scrap_body_part
            // 
            this.btn_scrap_body_part.Image = ((System.Drawing.Image)(resources.GetObject("btn_scrap_body_part.Image")));
            this.btn_scrap_body_part.Location = new System.Drawing.Point(198, 231);
            this.btn_scrap_body_part.Name = "btn_scrap_body_part";
            this.btn_scrap_body_part.Size = new System.Drawing.Size(57, 42);
            this.btn_scrap_body_part.TabIndex = 17;
            this.btn_scrap_body_part.UseVisualStyleBackColor = true;
            this.btn_scrap_body_part.Click += new System.EventHandler(this.btn_scrap_body_part_Click);
            // 
            // cmb_part_type
            // 
            this.cmb_part_type.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bodypartBindingSource, "Part_type", true));
            this.cmb_part_type.FormattingEnabled = true;
            this.cmb_part_type.Items.AddRange(new object[] {
            "HEAD",
            "TORSO",
            "ARM",
            "LEG"});
            this.cmb_part_type.Location = new System.Drawing.Point(155, 43);
            this.cmb_part_type.Name = "cmb_part_type";
            this.cmb_part_type.Size = new System.Drawing.Size(100, 21);
            this.cmb_part_type.TabIndex = 16;
            // 
            // grp_modle_data
            // 
            this.grp_modle_data.Controls.Add(this.btn_scrap_modle);
            this.grp_modle_data.Controls.Add(this.btn_load_modle);
            this.grp_modle_data.Controls.Add(this.cmb_modle_die);
            this.grp_modle_data.Controls.Add(this.label1);
            this.grp_modle_data.Controls.Add(this.btn_save_modle);
            this.grp_modle_data.Controls.Add(this.lbl_modle_name);
            this.grp_modle_data.Controls.Add(this.txt_model_name);
            this.grp_modle_data.Location = new System.Drawing.Point(504, 297);
            this.grp_modle_data.Name = "grp_modle_data";
            this.grp_modle_data.Size = new System.Drawing.Size(255, 144);
            this.grp_modle_data.TabIndex = 16;
            this.grp_modle_data.TabStop = false;
            this.grp_modle_data.Text = "Modelldata";
            // 
            // cmb_modle_die
            // 
            this.cmb_modle_die.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bodymodleBindingSource, "Modle_hit_die", true));
            this.cmb_modle_die.FormattingEnabled = true;
            this.cmb_modle_die.Items.AddRange(new object[] {
            "1T4",
            "1T6",
            "1T8",
            "1T10",
            "1T12",
            "1T20",
            "1T100"});
            this.cmb_modle_die.Location = new System.Drawing.Point(137, 53);
            this.cmb_modle_die.Name = "cmb_modle_die";
            this.cmb_modle_die.Size = new System.Drawing.Size(100, 21);
            this.cmb_modle_die.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Tärningstyp:";
            // 
            // lbl_modle_name
            // 
            this.lbl_modle_name.AutoSize = true;
            this.lbl_modle_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_modle_name.Location = new System.Drawing.Point(11, 26);
            this.lbl_modle_name.Name = "lbl_modle_name";
            this.lbl_modle_name.Size = new System.Drawing.Size(78, 13);
            this.lbl_modle_name.TabIndex = 17;
            this.lbl_modle_name.Text = "Modellnamn:";
            // 
            // txt_model_name
            // 
            this.txt_model_name.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bodymodleBindingSource, "Modle_name", true));
            this.txt_model_name.Location = new System.Drawing.Point(137, 19);
            this.txt_model_name.Name = "txt_model_name";
            this.txt_model_name.Size = new System.Drawing.Size(100, 20);
            this.txt_model_name.TabIndex = 17;
            // 
            // lbl_X_head
            // 
            this.lbl_X_head.AutoSize = true;
            this.lbl_X_head.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_X_head.Location = new System.Drawing.Point(13, 413);
            this.lbl_X_head.Name = "lbl_X_head";
            this.lbl_X_head.Size = new System.Drawing.Size(19, 13);
            this.lbl_X_head.TabIndex = 17;
            this.lbl_X_head.Text = "X:";
            // 
            // lbl_Y_head
            // 
            this.lbl_Y_head.AutoSize = true;
            this.lbl_Y_head.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Y_head.Location = new System.Drawing.Point(13, 435);
            this.lbl_Y_head.Name = "lbl_Y_head";
            this.lbl_Y_head.Size = new System.Drawing.Size(19, 13);
            this.lbl_Y_head.TabIndex = 18;
            this.lbl_Y_head.Text = "Y:";
            // 
            // lbl_X
            // 
            this.lbl_X.AutoSize = true;
            this.lbl_X.Location = new System.Drawing.Point(38, 413);
            this.lbl_X.Name = "lbl_X";
            this.lbl_X.Size = new System.Drawing.Size(10, 13);
            this.lbl_X.TabIndex = 19;
            this.lbl_X.Text = "-";
            // 
            // lbl_Y
            // 
            this.lbl_Y.AutoSize = true;
            this.lbl_Y.Location = new System.Drawing.Point(38, 435);
            this.lbl_Y.Name = "lbl_Y";
            this.lbl_Y.Size = new System.Drawing.Size(10, 13);
            this.lbl_Y.TabIndex = 20;
            this.lbl_Y.Text = "-";
            // 
            // grid_draw_points
            // 
            this.grid_draw_points.AutoGenerateColumns = false;
            this.grid_draw_points.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_draw_points.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.xDataGridViewTextBoxColumn,
            this.yDataGridViewTextBoxColumn});
            this.grid_draw_points.DataSource = this.drawpointsBindingSource;
            this.grid_draw_points.Location = new System.Drawing.Point(271, 16);
            this.grid_draw_points.Name = "grid_draw_points";
            this.grid_draw_points.RowHeadersWidth = 4;
            this.grid_draw_points.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.grid_draw_points.Size = new System.Drawing.Size(133, 255);
            this.grid_draw_points.TabIndex = 18;
            // 
            // drawpointsBindingSource
            // 
            this.drawpointsBindingSource.DataMember = "Draw_points";
            this.drawpointsBindingSource.DataSource = this.bodypartBindingSource;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.Location = new System.Drawing.Point(765, 323);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(159, 132);
            this.panel1.TabIndex = 21;
            // 
            // bodypartBindingSource
            // 
            this.bodypartBindingSource.DataSource = typeof(MPC4.classes.Body_part);
            // 
            // xDataGridViewTextBoxColumn
            // 
            this.xDataGridViewTextBoxColumn.DataPropertyName = "X";
            this.xDataGridViewTextBoxColumn.HeaderText = "X";
            this.xDataGridViewTextBoxColumn.Name = "xDataGridViewTextBoxColumn";
            this.xDataGridViewTextBoxColumn.Width = 50;
            // 
            // yDataGridViewTextBoxColumn
            // 
            this.yDataGridViewTextBoxColumn.DataPropertyName = "Y";
            this.yDataGridViewTextBoxColumn.HeaderText = "Y";
            this.yDataGridViewTextBoxColumn.Name = "yDataGridViewTextBoxColumn";
            this.yDataGridViewTextBoxColumn.Width = 50;
            // 
            // bodymodleBindingSource
            // 
            this.bodymodleBindingSource.DataSource = typeof(MPC4.classes.Body_modle);
            // 
            // Hit_modle_creator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 457);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbl_Y);
            this.Controls.Add(this.lbl_X);
            this.Controls.Add(this.lbl_Y_head);
            this.Controls.Add(this.lbl_X_head);
            this.Controls.Add(this.txt_mod_dmg_two_hand);
            this.Controls.Add(this.txt_mod_dmg_all);
            this.Controls.Add(this.txt_draw_point_y);
            this.Controls.Add(this.txt_draw_point_x);
            this.Controls.Add(this.txt_die_end);
            this.Controls.Add(this.txt_die_start);
            this.Controls.Add(this.txt_name);
            this.Controls.Add(this.lbl_mod_damage_two_hand);
            this.Controls.Add(this.lbl_mod_damage_all);
            this.Controls.Add(this.lbl_drawpoint_y);
            this.Controls.Add(this.lbl_drawpoint_x);
            this.Controls.Add(this.lbl_hit_die_end);
            this.Controls.Add(this.lbl_hit_die_start);
            this.Controls.Add(this.lbl_part_type);
            this.Controls.Add(this.lbl_name);
            this.Controls.Add(this.btn_add_tracer_points);
            this.Controls.Add(this.btn_load_tracer_img);
            this.Controls.Add(this.pic_hit_modle);
            this.Controls.Add(this.pic_tracer);
            this.Controls.Add(this.grp_area_description);
            this.Controls.Add(this.grp_modle_data);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Hit_modle_creator";
            this.Text = "Hit_modle_creator";
            ((System.ComponentModel.ISupportInitialize)(this.pic_tracer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_hit_modle)).EndInit();
            this.grp_area_description.ResumeLayout(false);
            this.grp_modle_data.ResumeLayout(false);
            this.grp_modle_data.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_draw_points)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.drawpointsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bodypartBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bodymodleBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pic_tracer;
        private System.Windows.Forms.PictureBox pic_hit_modle;
        private System.Windows.Forms.Button btn_load_tracer_img;
        private System.Windows.Forms.OpenFileDialog open_FD;
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.Label lbl_part_type;
        private System.Windows.Forms.Label lbl_hit_die_start;
        private System.Windows.Forms.Label lbl_hit_die_end;
        private System.Windows.Forms.Label lbl_drawpoint_x;
        private System.Windows.Forms.Label lbl_drawpoint_y;
        private System.Windows.Forms.Label lbl_mod_damage_all;
        private System.Windows.Forms.Label lbl_mod_damage_two_hand;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.TextBox txt_die_start;
        private System.Windows.Forms.TextBox txt_die_end;
        private System.Windows.Forms.TextBox txt_draw_point_x;
        private System.Windows.Forms.TextBox txt_draw_point_y;
        private System.Windows.Forms.TextBox txt_mod_dmg_all;
        private System.Windows.Forms.TextBox txt_mod_dmg_two_hand;
        private System.Windows.Forms.BindingSource bodypartBindingSource;
        private System.Windows.Forms.Button btn_save_modle;
        private System.Windows.Forms.Button btn_add_tracer_points;
        private System.Windows.Forms.Button btn_scrap_modle;
        private System.Windows.Forms.Button btn_load_modle;
        private System.Windows.Forms.GroupBox grp_area_description;
        private System.Windows.Forms.ComboBox cmb_part_type;
        private System.Windows.Forms.GroupBox grp_modle_data;
        private System.Windows.Forms.Label lbl_modle_name;
        private System.Windows.Forms.TextBox txt_model_name;
        private System.Windows.Forms.ComboBox cmb_modle_die;
        private System.Windows.Forms.BindingSource bodymodleBindingSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_scrap_body_part;
        private System.Windows.Forms.Label lbl_X_head;
        private System.Windows.Forms.Label lbl_Y_head;
        private System.Windows.Forms.Label lbl_X;
        private System.Windows.Forms.Label lbl_Y;
        private System.Windows.Forms.DataGridView grid_draw_points;
        private System.Windows.Forms.BindingSource drawpointsBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn xDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn yDataGridViewTextBoxColumn;
        private System.Windows.Forms.Panel panel1;

    }
}