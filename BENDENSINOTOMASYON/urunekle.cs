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
    public partial class urunekle : Form
    {
        public string gelenid = null;
        static string baglantiyolu = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=restorandb.mdb";
        static OleDbConnection baglanti = new OleDbConnection(baglantiyolu);        
        OleDbCommand cmd = new OleDbCommand();
        public urunekle()
        {
            InitializeComponent();
        }

        private void urunekle_Load(object sender, EventArgs e)
        {
            //combobax a kategorileri çekmek için
            baglanti.Open();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter("select * from urunkategori ORDER BY id ASC ", baglanti); //id leri artana göre çeker
            da.Fill(dt);
            combourungrup.ValueMember = "id";
            combourungrup.DisplayMember = "kategori";
            combourungrup.DataSource = dt;

            if (gelenid != null) //gelenid var null değilse yani bir değer geldiyse if içindeki işlemleri yapar 
            {
                this.Text = "Ürün Düzenle"; // bu formun adını "Ürün Düzenle" yap
                //gelen id ye göre verileri çekmek için
                button1.Visible = false;
                btnguncelle.Visible = true;
                OleDbCommand verioku = new OleDbCommand("select * from urun where urunid = " + gelenid + "", baglanti);
                verioku.ExecuteNonQuery();
                OleDbDataReader oku;
                oku = verioku.ExecuteReader();
                while (oku.Read())
                {
                    
                    try  // resim almaz ise hatayı yakalama
                    {
                        txturunadi.Text = oku["adi"].ToString();
                        txturunfiyati.Text = oku["fiyati"].ToString();
                        bunifuImageButton1.Image = new Bitmap(Application.StartupPath + oku["resim"].ToString());
                        combourungrup.SelectedValue = Convert.ToInt32(oku["kategori"]);
                        txtresimyolu.Text = oku["resim"].ToString();
                        txtcalori.Text = oku["calori"].ToString();
                        txtaciklama.Text = oku["aciklama"].ToString();
                    }
                    catch (System.NotSupportedException ArgumentException)
                    {

                      
                    }
                    
                }
                oku.Close();
                             
            }
            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ürün ekleme komutu
                        baglanti.Open();
                        string veri = "insert into urun(adi,fiyati,kategori,resim,calori,aciklama) values (@adı,@fyt,@grpid,@rsm,@clr,@ack)";
                        OleDbCommand komut = new OleDbCommand(veri, baglanti);
                        komut.Parameters.AddWithValue("@adı", txturunadi.Text);
                        komut.Parameters.AddWithValue("@fyt", txturunfiyati.Text);
                        komut.Parameters.AddWithValue("@grpid", combourungrup.SelectedValue);
                        komut.Parameters.AddWithValue("@rsm", txtresimyolu.Text);
                        komut.Parameters.AddWithValue("@clr", txtcalori.Text);
                        komut.Parameters.AddWithValue("@ack", txtaciklama.Text);
                        komut.ExecuteNonQuery();
                        MessageBox.Show("Veri Başarıyla Eklendi.");
                        baglanti.Close();
                
            
        }

        private void btnresimsec_Click(object sender, EventArgs e)
        {
            resimsec();
        }

        private void urunekle_FormClosed(object sender, FormClosedEventArgs e)
        {
            baglanti.Close();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            resimsec();
        }

        public void resimsec()
        {
            openFileDialog1.Title = "Resimi Seçiniz"; //diolog başlık
            openFileDialog1.Filter = "Tümü|*.png;*.jpg;*ico;*.gif|png|*.png|jpeg|*.jpg|icon|*ico|gif|*.gif"; //diolog tür
            openFileDialog1.DefaultExt = "jpg"; //varsayılan diolog tür *** bidaha bak
            openFileDialog1.RestoreDirectory = true; //En son hangi klasörden dosya çekildiyse o klasöre odaklanacaktır
            openFileDialog1.FileName = ""; //diolog dosya adı
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                System.IO.File.Copy(@openFileDialog1.FileName, Application.StartupPath + @"\img\" + openFileDialog1.SafeFileName);
                txtresimyolu.Text = @"\img\" + openFileDialog1.SafeFileName; // resimin yolu ve adını yazdırıyorum 
                bunifuImageButton1.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }
        void guncelle()
        {
            baglanti.Open();
            
            string veri = "update urun set adi = @adi, fiyati = @fyt, kategori = @grpid, resim = @rsm, calori = @clr, aciklama = @ack where urunid = "+gelenid;
            OleDbCommand komut = new OleDbCommand(veri, baglanti);
            komut.Parameters.AddWithValue("@adi", txturunadi.Text);
            komut.Parameters.AddWithValue("@fyt", txturunfiyati.Text);
            komut.Parameters.AddWithValue("@grpid", combourungrup.SelectedValue);
            komut.Parameters.AddWithValue("@rsm", txtresimyolu.Text);
            komut.Parameters.AddWithValue("@clr", txtcalori.Text);
            komut.Parameters.AddWithValue("@ack", txtaciklama.Text);
            komut.ExecuteNonQuery();
            MessageBox.Show("Veri Başarıyla Güncellendi.");
            baglanti.Close();
        }       

        private void btnguncelle_Click(object sender, EventArgs e) //güncelle
        {
            guncelle();
        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            kategoriduzenle ekle = new kategoriduzenle();
            ekle.Show();
        }
    }
    }

