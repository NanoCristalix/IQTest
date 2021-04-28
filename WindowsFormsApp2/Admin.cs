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
using System.Threading;

namespace WindowsFormsApp2
{
    
    public partial class Admin : Form
    {
        Thread th;
        public static string SetValueForText1 = "";
        OleDbConnection connection = new OleDbConnection();
        public Admin()
        {
            InitializeComponent();
            Login.TabStop = false;
            Login.FlatStyle = FlatStyle.Flat;
            Login.BackColor = Color.Transparent;
            Login.FlatAppearance.MouseDownBackColor = Color.Transparent;
            Login.FlatAppearance.MouseOverBackColor = Color.Transparent;
            Login.FlatAppearance.BorderSize = 0;
            button1.TabStop = false;
            button1.FlatStyle = FlatStyle.Flat;
            button1.BackColor = Color.Transparent;
            button1.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button1.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button1.FlatAppearance.BorderSize = 0;

            String path = "\\Database1.accdb";
            String strAbsoluteFilePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).Replace("file:\\", "") + path;
            connection.ConnectionString = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={strAbsoluteFilePath};Persist Security Info=False;";
        }

        private void Login_Click(object sender, EventArgs e)
        {
            
            string query = "SELECT* From Login Where Username=@Username and Password=@Password";
            OleDbCommand a = new OleDbCommand(query, connection);
            a.Parameters.AddWithValue("Username", username.Text);
            a.Parameters.AddWithValue("Username", password.Text);
            connection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(a);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            if(dt.Rows.Count ==1)
            {
                MessageBox.Show("Login Sucess");
                SetValueForText1 = username.Text;
                this.Close();
                th = new Thread(opennewform);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();


            }
            else
            {
                MessageBox.Show("Login fail");
            }
            connection.Close();





        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
           
        }

        public void opennewform(object obj)
        {
            Application.Run(new AdminPrsanja());
        }

        private void Admin_Load(object sender, EventArgs e)
        {

        }
    }
}
