namespace MPC4
{
    partial class Ability_creator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ability_creator));
            this.lbl_name_head = new System.Windows.Forms.Label();
            this.lbl_activation_head = new System.Windows.Forms.Label();
            this.lbl_range_head = new System.Windows.Forms.Label();
            this.lbl_effect_head = new System.Windows.Forms.Label();
            this.lbl_duration_head = new System.Windows.Forms.Label();
            this.lbl_description_head = new System.Windows.Forms.Label();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.specialabilityBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txt_activation = new System.Windows.Forms.TextBox();
            this.txt_range = new System.Windows.Forms.TextBox();
            this.txt_effect = new System.Windows.Forms.TextBox();
            this.txt_duration = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.txt_description = new System.Windows.Forms.TextBox();
            this.btn_save = new System.Windows.Forms.Button();
            this.grp_base = new System.Windows.Forms.GroupBox();
            this.grp_skill = new System.Windows.Forms.GroupBox();
            this.cmb_base_attrib = new System.Windows.Forms.ComboBox();
            this.skillBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lbl_ability_name_head = new System.Windows.Forms.Label();
            this.lbl_base_head = new System.Windows.Forms.Label();
            this.txt_skill_name = new System.Windows.Forms.TextBox();
            this.chk_gives_skill = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.specialabilityBindingSource)).BeginInit();
            this.grp_base.SuspendLayout();
            this.grp_skill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.skillBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_name_head
            // 
            this.lbl_name_head.AutoSize = true;
            this.lbl_name_head.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_name_head.Location = new System.Drawing.Point(6, 16);
            this.lbl_name_head.Name = "lbl_name_head";
            this.lbl_name_head.Size = new System.Drawing.Size(43, 13);
            this.lbl_name_head.TabIndex = 0;
            this.lbl_name_head.Text = "Namn:";
            // 
            // lbl_activation_head
            // 
            this.lbl_activation_head.AutoSize = true;
            this.lbl_activation_head.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_activation_head.Location = new System.Drawing.Point(6, 43);
            this.lbl_activation_head.Name = "lbl_activation_head";
            this.lbl_activation_head.Size = new System.Drawing.Size(68, 13);
            this.lbl_activation_head.TabIndex = 0;
            this.lbl_activation_head.Text = "Aktivering:";
            // 
            // lbl_range_head
            // 
            this.lbl_range_head.AutoSize = true;
            this.lbl_range_head.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_range_head.Location = new System.Drawing.Point(6, 69);
            this.lbl_range_head.Name = "lbl_range_head";
            this.lbl_range_head.Size = new System.Drawing.Size(65, 13);
            this.lbl_range_head.TabIndex = 0;
            this.lbl_range_head.Text = "Räckvidd:";
            // 
            // lbl_effect_head
            // 
            this.lbl_effect_head.AutoSize = true;
            this.lbl_effect_head.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_effect_head.Location = new System.Drawing.Point(6, 93);
            this.lbl_effect_head.Name = "lbl_effect_head";
            this.lbl_effect_head.Size = new System.Drawing.Size(45, 13);
            this.lbl_effect_head.TabIndex = 0;
            this.lbl_effect_head.Text = "Effekt:";
            // 
            // lbl_duration_head
            // 
            this.lbl_duration_head.AutoSize = true;
            this.lbl_duration_head.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_duration_head.Location = new System.Drawing.Point(6, 116);
            this.lbl_duration_head.Name = "lbl_duration_head";
            this.lbl_duration_head.Size = new System.Drawing.Size(76, 13);
            this.lbl_duration_head.TabIndex = 0;
            this.lbl_duration_head.Text = "Varaktighet:";
            // 
            // lbl_description_head
            // 
            this.lbl_description_head.AutoSize = true;
            this.lbl_description_head.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_description_head.Location = new System.Drawing.Point(6, 143);
            this.lbl_description_head.Name = "lbl_description_head";
            this.lbl_description_head.Size = new System.Drawing.Size(77, 13);
            this.lbl_description_head.TabIndex = 0;
            this.lbl_description_head.Text = "Beskrivning:";
            // 
            // txt_name
            // 
            this.txt_name.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.specialabilityBindingSource, "Name", true));
            this.txt_name.Location = new System.Drawing.Point(88, 13);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(178, 20);
            this.txt_name.TabIndex = 1;
            // 
            // specialabilityBindingSource
            // 
            this.specialabilityBindingSource.DataSource = typeof(MPC4.classes.Special_ability);
            // 
            // txt_activation
            // 
            this.txt_activation.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.specialabilityBindingSource, "Activation", true));
            this.txt_activation.Location = new System.Drawing.Point(88, 39);
            this.txt_activation.Name = "txt_activation";
            this.txt_activation.Size = new System.Drawing.Size(178, 20);
            this.txt_activation.TabIndex = 2;
            // 
            // txt_range
            // 
            this.txt_range.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.specialabilityBindingSource, "Range", true));
            this.txt_range.Location = new System.Drawing.Point(88, 65);
            this.txt_range.Name = "txt_range";
            this.txt_range.Size = new System.Drawing.Size(178, 20);
            this.txt_range.TabIndex = 3;
            // 
            // txt_effect
            // 
            this.txt_effect.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.specialabilityBindingSource, "Effect", true));
            this.txt_effect.Location = new System.Drawing.Point(88, 89);
            this.txt_effect.Name = "txt_effect";
            this.txt_effect.Size = new System.Drawing.Size(178, 20);
            this.txt_effect.TabIndex = 4;
            // 
            // txt_duration
            // 
            this.txt_duration.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.specialabilityBindingSource, "Duration", true));
            this.txt_duration.Location = new System.Drawing.Point(88, 113);
            this.txt_duration.Name = "txt_duration";
            this.txt_duration.Size = new System.Drawing.Size(178, 20);
            this.txt_duration.TabIndex = 5;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(9, 170);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(100, 20);
            this.textBox6.TabIndex = 1;
            // 
            // txt_description
            // 
            this.txt_description.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.specialabilityBindingSource, "Description", true));
            this.txt_description.Location = new System.Drawing.Point(9, 159);
            this.txt_description.Multiline = true;
            this.txt_description.Name = "txt_description";
            this.txt_description.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_description.Size = new System.Drawing.Size(257, 99);
            this.txt_description.TabIndex = 6;
            // 
            // btn_save
            // 
            this.btn_save.Image = global::MPC4._0.Properties.Resources.disc_icon2;
            this.btn_save.Location = new System.Drawing.Point(441, 232);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(50, 40);
            this.btn_save.TabIndex = 10;
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // grp_base
            // 
            this.grp_base.Controls.Add(this.lbl_name_head);
            this.grp_base.Controls.Add(this.txt_description);
            this.grp_base.Controls.Add(this.lbl_activation_head);
            this.grp_base.Controls.Add(this.textBox6);
            this.grp_base.Controls.Add(this.lbl_range_head);
            this.grp_base.Controls.Add(this.txt_duration);
            this.grp_base.Controls.Add(this.lbl_effect_head);
            this.grp_base.Controls.Add(this.txt_effect);
            this.grp_base.Controls.Add(this.lbl_duration_head);
            this.grp_base.Controls.Add(this.txt_range);
            this.grp_base.Controls.Add(this.lbl_description_head);
            this.grp_base.Controls.Add(this.txt_activation);
            this.grp_base.Controls.Add(this.txt_name);
            this.grp_base.Location = new System.Drawing.Point(7, 6);
            this.grp_base.Name = "grp_base";
            this.grp_base.Size = new System.Drawing.Size(276, 266);
            this.grp_base.TabIndex = 3;
            this.grp_base.TabStop = false;
            this.grp_base.Text = "Grund";
            // 
            // grp_skill
            // 
            this.grp_skill.Controls.Add(this.cmb_base_attrib);
            this.grp_skill.Controls.Add(this.lbl_ability_name_head);
            this.grp_skill.Controls.Add(this.lbl_base_head);
            this.grp_skill.Controls.Add(this.txt_skill_name);
            this.grp_skill.Location = new System.Drawing.Point(291, 6);
            this.grp_skill.Name = "grp_skill";
            this.grp_skill.Size = new System.Drawing.Size(200, 85);
            this.grp_skill.TabIndex = 4;
            this.grp_skill.TabStop = false;
            // 
            // cmb_base_attrib
            // 
            this.cmb_base_attrib.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.skillBindingSource, "Skill_base_attribute", true));
            this.cmb_base_attrib.Enabled = false;
            this.cmb_base_attrib.FormattingEnabled = true;
            this.cmb_base_attrib.Items.AddRange(new object[] {
            "STY",
            "FYS",
            "STO",
            "SMI",
            "INT",
            "VIL",
            "PER"});
            this.cmb_base_attrib.Location = new System.Drawing.Point(84, 51);
            this.cmb_base_attrib.Name = "cmb_base_attrib";
            this.cmb_base_attrib.Size = new System.Drawing.Size(110, 21);
            this.cmb_base_attrib.TabIndex = 9;
            // 
            // skillBindingSource
            // 
            this.skillBindingSource.DataSource = typeof(MPC4.classes.Skill);
            // 
            // lbl_ability_name_head
            // 
            this.lbl_ability_name_head.AutoSize = true;
            this.lbl_ability_name_head.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ability_name_head.Location = new System.Drawing.Point(6, 27);
            this.lbl_ability_name_head.Name = "lbl_ability_name_head";
            this.lbl_ability_name_head.Size = new System.Drawing.Size(43, 13);
            this.lbl_ability_name_head.TabIndex = 0;
            this.lbl_ability_name_head.Text = "Namn:";
            // 
            // lbl_base_head
            // 
            this.lbl_base_head.AutoSize = true;
            this.lbl_base_head.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_base_head.Location = new System.Drawing.Point(6, 54);
            this.lbl_base_head.Name = "lbl_base_head";
            this.lbl_base_head.Size = new System.Drawing.Size(72, 13);
            this.lbl_base_head.TabIndex = 0;
            this.lbl_base_head.Text = "Basattribut:";
            // 
            // txt_skill_name
            // 
            this.txt_skill_name.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.skillBindingSource, "Name", true));
            this.txt_skill_name.Enabled = false;
            this.txt_skill_name.Location = new System.Drawing.Point(84, 24);
            this.txt_skill_name.Name = "txt_skill_name";
            this.txt_skill_name.Size = new System.Drawing.Size(110, 20);
            this.txt_skill_name.TabIndex = 8;
            // 
            // chk_gives_skill
            // 
            this.chk_gives_skill.AutoSize = true;
            this.chk_gives_skill.Location = new System.Drawing.Point(300, 6);
            this.chk_gives_skill.Name = "chk_gives_skill";
            this.chk_gives_skill.Size = new System.Drawing.Size(70, 17);
            this.chk_gives_skill.TabIndex = 7;
            this.chk_gives_skill.Text = "Färdighet";
            this.chk_gives_skill.UseVisualStyleBackColor = true;
            this.chk_gives_skill.CheckedChanged += new System.EventHandler(this.chk_gives_skill_CheckedChanged);
            // 
            // Ability_creator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 276);
            this.Controls.Add(this.chk_gives_skill);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.grp_skill);
            this.Controls.Add(this.grp_base);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Ability_creator";
            this.Text = "Egenskaper";
            ((System.ComponentModel.ISupportInitialize)(this.specialabilityBindingSource)).EndInit();
            this.grp_base.ResumeLayout(false);
            this.grp_base.PerformLayout();
            this.grp_skill.ResumeLayout(false);
            this.grp_skill.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.skillBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_name_head;
        private System.Windows.Forms.Label lbl_activation_head;
        private System.Windows.Forms.Label lbl_range_head;
        private System.Windows.Forms.Label lbl_effect_head;
        private System.Windows.Forms.Label lbl_duration_head;
        private System.Windows.Forms.Label lbl_description_head;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.TextBox txt_activation;
        private System.Windows.Forms.TextBox txt_range;
        private System.Windows.Forms.TextBox txt_effect;
        private System.Windows.Forms.TextBox txt_duration;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox txt_description;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.BindingSource specialabilityBindingSource;
        private System.Windows.Forms.GroupBox grp_base;
        private System.Windows.Forms.GroupBox grp_skill;
        private System.Windows.Forms.Label lbl_ability_name_head;
        private System.Windows.Forms.Label lbl_base_head;
        private System.Windows.Forms.ComboBox cmb_base_attrib;
        private System.Windows.Forms.TextBox txt_skill_name;
        private System.Windows.Forms.CheckBox chk_gives_skill;
        private System.Windows.Forms.BindingSource skillBindingSource;
    }
}