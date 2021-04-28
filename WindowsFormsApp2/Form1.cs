using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        Thread th;
        public Form1()
        {
            InitializeComponent();
            label1.BackColor = System.Drawing.Color.Transparent;
            label3.BackColor = System.Drawing.Color.Transparent;
            label4.BackColor = System.Drawing.Color.Transparent;
            Admin.TabStop = false;
            Admin.FlatStyle = FlatStyle.Flat;
            Admin.BackColor = Color.Transparent;
            Admin.FlatAppearance.MouseDownBackColor = Color.Transparent;
            Admin.FlatAppearance.MouseOverBackColor = Color.Transparent;
            Admin.FlatAppearance.BorderSize = 0;
            button1.TabStop = false;
            button1.FlatStyle = FlatStyle.Flat;
            button1.BackColor = Color.Transparent;
            button1.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button1.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button1.FlatAppearance.BorderSize = 0;
        }

        private void Admin_Click(object sender, EventArgs e)
        {
            this.Close();
            th = new Thread(opennewform);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            th = new Thread(opennewform1);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();

        }
        public void opennewform(object obj)
        {
            Application.Run(new Admin());
        }

        public void opennewform1(object obj)
        {
            Application.Run(new Korisnik());
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
