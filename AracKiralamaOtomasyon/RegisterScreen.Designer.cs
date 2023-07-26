namespace AracKiralamaOtomasyon
{
    partial class RegisterScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterScreen));
            this.btnKaydol = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtEposta = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblEposta = new System.Windows.Forms.Label();
            this.lblRightTop = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblLeftNumber = new System.Windows.Forms.Label();
            this.lblLeftLogo = new System.Windows.Forms.Label();
            this.lblLeftText3 = new System.Windows.Forms.Label();
            this.lblLeftText2 = new System.Windows.Forms.Label();
            this.lblLeftText1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPasswordRepeat = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTcKimlik = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAd = new System.Windows.Forms.TextBox();
            this.txtSoyad = new System.Windows.Forms.TextBox();
            this.txtNumara = new System.Windows.Forms.TextBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.panelRight = new System.Windows.Forms.Panel();
            this.checkBoxShowPassword = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnKaydol
            // 
            this.btnKaydol.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKaydol.Location = new System.Drawing.Point(536, 402);
            this.btnKaydol.Name = "btnKaydol";
            this.btnKaydol.Size = new System.Drawing.Size(120, 40);
            this.btnKaydol.TabIndex = 8;
            this.btnKaydol.Text = "Kaydol";
            this.btnKaydol.UseVisualStyleBackColor = true;
            this.btnKaydol.Click += new System.EventHandler(this.btnKaydol_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtPassword.ForeColor = System.Drawing.Color.Gray;
            this.txtPassword.Location = new System.Drawing.Point(476, 307);
            this.txtPassword.MaxLength = 20;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(228, 24);
            this.txtPassword.TabIndex = 6;
            this.txtPassword.Text = "Şifre";
            this.txtPassword.Enter += new System.EventHandler(this.txtPassword_Enter);
            this.txtPassword.Leave += new System.EventHandler(this.txtPassword_Leave);
            this.txtPassword.Validating += new System.ComponentModel.CancelEventHandler(this.txtPassword_Validating);
            // 
            // txtEposta
            // 
            this.txtEposta.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtEposta.ForeColor = System.Drawing.Color.Gray;
            this.txtEposta.Location = new System.Drawing.Point(476, 263);
            this.txtEposta.MaxLength = 100;
            this.txtEposta.Name = "txtEposta";
            this.txtEposta.Size = new System.Drawing.Size(228, 24);
            this.txtEposta.TabIndex = 5;
            this.txtEposta.Text = "E-Posta";
            this.txtEposta.Enter += new System.EventHandler(this.txtEposta_Enter);
            this.txtEposta.Leave += new System.EventHandler(this.txtEposta_Leave);
            this.txtEposta.Validating += new System.ComponentModel.CancelEventHandler(this.txtEposta_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(427, 312);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 16);
            this.label1.TabIndex = 14;
            this.label1.Text = "Şifre:";
            // 
            // lblEposta
            // 
            this.lblEposta.AutoSize = true;
            this.lblEposta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblEposta.Location = new System.Drawing.Point(392, 266);
            this.lblEposta.Name = "lblEposta";
            this.lblEposta.Size = new System.Drawing.Size(78, 20);
            this.lblEposta.TabIndex = 13;
            this.lblEposta.Text = "E-Posta:";
            // 
            // lblRightTop
            // 
            this.lblRightTop.AutoSize = true;
            this.lblRightTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblRightTop.Location = new System.Drawing.Point(528, 39);
            this.lblRightTop.Name = "lblRightTop";
            this.lblRightTop.Size = new System.Drawing.Size(128, 29);
            this.lblRightTop.TabIndex = 11;
            this.lblRightTop.Text = "KAYIT OL";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.lblLeftNumber);
            this.panel1.Controls.Add(this.lblLeftLogo);
            this.panel1.Controls.Add(this.lblLeftText3);
            this.panel1.Controls.Add(this.lblLeftText2);
            this.panel1.Controls.Add(this.lblLeftText1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(350, 511);
            this.panel1.TabIndex = 10;
            this.panel1.Click += new System.EventHandler(this.panel1_Click);
            // 
            // lblLeftNumber
            // 
            this.lblLeftNumber.AutoSize = true;
            this.lblLeftNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblLeftNumber.Location = new System.Drawing.Point(62, 391);
            this.lblLeftNumber.Name = "lblLeftNumber";
            this.lblLeftNumber.Size = new System.Drawing.Size(214, 31);
            this.lblLeftNumber.TabIndex = 4;
            this.lblLeftNumber.Text = "0216 555 44 32";
            // 
            // lblLeftLogo
            // 
            this.lblLeftLogo.Image = global::AracKiralamaOtomasyon.Properties.Resources.customerService;
            this.lblLeftLogo.Location = new System.Drawing.Point(127, 315);
            this.lblLeftLogo.Name = "lblLeftLogo";
            this.lblLeftLogo.Size = new System.Drawing.Size(67, 55);
            this.lblLeftLogo.TabIndex = 3;
            // 
            // lblLeftText3
            // 
            this.lblLeftText3.AutoSize = true;
            this.lblLeftText3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblLeftText3.Location = new System.Drawing.Point(32, 263);
            this.lblLeftText3.Name = "lblLeftText3";
            this.lblLeftText3.Size = new System.Drawing.Size(282, 31);
            this.lblLeftText3.TabIndex = 2;
            this.lblLeftText3.Text = "Müşteri Memnuniyeti";
            // 
            // lblLeftText2
            // 
            this.lblLeftText2.AutoSize = true;
            this.lblLeftText2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblLeftText2.Location = new System.Drawing.Point(138, 220);
            this.lblLeftText2.Name = "lblLeftText2";
            this.lblLeftText2.Size = new System.Drawing.Size(49, 31);
            this.lblLeftText2.TabIndex = 1;
            this.lblLeftText2.Text = "Ve";
            // 
            // lblLeftText1
            // 
            this.lblLeftText1.AutoSize = true;
            this.lblLeftText1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblLeftText1.Location = new System.Drawing.Point(61, 173);
            this.lblLeftText1.Name = "lblLeftText1";
            this.lblLeftText1.Size = new System.Drawing.Size(224, 31);
            this.lblLeftText1.TabIndex = 0;
            this.lblLeftText1.Text = "Kaliteli Güvenlik";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(377, 359);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 16);
            this.label2.TabIndex = 20;
            this.label2.Text = "Şifre Tekrar:";
            // 
            // txtPasswordRepeat
            // 
            this.txtPasswordRepeat.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtPasswordRepeat.ForeColor = System.Drawing.Color.Gray;
            this.txtPasswordRepeat.Location = new System.Drawing.Point(476, 354);
            this.txtPasswordRepeat.MaxLength = 20;
            this.txtPasswordRepeat.Name = "txtPasswordRepeat";
            this.txtPasswordRepeat.Size = new System.Drawing.Size(228, 24);
            this.txtPasswordRepeat.TabIndex = 7;
            this.txtPasswordRepeat.Text = "Şifre Tekrar";
            this.txtPasswordRepeat.Enter += new System.EventHandler(this.txtPasswordRepeat_Enter);
            this.txtPasswordRepeat.Leave += new System.EventHandler(this.txtPasswordRepeat_Leave);
            this.txtPasswordRepeat.Validating += new System.ComponentModel.CancelEventHandler(this.txtPasswordRepeat_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(438, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 20);
            this.label3.TabIndex = 22;
            this.label3.Text = "TC:";
            // 
            // txtTcKimlik
            // 
            this.txtTcKimlik.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtTcKimlik.ForeColor = System.Drawing.Color.Gray;
            this.txtTcKimlik.Location = new System.Drawing.Point(476, 90);
            this.txtTcKimlik.MaxLength = 11;
            this.txtTcKimlik.Name = "txtTcKimlik";
            this.txtTcKimlik.Size = new System.Drawing.Size(228, 24);
            this.txtTcKimlik.TabIndex = 1;
            this.txtTcKimlik.Text = "TC Kimlik No";
            this.txtTcKimlik.Enter += new System.EventHandler(this.txtTcKimlik_Enter);
            this.txtTcKimlik.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTcKimlik_KeyPress);
            this.txtTcKimlik.Leave += new System.EventHandler(this.txtTcKimlik_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(438, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 20);
            this.label4.TabIndex = 24;
            this.label4.Text = "Ad:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(406, 173);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 20);
            this.label5.TabIndex = 25;
            this.label5.Text = "Soyad:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(369, 222);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 20);
            this.label6.TabIndex = 26;
            this.label6.Text = "Telefon No:";
            // 
            // txtAd
            // 
            this.txtAd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtAd.ForeColor = System.Drawing.Color.Gray;
            this.txtAd.Location = new System.Drawing.Point(476, 130);
            this.txtAd.MaxLength = 100;
            this.txtAd.Name = "txtAd";
            this.txtAd.Size = new System.Drawing.Size(228, 24);
            this.txtAd.TabIndex = 2;
            this.txtAd.Text = "Adınız";
            this.txtAd.Enter += new System.EventHandler(this.txtAd_Enter);
            this.txtAd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAd_KeyPress);
            this.txtAd.Leave += new System.EventHandler(this.txtAd_Leave);
            // 
            // txtSoyad
            // 
            this.txtSoyad.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtSoyad.ForeColor = System.Drawing.Color.Gray;
            this.txtSoyad.Location = new System.Drawing.Point(476, 173);
            this.txtSoyad.MaxLength = 100;
            this.txtSoyad.Name = "txtSoyad";
            this.txtSoyad.Size = new System.Drawing.Size(228, 24);
            this.txtSoyad.TabIndex = 3;
            this.txtSoyad.Text = "Soyadınız";
            this.txtSoyad.Enter += new System.EventHandler(this.txtSoyad_Enter);
            this.txtSoyad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSoyad_KeyPress);
            this.txtSoyad.Leave += new System.EventHandler(this.txtSoyad_Leave);
            // 
            // txtNumara
            // 
            this.txtNumara.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtNumara.ForeColor = System.Drawing.Color.Gray;
            this.txtNumara.Location = new System.Drawing.Point(476, 220);
            this.txtNumara.MaxLength = 10;
            this.txtNumara.Name = "txtNumara";
            this.txtNumara.Size = new System.Drawing.Size(228, 24);
            this.txtNumara.TabIndex = 4;
            this.txtNumara.Text = "Telefon Numaranız";
            this.txtNumara.Enter += new System.EventHandler(this.txtNumara_Enter);
            this.txtNumara.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumara_KeyPress);
            this.txtNumara.Leave += new System.EventHandler(this.txtNumara_Leave);
            this.txtNumara.Validating += new System.ComponentModel.CancelEventHandler(this.txtNumara_Validating);
            // 
            // btnBack
            // 
            this.btnBack.Image = global::AracKiralamaOtomasyon.Properties.Resources.BackIcon;
            this.btnBack.Location = new System.Drawing.Point(475, 402);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(55, 40);
            this.btnBack.TabIndex = 9;
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // panelRight
            // 
            this.panelRight.Controls.Add(this.checkBoxShowPassword);
            this.panelRight.Location = new System.Drawing.Point(348, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(489, 511);
            this.panelRight.TabIndex = 27;
            this.panelRight.Click += new System.EventHandler(this.panelRight_Click);
            // 
            // checkBoxShowPassword
            // 
            this.checkBoxShowPassword.AutoSize = true;
            this.checkBoxShowPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.checkBoxShowPassword.Location = new System.Drawing.Point(266, 381);
            this.checkBoxShowPassword.Name = "checkBoxShowPassword";
            this.checkBoxShowPassword.Size = new System.Drawing.Size(88, 17);
            this.checkBoxShowPassword.TabIndex = 11;
            this.checkBoxShowPassword.Text = "Şifreyi Göster";
            this.checkBoxShowPassword.UseVisualStyleBackColor = true;
            this.checkBoxShowPassword.CheckedChanged += new System.EventHandler(this.checkBoxShowPassword_CheckedChanged);
            // 
            // RegisterScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 511);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.txtNumara);
            this.Controls.Add(this.txtSoyad);
            this.Controls.Add(this.txtAd);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTcKimlik);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPasswordRepeat);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnKaydol);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtEposta);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblEposta);
            this.Controls.Add(this.lblRightTop);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelRight);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RegisterScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kaydol";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RegisterScreen_FormClosing);
            this.Shown += new System.EventHandler(this.RegisterScreen_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelRight.ResumeLayout(false);
            this.panelRight.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnKaydol;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtEposta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblEposta;
        private System.Windows.Forms.Label lblRightTop;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblLeftNumber;
        private System.Windows.Forms.Label lblLeftLogo;
        private System.Windows.Forms.Label lblLeftText3;
        private System.Windows.Forms.Label lblLeftText2;
        private System.Windows.Forms.Label lblLeftText1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPasswordRepeat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTcKimlik;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAd;
        private System.Windows.Forms.TextBox txtSoyad;
        private System.Windows.Forms.TextBox txtNumara;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.CheckBox checkBoxShowPassword;
    }
}