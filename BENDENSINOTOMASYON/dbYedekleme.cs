using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Data.OleDb;

namespace BENDENSINOTOMASYON
{
    public partial class dbYedekleme : Form
    {
        static string baglantiyolu = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=restorandb.mdb";
        static OleDbConnection baglanti = new OleDbConnection(baglantiyolu);
        public dbYedekleme()
        {
            
            InitializeComponent();
        }

        private void btnyedekle_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.InitialDirectory = textBox1.Text;
                saveFileDialog1.Title = "Db Kayıt";
                saveFileDialog1.DefaultExt = "mdb";
             
                saveFileDialog1.Filter = "mdb Dosyaları|*.mdb";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {

                    if (System.IO.File.Exists(saveFileDialog1.FileName))
                    {
                        System.IO.File.Delete(saveFileDialog1.FileName);
                    }

                    System.IO.File.Copy(Application.StartupPath.ToString() + "\\restorandb.mdb", saveFileDialog1.FileName);
                    textBox1.Text = saveFileDialog1.FileName;
                    MessageBox.Show("Yedek alma işlemi tamamlandı !");
                    string kaydedilendosyaismi = Path.GetFileNameWithoutExtension(saveFileDialog1.FileName);
                    string kaydedilmetarihi = File.GetLastAccessTime(textBox1.Text).ToString();
                    
                    baglanti.Open();
                    string veri = "insert into Yedekler(yedekadi,yedektarih,yedekyol) values (@ydkadi,@ydktrh,@ydkyol)";
                    OleDbCommand komut = new OleDbCommand(veri, baglanti);
                    komut.Parameters.AddWithValue("@ydkadi", kaydedilendosyaismi);
                    komut.Parameters.AddWithValue("@ydktrh", kaydedilmetarihi);
                    string filename_with_ext = Path.GetFileName(saveFileDialog1.FileName);
                    komut.Parameters.AddWithValue("@ydkyol", @"\Yedekler\" + filename_with_ext);
                    komut.ExecuteNonQuery();                  
                    

                    label1.Text = "Son Başarılı Yedekleme Zamanı  : " + kaydedilmetarihi;
                }
                else
                {
                    MessageBox.Show("Yedekle işlemi iptal edildi !");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            baglanti.Close();

        }

        private void btndizinguncelle_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowNewFolderButton = true;
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = @Application.StartupPath + "\\Yedekler";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (System.IO.File.Exists(Application.StartupPath.ToString() + "\\restorandb.mdb"))
                {
                    System.IO.File.Delete(Application.StartupPath.ToString() + "\\restorandb.mdb");
                }
                System.IO.File.Copy(openFileDialog1.FileName, Application.StartupPath.ToString() + "\\restorandb.mdb");
                MessageBox.Show("Geri yükleme işlemi tamamlandı !");
            }
            else
            {
                MessageBox.Show("Geri yükleme işlemi iptal edildi !");
            }
        }

        private void dbYedekleme_Load(object sender, EventArgs e)
        {

            string sonbasariliyedeklemetarihi;
            baglanti.Open();
            string sorgu = "Select top 1 *From Yedekler ORDER BY yedekid DESC ";
            OleDbCommand komut = new OleDbCommand(sorgu, baglanti);
            OleDbDataReader cikti = komut.ExecuteReader();
            while (cikti.Read())
            {
                sonbasariliyedeklemetarihi = Convert.ToString(cikti["yedektarih"]);
                if (sonbasariliyedeklemetarihi != null)
                {
                    label1.Text = "Son Başarılı Yedekleme Zamanı  : " + sonbasariliyedeklemetarihi;
                    
                }
            }
           
            cikti.Close();
            //combobax a kategorileri çekmek için
            
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter("select * from Yedekler ORDER BY yedekid ASC ", baglanti);
            da.Fill(dt);
            combodbyedek.ValueMember = "yedekyol";
            combodbyedek.DisplayMember = "yedekadi";
            
            combodbyedek.DataSource = dt;
            baglanti.Close();

            if (textBox1.Text != "")
            {
                saveFileDialog1.InitialDirectory = @Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            }
            else
            {
                string yol = @Application.StartupPath + "\\Yedekler";
                textBox1.Text = yol;
                saveFileDialog1.InitialDirectory = yol;
            }
        }

        private void combodbyedek_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }
    }
}
