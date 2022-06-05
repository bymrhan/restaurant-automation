using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BENDENSINOTOMASYON
{
    public partial class kategori : UserControl
    {
        public kategori()
        {
            InitializeComponent();
        }

        
        private void gunaGradientButton1_Click(object sender, EventArgs e)
        {
            
            this.Visible = false;
            
        }

        private void bunifuPanel1_MouseMove(object sender, MouseEventArgs e)
        {
            bunifuPanel1.BorderColor = Color.Black;
            gunaGradientButton1.Visible = true;
        }
    
        private void btnkahvalti_Click(object sender, EventArgs e)
        {
            Menuurunler m1 = new Menuurunler();
            m1.gelenid = "4";
            m1.Show();
        }

        private void btnhamburger_Click(object sender, EventArgs e)
        {
            Menuurunler m1 = new Menuurunler();
            m1.gelenid = "6";
            m1.Show();
        }

        private void btnsalatalar_Click(object sender, EventArgs e)
        {
            Menuurunler m1 = new Menuurunler();
            m1.gelenid = "1";
            m1.Show();
        }

        private void btnpizza_Click(object sender, EventArgs e)
        {
            Menuurunler m1 = new Menuurunler();
            m1.gelenid = "5";
            m1.Show();
        }

        private void btntatlı_Click(object sender, EventArgs e)
        {
            Menuurunler m1 = new Menuurunler();
            m1.gelenid = "7";
            m1.Show();
        }

        private void btncorba_Click(object sender, EventArgs e)
        {
            Menuurunler m1 = new Menuurunler();
            m1.gelenid = "8";
            m1.Show();
        }

        private void btnicecek_Click(object sender, EventArgs e)
        {
            Menuurunler m1 = new Menuurunler();
            m1.gelenid = "2";
            m1.Show();
        }
    }
}
