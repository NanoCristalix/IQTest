using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
namespace WindowsFormsApp2
{
    public partial class Mail : Form
    {
        public Mail()
        {
            InitializeComponent();
            button1.TabStop = false;
            button1.FlatStyle = FlatStyle.Flat;
            button1.BackColor = Color.Transparent;
            button1.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button1.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button1.FlatAppearance.BorderSize = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {


                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                int bodovi = IQTEST.poeni;
                string vreme = IQTEST.vreme;
                mail.From = new MailAddress("iqtestodgovor@gmail.com");
                string email = textBox1.Text;
                mail.To.Add(email);
                mail.Subject = "IQ TEST POINTS";
                mail.IsBodyHtml = true;
                mail.Body = "Your IQ points are: "+bodovi+ "<br />" + vreme;

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("iqtestodgovor@gmail.com", "nenad123");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                MessageBox.Show("The results have been sent to your email");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            Application.Exit();
        }

        private void Mail_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 a = new Form1();
            a.Close();
            System.Windows.Forms.Application.Exit();
        }

        private void Mail_Load(object sender, EventArgs e)
        {

        }
    }
}
