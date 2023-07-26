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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AracKiralamaOtomasyon
{
    public partial class AdminScreen : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-BTIS91A;Initial Catalog=Db_AracKiralama;Integrated Security=True");
        ErrorProvider errorProvider = new ErrorProvider();
        public AdminScreen()
        {
            InitializeComponent();

            // Karşılama Mesajı
            lblLeftName.Text = "Merhaba , " + LoginScreen.userName;
            cmbBoxYetkiDuzeyi.SelectedIndex= 0;

            getAllMembersData();

        }

        //Methods
        private void getAllMembersData() // tüm üyelerin bilgilerini çeker
        {
            if (baglanti.State == ConnectionState.Open)
            { baglanti.Close(); }

            DataTable dataTable = new DataTable(); // datatable nesnesi oluşturuluyor
            try
            {
                baglanti.Open(); // bağlantıyı aç
                string query = "select * from tblUye where YetkiDuzeyi != 2 "; // sql sorgu cümlesi
                SqlCommand cmd = new SqlCommand(query, baglanti); // sqlCommand oluşturma
                SqlDataReader reader = cmd.ExecuteReader(); // execute işlemi ve dönen verinin reader nesnesine aktarılması
                dataTable.Load(reader); // reader içindeki verinin dataTable a yüklenmesi 
                reader.Close();// reader kapat
                dataUye.DataSource = dataTable; // datatable daki verileri datagridviewe yükle

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { baglanti.Close(); } // bağlantıyı kapat
        }

        private void getSelectedMemberInfo() // seçili üyenin bilgilerini ilgili textboxlara yazdırır
        {
            if (dataUye.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataUye.SelectedRows[0];
                if (selectedRow.Cells[0].Value != null)
                {
                    txtIdInfo.Text = selectedRow.Cells[0].Value.ToString();
                    txtTcInfo.Text = selectedRow.Cells[1].Value.ToString();
                    txtAdInfo.Text = selectedRow.Cells[2].Value.ToString();
                    txtSoyadInfo.Text = selectedRow.Cells[3].Value.ToString();
                    txtTelNoInfo.Text = selectedRow.Cells[4].Value.ToString();
                    txtEpostaInfo.Text = selectedRow.Cells[5].Value.ToString();
                    txtSifreInfo.Text = selectedRow.Cells[6].Value.ToString();
                    // 7 nolu indisteki veri 0 ise "Pasif Üye" değilse "Yönetici" olarak ilgili textboxa yazdırır.
                    txtYetkiInfo.Text = selectedRow.Cells[7].Value.ToString() == "0" ? "Pasif Üye":"Yönetici";

                }
            }
        }
        private void setEnableTextbox() // ilgili textboxları veri girişine açar
        {
            txtTcInfo.Enabled = true;
            txtAdInfo.Enabled = true;
            txtSoyadInfo.Enabled = true;
            txtTelNoInfo.Enabled = true;
            txtEpostaInfo.Enabled = true;
            txtSifreInfo.Enabled = true;

        }
        private void setDisableTextbox() // ilgili textboxları veri girişine kapatır
        {
            txtTcInfo.Enabled = false;
            txtAdInfo.Enabled = false;
            txtSoyadInfo.Enabled = false;
            txtTelNoInfo.Enabled = false;
            txtEpostaInfo.Enabled = false;
            txtSifreInfo.Enabled = false;

        }
        private void clearTextbox() // ilgili textboxları temizler ve placeholderlarını yazar
        {
            txtAddTc.Text = "Tc Kimlik No";
            txtAddTc.ForeColor = Color.Gray;
            txtAddName.Text = "Ad";
            txtAddName.ForeColor = Color.Gray;
            txtAddSoyad.Text = "Soyad";
            txtAddSoyad.ForeColor = Color.Gray;
            txtAddTelNo.Text = "Telefon No";
            txtAddTelNo.ForeColor = Color.Gray;
            txtAddEposta.Text = "E-posta";
            txtAddEposta.ForeColor = Color.Gray;
            txtAddSifre.Text = "Şifre";
            txtAddSifre.ForeColor = Color.Gray;
            cmbBoxYetkiDuzeyi.SelectedIndex = 0;
        }

        private void updateData(List<String> paramListe) // parametre geçilen listeyi veritabanında ilgili kayıta aktarır
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)// bağlantı kapalıysa
                { 
                    baglanti.Open(); // bağlantıyı aç
                }



                // *** SQL UPDATE ***
                
                string query = 
                    "update tblUye SET Tc=@tc, Ad = @ad , Soyad = @soyad ," +
                    " TelNo = @telNo, Mail = @mail  ,Sifre=@sifre, YetkiDuzeyi = @yetkiDuzeyi where Id = @Id "; // where koşulu !!!
                SqlCommand cmdUpdate = new SqlCommand(query, baglanti); // sqlCommand oluşturma

                //parametre geçiliyor...
                cmdUpdate.Parameters.AddWithValue("@tc", paramListe[0]);
                cmdUpdate.Parameters.AddWithValue("@ad", paramListe[1]);
                cmdUpdate.Parameters.AddWithValue("@soyad", paramListe[2]);
                cmdUpdate.Parameters.AddWithValue("@telNo", paramListe[3]);
                cmdUpdate.Parameters.AddWithValue("@mail", paramListe[4]);
                cmdUpdate.Parameters.AddWithValue("@sifre", paramListe[5]);
                cmdUpdate.Parameters.AddWithValue("@yetkiDuzeyi", paramListe[6]);
                cmdUpdate.Parameters.AddWithValue("@Id", txtIdInfo.Text);

                cmdUpdate.ExecuteNonQuery(); //execute

                MessageBox.Show(txtIdInfo.Text+" Nolu Üye Başarıyla Güncellendi."); // başarılı mesajı
                getAllMembersData(); // tüm üyelerin bilgilerini getir



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

        private bool isEmpty() // ilgili textboxların boş olup olmadığını kontrol eder
        {
            bool IsEmpty = false;
            if (
                txtAddTc.Text == "Tc Kimlik No" ||
                txtAddName.Text == "Ad" ||
                txtAddSoyad.Text == "Soyad" ||
                txtTelNoInfo.Text == "Telefon No" ||
                txtAddEposta.Text == "E-posta" ||
                txtAddSifre.Text == "Şifre" ||
                cmbBoxYetkiDuzeyi.SelectedItem.ToString() == "Seçiniz..."
                )
            {
                IsEmpty = true;
            }

            return IsEmpty;
        }



        private void AdminScreen_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'db_UyeYonetimi.tblUye' table. You can move, or remove it, as needed.
            this.tblUyeTableAdapter.Fill(this.db_UyeYonetimi.tblUye);

        }

        private void AdminScreen_FormClosing(object sender, FormClosingEventArgs e)
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

        private void dataUye_SelectionChanged(object sender, EventArgs e) // farklı bir satır seçildiğinde çalışacak event
        {
            getSelectedMemberInfo(); // seçili üyenin bilgilerini getir
        }

        private void btnUyeyiDuzenle_Click(object sender, EventArgs e) // üyeyi düzenle butonuna tıklandığında yapılacak işlemler
        {
            btnUyeyiDuzenle.Visible = false; //düzenle butonunu gizle 
            btnKaydet.Visible = true; // kaydet butonunu göster
            btnIptalEt.Visible = true; // iptal et butonunu göster
            setEnableTextbox(); // textboxları veri girişine aç
            dataUye.Enabled = false; // datagridviewi dondur
            cmbBoxYetkiEdit.Visible = true; // comboboxı göster
            txtYetkiInfo.Visible = false; // textboxı gizle

            //OLD DATA FOR EDİT
            List<String> oldData = new List<string>();
            oldData.Add(txtIdInfo.Text);
            oldData.Add(txtTcInfo.Text);
            oldData.Add(txtAdInfo.Text);
            oldData.Add(txtSoyadInfo.Text);
            oldData.Add(txtTelNoInfo.Text);
            oldData.Add(txtEpostaInfo.Text);
            oldData.Add(txtSifreInfo.Text);
            oldData.Add(txtYetkiInfo.Text == "Pasif Üye" ? "0":"1");

            // DURUMU COMBOBOX
            cmbBoxYetkiEdit.Items.Clear();
            cmbBoxYetkiEdit.Items.Add("Yönetici");
            cmbBoxYetkiEdit.Items.Add("Pasif Üye");
            switch (oldData[7])
            {
                case "1":
                    {
                        cmbBoxYetkiEdit.SelectedIndex = 0;
                        break;
                    }
                default:
                    {
                        cmbBoxYetkiEdit.SelectedIndex = 1;
                        break;
                    }
            }
        }

        private void btnIptalEt_Click(object sender, EventArgs e) // iptal et butonuna tıklanınca yapılacak işlemler
        {
            btnUyeyiDuzenle.Visible = true; // düzenle butonunu göster
            btnKaydet.Visible = false; // kaydet butonun gizle
            lblUyeYonetim.Focus(); 
            btnIptalEt.Visible = false; // iptal et butonunu gizle
            setDisableTextbox(); // textboxları veri girişine kapat
            dataUye.Enabled = true; // datagridviewi aktif et
            cmbBoxYetkiEdit.Visible = false; // comboboxı gizle
            txtYetkiInfo.Visible = true; // textboxı göster
            // hata mesajlarını kaldır
            errorProvider.SetError(txtTcInfo, ""); 
            errorProvider.SetError(txtAdInfo, "");
            errorProvider.SetError(txtSoyadInfo, "");
            errorProvider.SetError(txtTelNoInfo, "");
            errorProvider.SetError(txtEpostaInfo, "");
            errorProvider.SetError(txtSifreInfo, "");
            getSelectedMemberInfo(); // seçili üyeyinin bilgilerini getir
        }

        private void btnKaydet_Click(object sender, EventArgs e) // kaydet butonuna tıklanınca yapılacak işlemler
        {
            // hata mesajı yoksa
            if (
                errorProvider.GetError(txtTcInfo) == "" 
                && errorProvider.GetError(txtAdInfo) == "" 
                && errorProvider.GetError(txtSoyadInfo) == "" 
                && errorProvider.GetError(txtTelNoInfo) == "" 
                && errorProvider.GetError(txtEpostaInfo) == "" 
                && errorProvider.GetError(txtSifreInfo) == "")
            {

                //dataMusteri.ReadOnly = true;
                dataUye.Enabled = true;
                btnUyeyiDuzenle.Visible = true;
                btnKaydet.Visible = false;
                btnIptalEt.Visible = false;
                setDisableTextbox();
                cmbBoxYetkiEdit.Visible = false;
                txtYetkiInfo.Visible = true;

                // Yeni veriler
                List<String> newData = new List<string>();
                newData.Add(txtTcInfo.Text);
                newData.Add(txtAdInfo.Text);
                newData.Add(txtSoyadInfo.Text);
                newData.Add(txtTelNoInfo.Text);
                newData.Add(txtEpostaInfo.Text);
                newData.Add(txtSifreInfo.Text);
                switch (cmbBoxYetkiEdit.SelectedItem.ToString())
                {
                    case "Yönetici":
                        {
                            newData.Add("1");
                            break;
                        }

                    default:
                        {
                            newData.Add("0");
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

        private void btnUyeyiSil_Click(object sender, EventArgs e) // Üyeyi sil butonuna tıklanınca yapılacak işlemler
        {
            // onay mesajı
            DialogResult result = MessageBox.Show(txtIdInfo.Text + 
                " nolu üyeyi silmek istediğinize emin misiniz? Bu işlem geri alınamaz.", "Uyarı", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes) // onay verildiyse
            {
                try
                {
                    if (baglanti.State == ConnectionState.Closed) // bağlantı kapalıysa
                    {
                        baglanti.Open(); // bağlantıyı aç
                    }


                    // ARACI SİL
                    string query = "delete from tblUye where Id = @Id"; // sql sorgu cümlesi 
                    SqlCommand cmd = new SqlCommand(query, baglanti); // sqlCommand oluşturma
                    cmd.Parameters.AddWithValue("@Id", txtIdInfo.Text); // parametre geçme
                    cmd.ExecuteNonQuery(); // execute
                    MessageBox.Show(txtIdInfo.Text + " nolu üye silindi."); // başarılı mesajı
                    getAllMembersData(); // datagridview refresh
                    lblUyeYonetim.Focus(); 

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

        // Textbox placeholder kodları
        private void txtAddTc_Enter(object sender, EventArgs e)
        {
            if (txtAddTc.Text == "Tc Kimlik No")
            {
                txtAddTc.Text = "";
                txtAddTc.ForeColor = Color.Black;
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

        private void txtAddName_Enter(object sender, EventArgs e)
        {
            if (txtAddName.Text == "Ad")
            {
                txtAddName.Text = "";
                txtAddName.ForeColor = Color.Black;
            }
        }

        private void txtAddSoyad_Enter(object sender, EventArgs e)
        {
            if (txtAddSoyad.Text == "Soyad")
            {
                txtAddSoyad.Text = "";
                txtAddSoyad.ForeColor = Color.Black;
            }
        }

        private void txtAddTelNo_Enter(object sender, EventArgs e)
        {
            if (txtAddTelNo.Text == "Telefon No")
            {
                txtAddTelNo.Text = "";
                txtAddTelNo.ForeColor = Color.Black;
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

        private void txtAddSifre_Enter(object sender, EventArgs e)
        {
            if (txtAddSifre.Text == "Şifre")
            {
                txtAddSifre.Text = "";
                txtAddSifre.ForeColor = Color.Black;
            }
        }

        private void txtAddName_Leave(object sender, EventArgs e)
        {
            if (txtAddName.Text == "")
            {
                txtAddName.Text = "Ad";
                txtAddName.ForeColor = Color.Gray;
            }
        }

        private void txtAddSoyad_Leave(object sender, EventArgs e)
        {
            if (txtAddSoyad.Text == "")
            {
                txtAddSoyad.Text = "Soyad";
                txtAddSoyad.ForeColor = Color.Gray;
            }
        }

        private void txtAddTelNo_Leave(object sender, EventArgs e)
        {
            if (txtAddTelNo.Text == "")
            {
                txtAddTelNo.Text = "Telefon No";
                txtAddTelNo.ForeColor = Color.Gray;
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

        private void txtAddSifre_Leave(object sender, EventArgs e)
        {
            if (txtAddSifre.Text == "")
            {
                txtAddSifre.Text = "Şifre";
                txtAddSifre.ForeColor = Color.Gray;
            }
        }

        // *** Validate ***
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

        private void txtAddName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAddName.Text) || txtAddName.Text == "Ad")
            {
                errorProvider.SetError(txtAddName, "Lütfen üye adını girin."); // hata mesajı yazdır
            }
            else
            {
                errorProvider.SetError(txtAddName, null); // hata mesajını kaldır
            }
        }

        private void txtAddSoyad_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAddSoyad.Text) || txtAddSoyad.Text == "Soyad")
            {
                errorProvider.SetError(txtAddSoyad, "Lütfen üye soyadını girin."); // hata mesajı yazdır
            }
            else
            {
                errorProvider.SetError(txtAddSoyad, null); // hata mesajını kaldır
            }
        }

        private void txtAddTelNo_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAddTelNo.Text) || txtAddTelNo.Text == "Telefon No")
            {
                errorProvider.SetError(txtAddTelNo, "Lütfen telefon numarası girin."); // hata mesajı yazdır
            }
            else
            {
                errorProvider.SetError(txtAddTelNo, null); // hata mesajını kaldır
            }
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
                errorProvider.SetError(txtAddEposta, "Lütfen bir e-posta adresi girin"); // hata mesajı yazdır
            }
            else
            {
                errorProvider.SetError(txtAddEposta, "Lütfen geçerli bir e-posta adresi girin"); // hata mesajı yazdır
            }
        }

        private void txtAddSifre_Validating(object sender, CancelEventArgs e)
        {
            string sifre = txtAddSifre.Text.Trim(); // sifrede boşluk varsa siler

            // Şifre en az 8 karakter uzunluğunda ve en az bir büyük harf, bir küçük harf ve bir rakam içermelidir.
            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$";

            if (!Regex.IsMatch(sifre, pattern))  // şifre kurallara uygun değil ise
            {
                // hata mesajı göster
                errorProvider.SetError(txtAddSifre, 
                    "Şifre en az 8 karakter uzunluğunda olmalı ve en az bir büyük harf, bir küçük harf ve bir rakam içermelidir.");
            }
            else // şifre kurallara uygunsa
            {

                errorProvider.SetError(txtAddSifre, ""); // hata mesajını kaldır
            }
        }

        private void cmbBoxYetkiDuzeyi_Validating(object sender, CancelEventArgs e)
        {
            if(cmbBoxYetkiDuzeyi.SelectedIndex==0)
            {
                errorProvider.SetError(cmbBoxYetkiDuzeyi,"Lütfen bir seçim yapın"); // hata mesajını yazdır
            }
            else
            {
                errorProvider.SetError(cmbBoxYetkiDuzeyi, "");// hata mesajını kaldır
            }
        }
        private void txtTcInfo_Validating(object sender, CancelEventArgs e)
        {
            if (txtTcInfo.Text == "" || txtTcInfo.Text.Length < 11)
            {
                errorProvider.SetError(txtTcInfo, "Lütfen TC kimlik No Girin"); // hata mesajını yazdır
            } 
            else
            {
                errorProvider.SetError(txtTcInfo, "");// hata mesajını kaldır
            }
        }

        private void txtAdInfo_Validating(object sender, CancelEventArgs e)
        {
            if (txtAdInfo.Text == "" || txtAdInfo.Text.Length < 3)
            {
                errorProvider.SetError(txtAdInfo, "Lütfen adı girin."); // hata mesajını yazdır
            } 
            else
            {
                errorProvider.SetError(txtAdInfo, ""); // hata mesajını kaldır
            }
        }

        private void txtSoyadInfo_Validating(object sender, CancelEventArgs e)
        {
            if (txtSoyadInfo.Text == "" || txtSoyadInfo.Text.Length < 2)
            {
                errorProvider.SetError(txtSoyadInfo, "Lütfen soyadı girin."); // hata mesajını yazdır
            }
            else
            {
                errorProvider.SetError(txtSoyadInfo, ""); // hata mesajını kaldır
            }
        }

        private void txtTelNoInfo_Validating(object sender, CancelEventArgs e)
        {
            if (txtTelNoInfo.Text == "" || txtTelNoInfo.Text.Length < 10)
            {
                errorProvider.SetError(txtTelNoInfo, "Lütfen numara girin."); // hata mesajını yazdır
            }
            else
            {
                errorProvider.SetError(txtTelNoInfo, ""); // hata mesajını kaldır
            }
        }

        private void txtEpostaInfo_Validating(object sender, CancelEventArgs e)
        {
            string email = txtEpostaInfo.Text;
            bool isValid = IsValidEmail(email);
            if (isValid)
            {
                errorProvider.SetError(txtEpostaInfo, null); // hata mesajını kaldır
            }
            else
            {
                errorProvider.SetError(txtEpostaInfo, "Lütfen geçerli bir e-posta adresi girin"); // hata mesajını yazdır
            }
        }

        private void txtSifreInfo_Validating(object sender, CancelEventArgs e)
        {
            string sifre = txtSifreInfo.Text.Trim(); // sifrede boşluk varsa siler

            // Şifre en az 8 karakter uzunluğunda ve en az bir büyük harf, bir küçük harf ve bir rakam içermelidir.
            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$";

            if (!Regex.IsMatch(sifre, pattern))  // şifre kurallara uygun değil ise
            {
                // hata mesajı göster
                errorProvider.SetError(txtSifreInfo, 
                    "Şifre en az 8 karakter uzunluğunda olmalı ve en az bir büyük harf, bir küçük harf ve bir rakam içermelidir.");
            }
            else // şifre kurallara uygunsa
            {

                errorProvider.SetError(txtSifreInfo, ""); // hata mesajını kaldır
            }
        }

        private void btnUyeyiEkle_Click(object sender, EventArgs e) // Üyeyi ekle butonuna tıklandığında yapılacak işlemler
        {
            // hata yoksa
            if (
                errorProvider.GetError(txtAddTc) == "" &&
                errorProvider.GetError(txtAddName) == "" &&
                errorProvider.GetError(txtAddSoyad) == "" &&
                errorProvider.GetError(txtAddTelNo) == "" &&
                errorProvider.GetError(txtAddEposta) == "" &&
                errorProvider.GetError(txtAddSifre) == "" &&
                errorProvider.GetError(cmbBoxYetkiDuzeyi) == ""

                )
            {
                if (isEmpty()) // boş textbox var ise
                {
                    MessageBox.Show("Lütfen tüm bilgileri eksiksiz girin.");
                }
                else // yok ise
                {
                    try
                    {
                        if (baglanti.State == ConnectionState.Open) 
                        {
                            baglanti.Close();
                        }
                        baglanti.Open(); // bağlantıyı aç
                        // check tc no
                        SqlCommand cmdCheckTc = new SqlCommand("select * from tblUye where Tc = @tc", baglanti);
                        cmdCheckTc.Parameters.AddWithValue("@tc", txtAddTc.Text); // parametre geçme
                        // SqlDataReader reader = cmdCheckTc.ExecuteReader();
                        int result = Convert.ToInt32(cmdCheckTc.ExecuteScalar()); // kaç adet sonuç döndüğünü result değişkenine ata
                        if (result > 0) // sonuç varsa
                        {
                            MessageBox.Show("Eşleşen Kayıt bulundu.");
                        }
                        else // sonuç yoksa
                        {

                            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo; // metnin ilk harfi büyük gerisi küçük yazdırmak için
                            string query = 
                                "insert into tblUye ([Tc], [Ad], [Soyad],  [TelNo],[Mail], [Sifre],[YetkiDuzeyi]) " +
                                "Values (@tc,@ad,@soyad,@telNo,@mail,@sifre,@yetkiDuzeyi)"; // sql sorgu cümlesi
                            SqlCommand cmd = new SqlCommand(query, baglanti); // sqlCommand oluşturma
                            // parametre geçiliyor...
                            cmd.Parameters.AddWithValue("@tc", txtAddTc.Text); 
                            cmd.Parameters.AddWithValue("@ad", textInfo.ToTitleCase(txtAddName.Text));
                            cmd.Parameters.AddWithValue("@soyad", textInfo.ToTitleCase(txtAddSoyad.Text));
                            cmd.Parameters.AddWithValue("@telNo", txtAddTelNo.Text);
                            cmd.Parameters.AddWithValue("@mail", txtAddEposta.Text);
                            cmd.Parameters.AddWithValue("@sifre", txtAddSifre.Text);
                            cmd.Parameters.AddWithValue("@yetkiDuzeyi", cmbBoxYetkiDuzeyi.SelectedItem.ToString() == "Yönetici" ? 1 : 0);
                            cmd.ExecuteNonQuery(); // execute
                            MessageBox.Show("Üye başarıyla eklendi."); // başarılı mesajı
                            getAllMembersData(); // datagridview refresh
                            clearTextbox(); // textboxları temizle
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hata oluştu. Hata Mesajı : " + ex.Message);
                    }
                    finally
                    {

                        baglanti.Close(); // bağlantıyı kapat
                    }

                }

            }

            else { MessageBox.Show("Lütfen hataları giderin."); }
        }

        // Textboxların alabileceği değerlerin kontrolleri
        private void txtTcInfo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar); // sadece sayısal giriş
        }

        private void txtAdInfo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                && !char.IsSeparator(e.KeyChar);        // sadece harf girişi
        }

        private void txtSoyadInfo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                && !char.IsSeparator(e.KeyChar);        // sadece harf girişi
        }

        private void txtTelNoInfo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar); // sadece sayısal giriş
        }

        private void txtAddTelNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar); // sadece sayısal giriş
        }

        private void txtAddTc_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar); // sadece sayısal giriş
        }

        private void txtAddName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                && !char.IsSeparator(e.KeyChar);        // sadece harf girişi
        }

        private void txtAddSoyad_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                && !char.IsSeparator(e.KeyChar);        // sadece harf girişi
        }

    }
}
