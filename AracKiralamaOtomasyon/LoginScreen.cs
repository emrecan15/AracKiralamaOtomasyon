using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;

using System.Data.SqlClient;
using System.CodeDom;

namespace AracKiralamaOtomasyon
{
    public partial class LoginScreen : Form
    {
        public static string tc = "";
        public static string userName = "";
        public static string lastName = "";
        public static string telNo = "";
        public static string eposta = "";
        public static string password = "";
        
        public LoginScreen()
        {
            InitializeComponent();
        }
        // MSSQL Veritabanı bağlantısı kurar
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-BTIS91A;Initial Catalog=Db_AracKiralama;Integrated Security=True");

        // Kullanıcının girdiği verilerin doğruluğunu kontrol edip hatalıysa hata mesajı gösterir
        ErrorProvider errorProvider= new ErrorProvider();


        // Methods
        private bool IsValidEmail(string email)     // Epostanın doğru formatta olup olmadığını kontrol eder true - false döner
        {
            if (string.IsNullOrWhiteSpace(email))  
                return true;
            try
            {
                MailAddress mailAddress = new MailAddress(email);  //Girilen emaili formata uygun değilse hata fırlatır ve catch bloğu çalışır
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        private void txtEposta_Enter(object sender, EventArgs e)        // Textboxa girildiğine placeholder silmek için
        {
            if(txtEposta.Text == "E-Posta adresinizi giriniz")
            {
                txtEposta.Text = "";
                txtEposta.ForeColor = Color.Black;
            }
        }

        private void txtEposta_Leave(object sender, EventArgs e)     // Textboxdan çıkıldığında eğer veri girilmediyse placeholderı tekrar yazdırır
        {
            if(txtEposta.Text == "")
            {
                txtEposta.Text= "E-Posta adresinizi giriniz";
                txtEposta.ForeColor= Color.Gray;
            }
        }

       

        private void txtPassword_Leave(object sender, EventArgs e)  // Textboxdan çıkıldığında eğer veri girilmediyse placeholderı tekrar yazdırır
        {
            if (txtPassword.Text == "")
            {
                txtPassword.PasswordChar = '\u0000';  // şifreyi görünür yap
                txtPassword.Text = "Şifrenizi giriniz";
                txtPassword.ForeColor = Color.Gray;
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)  // Textboxa girildiğine placeholder siler
        {
            if (txtPassword.Text == "Şifrenizi giriniz")
            {
                txtPassword.Text = "";
                if (!checkBoxShowPassword.Checked)   // şifreyi göster checkboxı işaretli değilse
                    txtPassword.PasswordChar = '*'; // şifreyi sansürle
                txtPassword.ForeColor = Color.Black;
            }
        }

        // Başlangıçta textboxa focus olmasını önler
        private void LoginScreen_Shown(object sender, EventArgs e)
        {
            lblEposta.Focus();
        }

        // Ekranda boş bir yere tıklandığında textbox odağını kaldırmak için
        private void LoginScreen_Click(object sender, EventArgs e)
        {
            lblEposta.Focus();
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            lblEposta.Focus();
        }


        // Kayıt olma formunu açar ve bu formu gizler
        private void btnKaydol_Click(object sender, EventArgs e)
        {
            RegisterScreen registerScreen= new RegisterScreen();
            registerScreen.Show();
            this.Hide();
        }

        // ekran kapatılırsa çalışacak kod bloğu
        private void LoginScreen_FormClosing(object sender, FormClosingEventArgs e) 
        {

            Application.Exit();  // uygulamayı sonlandır
        }

        // Şifre sıfırlama ekranını açar
        private void lblSifreReset_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ResetPasswordScreen resetPasswordScreen = new ResetPasswordScreen();
            resetPasswordScreen.Show();

        }

        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            if (txtEposta.Text=="E-Posta adresinizi giriniz" || txtPassword.Text == "Şifrenizi Giriniz")   // Eposta - şifre boş ise
            {
                MessageBox.Show("Lütfen E-Posta ve şifrenizi eksiksiz girin.");
            }
            
            else 
            {

                try             
                {
                    baglanti.Open();    // veritabanı bağlantısını aktif et

                    //sql sorgusu oluşturma
                    SqlCommand cmd = new SqlCommand("select Mail , Sifre , YetkiDuzeyi ,Ad,Soyad,TelNo,Tc from tblUye where Mail=@mail and Sifre=@sifre",baglanti);

                    //Parametre geçiliyor...
                    cmd.Parameters.AddWithValue("@mail",txtEposta.Text);
                    cmd.Parameters.AddWithValue("@sifre", txtPassword.Text);
                    // Data okuyucu
                    SqlDataReader reader;
                    reader = cmd.ExecuteReader();   // Sorguyu execute et dönen değeri reader değişkenine at
                    if(reader.Read())   // Girilen eposta ve şifreyle eşleşen kayıt varsa 
                    {
                        string permission = reader.GetValue(2).ToString();  // Sorgu sonucundan YetkiDuzeyi (2 nolu index) çekip permission değişkenine at
                        tc = reader.GetValue(6).ToString();
                        userName = reader.GetValue(3).ToString();   // 3 nolu index (Ad) verisini name değişkenine at
                        lastName= reader.GetValue(4).ToString();
                        telNo= reader.GetValue(5).ToString();
                        password = reader.GetValue(1).ToString();
                        eposta = reader.GetValue(0).ToString();

                        



                        switch(permission)   // Giriş yapan üyenin türünü kontrol et
                        {
                                case "1":  // permission 1 ise normal üye
                                    {
                                        
                                        MainScreen mainScreen = new MainScreen();
                                    //mainScreen.ad = name;       // Ana ekrana kullanıcının adını aktarma
                                        
                                        mainScreen.Show();          // Ana ekranı göster
                                        this.Hide();                // Bu ekranı gizle
                                        break;
                                    }
                                case "2":  // permission 2 ise admin 
                                    {
                                     AdminScreen adminScreen = new AdminScreen();
                                     adminScreen.Show();
                                     this.Hide();
                                    break;
                                    }
                               default:   // aksi durumda pasif üye 
                                {
                                    MessageBox.Show("Üyeliğiniz pasif durumda lütfen yöneticiniz ile iletişime geçin.");
                                    break;
                                }
                        }
                    }
                    else    // Girilen Eposta ve şifreyle eşleşen kayıt yoksa
                    {
                        if (txtPassword.Text =="Şifrenizi giriniz")
                        {
                            MessageBox.Show("Lütfen E-Posta ve şifrenizi eksiksiz girin.");
                        }
                        else
                        MessageBox.Show("E-Posta veya Şifre Hatalı !");
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());     // try bloğu içerisinde herhangi bir hata olursa hatayı yazdır.
                
                }
                finally
                {
                    baglanti.Close();   // Veritabanı bağlantısını kapatır
                }
            }
        }

        private void txtEposta_Validating(object sender, CancelEventArgs e)  //textbox içerisine girilen verinin formatını kontrol eder
        {
            string email = txtEposta.Text;
            bool isValid = IsValidEmail(email); // Girilen değer eposta mı ?
            if (!isValid)       // Eposta değilse
            {
                // Hata mesajının görüntülenme durumları

                if (txtEposta.Text == "E-Posta adresinizi giriniz") 
                {
                    txtEposta.BackColor = Color.White;
                    errorProvider.SetError(txtEposta, "");
                }
                else
                {
                    // Eposta yanlış formatta
                    txtEposta.BackColor = Color.FromArgb(255, 114, 86);  // arkaplanı kırmızı yapar
                    txtEposta.ForeColor = Color.Black;                  // yazı rengini siyah yapar
                    errorProvider.SetError(txtEposta, "Lütfen geçerli bir eposta adresi girin.");   //Hata mesajı gösterir
                    e.Cancel = false;  // Hata varken textboxdan çıkmaya izin verir
                }

            }
            else
            {
                // Eposta doğru formatlıdır
                txtEposta.BackColor = Color.White;  // arkaplanı beyaz yapar
                txtEposta.ForeColor = Color.Black;  // yazı rengini siyah yapar
                errorProvider.SetError(txtEposta, "");  // hata mesajını kaldırır
                e.Cancel = false; 
            }
        }

        // Login ekranı şifreyi göster checkboxı durum değişimi
        private void checkBoxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxShowPassword.Checked)    // checkbox işaretliyse 
            {
                txtPassword.PasswordChar = '\u0000';    // şifreyi göster
            }
            else
            {
                // İşaretli değilse şifreyi gösterme

                // textbox ın boş olup olmama durumu ve placeholder yazılı olma durumunun kontrolü
                if (!String.IsNullOrEmpty(txtPassword.Text) && txtPassword.Text != "Şifrenizi giriniz")
                    txtPassword.PasswordChar = '*';
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnGirisYap.PerformClick();
            }
        }
    }
}
