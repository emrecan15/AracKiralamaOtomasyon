using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AracKiralamaOtomasyon
{
    public partial class CustomerManagmentScreen : Form
    {
        //Veritabanı bağlantı işlemi
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-BTIS91A;Initial Catalog=Db_AracKiralama;Integrated Security=True");
        //ErrorProvider nesnesinin çağrılması
        ErrorProvider errorProvider = new ErrorProvider();


        public CustomerManagmentScreen()
        {
            InitializeComponent();

            // Karşılama Mesajı
            lblLeftName.Text = "Merhaba , " + LoginScreen.userName;
            cmbBoxDurumu.SelectedIndex = 0; // combobox ın default değerinin seçilmesi
            getAllCustomersData();
        }


        //Methods
        private void getAllCustomersData()
        {
            if (baglanti.State == ConnectionState.Open)
            { baglanti.Close(); }

            DataTable dataTable = new DataTable(); // DataTable nesnesi oluşturma
            try
            {
                baglanti.Open(); // bağlantıyı aç
                string query = "select * from tblMusteri"; // sql sorgu cümlesi
                SqlCommand cmd = new SqlCommand(query, baglanti); // sqlCommand oluşturma
                SqlDataReader reader = cmd.ExecuteReader(); // execute işlemi ve reader nesnesine dönen verinin aktarılması
                dataTable.Load(reader); // dataTable nesnesine reader içindeki verinin aktarımı
                reader.Close(); // reader kapat
                dataMusteri.DataSource = dataTable; // dataTable içerisindeki veriyi datagridviewe ekleme

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { baglanti.Close(); } // bağlantıyı kapat
        }

        private void getSelectedCustomerInfo() // seçili müşteri bilgilerini ilgili textboxlara yazdırır
        {
            if (dataMusteri.SelectedRows.Count > 0) // seçili satır var ise
            {
                DataGridViewRow selectedRow = dataMusteri.SelectedRows[0];
                if (selectedRow.Cells[0].Value != null) 
                {
                    txtIdInfo.Text = selectedRow.Cells[0].Value.ToString();
                    txtTcInfo.Text = selectedRow.Cells[1].Value.ToString();
                    txtEhliyetInfo.Text = selectedRow.Cells[2].Value.ToString();
                    txtMusteriAdiInfo.Text = selectedRow.Cells[3].Value.ToString();
                    txtMusteriSoyadiInfo.Text = selectedRow.Cells[4].Value.ToString();
                    txtEpostaInfo.Text = selectedRow.Cells[5].Value.ToString();
                    txtTelefonNoInfo.Text = selectedRow.Cells[6].Value.ToString();
                    txtDurumuInfo.Text = selectedRow.Cells[7].Value.ToString();

                }
            }
        }

        private void setEnableTextbox() // ilgili textboxları enable yapar
        {
            txtTcInfo.Enabled = true;
            txtEhliyetInfo.Enabled = true;
            txtMusteriAdiInfo.Enabled = true;
            txtMusteriSoyadiInfo.Enabled = true;
            txtEpostaInfo.Enabled = true;
            txtTelefonNoInfo.Enabled = true;

        }
        private void setDisableTextbox() // ilgili textboxları disable yapar
        {
            txtTcInfo.Enabled = false;
            txtEhliyetInfo.Enabled = false;
            txtMusteriAdiInfo.Enabled = false;
            txtMusteriSoyadiInfo.Enabled = false;
            txtEpostaInfo.Enabled = false;
            txtTelefonNoInfo.Enabled = false;
        }
        private bool IsValidEmail(string email)     // Epostanın doğru formatta olup olmadığını kontrol eder true - false döner
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;
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


        private void CustomerManagmentScreen_Load(object sender, EventArgs e)
        {

        }

        private void CustomerManagmentScreen_FormClosing(object sender, FormClosingEventArgs e)
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

        

        private void dataMusteri_SelectionChanged(object sender, EventArgs e) // datagridviewde seçilen satırın bilgilerini getirir
        {
            getSelectedCustomerInfo();
        }

        private void btnMusteriDuzenle_Click(object sender, EventArgs e) // müşteriyi düzenle butonuna basıldığında çalışacak event
        {
            btnMusteriDuzenle.Visible = false;
            btnKaydet.Visible = true;
            btnIptalEt.Visible = true;
            setEnableTextbox();
            dataMusteri.Enabled = false;
            // dataMusteri.ReadOnly= false;
            cmbBoxDurumuEdit.Visible = true;
            txtDurumuInfo.Visible = false;

            //OLD DATA FOR EDİT (eski verileri bir list içerisinde tutmak için)
            List<String> oldData = new List<string>(); 
            oldData.Add(txtIdInfo.Text);
            oldData.Add(txtTcInfo.Text);
            oldData.Add(txtEhliyetInfo.Text);
            oldData.Add(txtMusteriAdiInfo.Text);
            oldData.Add(txtMusteriSoyadiInfo.Text);
            oldData.Add(txtEpostaInfo.Text);
            oldData.Add(txtTelefonNoInfo.Text);
            oldData.Add(txtDurumuInfo.Text);

            // DURUMU COMBOBOX
            cmbBoxDurumuEdit.Items.Clear(); // comboboxın içerisi temizlendi.
            //item ekleme
            cmbBoxDurumuEdit.Items.Add("Aktif"); 
            cmbBoxDurumuEdit.Items.Add("Pasif");
            switch (oldData[7]) 
            {
                case "True":
                    {
                        cmbBoxDurumuEdit.SelectedIndex = 0;
                        break;
                    }
                default:
                    {
                        cmbBoxDurumuEdit.SelectedIndex = 1;
                        break;
                    }
            }
        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {

            //hata yoksa
            if (errorProvider.GetError(txtTcInfo) == "" 
                && errorProvider.GetError(txtEhliyetInfo) == "" 
                && errorProvider.GetError(txtMusteriAdiInfo) == "" 
                && errorProvider.GetError(txtMusteriSoyadiInfo) == "" 
                && errorProvider.GetError(txtEpostaInfo) == "" 
                && errorProvider.GetError(txtTelefonNoInfo) == "")
            {

                //dataMusteri.ReadOnly = true;
                dataMusteri.Enabled = true;
                btnMusteriDuzenle.Visible = true;
                btnKaydet.Visible = false;
                btnIptalEt.Visible = false;
                setDisableTextbox();
                cmbBoxDurumuEdit.Visible = false;
                txtDurumuInfo.Visible = true;

                // Yeni veriler(veritabanına gidecek veriler önce bu listeye eklenip daha sonra gerekli düzenlemeler yapılacak)
                List<String> newData = new List<string>();
                newData.Add(txtTcInfo.Text);
                newData.Add(txtEhliyetInfo.Text);
                newData.Add(txtMusteriAdiInfo.Text);
                newData.Add(txtMusteriSoyadiInfo.Text);
                newData.Add(txtEpostaInfo.Text);
                newData.Add(txtTelefonNoInfo.Text);
                switch (cmbBoxDurumuEdit.SelectedItem.ToString())
                {
                    case "Aktif": //combobox içerisinden Aktif seçilirse veritabanına true olarak gider
                        {
                            newData.Add("true");
                            break;
                        }

                    default: // aksi takdirde false olarak eklenir
                        {
                            newData.Add("false");
                            break;
                        }
                }

                updateData(newData);    //sql güncelleştirme
            }
            else
            {
                MessageBox.Show("Lütfen hataları düzeltin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnIptalEt_Click(object sender, EventArgs e) // iptal et butonuna tıklandığında çalışacak event
        {
            btnMusteriDuzenle.Visible = true; // düzenle butonunu görünür yap
            btnKaydet.Visible = false; // kaydet butonunu gizle
            lblMusteriYonetim.Focus();
            btnIptalEt.Visible = false; // iptal et butonunu gizle
            setDisableTextbox(); // textboxları disable yap
            dataMusteri.Enabled = true; // datagridviewi aktif et
            cmbBoxDurumuEdit.Visible = false; //comboboxı gizle
            txtDurumuInfo.Visible = true; //durumu textboxını göster
            // hataları kaldır
            errorProvider.SetError(txtTcInfo, "");
            errorProvider.SetError(txtEhliyetInfo, "");
            errorProvider.SetError(txtMusteriAdiInfo, "");
            errorProvider.SetError(txtMusteriSoyadiInfo, "");
            errorProvider.SetError(txtEpostaInfo, "");
            errorProvider.SetError(txtTelefonNoInfo, "");
            getSelectedCustomerInfo(); // seçili müşteri bilgilerini getir
        }

        private void updateData(List<String> paramListe)
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }

                // *** SQL UPDATE ***
                string query = 
                    "update tblMusteri SET Tc=@tc, " +
                    "EhliyetNo=@ehliyetNo, " +
                    "Ad = @ad , Soyad = @soyad , " +
                    "Mail = @mail , TelNo = @telNo , " +
                    "Durumu = @durumu where Id = @Id "; // where koşulu !!!
                SqlCommand cmdUpdate = new SqlCommand(query, baglanti); //sqlCommand nesnesi oluşturma
                // parametre geçiliyor...
                cmdUpdate.Parameters.AddWithValue("@tc", paramListe[0]);
                cmdUpdate.Parameters.AddWithValue("@ehliyetNo", paramListe[1]);
                cmdUpdate.Parameters.AddWithValue("@ad", paramListe[2]);
                cmdUpdate.Parameters.AddWithValue("@soyad", paramListe[3]);
                cmdUpdate.Parameters.AddWithValue("@mail", paramListe[4]);
                cmdUpdate.Parameters.AddWithValue("@telNo", paramListe[5]);
                cmdUpdate.Parameters.AddWithValue("@durumu", paramListe[6]);
                cmdUpdate.Parameters.AddWithValue("@Id", txtIdInfo.Text);

                cmdUpdate.ExecuteNonQuery(); // execute işlemi
                
                MessageBox.Show("Müşteri Başarıyla Güncellendi.");
                getAllCustomersData(); // datagridview refresh

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                baglanti.Close(); //bağlantıyı kapat
            }
        }

        // textboxların alabileceği değerlerin kontrolü
        private void txtTcInfo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar); // sadece sayısal giriş
        }

        private void txtEhliyetInfo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != '\b')   // sayısal ve harf girişi - boşluk hariç
            {
                e.Handled = true;
            }
        }

        private void txtMusteriAdiInfo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                && !char.IsSeparator(e.KeyChar);        // sadece harf girişi
        }

        private void txtMusteriSoyadiInfo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                && !char.IsSeparator(e.KeyChar);        // sadece harf girişi
        }

        private void txtTelefonNoInfo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar); // sadece sayısal giriş
        }

        // *** Validate işlemleri ***
        private void txtTcInfo_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTcInfo.Text)) //text null veya boşluk ise 
            {
                errorProvider.SetError(txtTcInfo, "Lütfen TC kimlik numarasını girin."); // hata mesajı yazdır
            }
            else
            {
                errorProvider.SetError(txtTcInfo, null); //hata mesajını kaldır
            }
        }

        private void txtEhliyetInfo_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEhliyetInfo.Text)) //text null veya boşluk ise 
            {
                errorProvider.SetError(txtEhliyetInfo, "Lütfen ehliyet numarasını girin."); // hata mesajı yazdır
            }
            else
            {
                errorProvider.SetError(txtEhliyetInfo, null); // hata mesajını kaldır
            }
        }

        private void txtMusteriAdiInfo_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMusteriAdiInfo.Text)) //text null veya boşluk ise 
            { 
                errorProvider.SetError(txtMusteriAdiInfo, "Lütfen müşteri adını girin."); // hata mesajı yazdır
            }
            else
            {
                errorProvider.SetError(txtMusteriAdiInfo, null); // hata mesajını kaldır
            }
        }

        private void txtMusteriSoyadiInfo_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMusteriSoyadiInfo.Text)) //text null veya boşluk ise 
            {
                errorProvider.SetError(txtMusteriSoyadiInfo, "Lütfen müşteri soyadını girin."); // hata mesajını yazdır
            }
            else
            {
                errorProvider.SetError(txtMusteriSoyadiInfo, null); // hata mesajını kaldır
            }
        }

        private void txtEpostaInfo_Validating(object sender, CancelEventArgs e)
        {
            string email = txtEpostaInfo.Text;
            bool isValid = IsValidEmail(email); // IsValidEmail() methodu ile girilen verinin eposta olup olmaması durumuna göre true-false döner
            if (isValid) //true ise
            {
                errorProvider.SetError(txtEpostaInfo, null); // hata mesajını kaldır
            }
            else
            {
                errorProvider.SetError(txtEpostaInfo, "Lütfen geçerli bir e-posta adresi girin"); // hata mesajını yazdır
            }

        }

        private void txtTelefonNoInfo_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTelefonNoInfo.Text)) //text null veya boşluk ise 
            {
                errorProvider.SetError(txtTelefonNoInfo, "Lütfen telefon numarası girin."); // hata mesajını yazdır
            }
            else
            {
                errorProvider.SetError(txtTelefonNoInfo, null); // hata mesajını kaldır
            }
        }
        private void txtAddTc_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAddTc.Text) || txtAddTc.Text == "Tc Kimlik No")
            {
                errorProvider.SetError(txtAddTc, "Lütfen TC kimlik numarasını girin."); // hata mesajını yazdır
            }
            else
            {
                errorProvider.SetError(txtAddTc, null); // hata mesajını kaldır
            }
        }

        private void txtAddEhliyetNo_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAddEhliyetNo.Text) || txtAddEhliyetNo.Text == "Ehliyet No")
            {
                errorProvider.SetError(txtAddEhliyetNo, "Lütfen ehliyet numarasını girin."); // hata mesajını yazdır
            }
            else
            {
                errorProvider.SetError(txtAddEhliyetNo, null); // hata mesajını kaldır
            }
        }

        private void txtAddMusteriAdi_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAddMusteriAdi.Text) || txtAddMusteriAdi.Text == "Müşteri Adı") 
            {
                errorProvider.SetError(txtAddMusteriAdi, "Lütfen müşteri adını girin."); // hata mesajını yazdır
            }
            else
            {
                errorProvider.SetError(txtAddMusteriAdi, null); // hata mesajını kaldır
            }
        }

        private void txtAddMusteriSoyadi_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAddMusteriSoyadi.Text) || txtAddMusteriSoyadi.Text == "Müşteri Soyadı")
            {
                errorProvider.SetError(txtAddMusteriSoyadi, "Lütfen müşteri soyadını girin."); // hata mesajını yazdır
            }

            else
            { 
                errorProvider.SetError(txtAddMusteriSoyadi, null); // hata mesajını kaldır
            }
        }

        private void txtAddEposta_Validating(object sender, CancelEventArgs e)
        {
            string email = txtAddEposta.Text;
            bool isValid = IsValidEmail(email);
            if (isValid)
            {
                errorProvider.SetError(txtAddEposta, null); // hata mesajını kaldır
            }
            else if (email == "E-posta")
            {
                errorProvider.SetError(txtAddEposta, "Lütfen bir e-posta adresi girin"); // hata mesajı ver
            }
            else
            {
                errorProvider.SetError(txtAddEposta, "Lütfen geçerli bir e-posta adresi girin"); // hata mesajı ver
            }
        }

        private void txtAddNumara_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAddNumara.Text) || txtAddNumara.Text == "Telefon No")
            {
                errorProvider.SetError(txtAddNumara, "Lütfen telefon numarası girin."); // hata mesajı ver
            }
            else
            {
                errorProvider.SetError(txtAddNumara, null); // hata mesajını kaldır
            }
        }

        private void cmbBoxDurumu_Validating(object sender, CancelEventArgs e)
        {
            if (cmbBoxDurumu.SelectedItem.ToString() == "Seçiniz...") 
            {
                errorProvider.SetError(cmbBoxDurumu, "Lütfen bir seçim yapın."); // hata mesajı ver
            }
            else
            {
                errorProvider.SetError(cmbBoxDurumu, null); // hata mesajını kaldır
            }
        }
        private bool isEmpty() // ilgili textboxlar boş mu kontrolünü yapmak için boş ise true döner
        {
            bool IsEmpty = false;
            if (
                txtAddTc.Text == "Tc Kimlik No" ||
                txtAddEhliyetNo.Text == "Ehliyet No" ||
                txtAddMusteriAdi.Text == "Müşteri Adı" ||
                txtAddMusteriSoyadi.Text == "Müşteri Soyadı" ||
                txtAddEposta.Text == "E-posta" ||
                txtAddNumara.Text == "Telefon No" ||
                cmbBoxDurumu.SelectedItem.ToString() == "Seçiniz..."
                )
            {
                IsEmpty = true;
            }

            return IsEmpty;
        }


        // Menü ekran geçişleri
        private void LnkLabelAracYonetim_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            VehicleManagmentScreen vehicleManagmentScreen = new VehicleManagmentScreen();
            vehicleManagmentScreen.Show();
            this.Hide();
        }

        private void LnkLabelAracTeslim_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            VehicleDeliveryScreen vehicleDeliveryScreen = new VehicleDeliveryScreen();
            vehicleDeliveryScreen.Show();
            this.Hide();
        }

        private void LnkLabelAracKiralamaIslemleri_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MainScreen mainScreen = new MainScreen();
            mainScreen.Show();
            this.Hide();
        }
        private void LnkLabelHesapAyar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AccountSettingsScreen accountSettingsScreen = new AccountSettingsScreen();
            accountSettingsScreen.Show();
            this.Hide();
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

        // Textbox placeholder kodları
        private void txtAddTc_Enter(object sender, EventArgs e)
        {
            if (txtAddTc.Text == "Tc Kimlik No")
            {
                txtAddTc.Text = "";
                txtAddTc.ForeColor = Color.Black;
            }
        }

        private void txtAddEhliyetNo_Enter(object sender, EventArgs e)
        {
            if (txtAddEhliyetNo.Text == "Ehliyet No")
            {
                txtAddEhliyetNo.Text = "";
                txtAddEhliyetNo.ForeColor = Color.Black;
            }
        }

        private void txtAddMusteriAdi_Enter(object sender, EventArgs e)
        {
            if (txtAddMusteriAdi.Text == "Müşteri Adı")
            {
                txtAddMusteriAdi.Text = "";
                txtAddMusteriAdi.ForeColor = Color.Black;
            }
        }

        private void txtAddMusteriSoyadi_Enter(object sender, EventArgs e)
        {
            if (txtAddMusteriSoyadi.Text == "Müşteri Soyadı")
            {
                txtAddMusteriSoyadi.Text = "";
                txtAddMusteriSoyadi.ForeColor = Color.Black;
            }
        }

        private void txtAddEposta_Enter(object sender, EventArgs e)
        {
            if (txtAddEposta.Text == "E-posta")
            {
                txtAddEposta.Text = "";
                txtAddEposta.ForeColor = Color.Black;
            }
        }

        private void txtAddNumara_Enter(object sender, EventArgs e)
        {
            if (txtAddNumara.Text == "Telefon No")
            {
                txtAddNumara.Text = "";
                txtAddNumara.ForeColor = Color.Black;
            }
        }

        private void txtAddTc_Leave(object sender, EventArgs e)
        {
            if (txtAddTc.Text == "")
            {
                txtAddTc.Text = "Tc Kimlik No";
                txtAddTc.ForeColor = Color.Gray;
            }
        }

        private void txtAddEhliyetNo_Leave(object sender, EventArgs e)
        {
            if (txtAddEhliyetNo.Text == "")
            {
                txtAddEhliyetNo.Text = "Ehliyet No";
                txtAddEhliyetNo.ForeColor = Color.Gray;
            }
        }

        private void txtAddMusteriAdi_Leave(object sender, EventArgs e)
        {
            if (txtAddMusteriAdi.Text == "")
            {
                txtAddMusteriAdi.Text = "Müşteri Adı";
                txtAddMusteriAdi.ForeColor = Color.Gray;
            }
        }

        private void txtAddMusteriSoyadi_Leave(object sender, EventArgs e)
        {
            if (txtAddMusteriSoyadi.Text == "")
            {
                txtAddMusteriSoyadi.Text = "Müşteri Soyadı";
                txtAddMusteriSoyadi.ForeColor = Color.Gray;
            }
        }

        private void txtAddEposta_Leave(object sender, EventArgs e)
        {
            if (txtAddEposta.Text == "")
            {
                txtAddEposta.Text = "E-posta";
                txtAddEposta.ForeColor = Color.Gray;
            }
        }

        private void txtAddNumara_Leave(object sender, EventArgs e)
        {
            if (txtAddNumara.Text == "")
            {
                txtAddNumara.Text = "Telefon No";
                txtAddNumara.ForeColor = Color.Gray;
            }
        }

        

        private void btnMusteriEkle_Click(object sender, EventArgs e)
        {
            //herhangi bir hata var mı
            if (
                errorProvider.GetError(txtAddTc) == "" &&
                errorProvider.GetError(txtAddEhliyetNo) == "" &&
                errorProvider.GetError(txtAddMusteriAdi) == "" &&
                errorProvider.GetError(txtAddMusteriSoyadi) == "" &&
                errorProvider.GetError(txtAddEposta) == "" &&
                errorProvider.GetError(txtAddNumara) == "" &&
                errorProvider.GetError(cmbBoxDurumu) == ""

                )
            {
                if (isEmpty()) //textboxlar boş mu
                {
                    MessageBox.Show("Lütfen tüm bilgileri eksiksiz girin.");
                }
                else
                {
                    try
                    {
                        if (baglanti.State == ConnectionState.Open)
                        {
                            baglanti.Close();
                        }
                        baglanti.Open(); //bağlantıyı aç
                        // check tc no
                        SqlCommand cmdCheckTc = new SqlCommand("select * from tblMusteri where Tc = @tc", baglanti); // sqlCommand
                        cmdCheckTc.Parameters.AddWithValue("@tc", txtAddTc.Text); // parametre geçiliyor
                        // SqlDataReader reader = cmdCheckTc.ExecuteReader();
                        int result = Convert.ToInt32(cmdCheckTc.ExecuteScalar()); //execute ve kaç sonuç döndüğünün result değişkenine atanması
                        if (result > 0) //ilgili tc ye ait kayıt bulunduysa
                        {
                            MessageBox.Show("Eşleşen Kayıt bulundu.");
                        }
                        else
                        {
                            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo; // metnin ilk harfi büyük gerisi küçük yazdırmak için
                            string query = 
                                "insert into tblMusteri " +
                                "([Tc], [EhliyetNo], [Ad], [Soyad], [Mail], [TelNo], [Durumu]) " +
                                "Values (@tc,@ehliyetNo,@ad,@soyad,@mail,@telNo,@durumu)"; // sql sorgu cümlesi
                            SqlCommand cmd = new SqlCommand(query, baglanti); // sqlCommand oluşturma
                            // parametre geçiliyor...
                            cmd.Parameters.AddWithValue("@tc", txtAddTc.Text);
                            cmd.Parameters.AddWithValue("@ehliyetNo", txtAddEhliyetNo.Text.ToUpper());
                            cmd.Parameters.AddWithValue("@ad", textInfo.ToTitleCase(txtAddMusteriAdi.Text));
                            cmd.Parameters.AddWithValue("@soyad", textInfo.ToTitleCase(txtAddMusteriSoyadi.Text));
                            cmd.Parameters.AddWithValue("@mail", txtAddEposta.Text);
                            cmd.Parameters.AddWithValue("@telNo", txtAddNumara.Text);
                            cmd.Parameters.AddWithValue("@durumu", cmbBoxDurumu.SelectedItem.ToString() == "Aktif" ? 1 : 0);
                            cmd.ExecuteNonQuery(); // execute
                            MessageBox.Show("Müşteri başarıyla eklendi."); // başarılı mesajı
                            getAllCustomersData(); // datagridview refresh
                            clearTextbox(); // textboxları temizle
                        }

                        

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hata oluştu. Hata Mesajı : "+ex.Message);
                    }
                    finally
                    {

                        baglanti.Close(); // bağlantıyı kapat
                    }

                }

            }

            else { MessageBox.Show("Lütfen hataları giderin."); }
        }

        private void btnMusteriSil_Click(object sender, EventArgs e)
        {
            // onay mesajı
            DialogResult result = MessageBox.Show(txtIdInfo.Text + 
                " nolu müşteriyi silmek istediğinize emin misiniz? Bu işlem geri alınamaz.", "Uyarı", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes) // onay verildiyse
            {
                try
                {
                    if (baglanti.State == ConnectionState.Closed)
                    {
                        baglanti.Open();
                    }


                    // ARACI SİL
                    string query = "delete from tblMusteri where Id = @Id"; // sql sorgu cümlesi
                    SqlCommand cmd = new SqlCommand(query, baglanti); // sqlCommand oluşturma
                    cmd.Parameters.AddWithValue("@Id", txtIdInfo.Text); // parametre geçme
                    cmd.ExecuteNonQuery();  // execute işlemi
                    MessageBox.Show(txtIdInfo.Text + " nolu müşteri silindi."); // başarılı mesajı
                    getAllCustomersData(); // datagridview refresh
                    lblMusteriYonetim.Focus(); 

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    baglanti.Close(); // bağlantıyı kapat
                }
            }
        }
        private void clearTextbox() // ilgili textboxlar içerisindeki veriyi temizler ve placeholder larını yazar
        {
            txtAddTc.Text = "Tc Kimlik No";
            txtAddTc.ForeColor = Color.Gray;
            txtAddEhliyetNo.Text = "Ehliyet No";
            txtAddEhliyetNo.ForeColor = Color.Gray;
            txtAddMusteriAdi.Text = "Müşteri Adı";
            txtAddMusteriAdi.ForeColor = Color.Gray;
            txtAddMusteriSoyadi.Text = "Müşteri Soyadı";
            txtAddMusteriSoyadi.ForeColor = Color.Gray;
            txtAddEposta.Text = "E-posta";
            txtAddEposta.ForeColor = Color.Gray;
            txtAddNumara.Text = "Telefon No";
            txtAddNumara.ForeColor = Color.Gray;
            cmbBoxDurumu.SelectedIndex= 0; 
        }
        private void panelKiralanabilirAracInfo_Click(object sender, EventArgs e)
        {
            lblMusteriYonetim.Focus();
        }


    }
}