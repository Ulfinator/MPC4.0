namespace MPC4
{
    partial class Body_part_selector
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
            this.grp_body_types = new System.Windows.Forms.GroupBox();
            this.grid_body_types = new System.Windows.Forms.DataGridView();
            this.modlelistBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.grp_body_parts = new System.Windows.Forms.GroupBox();
            this.grid_body_parts = new System.Windows.Forms.DataGridView();
            this.bodypartsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.grp_hit_modle = new System.Windows.Forms.GroupBox();
            this.pic_canvas = new System.Windows.Forms.PictureBox();
            this.btn_create_new_modle = new System.Windows.Forms.Button();
            this.modlenameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modlehitdieDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bodymodlelisterBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.grp_body_types.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_body_types)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.modlelistBindingSource)).BeginInit();
            this.grp_body_parts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_body_parts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bodypartsBindingSource)).BeginInit();
            this.grp_hit_modle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_canvas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bodymodlelisterBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // grp_body_types
            // 
            this.grp_body_types.Controls.Add(this.grid_body_types);
            this.grp_body_types.Location = new System.Drawing.Point(18, 18);
            this.grp_body_types.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grp_body_types.Name = "grp_body_types";
            this.grp_body_types.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grp_body_types.Size = new System.Drawing.Size(320, 272);
            this.grp_body_types.TabIndex = 0;
            this.grp_body_types.TabStop = false;
            this.grp_body_types.Text = "Kroppstyper";
            // 
            // grid_body_types
            // 
            this.grid_body_types.AllowUserToAddRows = false;
            this.grid_body_types.AllowUserToDeleteRows = false;
            this.grid_body_types.AllowUserToResizeColumns = false;
            this.grid_body_types.AllowUserToResizeRows = false;
            this.grid_body_types.AutoGenerateColumns = false;
            this.grid_body_types.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_body_types.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.modlenameDataGridViewTextBoxColumn,
            this.modlehitdieDataGridViewTextBoxColumn});
            this.grid_body_types.DataSource = this.modlelistBindingSource;
            this.grid_body_types.Dock = System.Windows.Forms.DockStyle.Top;
            this.grid_body_types.Location = new System.Drawing.Point(4, 24);
            this.grid_body_types.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grid_body_types.MultiSelect = false;
            this.grid_body_types.Name = "grid_body_types";
            this.grid_body_types.ReadOnly = true;
            this.grid_body_types.RowHeadersWidth = 20;
            this.grid_body_types.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.grid_body_types.Size = new System.Drawing.Size(312, 238);
            this.grid_body_types.TabIndex = 0;
            this.grid_body_types.MouseMove += new System.Windows.Forms.MouseEventHandler(this.grid_body_types_MouseMove);
            // 
            // modlelistBindingSource
            // 
            this.modlelistBindingSource.DataMember = "Modle_list";
            this.modlelistBindingSource.DataSource = this.bodymodlelisterBindingSource;
            // 
            // grp_body_parts
            // 
            this.grp_body_parts.Controls.Add(this.grid_body_parts);
            this.grp_body_parts.Location = new System.Drawing.Point(18, 291);
            this.grp_body_parts.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grp_body_parts.Name = "grp_body_parts";
            this.grp_body_parts.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grp_body_parts.Size = new System.Drawing.Size(314, 377);
            this.grp_body_parts.TabIndex = 0;
            this.grp_body_parts.TabStop = false;
            this.grp_body_parts.Text = "Kroppsdelar";
            // 
            // grid_body_parts
            // 
            this.grid_body_parts.AllowUserToAddRows = false;
            this.grid_body_parts.AllowUserToDeleteRows = false;
            this.grid_body_parts.AllowUserToResizeColumns = false;
            this.grid_body_parts.AllowUserToResizeRows = false;
            this.grid_body_parts.AutoGenerateColumns = false;
            this.grid_body_parts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_body_parts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn});
            this.grid_body_parts.DataSource = this.bodypartsBindingSource;
            this.grid_body_parts.Location = new System.Drawing.Point(4, 25);
            this.grid_body_parts.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grid_body_parts.Name = "grid_body_parts";
            this.grid_body_parts.RowHeadersWidth = 20;
            this.grid_body_parts.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.grid_body_parts.Size = new System.Drawing.Size(304, 335);
            this.grid_body_parts.TabIndex = 0;
            // 
            // bodypartsBindingSource
            // 
            this.bodypartsBindingSource.DataMember = "Body_parts";
            this.bodypartsBindingSource.DataSource = this.modlelistBindingSource;
            // 
            // grp_hit_modle
            // 
            this.grp_hit_modle.Controls.Add(this.pic_canvas);
            this.grp_hit_modle.Location = new System.Drawing.Point(346, 18);
            this.grp_hit_modle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grp_hit_modle.Name = "grp_hit_modle";
            this.grp_hit_modle.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grp_hit_modle.Size = new System.Drawing.Size(375, 649);
            this.grp_hit_modle.TabIndex = 1;
            this.grp_hit_modle.TabStop = false;
            this.grp_hit_modle.Text = "Träffmodel";
            // 
            // pic_canvas
            // 
            this.pic_canvas.Location = new System.Drawing.Point(10, 25);
            this.pic_canvas.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pic_canvas.Name = "pic_canvas";
            this.pic_canvas.Size = new System.Drawing.Size(360, 608);
            this.pic_canvas.TabIndex = 0;
            this.pic_canvas.TabStop = false;
            // 
            // btn_create_new_modle
            // 
            this.btn_create_new_modle.Location = new System.Drawing.Point(572, 677);
            this.btn_create_new_modle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_create_new_modle.Name = "btn_create_new_modle";
            this.btn_create_new_modle.Size = new System.Drawing.Size(146, 35);
            this.btn_create_new_modle.TabIndex = 2;
            this.btn_create_new_modle.Text = "Create modle";
            this.btn_create_new_modle.UseVisualStyleBackColor = true;
            this.btn_create_new_modle.Click += new System.EventHandler(this.btn_create_new_modle_Click);
            // 
            // modlenameDataGridViewTextBoxColumn
            // 
            this.modlenameDataGridViewTextBoxColumn.DataPropertyName = "Modle_name";
            this.modlenameDataGridViewTextBoxColumn.HeaderText = "Namn";
            this.modlenameDataGridViewTextBoxColumn.Name = "modlenameDataGridViewTextBoxColumn";
            this.modlenameDataGridViewTextBoxColumn.ReadOnly = true;
            this.modlenameDataGridViewTextBoxColumn.Width = 130;
            // 
            // modlehitdieDataGridViewTextBoxColumn
            // 
            this.modlehitdieDataGridViewTextBoxColumn.DataPropertyName = "Modle_hit_die";
            this.modlehitdieDataGridViewTextBoxColumn.HeaderText = "Tärning";
            this.modlehitdieDataGridViewTextBoxColumn.Name = "modlehitdieDataGridViewTextBoxColumn";
            this.modlehitdieDataGridViewTextBoxColumn.ReadOnly = true;
            this.modlehitdieDataGridViewTextBoxColumn.Width = 50;
            // 
            // bodymodlelisterBindingSource
            // 
            this.bodymodlelisterBindingSource.DataSource = typeof(MPC4.classes.Body_modle_lister);
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.Width = 180;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(437, 677);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 35);
            this.button1.TabIndex = 3;
            this.button1.Text = "Choose";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Body_part_selector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 728);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_create_new_modle);
            this.Controls.Add(this.grp_hit_modle);
            this.Controls.Add(this.grp_body_types);
            this.Controls.Add(this.grp_body_parts);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Body_part_selector";
            this.Text = "Kroppsval";
            this.grp_body_types.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid_body_types)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.modlelistBindingSource)).EndInit();
            this.grp_body_parts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid_body_parts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bodypartsBindingSource)).EndInit();
            this.grp_hit_modle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic_canvas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bodymodlelisterBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grp_body_types;
        private System.Windows.Forms.GroupBox grp_body_parts;
        private System.Windows.Forms.DataGridView grid_body_types;
        private System.Windows.Forms.DataGridView grid_body_parts;
        private System.Windows.Forms.DataGridViewTextBoxColumn modlenameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn modlehitdieDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource modlelistBindingSource;
        private System.Windows.Forms.BindingSource bodymodlelisterBindingSource;
        private System.Windows.Forms.BindingSource bodypartsBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.GroupBox grp_hit_modle;
        private System.Windows.Forms.PictureBox pic_canvas;
        private System.Windows.Forms.Button btn_create_new_modle;
        private System.Windows.Forms.Button button1;
    }
}