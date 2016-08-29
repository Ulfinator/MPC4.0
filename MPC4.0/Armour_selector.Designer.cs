namespace MPC4
{
    partial class Armour_selector
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
            this.grp_body_modle = new System.Windows.Forms.GroupBox();
            this.grid_body_modle = new System.Windows.Forms.DataGridView();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bodypartsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bodymodleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.grp_body_armour = new System.Windows.Forms.GroupBox();
            this.grid_body_armour = new System.Windows.Forms.DataGridView();
            this.nameDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.armourpartBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.lbl_body_part_abs_head = new System.Windows.Forms.Label();
            this.lbl_body_part_beg_head = new System.Windows.Forms.Label();
            this.lbl_body_part_beg = new System.Windows.Forms.Label();
            this.lbl_body_part_abs = new System.Windows.Forms.Label();
            this.grp_armour = new System.Windows.Forms.GroupBox();
            this.grid_armour_parts = new System.Windows.Forms.DataGridView();
            this.nameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.partcoverDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.absorptionvalueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.limitationvalueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.armourpartBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.grp_abs_beg = new System.Windows.Forms.GroupBox();
            this.lbl_total_move_beg = new System.Windows.Forms.Label();
            this.lbl_total_vision_beg = new System.Windows.Forms.Label();
            this.lbl_total_move_beg_head = new System.Windows.Forms.Label();
            this.lbl_total_vision_beg_head = new System.Windows.Forms.Label();
            this.grp_body_modle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_body_modle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bodypartsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bodymodleBindingSource)).BeginInit();
            this.grp_body_armour.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_body_armour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.armourpartBindingSource1)).BeginInit();
            this.grp_armour.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_armour_parts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.armourpartBindingSource)).BeginInit();
            this.grp_abs_beg.SuspendLayout();
            this.SuspendLayout();
            // 
            // grp_body_modle
            // 
            this.grp_body_modle.Controls.Add(this.grid_body_modle);
            this.grp_body_modle.Location = new System.Drawing.Point(12, 12);
            this.grp_body_modle.Name = "grp_body_modle";
            this.grp_body_modle.Size = new System.Drawing.Size(200, 243);
            this.grp_body_modle.TabIndex = 0;
            this.grp_body_modle.TabStop = false;
            this.grp_body_modle.Text = "Kropp";
            // 
            // grid_body_modle
            // 
            this.grid_body_modle.AllowUserToAddRows = false;
            this.grid_body_modle.AllowUserToDeleteRows = false;
            this.grid_body_modle.AllowUserToResizeColumns = false;
            this.grid_body_modle.AllowUserToResizeRows = false;
            this.grid_body_modle.AutoGenerateColumns = false;
            this.grid_body_modle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_body_modle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn});
            this.grid_body_modle.DataSource = this.bodypartsBindingSource;
            this.grid_body_modle.Location = new System.Drawing.Point(6, 19);
            this.grid_body_modle.MultiSelect = false;
            this.grid_body_modle.Name = "grid_body_modle";
            this.grid_body_modle.ReadOnly = true;
            this.grid_body_modle.RowHeadersWidth = 20;
            this.grid_body_modle.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.grid_body_modle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid_body_modle.Size = new System.Drawing.Size(188, 212);
            this.grid_body_modle.TabIndex = 0;
            this.grid_body_modle.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_body_modle_RowEnter);
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Namn";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            this.nameDataGridViewTextBoxColumn.Width = 150;
            // 
            // bodypartsBindingSource
            // 
            this.bodypartsBindingSource.DataMember = "Body_parts";
            this.bodypartsBindingSource.DataSource = this.bodymodleBindingSource;
            // 
            // bodymodleBindingSource
            // 
            this.bodymodleBindingSource.DataSource = typeof(MPC4.classes.Body_modle);
            // 
            // grp_body_armour
            // 
            this.grp_body_armour.Controls.Add(this.grid_body_armour);
            this.grp_body_armour.Controls.Add(this.lbl_body_part_abs_head);
            this.grp_body_armour.Controls.Add(this.lbl_body_part_beg_head);
            this.grp_body_armour.Controls.Add(this.lbl_body_part_beg);
            this.grp_body_armour.Controls.Add(this.lbl_body_part_abs);
            this.grp_body_armour.Location = new System.Drawing.Point(218, 12);
            this.grp_body_armour.Name = "grp_body_armour";
            this.grp_body_armour.Size = new System.Drawing.Size(200, 157);
            this.grp_body_armour.TabIndex = 1;
            this.grp_body_armour.TabStop = false;
            this.grp_body_armour.Text = "Bepansring";
            // 
            // grid_body_armour
            // 
            this.grid_body_armour.AllowDrop = true;
            this.grid_body_armour.AllowUserToAddRows = false;
            this.grid_body_armour.AllowUserToDeleteRows = false;
            this.grid_body_armour.AllowUserToResizeColumns = false;
            this.grid_body_armour.AllowUserToResizeRows = false;
            this.grid_body_armour.AutoGenerateColumns = false;
            this.grid_body_armour.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_body_armour.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn2});
            this.grid_body_armour.DataSource = this.armourpartBindingSource1;
            this.grid_body_armour.Location = new System.Drawing.Point(6, 19);
            this.grid_body_armour.Name = "grid_body_armour";
            this.grid_body_armour.ReadOnly = true;
            this.grid_body_armour.RowHeadersWidth = 20;
            this.grid_body_armour.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.grid_body_armour.Size = new System.Drawing.Size(188, 76);
            this.grid_body_armour.TabIndex = 0;
            this.grid_body_armour.DragDrop += new System.Windows.Forms.DragEventHandler(this.grid_body_armour_DragDrop);
            this.grid_body_armour.DragEnter += new System.Windows.Forms.DragEventHandler(this.grid_body_armour_DragEnter);
            this.grid_body_armour.MouseMove += new System.Windows.Forms.MouseEventHandler(this.grid_body_armour_MouseMove);
            // 
            // nameDataGridViewTextBoxColumn2
            // 
            this.nameDataGridViewTextBoxColumn2.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn2.HeaderText = "Namn";
            this.nameDataGridViewTextBoxColumn2.Name = "nameDataGridViewTextBoxColumn2";
            this.nameDataGridViewTextBoxColumn2.ReadOnly = true;
            this.nameDataGridViewTextBoxColumn2.Width = 150;
            // 
            // armourpartBindingSource1
            // 
            this.armourpartBindingSource1.DataSource = typeof(MPC4.classes.Armour_part);
            // 
            // lbl_body_part_abs_head
            // 
            this.lbl_body_part_abs_head.AutoSize = true;
            this.lbl_body_part_abs_head.Location = new System.Drawing.Point(3, 108);
            this.lbl_body_part_abs_head.Name = "lbl_body_part_abs_head";
            this.lbl_body_part_abs_head.Size = new System.Drawing.Size(47, 13);
            this.lbl_body_part_abs_head.TabIndex = 0;
            this.lbl_body_part_abs_head.Text = "Del Abs:";
            // 
            // lbl_body_part_beg_head
            // 
            this.lbl_body_part_beg_head.AutoSize = true;
            this.lbl_body_part_beg_head.Location = new System.Drawing.Point(3, 132);
            this.lbl_body_part_beg_head.Name = "lbl_body_part_beg_head";
            this.lbl_body_part_beg_head.Size = new System.Drawing.Size(48, 13);
            this.lbl_body_part_beg_head.TabIndex = 1;
            this.lbl_body_part_beg_head.Text = "Del Beg:";
            // 
            // lbl_body_part_beg
            // 
            this.lbl_body_part_beg.AutoSize = true;
            this.lbl_body_part_beg.Location = new System.Drawing.Point(64, 132);
            this.lbl_body_part_beg.Name = "lbl_body_part_beg";
            this.lbl_body_part_beg.Size = new System.Drawing.Size(10, 13);
            this.lbl_body_part_beg.TabIndex = 5;
            this.lbl_body_part_beg.Text = "-";
            // 
            // lbl_body_part_abs
            // 
            this.lbl_body_part_abs.AutoSize = true;
            this.lbl_body_part_abs.Location = new System.Drawing.Point(64, 108);
            this.lbl_body_part_abs.Name = "lbl_body_part_abs";
            this.lbl_body_part_abs.Size = new System.Drawing.Size(10, 13);
            this.lbl_body_part_abs.TabIndex = 5;
            this.lbl_body_part_abs.Text = "-";
            // 
            // grp_armour
            // 
            this.grp_armour.Controls.Add(this.grid_armour_parts);
            this.grp_armour.Location = new System.Drawing.Point(424, 12);
            this.grp_armour.Name = "grp_armour";
            this.grp_armour.Size = new System.Drawing.Size(385, 243);
            this.grp_armour.TabIndex = 2;
            this.grp_armour.TabStop = false;
            this.grp_armour.Text = "Pansar";
            // 
            // grid_armour_parts
            // 
            this.grid_armour_parts.AllowDrop = true;
            this.grid_armour_parts.AllowUserToAddRows = false;
            this.grid_armour_parts.AllowUserToDeleteRows = false;
            this.grid_armour_parts.AllowUserToResizeColumns = false;
            this.grid_armour_parts.AllowUserToResizeRows = false;
            this.grid_armour_parts.AutoGenerateColumns = false;
            this.grid_armour_parts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_armour_parts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn1,
            this.partcoverDataGridViewTextBoxColumn,
            this.absorptionvalueDataGridViewTextBoxColumn,
            this.limitationvalueDataGridViewTextBoxColumn});
            this.grid_armour_parts.DataSource = this.armourpartBindingSource;
            this.grid_armour_parts.Location = new System.Drawing.Point(6, 19);
            this.grid_armour_parts.MultiSelect = false;
            this.grid_armour_parts.Name = "grid_armour_parts";
            this.grid_armour_parts.ReadOnly = true;
            this.grid_armour_parts.RowHeadersWidth = 20;
            this.grid_armour_parts.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.grid_armour_parts.Size = new System.Drawing.Size(373, 212);
            this.grid_armour_parts.TabIndex = 0;
            this.grid_armour_parts.DragDrop += new System.Windows.Forms.DragEventHandler(this.grid_armour_parts_DragDrop);
            this.grid_armour_parts.DragEnter += new System.Windows.Forms.DragEventHandler(this.grid_armour_parts_DragEnter);
            this.grid_armour_parts.MouseMove += new System.Windows.Forms.MouseEventHandler(this.grid_armour_parts_MouseMove);
            // 
            // nameDataGridViewTextBoxColumn1
            // 
            this.nameDataGridViewTextBoxColumn1.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn1.HeaderText = "Namn";
            this.nameDataGridViewTextBoxColumn1.Name = "nameDataGridViewTextBoxColumn1";
            this.nameDataGridViewTextBoxColumn1.ReadOnly = true;
            this.nameDataGridViewTextBoxColumn1.Width = 150;
            // 
            // partcoverDataGridViewTextBoxColumn
            // 
            this.partcoverDataGridViewTextBoxColumn.DataPropertyName = "Part_cover";
            this.partcoverDataGridViewTextBoxColumn.HeaderText = "Kroppsdel";
            this.partcoverDataGridViewTextBoxColumn.Name = "partcoverDataGridViewTextBoxColumn";
            this.partcoverDataGridViewTextBoxColumn.ReadOnly = true;
            this.partcoverDataGridViewTextBoxColumn.Width = 80;
            // 
            // absorptionvalueDataGridViewTextBoxColumn
            // 
            this.absorptionvalueDataGridViewTextBoxColumn.DataPropertyName = "Absorption_value";
            this.absorptionvalueDataGridViewTextBoxColumn.HeaderText = "Abs";
            this.absorptionvalueDataGridViewTextBoxColumn.Name = "absorptionvalueDataGridViewTextBoxColumn";
            this.absorptionvalueDataGridViewTextBoxColumn.ReadOnly = true;
            this.absorptionvalueDataGridViewTextBoxColumn.Width = 50;
            // 
            // limitationvalueDataGridViewTextBoxColumn
            // 
            this.limitationvalueDataGridViewTextBoxColumn.DataPropertyName = "Limitation_value";
            this.limitationvalueDataGridViewTextBoxColumn.HeaderText = "Beg%";
            this.limitationvalueDataGridViewTextBoxColumn.Name = "limitationvalueDataGridViewTextBoxColumn";
            this.limitationvalueDataGridViewTextBoxColumn.ReadOnly = true;
            this.limitationvalueDataGridViewTextBoxColumn.Width = 50;
            // 
            // armourpartBindingSource
            // 
            this.armourpartBindingSource.DataSource = typeof(MPC4.classes.Armour_part);
            // 
            // grp_abs_beg
            // 
            this.grp_abs_beg.Controls.Add(this.lbl_total_move_beg);
            this.grp_abs_beg.Controls.Add(this.lbl_total_vision_beg);
            this.grp_abs_beg.Controls.Add(this.lbl_total_move_beg_head);
            this.grp_abs_beg.Controls.Add(this.lbl_total_vision_beg_head);
            this.grp_abs_beg.Location = new System.Drawing.Point(218, 177);
            this.grp_abs_beg.Name = "grp_abs_beg";
            this.grp_abs_beg.Size = new System.Drawing.Size(200, 78);
            this.grp_abs_beg.TabIndex = 3;
            this.grp_abs_beg.TabStop = false;
            this.grp_abs_beg.Text = "Total Beg";
            // 
            // lbl_total_move_beg
            // 
            this.lbl_total_move_beg.AutoSize = true;
            this.lbl_total_move_beg.Location = new System.Drawing.Point(108, 53);
            this.lbl_total_move_beg.Name = "lbl_total_move_beg";
            this.lbl_total_move_beg.Size = new System.Drawing.Size(10, 13);
            this.lbl_total_move_beg.TabIndex = 5;
            this.lbl_total_move_beg.Text = "-";
            // 
            // lbl_total_vision_beg
            // 
            this.lbl_total_vision_beg.AutoSize = true;
            this.lbl_total_vision_beg.Location = new System.Drawing.Point(90, 26);
            this.lbl_total_vision_beg.Name = "lbl_total_vision_beg";
            this.lbl_total_vision_beg.Size = new System.Drawing.Size(10, 13);
            this.lbl_total_vision_beg.TabIndex = 5;
            this.lbl_total_vision_beg.Text = "-";
            // 
            // lbl_total_move_beg_head
            // 
            this.lbl_total_move_beg_head.AutoSize = true;
            this.lbl_total_move_beg_head.Location = new System.Drawing.Point(7, 53);
            this.lbl_total_move_beg_head.Name = "lbl_total_move_beg_head";
            this.lbl_total_move_beg_head.Size = new System.Drawing.Size(95, 13);
            this.lbl_total_move_beg_head.TabIndex = 4;
            this.lbl_total_move_beg_head.Text = "Total Rörelse Beg:";
            // 
            // lbl_total_vision_beg_head
            // 
            this.lbl_total_vision_beg_head.AutoSize = true;
            this.lbl_total_vision_beg_head.Location = new System.Drawing.Point(7, 26);
            this.lbl_total_vision_beg_head.Name = "lbl_total_vision_beg_head";
            this.lbl_total_vision_beg_head.Size = new System.Drawing.Size(77, 13);
            this.lbl_total_vision_beg_head.TabIndex = 3;
            this.lbl_total_vision_beg_head.Text = "Total Syn Beg:";
            // 
            // Armour_selector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 270);
            this.Controls.Add(this.grp_abs_beg);
            this.Controls.Add(this.grp_armour);
            this.Controls.Add(this.grp_body_armour);
            this.Controls.Add(this.grp_body_modle);
            this.Name = "Armour_selector";
            this.Text = "Armour_selector";
            this.grp_body_modle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid_body_modle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bodypartsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bodymodleBindingSource)).EndInit();
            this.grp_body_armour.ResumeLayout(false);
            this.grp_body_armour.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_body_armour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.armourpartBindingSource1)).EndInit();
            this.grp_armour.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid_armour_parts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.armourpartBindingSource)).EndInit();
            this.grp_abs_beg.ResumeLayout(false);
            this.grp_abs_beg.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grp_body_modle;
        private System.Windows.Forms.GroupBox grp_body_armour;
        private System.Windows.Forms.GroupBox grp_armour;
        private System.Windows.Forms.DataGridView grid_body_modle;
        private System.Windows.Forms.DataGridView grid_body_armour;
        private System.Windows.Forms.DataGridView grid_armour_parts;
        private System.Windows.Forms.BindingSource bodypartsBindingSource;
        private System.Windows.Forms.BindingSource bodymodleBindingSource;
        private System.Windows.Forms.BindingSource armourpartBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn partcoverDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn absorptionvalueDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn limitationvalueDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource armourpartBindingSource1;
        private System.Windows.Forms.GroupBox grp_abs_beg;
        private System.Windows.Forms.Label lbl_total_vision_beg_head;
        private System.Windows.Forms.Label lbl_body_part_beg_head;
        private System.Windows.Forms.Label lbl_body_part_abs_head;
        private System.Windows.Forms.Label lbl_total_move_beg;
        private System.Windows.Forms.Label lbl_total_vision_beg;
        private System.Windows.Forms.Label lbl_body_part_beg;
        private System.Windows.Forms.Label lbl_body_part_abs;
        private System.Windows.Forms.Label lbl_total_move_beg_head;
    }
}