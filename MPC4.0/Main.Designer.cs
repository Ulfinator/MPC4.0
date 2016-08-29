namespace MPC4
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.btn_manipulate = new System.Windows.Forms.Button();
            this.btn_encounter = new System.Windows.Forms.Button();
            this.toolTip_control = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // btn_manipulate
            // 
            this.btn_manipulate.BackColor = System.Drawing.SystemColors.Control;
            this.btn_manipulate.Image = global::MPC4._0.Properties.Resources.Typewriter;
            this.btn_manipulate.Location = new System.Drawing.Point(42, 74);
            this.btn_manipulate.Margin = new System.Windows.Forms.Padding(0);
            this.btn_manipulate.Name = "btn_manipulate";
            this.btn_manipulate.Size = new System.Drawing.Size(87, 57);
            this.btn_manipulate.TabIndex = 2;
            this.btn_manipulate.Tag = "Manipulation";
            this.btn_manipulate.UseVisualStyleBackColor = false;
            this.btn_manipulate.Click += new System.EventHandler(this.btn_manipulate_Click);
            // 
            // btn_encounter
            // 
            this.btn_encounter.Image = global::MPC4._0.Properties.Resources.safari;
            this.btn_encounter.Location = new System.Drawing.Point(42, 162);
            this.btn_encounter.Name = "btn_encounter";
            this.btn_encounter.Size = new System.Drawing.Size(87, 56);
            this.btn_encounter.TabIndex = 3;
            this.btn_encounter.Tag = "Encounter";
            this.btn_encounter.UseVisualStyleBackColor = true;
            this.btn_encounter.Click += new System.EventHandler(this.btn_encounter_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(165, 288);
            this.Controls.Add(this.btn_encounter);
            this.Controls.Add(this.btn_manipulate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_manipulate;
        private System.Windows.Forms.Button btn_encounter;
        private System.Windows.Forms.ToolTip toolTip_control;
    }
}

