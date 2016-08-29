namespace MPC4
{
    partial class Special_ability_selector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Special_ability_selector));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.grp_special_abilitys = new System.Windows.Forms.GroupBox();
            this.btn_edit_ability = new System.Windows.Forms.Button();
            this.btn_remove_ability = new System.Windows.Forms.Button();
            this.btn_new_ability = new System.Windows.Forms.Button();
            this.grid_special_abilities = new System.Windows.Forms.DataGridView();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.activationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rangeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.effectDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.durationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.specialabilitiesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.abilitylisterBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.grp_description = new System.Windows.Forms.GroupBox();
            this.rtxt_description = new System.Windows.Forms.RichTextBox();
            this.toolTip_control = new System.Windows.Forms.ToolTip(this.components);
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.grp_special_abilitys.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_special_abilities)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.specialabilitiesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.abilitylisterBindingSource)).BeginInit();
            this.grp_description.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.grp_special_abilitys);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(5);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.grp_description);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(5);
            this.splitContainer1.Size = new System.Drawing.Size(550, 325);
            this.splitContainer1.SplitterDistance = 262;
            this.splitContainer1.TabIndex = 0;
            // 
            // grp_special_abilitys
            // 
            this.grp_special_abilitys.Controls.Add(this.btn_edit_ability);
            this.grp_special_abilitys.Controls.Add(this.btn_remove_ability);
            this.grp_special_abilitys.Controls.Add(this.btn_new_ability);
            this.grp_special_abilitys.Controls.Add(this.grid_special_abilities);
            this.grp_special_abilitys.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grp_special_abilitys.Location = new System.Drawing.Point(5, 5);
            this.grp_special_abilitys.Name = "grp_special_abilitys";
            this.grp_special_abilitys.Padding = new System.Windows.Forms.Padding(5);
            this.grp_special_abilitys.Size = new System.Drawing.Size(252, 315);
            this.grp_special_abilitys.TabIndex = 0;
            this.grp_special_abilitys.TabStop = false;
            this.grp_special_abilitys.Text = "Förmågor";
            // 
            // btn_edit_ability
            // 
            this.btn_edit_ability.Image = ((System.Drawing.Image)(resources.GetObject("btn_edit_ability.Image")));
            this.btn_edit_ability.Location = new System.Drawing.Point(102, 268);
            this.btn_edit_ability.Name = "btn_edit_ability";
            this.btn_edit_ability.Size = new System.Drawing.Size(50, 40);
            this.btn_edit_ability.TabIndex = 1;
            this.btn_edit_ability.UseVisualStyleBackColor = true;
            this.btn_edit_ability.Click += new System.EventHandler(this.btn_edit_ability_Click);
            // 
            // btn_remove_ability
            // 
            this.btn_remove_ability.Image = ((System.Drawing.Image)(resources.GetObject("btn_remove_ability.Image")));
            this.btn_remove_ability.Location = new System.Drawing.Point(5, 268);
            this.btn_remove_ability.Name = "btn_remove_ability";
            this.btn_remove_ability.Size = new System.Drawing.Size(50, 40);
            this.btn_remove_ability.TabIndex = 1;
            this.btn_remove_ability.UseVisualStyleBackColor = true;
            this.btn_remove_ability.Click += new System.EventHandler(this.btn_remove_ability_Click);
            // 
            // btn_new_ability
            // 
            this.btn_new_ability.Image = ((System.Drawing.Image)(resources.GetObject("btn_new_ability.Image")));
            this.btn_new_ability.Location = new System.Drawing.Point(197, 268);
            this.btn_new_ability.Name = "btn_new_ability";
            this.btn_new_ability.Size = new System.Drawing.Size(50, 40);
            this.btn_new_ability.TabIndex = 1;
            this.btn_new_ability.UseVisualStyleBackColor = true;
            this.btn_new_ability.Click += new System.EventHandler(this.btn_new_ability_Click);
            // 
            // grid_special_abilities
            // 
            this.grid_special_abilities.AllowUserToAddRows = false;
            this.grid_special_abilities.AllowUserToDeleteRows = false;
            this.grid_special_abilities.AllowUserToResizeColumns = false;
            this.grid_special_abilities.AllowUserToResizeRows = false;
            this.grid_special_abilities.AutoGenerateColumns = false;
            this.grid_special_abilities.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_special_abilities.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.activationDataGridViewTextBoxColumn,
            this.rangeDataGridViewTextBoxColumn,
            this.effectDataGridViewTextBoxColumn,
            this.durationDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn});
            this.grid_special_abilities.DataSource = this.specialabilitiesBindingSource;
            this.grid_special_abilities.Location = new System.Drawing.Point(5, 18);
            this.grid_special_abilities.Name = "grid_special_abilities";
            this.grid_special_abilities.RowHeadersWidth = 20;
            this.grid_special_abilities.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid_special_abilities.Size = new System.Drawing.Size(242, 246);
            this.grid_special_abilities.TabIndex = 0;
            this.grid_special_abilities.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_special_abilities_RowEnter);
            this.grid_special_abilities.MouseMove += new System.Windows.Forms.MouseEventHandler(this.grid_special_abilities_MouseMove);
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.Width = 220;
            // 
            // activationDataGridViewTextBoxColumn
            // 
            this.activationDataGridViewTextBoxColumn.DataPropertyName = "Activation";
            this.activationDataGridViewTextBoxColumn.HeaderText = "Activation";
            this.activationDataGridViewTextBoxColumn.Name = "activationDataGridViewTextBoxColumn";
            this.activationDataGridViewTextBoxColumn.Visible = false;
            // 
            // rangeDataGridViewTextBoxColumn
            // 
            this.rangeDataGridViewTextBoxColumn.DataPropertyName = "Range";
            this.rangeDataGridViewTextBoxColumn.HeaderText = "Range";
            this.rangeDataGridViewTextBoxColumn.Name = "rangeDataGridViewTextBoxColumn";
            this.rangeDataGridViewTextBoxColumn.Visible = false;
            // 
            // effectDataGridViewTextBoxColumn
            // 
            this.effectDataGridViewTextBoxColumn.DataPropertyName = "Effect";
            this.effectDataGridViewTextBoxColumn.HeaderText = "Effect";
            this.effectDataGridViewTextBoxColumn.Name = "effectDataGridViewTextBoxColumn";
            this.effectDataGridViewTextBoxColumn.Visible = false;
            // 
            // durationDataGridViewTextBoxColumn
            // 
            this.durationDataGridViewTextBoxColumn.DataPropertyName = "Duration";
            this.durationDataGridViewTextBoxColumn.HeaderText = "Duration";
            this.durationDataGridViewTextBoxColumn.Name = "durationDataGridViewTextBoxColumn";
            this.durationDataGridViewTextBoxColumn.Visible = false;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            this.descriptionDataGridViewTextBoxColumn.Visible = false;
            // 
            // specialabilitiesBindingSource
            // 
            this.specialabilitiesBindingSource.DataMember = "Special_abilities";
            this.specialabilitiesBindingSource.DataSource = this.abilitylisterBindingSource;
            // 
            // abilitylisterBindingSource
            // 
            this.abilitylisterBindingSource.DataSource = typeof(MPC4.classes.Ability_lister);
            // 
            // grp_description
            // 
            this.grp_description.Controls.Add(this.rtxt_description);
            this.grp_description.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grp_description.Location = new System.Drawing.Point(5, 5);
            this.grp_description.Name = "grp_description";
            this.grp_description.Padding = new System.Windows.Forms.Padding(5);
            this.grp_description.Size = new System.Drawing.Size(274, 315);
            this.grp_description.TabIndex = 0;
            this.grp_description.TabStop = false;
            this.grp_description.Text = "Info";
            // 
            // rtxt_description
            // 
            this.rtxt_description.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxt_description.Location = new System.Drawing.Point(5, 18);
            this.rtxt_description.Name = "rtxt_description";
            this.rtxt_description.ReadOnly = true;
            this.rtxt_description.Size = new System.Drawing.Size(264, 292);
            this.rtxt_description.TabIndex = 0;
            this.rtxt_description.Text = "";
            // 
            // Special_ability_selector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 325);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Special_ability_selector";
            this.Text = "Special_ability_selector";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.grp_special_abilitys.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid_special_abilities)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.specialabilitiesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.abilitylisterBindingSource)).EndInit();
            this.grp_description.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox grp_special_abilitys;
        private System.Windows.Forms.GroupBox grp_description;
        private System.Windows.Forms.RichTextBox rtxt_description;
        private System.Windows.Forms.DataGridView grid_special_abilities;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn activationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rangeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn effectDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn durationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource specialabilitiesBindingSource;
        private System.Windows.Forms.BindingSource abilitylisterBindingSource;
        private System.Windows.Forms.Button btn_new_ability;
        private System.Windows.Forms.Button btn_remove_ability;
        private System.Windows.Forms.Button btn_edit_ability;
        private System.Windows.Forms.ToolTip toolTip_control;

    }
}