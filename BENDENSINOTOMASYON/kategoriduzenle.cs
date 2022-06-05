using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace BENDENSINOTOMASYON
{
    public partial class kategoriduzenle : Form
    {
        static string baglantiyolu = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=restorandb.mdb";
        static OleDbConnection baglanti = new OleDbConnection(baglantiyolu);
        public kategoriduzenle()
        {
            InitializeComponent();
        }

        private void kategoriduzenle_Load(object sender, EventArgs e)
        {
            combolistele();
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            if (comboGruplar.Text == "" || txtDuzenlenenAd.Text == "")
            {
                if (txtDuzenlenenAd.Text == "")
                {
                    MessageBox.Show("Lütfen Boş Bırakmayınız!");
                }
                if (comboGruplar.Text == "")
                {
                    MessageBox.Show("Lütfen Grup Seçiniz.");
                }
            }
            else
            {
                bool durum = grupkontrol(txtDuzenlenenAd.Text);

                if (durum == true)
                {
                    lblBildirim.Visible = true;
                    lblBildirim.Text = "Böyle bir grup vardır.";
                }
                else
                {
                    try
                    {
                        //baglantikontrol();
                        baglanti.Open();
                        string veri = "update urunkategori set kategori = @ktgri where id = " + comboGruplar.SelectedValue;
                        OleDbCommand komut = new OleDbCommand(veri, baglanti);
                        komut.Parameters.AddWithValue("@kategori", txtDuzenlenenAd.Text);
                        komut.ExecuteNonQuery();
                        baglanti.Close();
                        durum = true;
                    }
                    catch 
                    {
                        durum = false;
                    }
                    if (durum == true)
                    {
                        lblBildirim.Visible = true;
                        txtDuzenlenenAd.Clear();
                        lblBildirim.ForeColor = Color.Green;
                        lblBildirim.Text = "Grup Başarılıyla Düzenlenmiştir.";
                    }
                    else if (durum == false)
                    {
                        lblBildirim.Visible = true;
                        txtDuzenlenenAd.Clear();
                        lblBildirim.ForeColor = Color.Green;
                        lblBildirim.Text = "Grup Düzenlenirken Hata Meydana Geldi.";
                    }
                    combolistele();
                }

            }
        }

        int kid;
        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (txtAdi.Text == "")
            {
                MessageBox.Show("Ürün Adını Boş Bırakmayınız!");
            }
            else
            {
                bool durum = grupkontrol(txtAdi.Text);
                if (durum == true)
                {
                    lblBildirim.Visible = true;
                    lblBildirim.Text = "Böyle bir grup vardır.";
                }
                else
                {
                    try
                    {
                        //baglantikontrol();
                        baglanti.Open();

                        string sorgu = "SELECT TOP 1 * FROM urunkategori ORDER By id DESC";
                        OleDbCommand komut = new OleDbCommand(sorgu, baglanti);
                        OleDbDataReader cikti = komut.ExecuteReader();
                        while (cikti.Read())
                        {
                            kid = Convert.ToInt32(cikti["id"]);
                            kid++;
                        }
                        cikti.Close();
                        string veri = "insert into urunkategori(id,kategori) values (@id,@ktgori)";
                    OleDbCommand komut1 = new OleDbCommand(veri, baglanti);
                    komut1.Parameters.AddWithValue("@id",kid);
                    komut1.Parameters.AddWithValue("@ktgori", txtAdi.Text);
                    komut1.ExecuteNonQuery();                               
                    baglanti.Close();
                     durum = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                        durum = false;
                    }

                    if (durum == true)
                    {
                        lblBildirim.Visible = true;
                        txtAdi.Clear();
                        lblBildirim.ForeColor = Color.Green;
                        lblBildirim.Text = "Grup Oluşturuldu.";
                    }
                    else if (durum == false)
                    {
                        lblBildirim.Visible = true;
                        txtAdi.Clear();
                        lblBildirim.ForeColor = Color.Red;
                        lblBildirim.Text = "Grup Oluştururken Hata Meydana Geldi.";
                    }
                    combolistele();
                }

            }

        }

        public bool grupkontrol(object grupadi)
        {
            //baglantikontrol();
            baglanti.Open();
            string sorgu = "Select *From urunkategori where kategori='" + grupadi +  "'";
            OleDbCommand komut = new OleDbCommand(sorgu, baglanti);
            OleDbDataReader cikti = komut.ExecuteReader();
            if (cikti.Read())
            {
                return  true;
            }
            else
            {
                return  false;
            }
            cikti.Close();
            baglanti.Close();          
        }

        void combolistele()
        {
            //combobax a kategorileri çekmek için
            //baglantikontrol();
            baglanti.Open();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter("select * from urunkategori ORDER BY id ASC ", baglanti);
            da.Fill(dt);
            comboGruplar.ValueMember = "id";
            comboGruplar.DisplayMember = "kategori";
            comboGruplar.DataSource = dt;
            baglanti.Close();
        }
        //void baglantikontrol()
        //{
        //    if (baglanti.State == ConnectionState.Closed)
        //    {
        //        try
        //        {
        //            baglanti.Open();
        //        }
        //        catch
        //        {
        //            MessageBox.Show("Veri Tabanı Bağlantısı Yapılamadı");
        //            Application.Exit();
        //        }
        //    }
        //}

        private void btnsil_Click(object sender, EventArgs e)
        {
            DialogResult c;
            c = MessageBox.Show("Silmek istediğinizden emin misiniz?", "Uyarı!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (c == DialogResult.Yes)
            {
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand();
                komut.Connection = baglanti;
                string secilenid = comboGruplar.SelectedValue.ToString();
                komut.CommandText = "Delete from urunkategori where id=" + secilenid + "";              
                komut.ExecuteNonQuery();
                komut.Dispose();
                baglanti.Close();
                
                lblBildirim.Visible = true;             
                lblBildirim.ForeColor = Color.Red;
                lblBildirim.Text = "Grup silindi !!";
                combolistele();
            }
        }
    }
}
