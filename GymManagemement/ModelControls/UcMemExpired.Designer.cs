namespace GymManagemement
{
    partial class UcMemExpired
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcMemExpired));
            this.guna2CirclePictureBox1 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.lbPhone = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lbMemShip = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lbName = new Guna.UI2.WinForms.Guna2HtmlLabel();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2CirclePictureBox1
            // 
            this.guna2CirclePictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("guna2CirclePictureBox1.Image")));
            this.guna2CirclePictureBox1.ImageRotate = 0F;
            this.guna2CirclePictureBox1.Location = new System.Drawing.Point(149, 27);
            this.guna2CirclePictureBox1.Name = "guna2CirclePictureBox1";
            this.guna2CirclePictureBox1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CirclePictureBox1.Size = new System.Drawing.Size(16, 16);
            this.guna2CirclePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2CirclePictureBox1.TabIndex = 7;
            this.guna2CirclePictureBox1.TabStop = false;
            // 
            // lbPhone
            // 
            this.lbPhone.BackColor = System.Drawing.Color.Transparent;
            this.lbPhone.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPhone.ForeColor = System.Drawing.Color.DarkGray;
            this.lbPhone.Location = new System.Drawing.Point(9, 49);
            this.lbPhone.Name = "lbPhone";
            this.lbPhone.Size = new System.Drawing.Size(36, 15);
            this.lbPhone.TabIndex = 6;
            this.lbPhone.Text = "Phone";
            // 
            // lbMemShip
            // 
            this.lbMemShip.BackColor = System.Drawing.Color.Transparent;
            this.lbMemShip.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMemShip.ForeColor = System.Drawing.Color.DarkGray;
            this.lbMemShip.Location = new System.Drawing.Point(9, 28);
            this.lbMemShip.Name = "lbMemShip";
            this.lbMemShip.Size = new System.Drawing.Size(67, 15);
            this.lbMemShip.TabIndex = 5;
            this.lbMemShip.Text = "Membership";
            // 
            // lbName
            // 
            this.lbName.BackColor = System.Drawing.Color.Transparent;
            this.lbName.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbName.Location = new System.Drawing.Point(9, 7);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(35, 17);
            this.lbName.TabIndex = 4;
            this.lbName.Text = "Name";
            // 
            // UcMemExpired
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.guna2CirclePictureBox1);
            this.Controls.Add(this.lbPhone);
            this.Controls.Add(this.lbMemShip);
            this.Controls.Add(this.lbName);
            this.Name = "UcMemExpired";
            this.Size = new System.Drawing.Size(175, 70);
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbPhone;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbMemShip;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbName;
    }
}
