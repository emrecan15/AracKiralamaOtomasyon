namespace AracKiralamaOtomasyon
{
    partial class LoginScreen
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginScreen));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblLeftNumber = new System.Windows.Forms.Label();
            this.lblLeftLogo = new System.Windows.Forms.Label();
            this.lblLeftText3 = new System.Windows.Forms.Label();
            this.lblLeftText2 = new System.Windows.Forms.Label();
            this.lblLeftText1 = new System.Windows.Forms.Label();
            this.lblRightTop = new System.Windows.Forms.Label();
            this.lblEposta = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEposta = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblSifreReset = new System.Windows.Forms.LinkLabel();
            this.btnGirisYap = new System.Windows.Forms.Button();
            this.btnKaydol = new System.Windows.Forms.Button();
            this.lblRightIcon = new System.Windows.Forms.Label();
            this.checkBoxShowPassword = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
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
            this.panel1.TabIndex = 0;
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
            this.lblLeftLogo.Image = ((System.Drawing.Image)(resources.GetObject("lblLeftLogo.Image")));
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
            // lblRightTop
            // 
            this.lblRightTop.AutoSize = true;
            this.lblRightTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblRightTop.Location = new System.Drawing.Point(397, 34);
            this.lblRightTop.Name = "lblRightTop";
            this.lblRightTop.Size = new System.Drawing.Size(405, 29);
            this.lblRightTop.TabIndex = 1;
            this.lblRightTop.Text = "ARAÇ KİRALAMA OTOMASYONU";
            // 
            // lblEposta
            // 
            this.lblEposta.AutoSize = true;
            this.lblEposta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblEposta.Location = new System.Drawing.Point(463, 241);
            this.lblEposta.Name = "lblEposta";
            this.lblEposta.Size = new System.Drawing.Size(62, 16);
            this.lblEposta.TabIndex = 3;
            this.lblEposta.Text = "E-Posta";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(463, 310);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Şifre";
            // 
            // txtEposta
            // 
            this.txtEposta.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtEposta.ForeColor = System.Drawing.Color.Gray;
            this.txtEposta.Location = new System.Drawing.Point(466, 263);
            this.txtEposta.MaxLength = 100;
            this.txtEposta.Name = "txtEposta";
            this.txtEposta.Size = new System.Drawing.Size(270, 24);
            this.txtEposta.TabIndex = 5;
            this.txtEposta.Text = "E-Posta adresinizi giriniz";
            this.txtEposta.Enter += new System.EventHandler(this.txtEposta_Enter);
            this.txtEposta.Leave += new System.EventHandler(this.txtEposta_Leave);
            this.txtEposta.Validating += new System.ComponentModel.CancelEventHandler(this.txtEposta_Validating);
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtPassword.ForeColor = System.Drawing.Color.Gray;
            this.txtPassword.Location = new System.Drawing.Point(466, 335);
            this.txtPassword.MaxLength = 20;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(270, 24);
            this.txtPassword.TabIndex = 6;
            this.txtPassword.Text = "Şifrenizi giriniz";
            this.txtPassword.Enter += new System.EventHandler(this.txtPassword_Enter);
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
            this.txtPassword.Leave += new System.EventHandler(this.txtPassword_Leave);
            // 
            // lblSifreReset
            // 
            this.lblSifreReset.AutoSize = true;
            this.lblSifreReset.LinkColor = System.Drawing.Color.Gray;
            this.lblSifreReset.Location = new System.Drawing.Point(639, 362);
            this.lblSifreReset.Name = "lblSifreReset";
            this.lblSifreReset.Size = new System.Drawing.Size(97, 13);
            this.lblSifreReset.TabIndex = 7;
            this.lblSifreReset.TabStop = true;
            this.lblSifreReset.Text = "Şifreni mi unuttun ?";
            this.lblSifreReset.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblSifreReset_LinkClicked);
            // 
            // btnGirisYap
            // 
            this.btnGirisYap.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGirisYap.Location = new System.Drawing.Point(466, 391);
            this.btnGirisYap.Name = "btnGirisYap";
            this.btnGirisYap.Size = new System.Drawing.Size(120, 40);
            this.btnGirisYap.TabIndex = 8;
            this.btnGirisYap.Text = "Giriş Yap";
            this.btnGirisYap.UseVisualStyleBackColor = true;
            this.btnGirisYap.Click += new System.EventHandler(this.btnGirisYap_Click);
            // 
            // btnKaydol
            // 
            this.btnKaydol.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKaydol.Location = new System.Drawing.Point(616, 391);
            this.btnKaydol.Name = "btnKaydol";
            this.btnKaydol.Size = new System.Drawing.Size(120, 40);
            this.btnKaydol.TabIndex = 9;
            this.btnKaydol.Text = "Kaydol";
            this.btnKaydol.UseVisualStyleBackColor = true;
            this.btnKaydol.Click += new System.EventHandler(this.btnKaydol_Click);
            // 
            // lblRightIcon
            // 
            this.lblRightIcon.Image = ((System.Drawing.Image)(resources.GetObject("lblRightIcon.Image")));
            this.lblRightIcon.Location = new System.Drawing.Point(527, 83);
            this.lblRightIcon.Name = "lblRightIcon";
            this.lblRightIcon.Size = new System.Drawing.Size(124, 84);
            this.lblRightIcon.TabIndex = 2;
            // 
            // checkBoxShowPassword
            // 
            this.checkBoxShowPassword.AutoSize = true;
            this.checkBoxShowPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.checkBoxShowPassword.Location = new System.Drawing.Point(740, 340);
            this.checkBoxShowPassword.Name = "checkBoxShowPassword";
            this.checkBoxShowPassword.Size = new System.Drawing.Size(88, 17);
            this.checkBoxShowPassword.TabIndex = 10;
            this.checkBoxShowPassword.Text = "Şifreyi Göster";
            this.checkBoxShowPassword.UseVisualStyleBackColor = true;
            this.checkBoxShowPassword.CheckedChanged += new System.EventHandler(this.checkBoxShowPassword_CheckedChanged);
            // 
            // LoginScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 511);
            this.Controls.Add(this.checkBoxShowPassword);
            this.Controls.Add(this.btnKaydol);
            this.Controls.Add(this.btnGirisYap);
            this.Controls.Add(this.lblSifreReset);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtEposta);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblEposta);
            this.Controls.Add(this.lblRightIcon);
            this.Controls.Add(this.lblRightTop);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LoginScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Giriş";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LoginScreen_FormClosing);
            this.Shown += new System.EventHandler(this.LoginScreen_Shown);
            this.Click += new System.EventHandler(this.LoginScreen_Click);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblLeftText1;
        private System.Windows.Forms.Label lblLeftText2;
        private System.Windows.Forms.Label lblLeftText3;
        private System.Windows.Forms.Label lblLeftLogo;
        private System.Windows.Forms.Label lblLeftNumber;
        private System.Windows.Forms.Label lblRightTop;
        private System.Windows.Forms.Label lblRightIcon;
        private System.Windows.Forms.Label lblEposta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEposta;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.LinkLabel lblSifreReset;
        private System.Windows.Forms.Button btnGirisYap;
        private System.Windows.Forms.Button btnKaydol;
        private System.Windows.Forms.CheckBox checkBoxShowPassword;
    }
}

