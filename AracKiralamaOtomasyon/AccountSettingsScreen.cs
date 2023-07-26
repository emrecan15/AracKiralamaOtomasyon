using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AracKiralamaOtomasyon
{
    public partial class AccountSettingsScreen : Form
    {

        // veritabanı connection işlemi
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-BTIS91A;Initial Catalog=Db_AracKiralama;Integrated Security=True");

        // error provider nesnesi oluşturuluyor
        ErrorProvider errorProvider = new ErrorProvider();

        List<String> oldData = new List<String>();
        List<String> newData = new List<String>();
        public AccountSettingsScreen()
        {
            InitializeComponent();

            // Karşılama Mesajı
            lblLeftName.Text = "Merhaba , " + LoginScreen.userName;


            getMemberInfo();
        }

        public void setEnableTextbox() // ilgili textboxları veri girişine açar
        {
            txtTcKimlik.Enabled = true;
            txtAd.Enabled = true;
            txtSoyad.Enabled = true;
            txtNumara.Enabled = true;
            txtEposta.Enabled = true;
            txtPassword.Enabled = true;
            txtPasswordRepeat.Enabled = true;

        }
        public void setDisableTextbox() // ilgili textboxları veri girişine kapatır
        {
            txtTcKimlik.Enabled = false;
            txtAd.Enabled = false;
            txtSoyad.Enabled = false;
            txtNumara.Enabled = false;
            txtEposta.Enabled = false;
            txtPassword.Enabled = false;
            txtPasswordRepeat.Enabled = false;

        }

        private void AccountSettingsScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing) // Form, kullanıcı tarafından kapatıldıysa
            {
                DialogResult result = MessageBox.Show("Uygulamadan çıkmak istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    e.Cancel = false;

                    if (this.DialogResult != DialogResult.OK) // Eğer form dialog olarak kullanılmıyorsa
                    {
                        // Login ekranına yönlendir
                        LoginScreen loginScreen = new LoginScreen();
                        loginScreen.Show();
                    }
                }
                else
                {
                    e.Cancel = true; // Formun kapatılmasını engelle
                }
            }
            else // Diğer kapatılma sebeplerinde uygulamayı kapat
            {
                Application.Exit();
            }
        }

        private void getMemberInfo() //giriş yapılan hesaba ait bilgileri ilgili textlere yazdırır
        {
            txtTcKimlik.Text = LoginScreen.tc;
            txtAd.Text = LoginScreen.userName;
            txtSoyad.Text = LoginScreen.lastName;
            txtEposta.Text = LoginScreen.eposta;
            txtNumara.Text = LoginScreen.telNo;
            txtPassword.Text = LoginScreen.password;
            txtPasswordRepeat.Text = LoginScreen.password;
        }

        private void btnDuzenle_Click(object sender, EventArgs e) // düzenle butonuna tıklandığında çalışacak kod bloğu
        {
            btnDuzenle.Visible = false; // düzenle butonunu gizle
            btnIptal.Visible = true; // iptal butonunu göster
            setEnableTextbox(); // textboxları aktif et
            btnKaydet.Enabled = true; //kaydet butonunu tıklanabilir yap
            txtPassword.PasswordChar = '\u0000'; //şifreyi görünür yap
            txtPasswordRepeat.PasswordChar = '\u0000'; // şifre tekrarını görünür yap

            oldData.Clear(); // listeyi temizle
            //eski veriyi listeye aktarmak (iptal durumunda bilgileri tekrar getirmek için)
            oldData.Add(txtTcKimlik.Text);
            oldData.Add(txtAd.Text);
            oldData.Add(txtSoyad.Text);
            oldData.Add(txtNumara.Text);
            oldData.Add(txtEposta.Text);
            oldData.Add(txtPassword.Text);
            oldData.Add(txtPasswordRepeat.Text);
            

        }
        public void fetchOldData() //eski verileri ilgili textboxlara yazdırır
        {
            txtTcKimlik.Text = oldData[0];
            txtAd.Text = oldData[1];
            txtSoyad.Text = oldData[2];
            txtNumara.Text = oldData[3];
            txtEposta.Text= oldData[4];
            txtPassword.Text = oldData[5];
            txtPasswordRepeat.Text = oldData[6];
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
                return false;

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
        public void clearError() // hata mesajlarını siler(iptal butonu için)
        {
            errorProvider.SetError(txtTcKimlik,"");
            errorProvider.SetError(txtAd, "");
            errorProvider.SetError(txtSoyad, "");
            errorProvider.SetError(txtNumara, "");
            errorProvider.SetError(txtEposta, "");
            errorProvider.SetError(txtPassword, "");
            errorProvider.SetError(txtPasswordRepeat, "");
        }
        private void btnIptal_Click(object sender, EventArgs e)
        {
            setDisableTextbox(); // textboxları veri girişine kapatır
            btnIptal.Visible = false; // iptal butonunu gizle
            btnDuzenle.Visible = true; // düzenle butonunu göster
            btnKaydet.Enabled = false; // kaydet butonunun tıklanabilirliğini kaldır
            txtPassword.PasswordChar = '*'; // şifreyi sansürle
            txtPasswordRepeat.PasswordChar = '*'; // şifre tekrarını sansürle
            fetchOldData(); // eski verileri getir
            clearError(); // iptal işlemi öncesi kalan hataları temizler.
        }

        //Textboxların alabileceği değerlerin kontrolü
        private void txtTcKimlik_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);  // Yalnızca sayısal değerlerin girilmesine izin verir.
        }

        private void txtAd_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
               && !char.IsSeparator(e.KeyChar);        // sadece harf girişi
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


        // *** Validate ***
        private void txtTcKimlik_Validating(object sender, CancelEventArgs e)
        {
            if (txtTcKimlik.Text.Length < 11)
            {
                errorProvider.SetError(txtTcKimlik, "Lütfen geçerli bir tc kimlik no girin"); // hata mesajını göster
            }
            else
            {
                errorProvider.SetError(txtTcKimlik, ""); // hata mesajını kaldır
            }
        }

        private void txtAd_Validating(object sender, CancelEventArgs e)
        {
            if (txtAd.Text.Length < 3)
            {
                errorProvider.SetError(txtAd, "Lütfen adınızı eksiksiz girin"); // hata mesajını göster
            }
            else
            {
                errorProvider.SetError(txtAd, ""); // hata mesajını kaldır
            }
        }

        private void txtSoyad_Validating(object sender, CancelEventArgs e)
        {
            if (txtSoyad.Text.Length < 3)
            {
                errorProvider.SetError(txtSoyad, "Lütfen soyadınızı eksiksiz girin"); // hata mesajını göster
            }
            else
            {
                errorProvider.SetError(txtSoyad, ""); // hata mesajını kaldır
            }
        }

        private void txtNumara_Validating(object sender, CancelEventArgs e)
        {
            if (IsValidPhoneNumber(txtNumara.Text))
            {
                errorProvider.SetError(txtNumara, ""); // hata mesajını kaldır
            }
            else
            {
                // hata mesajı göster
                errorProvider.SetError(txtNumara, "Lütfen telefon numaranızı doğru girdiğinizden emin olun.Örn: 5554443322");
            }
        }

        private void txtEposta_Validating(object sender, CancelEventArgs e)
        {
            if (IsValidEmail(txtEposta.Text))
            {
                errorProvider.SetError(txtEposta, ""); // hata mesajını kaldır
            }
            else
            {
                errorProvider.SetError(txtEposta, "Lütfen geçerli bir eposta girin."); // hata mesajını göster
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            string sifre = txtPassword.Text.Trim(); // sifrede boşluk varsa siler

            // Şifre en az 8 karakter uzunluğunda ve en az bir büyük harf, bir küçük harf ve bir rakam içermelidir.
            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$";

            if (!Regex.IsMatch(sifre, pattern))  // şifre kurallara uygun değil ise
            {
                // hata mesajı göster
                errorProvider.SetError(txtPassword, 
                    "Şifre en az 8 karakter uzunluğunda olmalı ve en az bir büyük harf, bir küçük harf ve bir rakam içermelidir.");
            }
            else // şifre kurallara uygunsa
            {

                errorProvider.SetError(txtPassword, ""); // hata mesajını kaldır
            }
        }

        private void txtPasswordRepeat_Validating(object sender, CancelEventArgs e)
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
        public void fetchNewData() // yeni verileri ilgili textboxlara yazdırır
        {
            txtTcKimlik.Text = newData[0];
            txtAd.Text = newData[1];
            txtSoyad.Text = newData[2];
            txtNumara.Text= newData[3];
            txtEposta.Text = newData[4];
            txtPassword.Text = newData[5];
            txtPasswordRepeat.Text = newData[5];
        }

        private void btnKaydet_Click(object sender, EventArgs e) // kaydet butonuna tıklanınca yapılacak işlemler
        {
            // hata yoksa
            if (
                errorProvider.GetError(txtTcKimlik) == ""
                && errorProvider.GetError(txtAd) == ""
                && errorProvider.GetError(txtSoyad) == ""
                && errorProvider.GetError(txtNumara) == ""
                && errorProvider.GetError(txtEposta) == ""
                && errorProvider.GetError(txtPassword) == ""
                && errorProvider.GetError(txtPasswordRepeat) == "")
            {
                try
                {
                    //update işlemi
                    if (baglanti.State == ConnectionState.Closed) // bağlantı kapalıysa
                    {
                        baglanti.Open(); // bağlantıyı aç
                    }
                    // sql sorgu cümlesi
                    string query = "update tblUye SET Tc=@tc,Ad=@ad,Soyad=@soyad,TelNo=@telNo,Mail=@mail,Sifre=@sifre where Tc = @conTc";
                    SqlCommand cmd = new SqlCommand(query, baglanti); // sqlCommand oluşturma
                    //parametre geçiliyor...
                    cmd.Parameters.AddWithValue("@tc",txtTcKimlik.Text);
                    cmd.Parameters.AddWithValue("@ad", txtAd.Text);
                    cmd.Parameters.AddWithValue("@soyad", txtSoyad.Text);
                    cmd.Parameters.AddWithValue("@telNo", txtNumara.Text);
                    cmd.Parameters.AddWithValue("@mail", txtEposta.Text);
                    cmd.Parameters.AddWithValue("@sifre", txtPassword.Text);
                    cmd.Parameters.AddWithValue("@conTc", oldData[0]);
                    cmd.ExecuteNonQuery(); // update execute
                    MessageBox.Show("Güncelleme başarılı."); // başarılı mesajı
                    
                    string selectQuery = "select Tc,Ad,Soyad,TelNo,Mail,Sifre from tblUye where Tc = @conTc"; //sorgu cümlesi oluşturma
                    SqlCommand cmd2 = new SqlCommand(selectQuery, baglanti); // sqlCommand oluşturma
                    cmd2.Parameters.AddWithValue("@conTc", txtTcKimlik.Text); // parametre geçme
                    SqlDataReader reader = cmd2.ExecuteReader(); // execute işlemi ve dönen verinin reader a atılması
                    while (reader.Read()) // reader içerisindeki verinin okunması
                    {
                        // yeni verilerin newData listesine eklenmesi
                        newData.Add(reader.GetString(0));
                        newData.Add(reader.GetString(1));
                        newData.Add(reader.GetString(2));
                        newData.Add(reader.GetString(3));
                        newData.Add(reader.GetString(4));
                        newData.Add(reader.GetString(5));
                    }
                    
                    
                    reader.Close(); // reader kapat
                    fetchNewData(); // yeni bilgileri ilgili textboxlara yazdır
                     
                    setDisableTextbox(); // textboxları disable yapar
                    btnDuzenle.Visible = true; // düzenle butonunu göster
                    btnIptal.Visible = false; // iptal butonunu gizle
                    btnKaydet.Enabled= false; // kaydet butonunun tıklanabilir özelliğini kaldır
                    
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    baglanti.Close(); // bağlantıyı kapat
                }
               

            }
            else
            {
                MessageBox.Show("Lütfen hataları giderin."); //hata bildirimi
            }
        }

        // Menü ekran geçişleri
        private void LnkLabelAracKiralamaIslemleri_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            MainScreen mainScreen = new MainScreen();
            mainScreen.Show();
        }

        private void LnkLabelAracTeslim_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            VehicleDeliveryScreen vehicleDeliveryScreen = new VehicleDeliveryScreen();
            vehicleDeliveryScreen.Show();
        }

        private void LnkLabelAracYonetim_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            VehicleManagmentScreen vehicleManagmentScreen = new VehicleManagmentScreen();
            vehicleManagmentScreen.Show();
        }

        private void LnkLabelMusteriYonetim_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            CustomerManagmentScreen customerManagmentScreen = new CustomerManagmentScreen();
            customerManagmentScreen.Show();
        }

        private void LnkLabelCikis_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult result = MessageBox.Show("Hesabınızdan çıkmak istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {


                if (this.DialogResult != DialogResult.OK) // Eğer form dialog olarak kullanılmıyorsa
                {
                    // Login ekranına yönlendir
                    LoginScreen loginScreen = new LoginScreen();
                    loginScreen.Show();
                    this.Hide();
                }
            }
        }
    }
}
