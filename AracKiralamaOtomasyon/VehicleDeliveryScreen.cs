using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AracKiralamaOtomasyon
{
    public partial class VehicleDeliveryScreen : Form
    {
        // veritabanı bağlantısı
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-BTIS91A;Initial Catalog=Db_AracKiralama;Integrated Security=True");
        // hata yönetimi
        ErrorProvider errorProvider = new ErrorProvider();

        public VehicleDeliveryScreen()
        {
            InitializeComponent();

            // Karşılama Mesajı
            lblLeftName.Text = "Merhaba , " + LoginScreen.userName;

            //Veri çekme
            getDeliveryData();
            getSelectedCarInfo();
        }

        // Methods

        private void getDeliveryData()  // kiradaki araçların datasını çeker
        {
            if (baglanti.State == ConnectionState.Open)
            { baglanti.Close(); }

            DataTable dataTable = new DataTable(); //DataTable nesnesinin oluşturulması
            try
            {
                baglanti.Open(); // bağlantıyı aç
                SqlCommand cmd = new SqlCommand("getDeliveryDetails", baglanti); // sqlCommand oluşturma
                cmd.CommandType = CommandType.StoredProcedure; // command türünü storedProcedure olarak belirleme

                SqlDataReader reader = cmd.ExecuteReader(); // execute işlemi ve dönen verinin reader nesnesinde tutulması
                dataTable.Load(reader); // reader nesnesindeki verinin dataTable a yüklenmesi
                dataAracTeslim.DataSource = dataTable;  // datagridviewde dataTable nesnesindeki verileri gösterme

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { baglanti.Close(); } // bağlantıyı kapat
        }

        private void getSelectedCarInfo()  // datagridview de seçili olan aracın bilgilerini textboxlara yazdırma
        {
            if (dataAracTeslim.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataAracTeslim.SelectedRows[0];
                if (selectedRow.Cells[0].Value != null)
                {
                    txtPlakaInfo.Text = selectedRow.Cells[0].Value.ToString();
                    txtMarkaInfo.Text = selectedRow.Cells[1].Value.ToString();
                    txtModelInfo.Text = selectedRow.Cells[2].Value.ToString();
                    txtYilInfo.Text= selectedRow.Cells[3].Value.ToString();
                    txtVitesTuruInfo.Text= selectedRow.Cells[4].Value.ToString();
                    txtYakitTuruInfo.Text= selectedRow.Cells[5].Value.ToString();
                    txtKiralamaSekliInfo.Text = selectedRow.Cells[6].Value.ToString();
                    txtMusteriAdiInfo.Text = selectedRow.Cells[7].Value.ToString();
                    txtBorcInfo.Text = selectedRow.Cells[8].Value.ToString();
                    txtDurum.Text = selectedRow.Cells[11].Value.ToString();
                }
            }
        }


        private void VehicleDeliveryScreen_FormClosing(object sender, FormClosingEventArgs e)  
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

       

        private void VehicleDeliveryScreen_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'db_AracKiralamaDataSet2.getDeliveryDetails' table. You can move, or remove it, as needed.
            this.getDeliveryDetailsTableAdapter.Fill(this.db_AracKiralamaDataSet2.getDeliveryDetails);


        }

        // Placeholder kodları
        private void txtGecikenGun_Enter(object sender, EventArgs e)
        {
            if (txtGecikenGun.Text == "Geciken Gün")
            {
                txtGecikenGun.Text = "";
                txtGecikenGun.ForeColor = Color.Black;
            }
        }

        private void txtGecikenGun_Leave(object sender, EventArgs e)
        {
            if (txtGecikenGun.Text == "")
            {
                txtGecikenGun.Text = "Geciken Gün";
                txtGecikenGun.ForeColor = Color.Gray;
            }
        }

        private void txtHasarUcreti_Enter(object sender, EventArgs e)
        {
            if (txtHasarUcreti.Text == "Hasar Ücreti")
            {
                txtHasarUcreti.Text = "";
                txtHasarUcreti.ForeColor = Color.Black;
            }
        }

        private void txtHasarUcreti_Leave(object sender, EventArgs e)
        {
            if (txtHasarUcreti.Text == "")
            {
                txtHasarUcreti.Text = "Hasar Ücreti";
                txtHasarUcreti.ForeColor = Color.Gray;
            }
        }

        private void txtCezaUcreti_Leave(object sender, EventArgs e)
        {
            if (txtCezaUcreti.Text == "")
            {
                txtCezaUcreti.Text = "Ceza Ücreti";
                txtCezaUcreti.ForeColor = Color.Gray;
            }
        }

        private void txtCezaUcreti_Enter(object sender, EventArgs e)
        {
            if (txtCezaUcreti.Text == "Ceza Ücreti")
            {
                txtCezaUcreti.Text = "";
                txtCezaUcreti.ForeColor = Color.Black;
            }
        }

        private void dataAracTeslim_SelectionChanged(object sender, EventArgs e) 
        {
            //Seçilen arabanın bilgilerini getir.
            getSelectedCarInfo();
        }

        private void btnAracTeslim_Click(object sender, EventArgs e)
        {
            if (txtPlakaInfo.Text != "")
            {
                int gecikenGun = 0;
                int cezaUcreti = 0;
                int hasarUcreti = 0;
                Boolean listele = false;
                if (txtGecikenGun.Text != "Geciken Gün")
                {
                    gecikenGun += Convert.ToInt32(txtGecikenGun.Text);
                }
                if (txtCezaUcreti.Text != "Ceza Ücreti")
                {
                    cezaUcreti += Convert.ToInt32(txtCezaUcreti.Text);
                }
                if (txtHasarUcreti.Text != "Hasar Ücreti")
                {
                    hasarUcreti += Convert.ToInt32(txtHasarUcreti.Text);
                }
                if (chkListele.Checked)
                {
                    listele = true;
                }
                try
                {

                    if (baglanti.State == ConnectionState.Closed)
                    { baglanti.Open(); } // bağlantıyı aç

                    SqlCommand cmd = new SqlCommand("updateDeliveryDetails", baglanti); // command oluşturma
                    cmd.CommandType = CommandType.StoredProcedure; // command türü storedProcedure olarak ayarlama
                    // parametre geçiliyor
                    cmd.Parameters.AddWithValue("@paramPlaka", txtPlakaInfo.Text);
                    cmd.Parameters.AddWithValue("@paramGecikenGun", gecikenGun);
                    cmd.Parameters.AddWithValue("@paramCezaUcreti", cezaUcreti);
                    cmd.Parameters.AddWithValue("@paramHasarUcreti", hasarUcreti);
                    cmd.Parameters.AddWithValue("@paramListele", listele);
                    cmd.ExecuteNonQuery(); // execute işlemi
                    MessageBox.Show(txtPlakaInfo.Text + " Plakalı araç teslim alındı."); 
                    getDeliveryData(); // datagridview refresh işlemi

                    // İşlem sonrası placeholder 
                    txtGecikenGun.ForeColor = Color.Gray;
                    txtCezaUcreti.ForeColor= Color.Gray;
                    txtHasarUcreti.ForeColor = Color.Gray;
                    txtGecikenGun.Text = "Geciken Gün";
                    txtHasarUcreti.Text = "Hasar Ücreti";
                    txtCezaUcreti.Text = "Ceza Ücreti";

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
            else
            {
                MessageBox.Show("Lütfen teslim almak istediğiniz aracı seçiniz."); 
            }
        }

        // çıkış yap labelına tıklandığında çalışacak event
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

        // menü ekran geçişleri
        private void LnkLabelAracKiralamaIslemleri_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            MainScreen mainScreen = new MainScreen();
            mainScreen.Show();
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

        private void LnkLabelHesapAyar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AccountSettingsScreen accountSettingsScreen = new AccountSettingsScreen();
            accountSettingsScreen.Show();
            this.Hide();
        }
    }
}
