namespace MPC4
{
    partial class Equipment_selector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Equipment_selector));
            this.grp_equip_type = new System.Windows.Forms.GroupBox();
            this.cmb_equip_type = new System.Windows.Forms.ComboBox();
            this.grp_equip = new System.Windows.Forms.GroupBox();
            this.grid_equip = new System.Windows.Forms.DataGridView();
            this.grp_info = new System.Windows.Forms.GroupBox();
            this.rtxt_description = new System.Windows.Forms.RichTextBox();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.equipmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btn_create_new_equip = new System.Windows.Forms.Button();
            this.grp_equip_type.SuspendLayout();
            this.grp_equip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_equip)).BeginInit();
            this.grp_info.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.equipmentBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // grp_equip_type
            // 
            this.grp_equip_type.Controls.Add(this.btn_create_new_equip);
            this.grp_equip_type.Controls.Add(this.cmb_equip_type);
            this.grp_equip_type.Location = new System.Drawing.Point(6, 0);
            this.grp_equip_type.Name = "grp_equip_type";
            this.grp_equip_type.Size = new System.Drawing.Size(442, 53);
            this.grp_equip_type.TabIndex = 0;
            this.grp_equip_type.TabStop = false;
            this.grp_equip_type.Text = "Utrustningskategori";
            // 
            // cmb_equip_type
            // 
            this.cmb_equip_type.FormattingEnabled = true;
            this.cmb_equip_type.Location = new System.Drawing.Point(6, 19);
            this.cmb_equip_type.Name = "cmb_equip_type";
            this.cmb_equip_type.Size = new System.Drawing.Size(197, 21);
            this.cmb_equip_type.TabIndex = 0;
            this.cmb_equip_type.SelectedIndexChanged += new System.EventHandler(this.cmb_equip_type_SelectedIndexChanged);
            // 
            // grp_equip
            // 
            this.grp_equip.Controls.Add(this.grid_equip);
            this.grp_equip.Location = new System.Drawing.Point(6, 56);
            this.grp_equip.Name = "grp_equip";
            this.grp_equip.Size = new System.Drawing.Size(208, 342);
            this.grp_equip.TabIndex = 1;
            this.grp_equip.TabStop = false;
            this.grp_equip.Text = "Utrustning";
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
            this.grid_equip.Location = new System.Drawing.Point(3, 16);
            this.grid_equip.MultiSelect = false;
            this.grid_equip.Name = "grid_equip";
            this.grid_equip.ReadOnly = true;
            this.grid_equip.RowHeadersWidth = 20;
            this.grid_equip.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.grid_equip.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid_equip.Size = new System.Drawing.Size(199, 317);
            this.grid_equip.TabIndex = 0;
            this.grid_equip.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_equip_RowEnter);
            this.grid_equip.MouseMove += new System.Windows.Forms.MouseEventHandler(this.grid_equip_MouseMove);
            // 
            // grp_info
            // 
            this.grp_info.Controls.Add(this.rtxt_description);
            this.grp_info.Location = new System.Drawing.Point(220, 56);
            this.grp_info.Name = "grp_info";
            this.grp_info.Size = new System.Drawing.Size(228, 342);
            this.grp_info.TabIndex = 2;
            this.grp_info.TabStop = false;
            this.grp_info.Text = "Info";
            // 
            // rtxt_description
            // 
            this.rtxt_description.Location = new System.Drawing.Point(6, 19);
            this.rtxt_description.Name = "rtxt_description";
            this.rtxt_description.ReadOnly = true;
            this.rtxt_description.Size = new System.Drawing.Size(218, 314);
            this.rtxt_description.TabIndex = 0;
            this.rtxt_description.Text = "";
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Namn";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            this.nameDataGridViewTextBoxColumn.Width = 200;
            // 
            // equipmentBindingSource
            // 
            this.equipmentBindingSource.DataSource = typeof(MPC4.classes.Equipment);
            // 
            // btn_create_new_equip
            // 
            this.btn_create_new_equip.Location = new System.Drawing.Point(335, 16);
            this.btn_create_new_equip.Name = "btn_create_new_equip";
            this.btn_create_new_equip.Size = new System.Drawing.Size(75, 23);
            this.btn_create_new_equip.TabIndex = 1;
            this.btn_create_new_equip.Text = "button1";
            this.btn_create_new_equip.UseVisualStyleBackColor = true;
            this.btn_create_new_equip.Click += new System.EventHandler(this.btn_create_new_equip_Click);
            // 
            // Equipment_selector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 399);
            this.Controls.Add(this.grp_info);
            this.Controls.Add(this.grp_equip);
            this.Controls.Add(this.grp_equip_type);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Equipment_selector";
            this.grp_equip_type.ResumeLayout(false);
            this.grp_equip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid_equip)).EndInit();
            this.grp_info.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.equipmentBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grp_equip_type;
        private System.Windows.Forms.ComboBox cmb_equip_type;
        private System.Windows.Forms.GroupBox grp_equip;
        private System.Windows.Forms.DataGridView grid_equip;
        private System.Windows.Forms.BindingSource equipmentBindingSource;
        private System.Windows.Forms.GroupBox grp_info;
        private System.Windows.Forms.RichTextBox rtxt_description;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btn_create_new_equip;
    }
}