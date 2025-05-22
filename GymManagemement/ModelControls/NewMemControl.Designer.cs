namespace GymManagemement.NewMembers
{
    partial class NewMemControl
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
            this.lbName = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lbTime = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.SuspendLayout();
            // 
            // lbName
            // 
            this.lbName.BackColor = System.Drawing.Color.Transparent;
            this.lbName.Location = new System.Drawing.Point(3, 8);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(3, 2);
            this.lbName.TabIndex = 0;
            // 
            // lbTime
            // 
            this.lbTime.BackColor = System.Drawing.Color.Transparent;
            this.lbTime.Location = new System.Drawing.Point(95, 8);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(3, 2);
            this.lbTime.TabIndex = 1;
            // 
            // NewMemControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbTime);
            this.Controls.Add(this.lbName);
            this.Name = "NewMemControl";
            this.Size = new System.Drawing.Size(170, 30);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2HtmlLabel lbName;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbTime;
    }
}
