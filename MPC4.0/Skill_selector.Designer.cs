namespace MPC4
{
    partial class Skill_selector
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
            this.grp_natural_skills = new System.Windows.Forms.GroupBox();
            this.grid_skills = new System.Windows.Forms.DataGridView();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Skill_base_attribute = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.skillvalueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.skillsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.skilllisterBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.grp_natural_skills.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_skills)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.skillsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.skilllisterBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // grp_natural_skills
            // 
            this.grp_natural_skills.Controls.Add(this.grid_skills);
            this.grp_natural_skills.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grp_natural_skills.Location = new System.Drawing.Point(5, 5);
            this.grp_natural_skills.Name = "grp_natural_skills";
            this.grp_natural_skills.Padding = new System.Windows.Forms.Padding(5);
            this.grp_natural_skills.Size = new System.Drawing.Size(293, 324);
            this.grp_natural_skills.TabIndex = 0;
            this.grp_natural_skills.TabStop = false;
            this.grp_natural_skills.Text = "Färdigheter";
            // 
            // grid_skills
            // 
            this.grid_skills.AllowUserToDeleteRows = false;
            this.grid_skills.AutoGenerateColumns = false;
            this.grid_skills.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_skills.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.Skill_base_attribute,
            this.skillvalueDataGridViewTextBoxColumn});
            this.grid_skills.DataSource = this.skillsBindingSource;
            this.grid_skills.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid_skills.Location = new System.Drawing.Point(5, 18);
            this.grid_skills.MultiSelect = false;
            this.grid_skills.Name = "grid_skills";
            this.grid_skills.ReadOnly = true;
            this.grid_skills.RowHeadersWidth = 20;
            this.grid_skills.Size = new System.Drawing.Size(283, 301);
            this.grid_skills.TabIndex = 0;
            this.grid_skills.MouseMove += new System.Windows.Forms.MouseEventHandler(this.grid_skills_MouseMove);
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Färdighet";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            this.nameDataGridViewTextBoxColumn.Width = 180;
            // 
            // Skill_base_attribute
            // 
            this.Skill_base_attribute.DataPropertyName = "Skill_base_attribute";
            this.Skill_base_attribute.HeaderText = "Bas";
            this.Skill_base_attribute.Name = "Skill_base_attribute";
            this.Skill_base_attribute.ReadOnly = true;
            this.Skill_base_attribute.Width = 40;
            // 
            // skillvalueDataGridViewTextBoxColumn
            // 
            this.skillvalueDataGridViewTextBoxColumn.DataPropertyName = "Skill_value";
            this.skillvalueDataGridViewTextBoxColumn.HeaderText = "Skill_value";
            this.skillvalueDataGridViewTextBoxColumn.Name = "skillvalueDataGridViewTextBoxColumn";
            this.skillvalueDataGridViewTextBoxColumn.ReadOnly = true;
            this.skillvalueDataGridViewTextBoxColumn.Visible = false;
            // 
            // skillsBindingSource
            // 
            this.skillsBindingSource.DataMember = "Skills";
            this.skillsBindingSource.DataSource = this.skilllisterBindingSource;
            // 
            // skilllisterBindingSource
            // 
            this.skilllisterBindingSource.DataSource = typeof(MPC4.classes.Skill_lister);
            // 
            // Skill_selector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 334);
            this.Controls.Add(this.grp_natural_skills);
            this.Name = "Skill_selector";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "Skill_selector";
            this.grp_natural_skills.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid_skills)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.skillsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.skilllisterBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grp_natural_skills;
        private System.Windows.Forms.DataGridView grid_skills;
        private System.Windows.Forms.BindingSource skillsBindingSource;
        private System.Windows.Forms.BindingSource skilllisterBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Skill_base_attribute;
        private System.Windows.Forms.DataGridViewTextBoxColumn skillvalueDataGridViewTextBoxColumn;
    }
}