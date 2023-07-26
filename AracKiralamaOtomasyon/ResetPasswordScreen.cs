using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;  // Mail Gönderimi için 
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Data.SqlClient;

namespace AracKiralamaOtomasyon
{
    public partial class ResetPasswordScreen : Form
    {
        public ResetPasswordScreen()
        {
            InitializeComponent();
        }
        // veritabanı bağlantısı oluştur
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-BTIS91A;Initial Catalog=Db_AracKiralama;Integrated Security=True");

        //error provider nesnesini yarat
        ErrorProvider errorProvider= new ErrorProvider();


        // Methods
        private void SifreGonder(string aliciEposta)
        {
            string ad = "";
            string passFromDb = "";

            try
            {
                baglanti.Open(); // veritabanı bağlantısını aç
                SqlCommand cmd = new SqlCommand("select Ad,Mail , Sifre  from tblUye where Mail=@mail", baglanti);
                cmd.Parameters.AddWithValue("@mail", txtEposta.Text); // @mail parametresini geç
                SqlDataReader reader; // data okuyucu tanımlama
                reader = cmd.ExecuteReader(); // sorguyu execute et ve sonucu reader a aktar
                if (reader.Read()) // sonuc var ise
                {
                    ad = reader.GetString(0);
                    passFromDb = reader.GetString(2);


                    MailMessage mail = new MailMessage(); // mesaj gönderme kütüphanesi
                    SmtpClient smtpServer = new SmtpClient("smtp.gmail.com"); // gmail smtp adresi

                    mail.From = new MailAddress("arackiralamayc@gmail.com");  // maili gönderecek olan eposta
                    mail.To.Add(aliciEposta);                             // alici eposta adresi
                    mail.Subject = "Araç Kiralama Otomasyonu Şifreniz";  // mail konusu
                    mail.Body = "Araç Kiralama Otomasyonu Giriş Şifreniz: " + passFromDb; // mail içeriğine db den çekilen passwordu yazdır.

                    smtpServer.Port = 587; // gmail smtp portu
                    smtpServer.Credentials = new NetworkCredential("arackiralamayc@gmail.com", "rniskylvicjdzcvj"); // mail gönderecek hesabın eposta - şifresi
                    smtpServer.EnableSsl = true; //SSL aktif et

                    smtpServer.Send(mail);  // maili gönder
                    MessageBox.Show("Şifreniz " + aliciEposta + " adresine gönderildi."); // kullanıcıya mesajın gönderildiğine dair mesaj ver
                    this.Close(); // ekranı kapat

                }
                else // girilen eposta ile eşleşen kayıt bulunamazsa
                {
                    MessageBox.Show("Girdiğiniz E-Posta ile eşleşen kayıt bulunamadı !");
                    txtEposta.Text = "E-Posta adresinizi giriniz";
                    txtEposta.ForeColor = Color.Gray;

                }


            }
            catch (Exception ex)  // try bloğu içerisinde bir hata oluştuğunda
            {
                MessageBox.Show(ex.ToString());

            }
            finally
            {
                baglanti.Close();  // veritabanı bağlantısını kapat
            }


           
        }
        private bool IsValidEmail(string email)  // verilen parametrenin eposta olup olmadığını kontrol eder
        {
            if (string.IsNullOrWhiteSpace(email))
                return true;
            try
            {
                MailAddress mailAddress = new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        private void ResetPasswordScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
           

        }

        private void ResetPasswordScreen_Shown(object sender, EventArgs e)
        {
            lblSifreSifirlama.Focus();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if(txtEposta.Text== "E-Posta adresinizi giriniz")
            {
                txtEposta.Text = "";
                txtEposta.ForeColor = Color.Black;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if(txtEposta.Text=="")
            {
                txtEposta.Text = "E-Posta adresinizi giriniz";
                txtEposta.ForeColor = Color.Gray;
            }
        }


        private void txtEposta_Validating(object sender, CancelEventArgs e)
        {
            string email = txtEposta.Text;
            bool isValid = IsValidEmail(email);
            if (!isValid)
            {
                if (txtEposta.Text == "E-Posta adresinizi giriniz")
                {
                    txtEposta.BackColor = Color.White;
                    errorProvider.SetError(txtEposta, "");
                }
                else
                {
                    // Eposta yanlış formatta
                    txtEposta.BackColor = Color.FromArgb(255, 114, 86);
                    txtEposta.ForeColor = Color.Black;
                    errorProvider.SetError(txtEposta, "Lütfen geçerli bir eposta adresi girin.");
                    e.Cancel = false;
                }

            }
            else
            {
                // Eposta doğru formatlıdır
                txtEposta.BackColor = Color.White;
                txtEposta.ForeColor = Color.Black;
                errorProvider.SetError(txtEposta, "");
                e.Cancel = false;
            }
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            lblSifreSifirlama.Focus();
        }

        private void btnSifreGonder_Click(object sender, EventArgs e)
        {
            if (errorProvider.GetError(txtEposta) == "")
            {
                // Şifre Gönderme işlemi yapılıyor.
                if(txtEposta.Text == "E-Posta adresinizi giriniz")
                {
                    MessageBox.Show("Lütfen bir E-Posta adresi girin.");
                    txtEposta.Focus();
                }
                else
                {
                    SifreGonder(txtEposta.Text);
                }
            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir E-Posta adresi girin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }  
        }
    }
}
