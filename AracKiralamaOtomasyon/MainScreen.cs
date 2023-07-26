using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AracKiralamaOtomasyon
{
    public partial class MainScreen : Form
    {
        public string ad = "";
        public MainScreen()
        {
            InitializeComponent();
        }

        // MSSQL Veritabanı bağlantısı kurar
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-BTIS91A;Initial Catalog=Db_AracKiralama;Integrated Security=True");
        ErrorProvider errorProvider= new ErrorProvider();
        
        
        private void MainScreen_FormClosing(object sender, FormClosingEventArgs e)
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


        private void LnkLabelCikis_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Çıkış yap labelına tıklandığında dialog oluşturulması işlemi
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

        private void MainScreen_Load(object sender, EventArgs e)
        {
            
            // Karşılama Mesajı
            lblLeftName.Text = "Merhaba , " + LoginScreen.userName;


            dateTimePickerLoad(); // timepicker getDate() işlemi ve format işlemi
            comboBoxLoad();  // combobox için belirlenen indexlerin set edilmesi


            //verileri çek
            getCarInfo();  // araç bilgilerini getirir
            getCustomersNameSurname();  // müşteri ad soyadını getirir

 
        }
        private void getCustomersNameSurname() // veritabanından müşterilerin ad - soyadını çekme işlemi
        {
            
            try
            {
                baglanti.Open(); // bağlantının açılması
                SqlCommand cmd = new SqlCommand("getCustomerNameSurname", baglanti); // sqlCommand oluşturulması
                cmd.CommandType = CommandType.StoredProcedure; // command türünün storedProcedure olarak belirlenmesi

                SqlDataReader reader = cmd.ExecuteReader();  // sqlCommandın çalıştırılıp dönen değerin reader ile okunması
                if(reader.HasRows)
                {
                    while(reader.Read()) // reader içerisindeki verilerin müşteri combobox'ına eklenmesi
                    {
                        cmbBoxMusteri.Items.Add(reader.GetString(1));
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally {
                baglanti.Close(); // bağlantının kapatılması
            }
        }

        private void getSelectedCarInfo()  // seçili datagridview deki verileri textboxlara yazdırma
        {
            if (dataAraclar.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataAraclar.SelectedRows[0];
                if (selectedRow.Cells[0].Value != null) // seçili satır varsa
                {
                    txtPlakaInfo.Text = selectedRow.Cells[0].Value.ToString();
                    txtMarkaInfo.Text = selectedRow.Cells[1].Value.ToString();
                    txtModelInfo.Text = selectedRow.Cells[2].Value.ToString();
                    txtYilInfo.Text = selectedRow.Cells[3].Value.ToString();
                    txtVitesInfo.Text = selectedRow.Cells[4].Value.ToString();
                    txtYakitInfo.Text = selectedRow.Cells[5].Value.ToString();
                }
            }
        }
        private void getCarInfo() // araçları veritabanından çekme işlemi
        {
            if(baglanti.State == ConnectionState.Open)
            { baglanti.Close(); }
            
            DataTable dataTable= new DataTable(); // DataTable nesnesini oluşturma
            try
            {
                baglanti.Open(); // bağlantıyı aç
                SqlCommand cmd = new SqlCommand("getCarData", baglanti); // sqlCommand oluşturma
                cmd.CommandType = CommandType.StoredProcedure; // command türünü storedProcedure olarak belirleme

                SqlDataReader reader = cmd.ExecuteReader(); // execute işlemi ve dönen verinin reader nesnesine alınması
                dataTable.Load(reader); // reader içerisindeki verinin dataTable a aktarılması
                dataAraclar.DataSource= dataTable; // datagridview e dataTable daki verilerin aktarımı

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { baglanti.Close(); } // bağlantıyı kapat
        }
        private void dateTimePickerLoad() //timepicker format ayarları ve minDate belirleme
        {
            timePickerAlis.CustomFormat = "dd/MM/yyyy"; 
            timePickerTeslim.CustomFormat = "dd/MM/yyyy";
            timePickerAlis.MinDate = DateTime.Today;
            timePickerTeslim.MinDate = timePickerAlis.Value.AddDays(1); // teslim tarihinin en az 1 gün sonra olmasının ayarlanması
        }

        private void comboBoxLoad() // load olayında comboboxların seçili indexlerinin ayarlanması
        {
            //Combobox SelectedIndex
            cmbBoxKiralamaSekli.SelectedIndex = 0;
            cmbBoxMusteri.SelectedIndex = 0;
        }

        private void btnAraciKirala_Click(object sender, EventArgs e) //Aracı Kirala butonuna tıklandığında yapılacak işlemler
        {
            DialogResult result = 
                MessageBox.Show(txtPlakaInfo.Text + " Plakalı " 
                              + txtMarkaInfo.Text + " marka araç " 
                              + cmbBoxMusteri.SelectedItem.ToString() 
                              + " adına kiralanacaktır. Devam etmek istiyor musunuz ?", "Uyarı", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                DateTime dateAlis = DateTime.ParseExact(timePickerAlis.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime dateTeslim = DateTime.ParseExact(timePickerTeslim.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                string dateAlisSqlFormat = dateAlis.ToString("yyyy-MM-dd"); // SQL format dönüştürme
                string dateTeslimSqlFormat = dateTeslim.ToString("yyyy-MM-dd"); // SQL formatına dönüştürme

                // hata kontrolü
                if (errorProvider.GetError(cmbBoxKiralamaSekli) == "" && errorProvider.GetError(cmbBoxMusteri) == "")
                {
                    //seçilmemiş alan var mı
                    if (cmbBoxKiralamaSekli.SelectedItem.ToString() == "Seçiniz..." || cmbBoxMusteri.SelectedItem.ToString() == "Seçiniz...")
                    {
                        MessageBox.Show("Lütfen eksik bilgileri doldurun");
                    }
                    else
                    {
                        // Veritabanı işlemleri
                        try 
                        {
                            if (baglanti.State == ConnectionState.Open)
                            {
                                baglanti.Close();
                            }
                            baglanti.Open(); // bağlantıyı aç
                            SqlCommand cmd = new SqlCommand("setRentedTest", baglanti); // testt!!!
                            cmd.CommandType = CommandType.StoredProcedure;
                            // storedProcedure parametre geçme
                            cmd.Parameters.AddWithValue("@paramPlaka", txtPlakaInfo.Text);
                            cmd.Parameters.AddWithValue("@paramMusteri", cmbBoxMusteri.SelectedItem.ToString());
                            cmd.Parameters.AddWithValue("@paramKiralamaTuru", cmbBoxKiralamaSekli.SelectedItem.ToString());
                            cmd.Parameters.AddWithValue("@paramAlisTarihi", dateAlisSqlFormat);
                            cmd.Parameters.AddWithValue("@paramTeslimTarihi", dateTeslimSqlFormat);
                            cmd.ExecuteNonQuery(); // command execute işlemi
                            MessageBox.Show(txtPlakaInfo.Text + " Plakalı " 
                                + txtMarkaInfo.Text 
                                + " marka araç " 
                                + cmbBoxMusteri.SelectedItem.ToString() 
                                + " adına kiralandı.");
                            getCarInfo(); // datagridview yenile

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
                else // eksik bilgi var ise 
                {
                    MessageBox.Show("Lütfen eksik bilgileri doldurun");
                }
            }

        }

        private void dataAraclar_SelectionChanged(object sender, EventArgs e)
        {
            // Seçili aracın bilgilerini ilgili textlere yazdırma
            getSelectedCarInfo();

        }

        private void timePickerAlis_ValueChanged(object sender, EventArgs e) // Alış tarihi seçildiğinde yapılacak kontroller
        {
            timePickerTeslim.MinDate = timePickerAlis.Value.AddDays(1); //Teslim tarihinin min değeri alış tarihinden 1 fazla olarak ayarlandı
            if (timePickerAlis.Value < DateTime.Today)
            {
                errorProvider.SetError(timePickerAlis, "Geçmiş bir tarih seçemezsiniz.");
                timePickerAlis.Value = DateTime.Today;
            }
            else
            {
                errorProvider.SetError(timePickerAlis, "");
            }
        }

        private void timePickerTeslim_ValueChanged(object sender, EventArgs e)
        {
            /*
            DateTime alisTarihi = DateTime.ParseExact(timePickerAlis.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime teslimTarihi = DateTime.ParseExact(timePickerTeslim.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            if (teslimTarihi < alisTarihi)
            {
                errorProvider.SetError(timePickerTeslim, "Teslim tarihi, alış tarihinden önce olamaz.");
            }
            else
            {
                errorProvider.SetError(timePickerTeslim, "");
            }
            */
        }

        private void dataAraclar_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            // Eğer satırın indexi tek sayı ise arkaplan rengini gri olarak ayarla
            if (e.RowIndex % 2 == 0)
            {
                dataAraclar.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
            }
            // Değilse arkaplan rengini beyaz olarak ayarla
            else
            {
                dataAraclar.Rows[e.RowIndex].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#e5e5e5");
            }
        }

        private void dataAraclar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void cmbBoxKiralamaSekli_Validating(object sender, CancelEventArgs e) //Kiralama şekli comboboxının seçilme durumunun kontrolü
        {
            if(cmbBoxKiralamaSekli.SelectedItem.ToString().Equals("Seçiniz..."))  // bir seçim yapılmadıysa
            {
                errorProvider.SetError(cmbBoxKiralamaSekli,"Lütfen bir seçim yapın"); // hata mesajı göster
            }
            else
            {
                errorProvider.SetError(cmbBoxKiralamaSekli,"");  //  hata mesajını kaldır
            }
        }

        private void cmbBoxMusteri_Validating(object sender, CancelEventArgs e) // müşteri comboboxının seçilme durumu kontrolü
        {
            if (cmbBoxMusteri.SelectedItem.ToString().Equals("Seçiniz...")) // bir seçim yapılmadıysa
            {
                errorProvider.SetError(cmbBoxMusteri, "Lütfen bir seçim yapın"); // hata mesajı göster
            }
            else
            {
                errorProvider.SetError(cmbBoxMusteri, ""); // hata mesajını kaldır
            }
        }

        private void LnkLabelAracTeslim_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) // araç teslim ekranını açar
        {
            this.Hide();
            VehicleDeliveryScreen vehicleDeliveryScreen = new VehicleDeliveryScreen();
            vehicleDeliveryScreen.Show();
        }

        private void LnkLabelAracYonetim_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) // araç yönetim ekranını açar
        {
            this.Hide();
            VehicleManagmentScreen vehicleManagmentScreen = new VehicleManagmentScreen();
            vehicleManagmentScreen.Show();
        }

        private void LnkLabelMusteriYonetim_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) // müşteri yönetim ekranını açar
        {
            this.Hide();
            CustomerManagmentScreen customerManagmentScreen = new CustomerManagmentScreen();
            customerManagmentScreen.Show();
        }

        private void LnkLabelHesapAyar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) // hesap ayarları ekranını açar
        {
            this.Hide();
            AccountSettingsScreen accountSettingsScreen = new AccountSettingsScreen();
            accountSettingsScreen.Show();
        }
    }
}
