using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient; // sql connection library
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Security.Cryptography.X509Certificates;
using System.Drawing.Text;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace AracKiralamaOtomasyon
{
    public partial class RegisterScreen : Form
    {
        public RegisterScreen()
        {
            InitializeComponent();
        }
        // veritabanı connection işlemi
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-BTIS91A;Initial Catalog=Db_AracKiralama;Integrated Security=True");

        // error provider nesnesi oluşturuluyor
        ErrorProvider errorProvider = new ErrorProvider();


        // form kapatıldığında yapılacak işlemler
        private void RegisterScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            LoginScreen loginScreen = new LoginScreen(); // login ekranınını oluştur
            loginScreen.Show(); // login ekranını göster
        }

        // geri butonuna tıklandığında yapılacak işlemler
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close(); // bu ekranı kapat
        }

        private void RegisterScreen_Shown(object sender, EventArgs e)
        {
            lblEposta.Focus(); // kayıt ol ekranı ilk açılışta focusu textboxdan almak için labela focuslan
        }

        private void btnKaydol_Click(object sender, EventArgs e) // kaydol butonuna tıklandığına çalışacak kodlar
        {
            // Tüm hataların düzeltilmesi kontrol ediliyor.
            if (
                errorProvider.GetError(txtTcKimlik) == "" 
                && errorProvider.GetError(txtAd) == "" 
                && errorProvider.GetError(txtSoyad) == "" 
                && errorProvider.GetError(txtNumara) == "" 
                && errorProvider.GetError(txtEposta) == "" 
                && errorProvider.GetError(txtPassword) == "" 
                && errorProvider.GetError(txtPasswordRepeat) == "")
           
            {
                // Textboxların içerisine herhangi bir veri girişi olmadığnda
                if(
                    txtTcKimlik.Text=="TC Kimlik No" 
                    || txtAd.Text =="Adınız" 
                    || txtSoyad.Text =="Soyadınız" 
                    || txtNumara.Text =="Telefon Numaranız" 
                    || txtEposta.Text=="E-Posta" 
                    || txtPassword.Text =="Şifre" 
                    || txtPasswordRepeat.Text=="Şifre Tekrar")
                {
                     MessageBox.Show("Lütfen tüm bilgileri eksiksiz doldurun.");
                }
                // Textboxlar boş değilse
                else
                {
                    try
                    {
                        baglanti.Open();        // veritabanı bağlantısını aç
                        SqlCommand ControlCmd = new SqlCommand("select Tc,Mail from tblUye where Tc = @tc or Mail=@mail  ", baglanti);
                        // parametre geçiliyor...
                        ControlCmd.Parameters.AddWithValue("@tc", txtTcKimlik.Text);
                        ControlCmd.Parameters.AddWithValue("@mail", txtEposta.Text);
                        SqlDataReader reader;  // data okuyucu tanımla

                        reader = ControlCmd.ExecuteReader(); // Sorguyu execute et ve dönen sonucu reader değişkenine at
                        if (reader.Read())  // Girilen bilgilerle eşleşen kayıt bulunursa
                        {
                            MessageBox.Show("Eşleşen kayıt bulundu !");
                        }
                        else
                        {
                            reader.Close(); // data okuyucuyu kapat
                            // Uye bilgilerini tblUye tablosuna insert et
                            SqlCommand cmd = 
                                new SqlCommand("INSERT INTO tblUye (Tc, Ad,Soyad,TelNo,Mail,Sifre) " +
                                                 "VALUES (@value1, @value2,@value3,@value4,@value5,@value6)", baglanti);
                          
                            //parametre geçiliyor...
                            cmd.Parameters.AddWithValue("@value1", txtTcKimlik.Text);
                            cmd.Parameters.AddWithValue("@value2", txtAd.Text);
                            cmd.Parameters.AddWithValue("@value3", txtSoyad.Text);
                            cmd.Parameters.AddWithValue("@value4", txtNumara.Text);
                            cmd.Parameters.AddWithValue("@value5", txtEposta.Text);
                            cmd.Parameters.AddWithValue("@value6", txtPassword.Text);
                            cmd.ExecuteNonQuery();  // sorguyu execute et

                            MessageBox.Show("Kayıt başarıyla gerçekleşti !");

                            this.Close(); // bu formu kapat

                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hata oluştu : " + ex.Message);
                    }
                    finally
                    {

                        baglanti.Close();       // veritabanı bağlantısını 

                    }
                }

            }
            else    //Error provider aktif olan textbox varsa kayıt işlemi gerçekleşmez
            {
                MessageBox.Show("Lütfen hataları düzeltin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private bool IsValidPhoneNumber(string phoneNumber) // Verilen parametre telefon numarası mı kontrol ediliyor
        {
            bool isValid = true;

            // Telefon numarasının uzunluğunu kontrol ediliyor.
            if (phoneNumber.Length != 10)
            {
                isValid = false;
            }

            // Telefon numarasının yalnızca sayılardan oluştuğu kontrol ediliyor.
            foreach (char c in phoneNumber)
            {
                if (!char.IsDigit(c))
                {
                    isValid = false;
                    break;
                }
            }

            return isValid;
        }

        private bool IsValidEmail(string email)     // Verilen parametre email formatına uygunluğu kontrol ediliyor
        {
            if (string.IsNullOrWhiteSpace(email)) // Eğer email boş ya da null ise, true döner
                return true;

            try   // Eğer email geçerli bir e-posta formatında değilse, false döndürülür. Aksi takdirde true döndürülür.
            {
                MailAddress mailAddress = new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

      

        private void txtTcKimlik_Enter(object sender, EventArgs e)  //textboxa girildiğinde yapılacak placeholder işlemi
        {
            if (txtTcKimlik.Text == "TC Kimlik No")             //textbox da placeholder duruyor ise 
            {
                txtTcKimlik.Text = "";                          //textbox içerisindeki placeholderı temizle

                txtTcKimlik.ForeColor = Color.Black;            // yazı rengini siyah yap
            }
        }

        private void txtTcKimlik_Leave(object sender, EventArgs e)
        {
            if (txtTcKimlik.Text == "") // textbox boş ise
            {
                txtTcKimlik.Text = "TC Kimlik No"; // placeholder ekle
                txtTcKimlik.ForeColor = Color.Gray; // yazı rengini gri yap
            }
        }

        private void txtTcKimlik_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);  // Yalnızca sayısal değerlerin girilmesine izin verir.
        }

        private void txtAd_Leave(object sender, EventArgs e)
        {
            if (txtAd.Text == "")  //textbox boş ise
            {
                txtAd.Text = "Adınız"; // textbox içerisine placeholder ekle
                txtAd.ForeColor = Color.Gray; // yazı rengini gri yap
            }
        }

        private void txtAd_Enter(object sender, EventArgs e)
        {
            if (txtAd.Text == "Adınız") // textbox içerisinde placeholder var ise
            {
                txtAd.Text = "";  //textbox içerisindeki placeholderı temizle

                txtAd.ForeColor = Color.Black;  // yazı rengini siyah yap
            }
        }

        private void txtAd_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                && !char.IsSeparator(e.KeyChar);        // sadece harf girişi
        }

        private void txtSoyad_Leave(object sender, EventArgs e)
        {
            if (txtSoyad.Text == "")  // textbox boş ise
            {
                txtSoyad.Text = "Soyadınız"; // placeholder ekle
                txtSoyad.ForeColor = Color.Gray; // yazı rengini gri yap
            }
        }

        private void txtSoyad_Enter(object sender, EventArgs e)
        {
            if (txtSoyad.Text == "Soyadınız")  // placeholder var ise
            {
                txtSoyad.Text = "";  // placeholder sil

                txtSoyad.ForeColor = Color.Black; // yazı rengini siyah yap
            }
        }

        private void txtSoyad_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
               && !char.IsSeparator(e.KeyChar);        // sadece harf girişi
        }

        private void txtNumara_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar); // sadece sayı girişi
        }

        private void txtNumara_Leave(object sender, EventArgs e)
        {
            if (txtNumara.Text == "") // textbox boş ise
            {
                txtNumara.Text = "Telefon Numaranız"; // placeholder ekle
                txtNumara.ForeColor = Color.Gray; // yazı rengini gri yap 
            }

        }

        private void txtNumara_Enter(object sender, EventArgs e)
        {
            if (txtNumara.Text == "Telefon Numaranız") // placeholder var ise 
            {
                txtNumara.Text = ""; // placeholder sil

                txtNumara.ForeColor = Color.Black; // yazı rengini siyah yap
            }
        }

        private void txtEposta_Enter(object sender, EventArgs e)
        {
            if (txtEposta.Text == "E-Posta")  // placeholder var ise 
            {
                txtEposta.Text = ""; // placeholder sil

                txtEposta.ForeColor = Color.Black; // yazı rengini siyah yap
            }
        }

        private void txtEposta_Leave(object sender, EventArgs e)
        {
            if (txtEposta.Text == "") // textbox boş ise
            {
                txtEposta.Text = "E-Posta"; // placeholder ekle
                txtEposta.BackColor = Color.White; // arkaplan rengini beyaz yap
                txtEposta.ForeColor = Color.Gray; // yazu rengini gri yap
            }

            

        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")  // textbox boş ise
            {
                txtPassword.PasswordChar = '\u0000'; // şifre alanını görünür yap
                txtPassword.Text = "Şifre"; // placeholder ekle
                txtPassword.ForeColor = Color.Gray; // yazı rengini gri yap
            }
            
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Şifre") // placeholder var ise
            {
                txtPassword.Text = ""; // placeholder sil
                if (!checkBoxShowPassword.Checked) // şifreyi göster chechbox işaretli değilse
                    txtPassword.PasswordChar= '*'; // şifreyi yıldızla
                txtPassword.ForeColor = Color.Black; // yazı rengini siyah yap
            }
        }

        private void txtPasswordRepeat_Leave(object sender, EventArgs e) // textbox bırakıldığında yapılacak işlemler
        {
            if (txtPasswordRepeat.Text == "")  // textbox boş ise 
            {
                txtPasswordRepeat.PasswordChar = '\u0000'; // şifreyi sansürleme
                txtPasswordRepeat.Text = "Şifre Tekrar"; // placeholder yaz
                txtPasswordRepeat.ForeColor = Color.Gray; // yazı rengini gri yap
            }
        }

        private void txtPasswordRepeat_Enter(object sender, EventArgs e)
        {
            if (txtPasswordRepeat.Text == "Şifre Tekrar")   // placeholder var ise
            {
                txtPasswordRepeat.Text = ""; // placeholder sil
                if (!checkBoxShowPassword.Checked) // şifreyi göster işaretli değilse
                    txtPasswordRepeat.PasswordChar = '*'; // şifreyi yıldızla

                txtPasswordRepeat.ForeColor = Color.Black; // yazı rengini siyah yap
            }
        }

        private void panelRight_Click(object sender, EventArgs e) // panele tıklanınca yapılacak işlem
        {
            lblEposta.Focus(); // focusu textbox dan almak için
        }

        private void panel1_Click(object sender, EventArgs e) // panele tıklanınca yapılacak işlem
        {
            lblEposta.Focus(); // focusu textbox dan almak için
        }

        private void txtEposta_Validating(object sender, CancelEventArgs e)
        {
            string email = txtEposta.Text; // textbox içerisindeki veriyi email değişkenine at
            bool isValid = IsValidEmail(email);  // enail formatına uygun olup olmadığını kontrol ediyor
            if (!isValid) // email doğru formatta değilse
            {
                    if(txtEposta.Text == "E-Posta") //placeholder var ise
                    {
                        txtEposta.BackColor = Color.White; // arkaplan renigini beyaz yap
                        errorProvider.SetError(txtEposta, ""); // hata mesajını kaldır
                    }
                    else
                    {
                             // Eposta yanlış formatta
                            txtEposta.BackColor = Color.FromArgb(255,114,86); // arka plan rengini kırmızı yap
                            txtEposta.ForeColor = Color.Black;    // yazı rengini siyah yap
                            errorProvider.SetError(txtEposta, "Lütfen geçerli bir eposta adresi girin.");  // hata mesajı görüntüle
                            e.Cancel = false;  // hata varken textboxdan ayrılamama durumunu kaldır
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

        private void txtNumara_Validating(object sender, CancelEventArgs e) // telefon numarası doğrulama
        {
          //  e.Cancel = false;
            string phoneNumber = txtNumara.Text;
            if (!IsValidPhoneNumber(phoneNumber)) // girilen değer telefon numarası değilse
            {
                if (txtNumara.Text == "Telefon Numaranız") // placeholder yazılı ise
                {
                    txtNumara.BackColor = Color.White; // arkaplan rengini beyaz yap
                    errorProvider.SetError(txtNumara, ""); // hata mesajını kaldır
                }
                else
                {
                    // Eposta yanlış formatta
                    txtNumara.Select(0, txtNumara.Text.Length); // numarayı seçili hale getir (silmeyi kolaylaştırmak için) 
                    txtNumara.BackColor = Color.FromArgb(255, 114, 86); // arkaplan rengini kırmızı yap
                    txtNumara.ForeColor = Color.Black; // yazı rengini siyah yap
                    errorProvider.SetError(txtNumara, "Lütfen geçerli bir telefon numarası girin.Örnek: 5554443322"); // hata mesajı göster
                }

            }
            else
            {
                txtNumara.BackColor = Color.White; // arkaplan rengini beyaz yap
                txtNumara.ForeColor = Color.Black; // yazı rengini siyah yap
                errorProvider.SetError(txtNumara, ""); // hata mesajını kaldır
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e) // doğrulama eventi
        {
            string sifre = txtPassword.Text.Trim(); // sifrede boşluk varsa siler

            // Şifre en az 8 karakter uzunluğunda ve en az bir büyük harf, bir küçük harf ve bir rakam içermelidir.
            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$"; 

            if (!Regex.IsMatch(sifre, pattern))  // şifre kurallara uygun değil ise
            {
                // hata mesajı göster
                errorProvider.SetError(txtPassword, "Şifre en az 8 karakter uzunluğunda olmalı ve en az bir büyük harf, bir küçük harf ve bir rakam içermelidir.");
            }
            else // şifre kurallara uygunsa
            {

                errorProvider.SetError(txtPassword, ""); // hata mesajını kaldır
            }
        }

        private void txtPasswordRepeat_Validating(object sender, CancelEventArgs e) // şifre doğrulama eventi
        {
            string sifreTekrar = txtPasswordRepeat.Text.Trim(); // şifre tekrarında boşluk varsa bunu kaldırıp şifreTekrar değişkenine atar

            if (sifreTekrar != txtPassword.Text.Trim()) // şifre tekrarı , şifre ile aynı değilse
            {
                errorProvider.SetError(txtPasswordRepeat, "Şifre tekrarı, şifre ile aynı olmalıdır."); // hata mesajı görüntüle
            }
            else
            {
                errorProvider.SetError(txtPasswordRepeat, ""); // hata mesajını kaldır
            }
        }

        private void checkBoxShowPassword_CheckedChanged(object sender, EventArgs e) // şifreyi göster checkbox durum değişimi
        {
            if (checkBoxShowPassword.Checked) // checkbox işaretliyse
            {
                txtPassword.PasswordChar = '\0'; // şifreyi göster
                txtPasswordRepeat.PasswordChar = '\0'; // şifre tekrarını göster
            }
            else
            {
                if(!String.IsNullOrEmpty(txtPasswordRepeat.Text) && txtPasswordRepeat.Text != "Şifre Tekrar") // şifre tekrarı boş değilse ve placeholder yok ise
                    txtPasswordRepeat.PasswordChar = '*'; // şifre tekrarını sansürle

                if(!String.IsNullOrEmpty(txtPassword.Text) && txtPassword.Text != "Şifre") // şifre boş veya null değilse ve placeholder yok ise
                    txtPassword.PasswordChar = '*'; // şifreyi sansürle
                
            }
            
        }
    }
}
