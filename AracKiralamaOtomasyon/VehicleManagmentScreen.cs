using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AracKiralamaOtomasyon
{
    public partial class VehicleManagmentScreen : Form
    {
        //Veritabanı bağlantısı
        
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-BTIS91A;Initial Catalog=Db_AracKiralama;Integrated Security=True");
        
        //Hata yönetim aracı
        ErrorProvider errorProvider = new ErrorProvider();

        string oldPlaka = "";
        public VehicleManagmentScreen()
        {

            InitializeComponent();

            // Karşılama Mesajı
            lblLeftName.Text = "Merhaba , " + LoginScreen.userName;
            
            //Combobox Load
            comboBoxLoad();
           
            //Verileri Çek
            getAllCarsData();
            getSelectedCarInfo();
            getBrand();
            getSegment();
        }

        //Methods
        private void getAllCarsData() // veritabanından araçları çeker
        {
            if (baglanti.State == ConnectionState.Open)
            { baglanti.Close(); }

            DataTable dataTable = new DataTable(); // DataTable nesnesi oluşturma
            try
            {
                baglanti.Open(); // bağlantıyı aç
                SqlCommand cmd = new SqlCommand("getCarsAllData", baglanti); // sqlCommand oluşturma
                cmd.CommandType = CommandType.StoredProcedure; // command türünü storedProcedure olarak ayarlama
                SqlDataReader reader = cmd.ExecuteReader(); // execute işlemi ve dönen verinin reader nesnesine yazılması
                dataTable.Load(reader); // reader içerisindeki verinin dataTable a yüklenmesi
                reader.Close(); // reader nesnesinin kapatılması
                dataAraclar.DataSource = dataTable; // dataTable içerisindeki verinin datagridviewe aktarılması
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { baglanti.Close(); } // bağlantıyı kapat
        }

        private void getBrand() // veritabanından markaları çekmek için
        {
            if (baglanti.State == ConnectionState.Open)
            { baglanti.Close(); } 

            try
            {
                baglanti.Open(); // bağlantıyı aç
                string query = "select Marka from tblMarka"; // sql sorgu cümleciği
                SqlCommand cmd = new SqlCommand(query, baglanti); // sqlCommand oluşturma
                SqlDataReader reader = cmd.ExecuteReader(); // execute işlemi ve dönen verinin reader'a aktarılması
                List<string> markalar = new List<string>(); 
                while (reader.Read()) 
                {
                    markalar.Add(reader.GetString(0));  // markalar listesine reader içindeki verinin eklenmesi
                }
                markalar.Sort(); // markaları sıralama

                foreach (var item in markalar)
                {
                    cmbBoxMarka.Items.Add(item); // sıralanmış listeyi comboBox içerisine ekleme
                }
                reader.Close(); // reader nesnesinin kapatılması

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { baglanti.Close(); } // bağlantıyı kapat
        }

        private void getSelectedCarInfo()   // seçili araç bilgisini getirir
        {
            if (dataAraclar.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataAraclar.SelectedRows[0];
                if (selectedRow.Cells[0].Value != null)
                {
                    txtPlakaInfo.Text = selectedRow.Cells[0].Value.ToString();
                    txtMarkaInfo.Text = selectedRow.Cells[1].Value.ToString();
                    txtModelInfo.Text = selectedRow.Cells[2].Value.ToString();
                    txtYilInfo.Text = selectedRow.Cells[3].Value.ToString();
                    txtVitesTuruInfo.Text = selectedRow.Cells[4].Value.ToString();
                    txtYakitTuruInfo.Text = selectedRow.Cells[5].Value.ToString();
                    txtGunlukUcret.Text = selectedRow.Cells[7].Value.ToString();
                    txtHaftalikUcret.Text = selectedRow.Cells[8].Value.ToString();
                    txtAylikUcret.Text = selectedRow.Cells[9].Value.ToString();
                    txtDurumuInfo.Text = selectedRow.Cells[10].Value.ToString();
                }
            }
        }
        private void setEnableTextbox() // ilgili textboxları enable yapar
        {
            txtPlakaInfo.Enabled = true;
            txtPlakaInfo.TextAlign = HorizontalAlignment.Left;
            txtPlakaInfo.ForeColor = Color.Black;
            //txtModelInfo.Enabled = true;
            //txtMarkaInfo.Enabled = true;
            //txtVitesTuruInfo.Enabled = true;
            txtYilInfo.Enabled = true;
            txtYilInfo.TextAlign = HorizontalAlignment.Left;
            txtYilInfo.ForeColor = Color.Black;
            //txtYakitTuruInfo.Enabled = true;

        }
        private void setDisableTextbox() // ilgili textboxları disable yapar
        {
            txtPlakaInfo.Enabled = false;
            txtPlakaInfo.TextAlign = HorizontalAlignment.Center;
            txtPlakaInfo.ForeColor = Color.Gray;
            //txtModelInfo.Enabled = false;
            //txtMarkaInfo.Enabled = false;
            //txtVitesTuruInfo.Enabled = false;
            txtYilInfo.Enabled = false;
            txtYilInfo.TextAlign = HorizontalAlignment.Center;
            txtYilInfo.ForeColor = Color.Gray;
            //txtYakitTuruInfo.Enabled = false;

        }
        private void getSegment() // veritabanından segmentleri çeker
        {
            if (baglanti.State == ConnectionState.Open)
            { baglanti.Close(); }

            try
            {
                baglanti.Open(); // bağlantıyı aç
                string query = "select Segment from tblSegment"; // sql sorgu cümlesi
                SqlCommand cmd = new SqlCommand(query, baglanti); // sqlCommand oluşturma
                SqlDataReader reader = cmd.ExecuteReader(); // execute işlemi ve reader nesnesine dönen verinin atılması
                List<string> segmentler = new List<string>(); 
                while (reader.Read())
                {
                    segmentler.Add(reader.GetString(0)); // reader içerisindeki veriyi segmentler listesine ekleme
                }
                segmentler.Sort(); // listeyi sıralama

                foreach (var item in segmentler)
                {
                    cmbBoxSegment.Items.Add(item); // sıralanmış listeyi segment comboboxına ekleme
                }
                reader.Close(); // reader kapat

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { baglanti.Close(); } // bağlantıyı kapat
        }
        private void comboBoxLoad()  // formun load olayında kullanmak için , ilgili comboboxların varsayılan değerlerini belirler
        {
            //Combobox SelectedIndex
            cmbBoxMarka.SelectedIndex = 0;
            cmbBoxModel.SelectedIndex = 0;
            cmbBoxDurum.SelectedIndex = 0;
            cmbBoxVitesTuru.SelectedIndex = 0;
            cmbBoxYakitTuru.SelectedIndex = 0;
            cmbBoxSegment.SelectedIndex = 0;
        }
        
        private void getModel() // veritabanından modelleri çeker
        {
            if (baglanti.State == ConnectionState.Closed)
            { baglanti.Open(); }

            try
            {
                SqlCommand cmd = new SqlCommand("getMarkaId",baglanti); // markaId almak için sqlCommand oluşturma
                cmd.CommandType= CommandType.StoredProcedure; // komut türünü stored procedure olarak ayarlama
                // parametre tanımlanıyor..
                SqlParameter paramMarkaAdi = new SqlParameter("@paramMarkaAdi", cmbBoxMarka.SelectedItem.ToString());
                //parametre input olarak ayarlanıyor..
                paramMarkaAdi.Direction = ParameterDirection.Input;
                // parametre geçiliyor..
                cmd.Parameters.Add(paramMarkaAdi);
                //dönen output değeri alınıyor..
                SqlParameter paramId = new SqlParameter("@Id", SqlDbType.Int);
                paramId.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(paramId); // id değerini commanda parametre geçme

                // SqlCommand nesnesini çalıştırma
                cmd.ExecuteNonQuery();
                
                // Çıktı parametresindeki değeri alma
                int markaId = (int)cmd.Parameters["@Id"].Value;
                string query = "select ModelAdi from tblModel where MarkaId = @markaId "; // sql sorgusu oluşturma
                SqlCommand cmdModel = new SqlCommand(query, baglanti); // sqlCommand oluşturma
                cmdModel.Parameters.AddWithValue("@markaId",markaId); // parametre geçiliyor
                SqlDataReader reader = cmdModel.ExecuteReader(); // execute işlemi ve dönen verinin readera aktarımı
                List<string> modeller = new List<string>(); // reader içerisindeki modelleri eklemek için liste(sıralama için)
                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        modeller.Add(reader.GetString(0)); // reader içerisindeki verinin listeye eklenmesi
                    }
                    modeller.Sort(); // modeller listesinin sıralanması 
                }
                cmbBoxModel.Items.Clear(); // comboboxın içerisinin temizlenmesi
                cmbBoxModel.Items.Add("Seçiniz..."); 
                cmbBoxModel.SelectedIndex= 0;
                foreach(var model in modeller)
                {
                    cmbBoxModel.Items.Add(model); // sıralanmış listeyi combobox a ekleme
                }
                reader.Close(); // reader kapatma

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally { baglanti.Close(); } // bağlantıyı kapat
        }

        private void getModelForEdit() // modelleri getirir
        {

            if (baglanti.State == ConnectionState.Closed)
            { baglanti.Open(); }

            try
            {
                SqlCommand cmd = new SqlCommand("getMarkaId", baglanti); // sqlCommand oluşturma
                cmd.CommandType = CommandType.StoredProcedure; // command türünü storedProcedure olarak belirleme
                // parametre oluşturma
                SqlParameter paramMarkaAdi = new SqlParameter("@paramMarkaAdi", cmbBoxMarkaEdit.SelectedItem.ToString());
                paramMarkaAdi.Direction = ParameterDirection.Input; // parametre türünü input olarak ayarlar
                cmd.Parameters.Add(paramMarkaAdi); // parametreyi ekler

                SqlParameter paramId = new SqlParameter("@Id", SqlDbType.Int); // parametre oluşturma
                paramId.Direction = ParameterDirection.Output; // parametre türünü output olarak ayarlama
                cmd.Parameters.Add(paramId); // parametre ekleme

                // SqlCommand nesnesini çalıştırma
                cmd.ExecuteNonQuery(); 

                // Çıktı parametresindeki değeri alma
                int markaId = (int)cmd.Parameters["@Id"].Value;
                string query = "select ModelAdi from tblModel where MarkaId = @markaId "; // sql sorgusu oluşturma
                SqlCommand cmdModel = new SqlCommand(query, baglanti); // sqlCommand oluşturma
                cmdModel.Parameters.AddWithValue("@markaId", markaId); // parametre geçiliyor
                SqlDataReader reader = cmdModel.ExecuteReader(); // execute işlemi ve reader nesnesine dönen verinin aktarımı
                List<string> modeller = new List<string>(); // modeller listesinin oluşturulması (sıralama için)
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        modeller.Add(reader.GetString(0)); // reader içerisindeki verinin listeye eklenmesi
                    }
                    modeller.Sort(); // modeller listesinin sıralanması
                }
                cmbBoxModelEdit.Items.Clear(); 
                if(cmbBoxMarkaEdit.SelectedItem.ToString() == txtMarkaInfo.Text)
                {
                    cmbBoxModelEdit.Items.Add(txtModelInfo.Text);
                    cmbBoxModelEdit.SelectedIndex = 0;
                }
                
                
                foreach (var model in modeller) // modeller listesindeki veriyi comboboxa ekler
                {
                    if (cmbBoxModelEdit.Items.Count != 0)
                    {
                        if (cmbBoxModelEdit.Items[0].ToString() != model.ToString())
                        {
                            cmbBoxModelEdit.Items.Add(model);
                        }
                    }
                    else
                    {
                        cmbBoxModelEdit.Items.Add(model);
                    }
                    
                }
                
                reader.Close(); // reader kapat

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally { baglanti.Close(); } // bağlantıyı kapat
        }


        private void editModeOn() // edit modu açıldığında çalıştırmak için
        {
            lblSegmentEdit.Visible = true;
            lblGunlukUcret.Visible = false;
            lblHaftalikUcret.Visible = false;
            lblAylikUcret.Visible = false;
            lblDurumuInfo.Visible = false;
            lblDurumuEdit.Visible = true;
            cmbBoxSegmentEdit.Visible = true;
            cmbBoxDurumuEdit.Visible = true;
            txtDurumuInfo.Visible = false;
            txtGunlukUcret.Visible = false;
            txtHaftalikUcret.Visible = false;
            txtAylikUcret.Visible = false;
            txtMarkaInfo.Visible = false;
            cmbBoxMarkaEdit.Visible = true;
            txtModelInfo.Visible = false;
            cmbBoxModelEdit.Visible = true;
            cmbBoxVitesTuruEdit.Visible = true;
            cmbBoxYakitTuruEdit.Visible = true;
        }
        private void editModeOff() // edit modu kapatıldığında çalıştırmak için
        {
            lblSegmentEdit.Visible = false;
            lblGunlukUcret.Visible = true;
            lblHaftalikUcret.Visible = true;
            lblAylikUcret.Visible = true;
            lblDurumuInfo.Visible = true;
            lblDurumuEdit.Visible = false;
            cmbBoxSegmentEdit.Visible = false;
            cmbBoxDurumuEdit.Visible = false;
            txtDurumuInfo.Visible = true;
            txtGunlukUcret.Visible = true;
            txtHaftalikUcret.Visible = true;
            txtAylikUcret.Visible = true;
            txtMarkaInfo.Visible = true;
            txtModelInfo.Visible = true;
            cmbBoxModelEdit.Visible = false;
            cmbBoxVitesTuruEdit.Visible = false;
            cmbBoxYakitTuruEdit.Visible = false;
            cmbBoxMarkaEdit.Visible = false;
            
        }

        // set cmbBoxYakitTuruEdit - cmbBoxVitesTuruEdit
        private void setEditComboBox() 
        {
            // comboboxları temizle 
            cmbBoxYakitTuruEdit.Items.Clear();
            cmbBoxVitesTuruEdit.Items.Clear();
             
                // varsayılan değerlerin eklenmesi
                cmbBoxYakitTuruEdit.Items.Add(txtYakitTuruInfo.Text);
                cmbBoxYakitTuruEdit.SelectedIndex = 0;
            
            
                cmbBoxVitesTuruEdit.Items.Add(txtVitesTuruInfo.Text);
                cmbBoxVitesTuruEdit.SelectedIndex = 0;


            foreach(var item in cmbBoxYakitTuru.Items) // yakıt türlerinin eklenmesi
            {
                if(item.ToString() != "Seçiniz..." && item.ToString() != txtYakitTuruInfo.Text)
                {
                    cmbBoxYakitTuruEdit.Items.Add(item);
                }
            }
            foreach(var item in cmbBoxVitesTuru.Items)  // vites türlerinin eklenmesi
            {
                if(item.ToString() != "Seçiniz..." && item.ToString() != txtVitesTuruInfo.Text)
                {
                    cmbBoxVitesTuruEdit.Items.Add(item);
                }
                
            }

        }

        private void VehicleManagmentScreen_Load(object sender, EventArgs e)
        {
            



        }




        private void VehicleManagmentScreen_FormClosing(object sender, FormClosingEventArgs e)
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



        private void dataAraclar_SelectionChanged(object sender, EventArgs e) 
        {
            // Seçili araç bilgilerini çek
            getSelectedCarInfo();
        }

        // textboxların alabileceği değerlerin belirlenmesi
        private void txtYilInfo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);  // Yalnızca sayısal değerlere izin ver
        }

        private void txtVitesTuruInfo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                && !char.IsSeparator(e.KeyChar);        // sadece harf girişi
        }

        private void txtYakitTuruInfo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                && !char.IsSeparator(e.KeyChar);        // sadece harf girişi
        }

        private void txtGunlukUcret_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Sadece 0-9 arasındaki sayılar ve virgül izin verilsin
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true; // Karakteri reddet
            }

            // Sadece bir tane virgül karakteri olmasına izin verilsin
           /* if (e.KeyChar == ',')
            {
                if (txtGunlukUcret.Text.Contains(","))
                {
                    e.Handled = true; // Karakteri reddet
                }
            }*/
        }

        private void btnAracDuzenle_Click(object sender, EventArgs e)
        {
            setEnableTextbox();  // textboxları veri girişine aç
            
            btnAracDuzenle.Visible = false;
            btnKaydet.Visible = true;
            dataAraclar.Enabled = false;    // gridview dondur
            btnIptalEt.Visible = true;

            editModeOn(); // Edit için gerekli olan nesneleri gösterir lazım olmayanları gizler.
            DataGridViewRow selectedRow = dataAraclar.SelectedRows[0];

            //OLD DATA FOR EDİT (eski verileri listeye ekleme)
            List<String> oldData = new List<string>();
            oldData.Add(txtPlakaInfo.Text);
            oldData.Add(txtMarkaInfo.Text);
            oldData.Add(txtModelInfo.Text);
            oldData.Add(txtYilInfo.Text);
            oldData.Add(txtVitesTuruInfo.Text);
            oldData.Add(txtYakitTuruInfo.Text);
            oldData.Add(selectedRow.Cells[6].Value.ToString());
            oldData.Add(txtDurumuInfo.Text);

            oldPlaka = txtPlakaInfo.Text; 

            // Marka Edit
            cmbBoxMarkaEdit.Items.Clear();
            cmbBoxMarkaEdit.Items.Add(oldData[1]);
            cmbBoxMarkaEdit.SelectedIndex = 0;
            foreach (var item in cmbBoxMarka.Items)
            {
                
                if (item.ToString() != "Seçiniz..." && item.ToString() != cmbBoxMarkaEdit.Items[0].ToString())
                {
                    cmbBoxMarkaEdit.Items.Add(item); // comboboxa markalar ekleniyor
                }
            }

            // VitesTuru YakitTuru
            setEditComboBox();

            // Segment 
            cmbBoxSegmentEdit.Items.Clear();
            cmbBoxSegmentEdit.Items.Add(oldData[6]);
            cmbBoxSegmentEdit.SelectedIndex = 0;

            foreach(var item in cmbBoxSegment.Items)
            {
                if(item.ToString() != "Seçiniz..." && item.ToString() != oldData[6])
                {
                    cmbBoxSegmentEdit.Items.Add(item); // segmentler ekleniyor..
                }
            }

            //Durumu 
            cmbBoxDurumuEdit.Items.Clear();
            //cmbBoxDurumuEdit.Items.Add(oldData[7]);
            switch(oldData[7]) 
            {
                case "True": // seçili satırdaki durum true ise
                    {
                        cmbBoxDurumuEdit.Items.Add("Aktif");
                        break;
                    }
                default: // false ise
                    {
                        cmbBoxDurumuEdit.Items.Add("Pasif");
                        break;
                    }
            }
            cmbBoxDurumuEdit.SelectedIndex = 0;
            
            foreach(var item in cmbBoxDurum.Items)
            {
                if (item.ToString() != "Seçiniz..." && item.ToString() != cmbBoxDurumuEdit.Items[0].ToString()) 
                {
                    cmbBoxDurumuEdit.Items.Add(item); // durum ekleniyor
                }
            }
        }

        private void updateData(List<String> paramListe) // veritabanı update işlemi
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }
                // PLAKAYA AİT ARAÇ ID ALMA
                SqlCommand cmdAracId = new SqlCommand("getAracId", baglanti); // sqlCommand oluşturma
                cmdAracId.CommandType = CommandType.StoredProcedure; // command türünü storedProcedure olarak ayarlama
                SqlParameter paramPlaka = new SqlParameter("@paramPlaka", oldPlaka); // parametre oluşturma
                paramPlaka.Direction = ParameterDirection.Input; // parametre türünü input olarak belirleme
                cmdAracId.Parameters.Add(paramPlaka); // parametre geçme

                SqlParameter paramAracId = new SqlParameter("@Id", SqlDbType.Int);
                paramAracId.Direction = ParameterDirection.Output; // parametre türünü output ayarlama
                cmdAracId.Parameters.Add(paramAracId); // parametre geçiliyor

                // SqlCommand nesnesini çalıştırma
                cmdAracId.ExecuteNonQuery();

                // Çıktı parametresindeki değeri alma
                int aracId = (int)cmdAracId.Parameters["@Id"].Value;     // ARAÇ ID



                // MARKA ID ALMA
                SqlCommand cmd = new SqlCommand("getMarkaId", baglanti); // sqlCommand oluşturma
                cmd.CommandType = CommandType.StoredProcedure; // command türünü storedProcedure olarak belirleme
                SqlParameter paramMarkaAdi = new SqlParameter("@paramMarkaAdi", paramListe[1]); // parametre oluşturma
                paramMarkaAdi.Direction = ParameterDirection.Input; // parametre türünü input olarak ayarlar
                cmd.Parameters.Add(paramMarkaAdi); // parametre geçme

                SqlParameter paramId = new SqlParameter("@Id", SqlDbType.Int); // parametre oluşturma
                paramId.Direction = ParameterDirection.Output; // parametre türünü output olarak ayarlar
                cmd.Parameters.Add(paramId); // parametre geçme

                // SqlCommand nesnesini çalıştırma
                cmd.ExecuteNonQuery();

                // Çıktı parametresindeki değeri alma
                int markaId = (int)cmd.Parameters["@Id"].Value;     // MARKA ID


                // MODEL ID ALMA
                SqlCommand cmdModelId = new SqlCommand("getModelId", baglanti); // sqlCommand oluşturma
                cmdModelId.CommandType = CommandType.StoredProcedure; // command türünü belirleme
                SqlParameter paramModelAdi = new SqlParameter("@paramModelAdi", paramListe[2]); // parametre oluşturma
                paramModelAdi.Direction = ParameterDirection.Input; // parametre türünü input olarak ayarlar
                cmdModelId.Parameters.Add(paramModelAdi); // parametre geçme

                SqlParameter paramModelId = new SqlParameter("@Id", SqlDbType.Int); //parametre oluşturma
                paramModelId.Direction = ParameterDirection.Output; // parametre türünü output olarak belirleme
                cmdModelId.Parameters.Add(paramModelId); // parametre geçme

                // SqlCommand nesnesini çalıştırma
                cmdModelId.ExecuteNonQuery();

                // Çıktı parametresindeki değeri alma
                int modelId = (int)cmdModelId.Parameters["@Id"].Value;      //MODEL ID


                // SEGMENT ID ALMA

                SqlCommand cmdSegmentId = new SqlCommand("getSegmentId", baglanti); // sqlCommand oluşturma
                cmdSegmentId.CommandType = CommandType.StoredProcedure; // command türü belirleme
                SqlParameter paramSegmentAdi = new SqlParameter("@paramSegmentAdi", paramListe[6]); // parametre oluşturma
                paramSegmentAdi.Direction = ParameterDirection.Input; // parametre türünü input yapar
                cmdSegmentId.Parameters.Add(paramSegmentAdi); // parametre geçme

                SqlParameter paramSegmentId = new SqlParameter("@Id", SqlDbType.Int); // parametre oluşturma
                paramSegmentId.Direction = ParameterDirection.Output; // parametre türünü output olarak ayarlama
                cmdSegmentId.Parameters.Add(paramSegmentId); // parametre geçme

                // SqlCommand nesnesini çalıştırma
                cmdSegmentId.ExecuteNonQuery();

                // Çıktı parametresindeki değeri alma
                int segmentId = (int)cmdSegmentId.Parameters["@Id"].Value;      //SEGMENT ID


                // *** SQL UPDATE ***
                string query = "update tblArac SET Plaka=@plaka, MarkaId=@markaId, " +
                    "ModelId = @modelId ," +
                    " Yili = @yili , " +
                    "VitesTuru = @vitesTuru , " +
                    "YakitTuru = @yakitTuru , " +
                    "SegmentId = @segmentId , " +
                    "Durumu = @durumu where Id = @Id "; // where koşulu !!!
                SqlCommand cmdUpdate = new SqlCommand(query,baglanti); // sqlCommand oluşturma
                // parametre geçiliyor...
                cmdUpdate.Parameters.AddWithValue("@plaka", paramListe[0]);
                cmdUpdate.Parameters.AddWithValue("@markaId", markaId);
                cmdUpdate.Parameters.AddWithValue("@modelId", modelId);
                cmdUpdate.Parameters.AddWithValue("@yili", paramListe[3]);
                cmdUpdate.Parameters.AddWithValue("@vitesTuru", paramListe[4]);
                cmdUpdate.Parameters.AddWithValue("@yakitTuru", paramListe[5]);
                cmdUpdate.Parameters.AddWithValue("@segmentId", segmentId);
                cmdUpdate.Parameters.AddWithValue("@durumu", paramListe[7]);
                cmdUpdate.Parameters.AddWithValue("@Id",aracId);

                cmdUpdate.ExecuteNonQuery(); //execute

                MessageBox.Show("Araç Başarıyla Güncellendi.");
                getAllCarsData(); // datagridview refresh



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


        private void btnKaydet_Click(object sender, EventArgs e)
        {
            

            if(errorProvider.GetError(txtPlakaInfo) == "" && errorProvider.GetError(txtYilInfo) == "") // aktif errorProvider(hata) yok ise
            {
                setDisableTextbox();
                dataAraclar.ReadOnly = true; // datagridviewi ReadOnly olarak ayarlama
                btnKaydet.Visible = false; // kaydet butonunu gizle
                btnAracDuzenle.Visible = true; //butonu aktif et
                dataAraclar.Enabled = true; // datagridviewi aktif et
                btnIptalEt.Visible = false; // iptal et butonunu gizler
                editModeOff(); // Edit için gerekli olan nesneleri gizler

                // Yeni veriler (güncelleme için)
                List<String> newData = new List<string>();
                newData.Add(txtPlakaInfo.Text);
                newData.Add(cmbBoxMarkaEdit.SelectedItem.ToString());
                newData.Add(cmbBoxModelEdit.SelectedItem.ToString());
                newData.Add(txtYilInfo.Text);
                newData.Add(cmbBoxVitesTuruEdit.SelectedItem.ToString());
                newData.Add(cmbBoxYakitTuruEdit.SelectedItem.ToString());
                newData.Add(cmbBoxSegmentEdit.SelectedItem.ToString());
                switch (cmbBoxDurumuEdit.SelectedItem.ToString())
                {
                    case "Aktif":
                        {
                            newData.Add("true");
                            break;
                        }

                    default:
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

        private void txtAddPlaka_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Yalnızca harf ve rakam , boşluk yok
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void txtAddYil_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);  // Yalnızca sayısal değerlerin girilmesine izin verir.
        }
        

        private void btnAracEkle_Click(object sender, EventArgs e)
        {
            // Veri Kontrolü
            // Tüm hataların düzeltilmesi kontrol ediliyor.
            if (
                errorProvider.GetError(txtAddPlaka) == ""
                && errorProvider.GetError(txtAddYil) == ""
                && errorProvider.GetError(cmbBoxMarka) == ""
                && errorProvider.GetError(cmbBoxModel) == ""
                && errorProvider.GetError(cmbBoxSegment) == ""
                && errorProvider.GetError(cmbBoxVitesTuru) == ""
                && errorProvider.GetError(cmbBoxYakitTuru) == ""
                && errorProvider.GetError(cmbBoxDurum) == "")

            {
                // Textboxların içerisine herhangi bir veri girişi olmadığnda
                if (
                    txtAddPlaka.Text == "Plaka"
                    || txtAddYil.Text == "Yıl"
                    || cmbBoxDurum.SelectedItem.ToString() == "Seçiniz..."
                    || cmbBoxMarka.SelectedItem.ToString() == "Seçiniz..."
                    || cmbBoxModel.SelectedItem.ToString() == "Seçiniz..."
                    || cmbBoxYakitTuru.SelectedItem.ToString() == "Seçiniz..."
                    || cmbBoxVitesTuru.SelectedItem.ToString() == "Seçiniz..."
                    || cmbBoxSegment.SelectedItem.ToString() == "Seçiniz...")
                {
                    MessageBox.Show("Lütfen tüm bilgileri eksiksiz doldurun.");
                }

                else
                {


                    if (baglanti.State == ConnectionState.Closed)
                    { baglanti.Open(); }

                    try
                    {
                        string query = "select * from tblArac where Plaka = @plaka "; // sql sorgu cümleciği oluşturma
                        SqlCommand cmd = new SqlCommand(query, baglanti); //sqlCommand oluşturma
                        cmd.Parameters.AddWithValue("@plaka", txtAddPlaka.Text); // parametre geçme
                        SqlDataReader reader = cmd.ExecuteReader(); // execute işlemi ve dönen verinin reader da tutulması
                        Boolean hasRows = reader.HasRows; // reader da veri var mı 
                        reader.Close(); // reader kapat
                        if (hasRows) // true ise
                        {
                            MessageBox.Show("Girdiğiniz plaka ait kayıt bulundu !");
                        }
                        else
                        {
                            string durum = cmbBoxDurum.SelectedItem.ToString();
                            Boolean durumu = false;
                            if (durum == "Aktif")
                            {
                                durumu = true;
                            }
                            SqlCommand cmdAdd = new SqlCommand("addCar", baglanti); // sqlCommand oluşturma 
                            cmdAdd.CommandType = CommandType.StoredProcedure; // command türü belirleme
                            // *** parametre geçiliyor ***
                            cmdAdd.Parameters.AddWithValue("@paramPlaka", txtAddPlaka.Text.ToUpper());
                            cmdAdd.Parameters.AddWithValue("@paramMarka", cmbBoxMarka.SelectedItem.ToString());
                            cmdAdd.Parameters.AddWithValue("@paramModel", cmbBoxModel.SelectedItem.ToString());
                            cmdAdd.Parameters.AddWithValue("@paramYil", txtAddYil.Text);
                            cmdAdd.Parameters.AddWithValue("@paramVitesTuru", cmbBoxVitesTuru.SelectedItem.ToString());
                            cmdAdd.Parameters.AddWithValue("@paramYakitTuru", cmbBoxYakitTuru.SelectedItem.ToString());
                            cmdAdd.Parameters.AddWithValue("@paramSegment", cmbBoxSegment.SelectedItem.ToString());
                            cmdAdd.Parameters.AddWithValue("@paramDurumu", durumu);

                            cmdAdd.ExecuteNonQuery(); // execute
                            MessageBox.Show(txtAddPlaka.Text + " Plakalı " + cmbBoxMarka.SelectedItem.ToString() + " marka araç başarıyla eklendi.");

                            getAllCarsData(); // datagridview refresh
                            defaultValuesAracEkle(); // default değerlerin getirilmesi
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally { baglanti.Close(); } // bağlantıyı kapat

                }
            }
            else
            {
                MessageBox.Show("Lütfen hataları düzeltin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            }

        private void defaultValuesAracEkle() //araç ekleme işleminden sonra default değerlerin getirilmesi için
        {
            txtAddPlaka.Text = "Plaka";
            txtAddYil.Text = "Yıl";
            cmbBoxDurum.SelectedIndex = 0;
            cmbBoxMarka.SelectedIndex = 0;
            cmbBoxModel.SelectedIndex = 0;
            cmbBoxSegment.SelectedIndex = 0;
            cmbBoxVitesTuru.SelectedIndex = 0;
            cmbBoxYakitTuru.SelectedIndex = 0;
        }

        private void cmbBoxMarka_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbBoxMarka.SelectedIndex != 0) // marka seçildiğinde o markaya ait modelleri getir
            {
                getModel();
 
            }
        }

        private void cmbBoxMarkaEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            getModelForEdit(); // güncelleme işlemi için marka seçildiğinde seçilen markanın modellerini getirir
        }

        private void btnIptalEt_Click(object sender, EventArgs e) // iptal et butonuna tıklandığında
        {
            setDisableTextbox();
            dataAraclar.ReadOnly = true;
            btnKaydet.Visible = false;
            btnAracDuzenle.Visible = true;
            dataAraclar.Enabled = true; //datagridviewi aktif eder
            editModeOff(); // Edit için gerekli olan nesneleri gizler.
            btnIptalEt.Visible = false;
            errorProvider.SetError(txtPlakaInfo,""); // hata varsa kaldırır
            errorProvider.SetError(txtYilInfo, ""); // hata varsa kaldırır
            getSelectedCarInfo(); // seçili araç bilgilerini getir
        }

        private void btnAraciSil_Click(object sender, EventArgs e) // araç silme işlemi
        {
            // onay mesajı
            DialogResult result = MessageBox.Show(
                txtPlakaInfo.Text+" Plakalı aracı silmek istediğinize emin misiniz? Bu işlem geri alınamaz.", "Uyarı", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes) // onay verildiyse
            {
                try
                {
                    if (baglanti.State == ConnectionState.Closed)
                    {
                        baglanti.Open();
                    }
                    // PLAKAYA AİT ARAÇ ID ALMA
                    SqlCommand cmdAracId = new SqlCommand("getAracId", baglanti);
                    cmdAracId.CommandType = CommandType.StoredProcedure; //command türü belirleme
                    string plaka = txtPlakaInfo.Text; // id si almak istenilen plaka
                    SqlParameter paramPlaka = new SqlParameter("@paramPlaka", plaka); // parametre oluşturma  
                    paramPlaka.Direction = ParameterDirection.Input; // parametre türünü input ayarlar
                    cmdAracId.Parameters.Add(paramPlaka); // parametre geçme

                    SqlParameter paramAracId = new SqlParameter("@Id", SqlDbType.Int); // parametre oluşturma
                    paramAracId.Direction = ParameterDirection.Output; // parametre türünü outpu olarak belirler
                    cmdAracId.Parameters.Add(paramAracId); //parametre geçme

                    // SqlCommand nesnesini çalıştırma
                    cmdAracId.ExecuteNonQuery();

                    // Çıktı parametresindeki değeri alma
                    int aracId = (int)cmdAracId.Parameters["@Id"].Value;     // ARAÇ ID

                    // ARACI SİL
                    string query = "delete from tblArac where Id = @Id"; // sql sorgu cümlesi
                    SqlCommand cmd = new SqlCommand(query, baglanti); // sqlCommand oluşturma
                    cmd.Parameters.AddWithValue("@Id", aracId); // parametre geçme
                    cmd.ExecuteNonQuery(); // execute işlemi
                    MessageBox.Show(plaka + " Plakalı araç silindi.");
                    getAllCarsData(); // refresh datagridview 
                    lblAracYonetim.Focus(); // focusu textlerden alır
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
        // *** Textbox Placeholder Kodları ***
        private void txtAddPlaka_Enter(object sender, EventArgs e)
        {
            if (txtAddPlaka.Text == "Plaka")
            {
                txtAddPlaka.Text = "";
                txtAddPlaka.ForeColor = Color.Black;
            }
        }

        private void txtAddPlaka_Leave(object sender, EventArgs e)
        {
            if (txtAddPlaka.Text == "")
            {
                txtAddPlaka.Text = "Plaka";
                txtAddPlaka.ForeColor = Color.Gray;
            }
        }

        private void txtAddYil_Enter(object sender, EventArgs e)
        {
            if (txtAddYil.Text == "Yıl")
            {
                txtAddYil.Text = "";
                txtAddYil.ForeColor = Color.Black;
            }
        }

        private void txtAddYil_Leave(object sender, EventArgs e)
        {
            if (txtAddYil.Text == "")
            {
                txtAddYil.Text = "Yıl";
                txtAddYil.ForeColor = Color.Gray;
            }
        }

        // *** Validation ***
        private void txtAddPlaka_Validating(object sender, CancelEventArgs e) 
        {
            if (string.IsNullOrWhiteSpace(txtAddPlaka.Text) || txtAddPlaka.Text == "Plaka")
            {
                errorProvider.SetError(txtAddPlaka, "Lütfen plakayı girin.");
            }
            else
            {
                errorProvider.SetError(txtAddPlaka, null);
            }
        }

        private void cmbBoxMarka_Validating(object sender, CancelEventArgs e)
        {
            if (cmbBoxMarka.SelectedIndex == 0)
            {
                errorProvider.SetError(cmbBoxMarka, "Lütfen eklemek istediğiniz aracın markasını seçin.");
            }
            else
            {
                errorProvider.SetError(cmbBoxMarka, null);
            }
        }

        private void cmbBoxModel_Validating(object sender, CancelEventArgs e)
        {
            if (cmbBoxModel.SelectedIndex == 0)
            {
                errorProvider.SetError(cmbBoxModel, "Lütfen eklemek istediğiniz aracın modelini seçin.");
            }
            else
            {
                errorProvider.SetError(cmbBoxModel, null);
            }
        }

        private void txtAddYil_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAddYil.Text) || txtAddYil.Text == "Yıl")
            {
                errorProvider.SetError(txtAddYil, "Lütfen aracın yılını girin.");
            }
            else
            {
                errorProvider.SetError(txtAddYil, null);
            }
        }

        private void cmbBoxVitesTuru_Validating(object sender, CancelEventArgs e)
        {
            if (cmbBoxVitesTuru.SelectedIndex == 0)
            {
                errorProvider.SetError(cmbBoxVitesTuru, "Lütfen eklemek istediğiniz vites türünü seçin.");
            }
            else
            {
                errorProvider.SetError(cmbBoxVitesTuru, null);
            }
        }

        private void cmbBoxYakitTuru_Validating(object sender, CancelEventArgs e)
        {
            if (cmbBoxYakitTuru.SelectedIndex == 0)
            {
                errorProvider.SetError(cmbBoxYakitTuru, "Lütfen eklemek istediğiniz aracın yakıt türünü seçin.");
            }
            else
            {
                errorProvider.SetError(cmbBoxYakitTuru, null);
            }
        }

        private void cmbBoxSegment_Validating(object sender, CancelEventArgs e)
        {
            if (cmbBoxSegment.SelectedIndex == 0)
            {
                errorProvider.SetError(cmbBoxSegment, "Lütfen eklemek istediğiniz aracın segmentini seçin.");
            }
            else
            {
                errorProvider.SetError(cmbBoxSegment, null);
            }
        }

        private void cmbBoxDurum_Validating(object sender, CancelEventArgs e)
        {
            if (cmbBoxDurum.SelectedIndex == 0)
            {
                errorProvider.SetError(cmbBoxDurum, "Lütfen eklemek istediğiniz aracın görüntülenme durumunu seçin.");
            }
            else
            {
                errorProvider.SetError(cmbBoxDurum, null);
            }
        }

        private void txtPlakaInfo_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPlakaInfo.Text))
            {
                errorProvider.SetError(txtPlakaInfo, "Lütfen aracın plakasını girin.");
            }
            else
            {
                errorProvider.SetError(txtPlakaInfo, null);
            }
        }

        private void txtYilInfo_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtYilInfo.Text))
            {
                errorProvider.SetError(txtYilInfo, "Lütfen aracın plakasını girin.");
            }
            else
            {
                errorProvider.SetError(txtYilInfo, null);
            }
        }

        // Menü butonları

        private void LnkLabelAracKiralamaIslemleri_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) //araç kiralama eknanına geçiş
        {
            this.Hide();
            MainScreen mainScreen = new MainScreen();
            mainScreen.Show();
        }

        private void LnkLabelAracTeslim_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) // araç teslim ekranına geçiş
        {
            this.Hide();
            VehicleDeliveryScreen vehicleDeliveryScreen = new VehicleDeliveryScreen();
            vehicleDeliveryScreen.Show();
        }

        private void LnkLabelCikis_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) // çıkış yap butonu
        {
            //onay mesajı
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
        private void LnkLabelMusteriYonetim_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) // müşteri yönetim ekranına geçiş
        {
            CustomerManagmentScreen customerManagmentScreen = new CustomerManagmentScreen();
            customerManagmentScreen.Show();
            this.Hide();
        }

        private void LnkLabelHesapAyar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) //hesap ayarları ekranına geçiş
        {
            AccountSettingsScreen accountSettingsScreen = new AccountSettingsScreen();
            accountSettingsScreen.Show();
            this.Hide();
        }
    }
}
