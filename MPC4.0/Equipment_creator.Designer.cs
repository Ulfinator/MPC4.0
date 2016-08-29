namespace MPC4
{
    partial class Equipment_creator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Equipment_creator));
            this.grp_equip_list = new System.Windows.Forms.GroupBox();
            this.grp_equip_data = new System.Windows.Forms.GroupBox();
            this.cmb_equip_type = new System.Windows.Forms.ComboBox();
            this.lbl_category = new System.Windows.Forms.Label();
            this.grid_equip = new System.Windows.Forms.DataGridView();
            this.lbl_equipment_list = new System.Windows.Forms.Label();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.equipmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btn_save_all_changes = new System.Windows.Forms.Button();
            this.grp_equip_list.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_equip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.equipmentBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // grp_equip_list
            // 
            this.grp_equip_list.Controls.Add(this.lbl_equipment_list);
            this.grp_equip_list.Controls.Add(this.grid_equip);
            this.grp_equip_list.Controls.Add(this.lbl_category);
            this.grp_equip_list.Controls.Add(this.cmb_equip_type);
            this.grp_equip_list.Location = new System.Drawing.Point(12, 12);
            this.grp_equip_list.Name = "grp_equip_list";
            this.grp_equip_list.Size = new System.Drawing.Size(311, 380);
            this.grp_equip_list.TabIndex = 2;
            this.grp_equip_list.TabStop = false;
            this.grp_equip_list.Text = "Utrustning";
            // 
            // grp_equip_data
            // 
            this.grp_equip_data.Location = new System.Drawing.Point(336, 12);
            this.grp_equip_data.Name = "grp_equip_data";
            this.grp_equip_data.Size = new System.Drawing.Size(311, 380);
            this.grp_equip_data.TabIndex = 3;
            this.grp_equip_data.TabStop = false;
            this.grp_equip_data.Text = "Utrustningsdata";
            // 
            // cmb_equip_type
            // 
            this.cmb_equip_type.FormattingEnabled = true;
            this.cmb_equip_type.Location = new System.Drawing.Point(106, 19);
            this.cmb_equip_type.Name = "cmb_equip_type";
            this.cmb_equip_type.Size = new System.Drawing.Size(197, 21);
            this.cmb_equip_type.TabIndex = 1;
            this.cmb_equip_type.SelectedIndexChanged += new System.EventHandler(this.cmb_equip_type_SelectedIndexChanged);
            // 
            // lbl_category
            // 
            this.lbl_category.AutoSize = true;
            this.lbl_category.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_category.Location = new System.Drawing.Point(6, 22);
            this.lbl_category.Name = "lbl_category";
            this.lbl_category.Size = new System.Drawing.Size(58, 13);
            this.lbl_category.TabIndex = 2;
            this.lbl_category.Text = "Kategori:";
            // 
            // grid_equip
            // 
            this.grid_equip.AllowUserToAddRows = false;
            this.grid_equip.AllowUserToDeleteRows = false;
            this.grid_equip.AllowUserToResizeColumns = false;
            this.grid_equip.AllowUserToResizeRows = false;
            this.grid_equip.AutoGenerateColumns = false;
            this.grid_equip.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grid_equip.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_equip.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn});
            this.grid_equip.DataSource = this.equipmentBindingSource;
            this.grid_equip.Location = new System.Drawing.Point(106, 46);
            this.grid_equip.MultiSelect = false;
            this.grid_equip.Name = "grid_equip";
            this.grid_equip.ReadOnly = true;
            this.grid_equip.RowHeadersWidth = 20;
            this.grid_equip.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.grid_equip.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid_equip.Size = new System.Drawing.Size(199, 317);
            this.grid_equip.TabIndex = 3;
            this.grid_equip.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_equip_RowEnter);
            // 
            // lbl_equipment_list
            // 
            this.lbl_equipment_list.AutoSize = true;
            this.lbl_equipment_list.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_equipment_list.Location = new System.Drawing.Point(6, 46);
            this.lbl_equipment_list.Name = "lbl_equipment_list";
            this.lbl_equipment_list.Size = new System.Drawing.Size(69, 13);
            this.lbl_equipment_list.TabIndex = 4;
            this.lbl_equipment_list.Text = "Utrustning:";
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            this.nameDataGridViewTextBoxColumn.Width = 200;
            // 
            // equipmentBindingSource
            // 
            this.equipmentBindingSource.DataSource = typeof(MPC4.classes.Equipment);
            // 
            // btn_save_all_changes
            // 
            this.btn_save_all_changes.Image = ((System.Drawing.Image)(resources.GetObject("btn_save_all_changes.Image")));
            this.btn_save_all_changes.Location = new System.Drawing.Point(597, 398);
            this.btn_save_all_changes.Name = "btn_save_all_changes";
            this.btn_save_all_changes.Size = new System.Drawing.Size(50, 40);
            this.btn_save_all_changes.TabIndex = 5;
            this.btn_save_all_changes.UseVisualStyleBackColor = true;
            this.btn_save_all_changes.Click += new System.EventHandler(this.btn_save_all_changes_Click);
            // 
            // Equipment_creator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 447);
            this.Controls.Add(this.btn_save_all_changes);
            this.Controls.Add(this.grp_equip_data);
            this.Controls.Add(this.grp_equip_list);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Equipment_creator";
            this.Text = "Ändra skapa utrustning";
            this.grp_equip_list.ResumeLayout(false);
            this.grp_equip_list.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_equip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.equipmentBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grp_equip_list;
        private System.Windows.Forms.GroupBox grp_equip_data;
        private System.Windows.Forms.ComboBox cmb_equip_type;
        private System.Windows.Forms.Label lbl_category;
        private System.Windows.Forms.DataGridView grid_equip;
        private System.Windows.Forms.BindingSource equipmentBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label lbl_equipment_list;
        private System.Windows.Forms.Button btn_save_all_changes;
    }
}