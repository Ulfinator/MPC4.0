namespace MPC4
{
    partial class Equipment_creator_control
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lbl_name = new System.Windows.Forms.Label();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.equipmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txt_equip_type = new System.Windows.Forms.TextBox();
            this.lbl_equip_type = new System.Windows.Forms.Label();
            this.txt_description = new System.Windows.Forms.TextBox();
            this.lbl_description = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.equipmentBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_name.Location = new System.Drawing.Point(6, 19);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(43, 13);
            this.lbl_name.TabIndex = 0;
            this.lbl_name.Text = "Name:";
            // 
            // txt_name
            // 
            this.txt_name.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.equipmentBindingSource, "Name", true));
            this.txt_name.Location = new System.Drawing.Point(87, 16);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(100, 20);
            this.txt_name.TabIndex = 1;
            // 
            // equipmentBindingSource
            // 
            this.equipmentBindingSource.DataSource = typeof(MPC4.classes.Equipment);
            // 
            // txt_equip_type
            // 
            this.txt_equip_type.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.equipmentBindingSource, "Equipment_type", true));
            this.txt_equip_type.Location = new System.Drawing.Point(87, 48);
            this.txt_equip_type.Name = "txt_equip_type";
            this.txt_equip_type.Size = new System.Drawing.Size(100, 20);
            this.txt_equip_type.TabIndex = 3;
            // 
            // lbl_equip_type
            // 
            this.lbl_equip_type.AutoSize = true;
            this.lbl_equip_type.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_equip_type.Location = new System.Drawing.Point(6, 48);
            this.lbl_equip_type.Name = "lbl_equip_type";
            this.lbl_equip_type.Size = new System.Drawing.Size(39, 13);
            this.lbl_equip_type.TabIndex = 2;
            this.lbl_equip_type.Text = "Type:";
            // 
            // txt_description
            // 
            this.txt_description.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.equipmentBindingSource, "Description", true));
            this.txt_description.Location = new System.Drawing.Point(87, 81);
            this.txt_description.Multiline = true;
            this.txt_description.Name = "txt_description";
            this.txt_description.Size = new System.Drawing.Size(185, 107);
            this.txt_description.TabIndex = 5;
            // 
            // lbl_description
            // 
            this.lbl_description.AutoSize = true;
            this.lbl_description.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_description.Location = new System.Drawing.Point(6, 84);
            this.lbl_description.Name = "lbl_description";
            this.lbl_description.Size = new System.Drawing.Size(75, 13);
            this.lbl_description.TabIndex = 4;
            this.lbl_description.Text = "Description:";
            // 
            // Equipment_creator_control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txt_description);
            this.Controls.Add(this.lbl_description);
            this.Controls.Add(this.txt_equip_type);
            this.Controls.Add(this.lbl_equip_type);
            this.Controls.Add(this.txt_name);
            this.Controls.Add(this.lbl_name);
            this.Name = "Equipment_creator_control";
            this.Size = new System.Drawing.Size(284, 202);
            ((System.ComponentModel.ISupportInitialize)(this.equipmentBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.BindingSource equipmentBindingSource;
        private System.Windows.Forms.TextBox txt_equip_type;
        private System.Windows.Forms.Label lbl_equip_type;
        private System.Windows.Forms.TextBox txt_description;
        private System.Windows.Forms.Label lbl_description;
    }
}
