namespace AracKiralamaOtomasyon
{
    partial class ResetPasswordScreen
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblSifreSifirlama = new System.Windows.Forms.Label();
            this.btnSifreGonder = new System.Windows.Forms.Button();
            this.txtEposta = new System.Windows.Forms.TextBox();
            this.lblText2 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblSifreSifirlama);
            this.panel2.Controls.Add(this.btnSifreGonder);
            this.panel2.Controls.Add(this.txtEposta);
            this.panel2.Controls.Add(this.lblText2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(634, 311);
            this.panel2.TabIndex = 2;
            this.panel2.Click += new System.EventHandler(this.panel2_Click);
            // 
            // lblSifreSifirlama
            // 
            this.lblSifreSifirlama.AutoSize = true;
            this.lblSifreSifirlama.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSifreSifirlama.Location = new System.Drawing.Point(225, 27);
            this.lblSifreSifirlama.Name = "lblSifreSifirlama";
            this.lblSifreSifirlama.Size = new System.Drawing.Size(178, 29);
            this.lblSifreSifirlama.TabIndex = 3;
            this.lblSifreSifirlama.Text = "Şifre Sıfırlama";
            // 
            // btnSifreGonder
            // 
            this.btnSifreGonder.AutoSize = true;
            this.btnSifreGonder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSifreGonder.Location = new System.Drawing.Point(254, 165);
            this.btnSifreGonder.MinimumSize = new System.Drawing.Size(0, 30);
            this.btnSifreGonder.Name = "btnSifreGonder";
            this.btnSifreGonder.Size = new System.Drawing.Size(97, 30);
            this.btnSifreGonder.TabIndex = 2;
            this.btnSifreGonder.Text = "Şifreyi Gönder";
            this.btnSifreGonder.UseVisualStyleBackColor = true;
            this.btnSifreGonder.Click += new System.EventHandler(this.btnSifreGonder_Click);
            // 
            // txtEposta
            // 
            this.txtEposta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtEposta.ForeColor = System.Drawing.Color.Gray;
            this.txtEposta.Location = new System.Drawing.Point(175, 127);
            this.txtEposta.Name = "txtEposta";
            this.txtEposta.Size = new System.Drawing.Size(280, 22);
            this.txtEposta.TabIndex = 1;
            this.txtEposta.Text = "E-Posta adresinizi giriniz";
            this.txtEposta.Enter += new System.EventHandler(this.textBox1_Enter);
            this.txtEposta.Leave += new System.EventHandler(this.textBox1_Leave);
            this.txtEposta.Validating += new System.ComponentModel.CancelEventHandler(this.txtEposta_Validating);
            // 
            // lblText2
            // 
            this.lblText2.AutoSize = true;
            this.lblText2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblText2.Location = new System.Drawing.Point(68, 91);
            this.lblText2.Name = "lblText2";
            this.lblText2.Size = new System.Drawing.Size(504, 24);
            this.lblText2.TabIndex = 0;
            this.lblText2.Text = "Şifresini öğrenmek istediğiniz hesabın e-posta adresini girin";
            // 
            // ResetPasswordScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 311);
            this.Controls.Add(this.panel2);
            this.Name = "ResetPasswordScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Şifre Sıfırlama";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ResetPasswordScreen_FormClosing);
            this.Shown += new System.EventHandler(this.ResetPasswordScreen_Shown);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSifreGonder;
        private System.Windows.Forms.TextBox txtEposta;
        private System.Windows.Forms.Label lblText2;
        private System.Windows.Forms.Label lblSifreSifirlama;
    }
}