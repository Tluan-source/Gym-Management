namespace GymManagemement
{
    partial class FrmDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDashboard));
            this.plTaskBar = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.btnSP = new Guna.UI2.WinForms.Guna2ImageButton();
            this.btnLogOut = new Guna.UI2.WinForms.Guna2ImageButton();
            this.btnClass = new Guna.UI2.WinForms.Guna2ImageButton();
            this.btnPay = new Guna.UI2.WinForms.Guna2ImageButton();
            this.btnPackage = new Guna.UI2.WinForms.Guna2ImageButton();
            this.btnTrainer = new Guna.UI2.WinForms.Guna2ImageButton();
            this.btnMember = new Guna.UI2.WinForms.Guna2ImageButton();
            this.btnSchedule = new Guna.UI2.WinForms.Guna2ImageButton();
            this.btnHome = new Guna.UI2.WinForms.Guna2ImageButton();
            this.btnNotifi = new Guna.UI2.WinForms.Guna2ImageButton();
            this.guna2HtmlToolTip1 = new Guna.UI2.WinForms.Guna2HtmlToolTip();
            this.guna2AnimateWindow1 = new Guna.UI2.WinForms.Guna2AnimateWindow(this.components);
            this.plHome = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.plTaskBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // plTaskBar
            // 
            this.plTaskBar.BorderRadius = 20;
            this.plTaskBar.Controls.Add(this.btnSP);
            this.plTaskBar.Controls.Add(this.btnLogOut);
            this.plTaskBar.Controls.Add(this.btnClass);
            this.plTaskBar.Controls.Add(this.btnPay);
            this.plTaskBar.Controls.Add(this.btnPackage);
            this.plTaskBar.Controls.Add(this.btnTrainer);
            this.plTaskBar.Controls.Add(this.btnMember);
            this.plTaskBar.Controls.Add(this.btnSchedule);
            this.plTaskBar.Controls.Add(this.btnHome);
            this.plTaskBar.Controls.Add(this.btnNotifi);
            this.plTaskBar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(153)))), ((int)(((byte)(181)))));
            this.plTaskBar.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(171)))), ((int)(((byte)(199)))));
            this.plTaskBar.FillColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(186)))), ((int)(((byte)(212)))));
            this.plTaskBar.FillColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(207)))), ((int)(((byte)(231)))));
            this.plTaskBar.Location = new System.Drawing.Point(10, 10);
            this.plTaskBar.Name = "plTaskBar";
            this.plTaskBar.Size = new System.Drawing.Size(70, 680);
            this.plTaskBar.TabIndex = 0;
            // 
            // btnSP
            // 
            this.btnSP.BackColor = System.Drawing.Color.Transparent;
            this.btnSP.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnSP.HoverState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            this.btnSP.HoverState.ImageSize = new System.Drawing.Size(25, 25);
            this.btnSP.Image = ((System.Drawing.Image)(resources.GetObject("btnSP.Image")));
            this.btnSP.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnSP.ImageRotate = 0F;
            this.btnSP.ImageSize = new System.Drawing.Size(25, 25);
            this.btnSP.Location = new System.Drawing.Point(15, 495);
            this.btnSP.Name = "btnSP";
            this.btnSP.PressedState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image1")));
            this.btnSP.PressedState.ImageSize = new System.Drawing.Size(25, 25);
            this.btnSP.Size = new System.Drawing.Size(37, 40);
            this.btnSP.TabIndex = 7;
            this.guna2HtmlToolTip1.SetToolTip(this.btnSP, "Sản Phẩm");
            this.btnSP.Click += new System.EventHandler(this.GunaButton_Click);
            // 
            // btnLogOut
            // 
            this.btnLogOut.BackColor = System.Drawing.Color.Transparent;
            this.btnLogOut.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnLogOut.HoverState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image2")));
            this.btnLogOut.HoverState.ImageSize = new System.Drawing.Size(25, 25);
            this.btnLogOut.Image = ((System.Drawing.Image)(resources.GetObject("btnLogOut.Image")));
            this.btnLogOut.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnLogOut.ImageRotate = 0F;
            this.btnLogOut.ImageSize = new System.Drawing.Size(25, 25);
            this.btnLogOut.Location = new System.Drawing.Point(15, 619);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.PressedState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image3")));
            this.btnLogOut.PressedState.ImageSize = new System.Drawing.Size(25, 25);
            this.btnLogOut.Size = new System.Drawing.Size(37, 40);
            this.btnLogOut.TabIndex = 6;
            this.guna2HtmlToolTip1.SetToolTip(this.btnLogOut, "Thoát");
            this.btnLogOut.Click += new System.EventHandler(this.GunaButton_Click);
            // 
            // btnClass
            // 
            this.btnClass.BackColor = System.Drawing.Color.Transparent;
            this.btnClass.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnClass.HoverState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image4")));
            this.btnClass.HoverState.ImageSize = new System.Drawing.Size(25, 25);
            this.btnClass.Image = ((System.Drawing.Image)(resources.GetObject("btnClass.Image")));
            this.btnClass.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnClass.ImageRotate = 0F;
            this.btnClass.ImageSize = new System.Drawing.Size(25, 25);
            this.btnClass.Location = new System.Drawing.Point(15, 439);
            this.btnClass.Name = "btnClass";
            this.btnClass.PressedState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image5")));
            this.btnClass.PressedState.ImageSize = new System.Drawing.Size(25, 25);
            this.btnClass.Size = new System.Drawing.Size(37, 40);
            this.btnClass.TabIndex = 5;
            this.guna2HtmlToolTip1.SetToolTip(this.btnClass, "Lớp tập");
            this.btnClass.Click += new System.EventHandler(this.GunaButton_Click);
            // 
            // btnPay
            // 
            this.btnPay.BackColor = System.Drawing.Color.Transparent;
            this.btnPay.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnPay.HoverState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image6")));
            this.btnPay.HoverState.ImageSize = new System.Drawing.Size(25, 25);
            this.btnPay.Image = ((System.Drawing.Image)(resources.GetObject("btnPay.Image")));
            this.btnPay.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnPay.ImageRotate = 0F;
            this.btnPay.ImageSize = new System.Drawing.Size(25, 25);
            this.btnPay.Location = new System.Drawing.Point(15, 327);
            this.btnPay.Name = "btnPay";
            this.btnPay.PressedState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image7")));
            this.btnPay.PressedState.ImageSize = new System.Drawing.Size(25, 25);
            this.btnPay.Size = new System.Drawing.Size(37, 40);
            this.btnPay.TabIndex = 5;
            this.guna2HtmlToolTip1.SetToolTip(this.btnPay, "Lịch sử thanh toán");
            this.btnPay.Click += new System.EventHandler(this.GunaButton_Click);
            // 
            // btnPackage
            // 
            this.btnPackage.BackColor = System.Drawing.Color.Transparent;
            this.btnPackage.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnPackage.HoverState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image8")));
            this.btnPackage.HoverState.ImageSize = new System.Drawing.Size(25, 25);
            this.btnPackage.Image = ((System.Drawing.Image)(resources.GetObject("btnPackage.Image")));
            this.btnPackage.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnPackage.ImageRotate = 0F;
            this.btnPackage.ImageSize = new System.Drawing.Size(25, 25);
            this.btnPackage.Location = new System.Drawing.Point(15, 383);
            this.btnPackage.Name = "btnPackage";
            this.btnPackage.PressedState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image9")));
            this.btnPackage.PressedState.ImageSize = new System.Drawing.Size(25, 25);
            this.btnPackage.Size = new System.Drawing.Size(37, 40);
            this.btnPackage.TabIndex = 4;
            this.guna2HtmlToolTip1.SetToolTip(this.btnPackage, "Gói tập");
            this.btnPackage.Click += new System.EventHandler(this.GunaButton_Click);
            // 
            // btnTrainer
            // 
            this.btnTrainer.BackColor = System.Drawing.Color.Transparent;
            this.btnTrainer.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnTrainer.HoverState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image10")));
            this.btnTrainer.HoverState.ImageSize = new System.Drawing.Size(25, 25);
            this.btnTrainer.Image = ((System.Drawing.Image)(resources.GetObject("btnTrainer.Image")));
            this.btnTrainer.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnTrainer.ImageRotate = 0F;
            this.btnTrainer.ImageSize = new System.Drawing.Size(25, 25);
            this.btnTrainer.Location = new System.Drawing.Point(15, 271);
            this.btnTrainer.Name = "btnTrainer";
            this.btnTrainer.PressedState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image11")));
            this.btnTrainer.PressedState.ImageSize = new System.Drawing.Size(25, 25);
            this.btnTrainer.Size = new System.Drawing.Size(37, 40);
            this.btnTrainer.TabIndex = 4;
            this.guna2HtmlToolTip1.SetToolTip(this.btnTrainer, "Huấn luyện viên");
            this.btnTrainer.Click += new System.EventHandler(this.GunaButton_Click);
            // 
            // btnMember
            // 
            this.btnMember.BackColor = System.Drawing.Color.Transparent;
            this.btnMember.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnMember.HoverState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image12")));
            this.btnMember.HoverState.ImageSize = new System.Drawing.Size(25, 25);
            this.btnMember.Image = ((System.Drawing.Image)(resources.GetObject("btnMember.Image")));
            this.btnMember.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnMember.ImageRotate = 0F;
            this.btnMember.ImageSize = new System.Drawing.Size(25, 25);
            this.btnMember.Location = new System.Drawing.Point(15, 215);
            this.btnMember.Name = "btnMember";
            this.btnMember.PressedState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image13")));
            this.btnMember.PressedState.ImageSize = new System.Drawing.Size(25, 25);
            this.btnMember.Size = new System.Drawing.Size(37, 40);
            this.btnMember.TabIndex = 3;
            this.guna2HtmlToolTip1.SetToolTip(this.btnMember, "Thành viên");
            this.btnMember.Click += new System.EventHandler(this.GunaButton_Click);
            // 
            // btnSchedule
            // 
            this.btnSchedule.BackColor = System.Drawing.Color.Transparent;
            this.btnSchedule.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnSchedule.HoverState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image14")));
            this.btnSchedule.HoverState.ImageSize = new System.Drawing.Size(25, 25);
            this.btnSchedule.Image = ((System.Drawing.Image)(resources.GetObject("btnSchedule.Image")));
            this.btnSchedule.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnSchedule.ImageRotate = 0F;
            this.btnSchedule.ImageSize = new System.Drawing.Size(25, 25);
            this.btnSchedule.Location = new System.Drawing.Point(15, 159);
            this.btnSchedule.Name = "btnSchedule";
            this.btnSchedule.PressedState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image15")));
            this.btnSchedule.PressedState.ImageSize = new System.Drawing.Size(25, 25);
            this.btnSchedule.Size = new System.Drawing.Size(37, 40);
            this.btnSchedule.TabIndex = 2;
            this.guna2HtmlToolTip1.SetToolTip(this.btnSchedule, "Lịch tập");
            this.btnSchedule.Click += new System.EventHandler(this.GunaButton_Click);
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.Color.Transparent;
            this.btnHome.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnHome.HoverState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image16")));
            this.btnHome.HoverState.ImageSize = new System.Drawing.Size(25, 25);
            this.btnHome.Image = ((System.Drawing.Image)(resources.GetObject("btnHome.Image")));
            this.btnHome.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnHome.ImageRotate = 0F;
            this.btnHome.ImageSize = new System.Drawing.Size(25, 25);
            this.btnHome.Location = new System.Drawing.Point(15, 103);
            this.btnHome.Name = "btnHome";
            this.btnHome.PressedState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image17")));
            this.btnHome.PressedState.ImageSize = new System.Drawing.Size(25, 25);
            this.btnHome.Size = new System.Drawing.Size(37, 40);
            this.btnHome.TabIndex = 1;
            this.guna2HtmlToolTip1.SetToolTip(this.btnHome, "Trang chủ");
            this.btnHome.Click += new System.EventHandler(this.GunaButton_Click);
            // 
            // btnNotifi
            // 
            this.btnNotifi.BackColor = System.Drawing.Color.Transparent;
            this.btnNotifi.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnNotifi.HoverState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image18")));
            this.btnNotifi.HoverState.ImageSize = new System.Drawing.Size(25, 25);
            this.btnNotifi.Image = ((System.Drawing.Image)(resources.GetObject("btnNotifi.Image")));
            this.btnNotifi.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnNotifi.ImageRotate = 0F;
            this.btnNotifi.ImageSize = new System.Drawing.Size(25, 25);
            this.btnNotifi.Location = new System.Drawing.Point(15, 23);
            this.btnNotifi.Name = "btnNotifi";
            this.btnNotifi.PressedState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image19")));
            this.btnNotifi.PressedState.ImageSize = new System.Drawing.Size(25, 25);
            this.btnNotifi.Size = new System.Drawing.Size(37, 40);
            this.btnNotifi.TabIndex = 0;
            this.guna2HtmlToolTip1.SetToolTip(this.btnNotifi, "Thông báo");
            this.btnNotifi.Click += new System.EventHandler(this.GunaButton_Click);
            // 
            // guna2HtmlToolTip1
            // 
            this.guna2HtmlToolTip1.AllowLinksHandling = true;
            this.guna2HtmlToolTip1.ForeColor = System.Drawing.Color.Black;
            this.guna2HtmlToolTip1.IsBalloon = true;
            this.guna2HtmlToolTip1.MaximumSize = new System.Drawing.Size(0, 0);
            // 
            // plHome
            // 
            this.plHome.BorderRadius = 20;
            this.plHome.Location = new System.Drawing.Point(86, 10);
            this.plHome.Name = "plHome";
            this.plHome.Size = new System.Drawing.Size(902, 676);
            this.plHome.TabIndex = 1;
            // 
            // FrmDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1000, 697);
            this.Controls.Add(this.plHome);
            this.Controls.Add(this.plTaskBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmDashboard";
            this.Load += new System.EventHandler(this.FrmDashboard_Load);
            this.plTaskBar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2CustomGradientPanel plTaskBar;
        private Guna.UI2.WinForms.Guna2ImageButton btnNotifi;
        private Guna.UI2.WinForms.Guna2ImageButton btnSchedule;
        private Guna.UI2.WinForms.Guna2ImageButton btnHome;
        private Guna.UI2.WinForms.Guna2ImageButton btnPay;
        private Guna.UI2.WinForms.Guna2ImageButton btnTrainer;
        private Guna.UI2.WinForms.Guna2ImageButton btnMember;
        private Guna.UI2.WinForms.Guna2ImageButton btnLogOut;
        private Guna.UI2.WinForms.Guna2ImageButton btnClass;
        private Guna.UI2.WinForms.Guna2ImageButton btnPackage;
        private Guna.UI2.WinForms.Guna2HtmlToolTip guna2HtmlToolTip1;
        private Guna.UI2.WinForms.Guna2AnimateWindow guna2AnimateWindow1;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel plHome;
        private Guna.UI2.WinForms.Guna2ImageButton btnSP;
    }
}