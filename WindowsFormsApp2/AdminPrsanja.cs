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

namespace WindowsFormsApp2
{
    public partial class AdminPrsanja : Form
    {
        public static string ID1 = "";
        OleDbConnection connection = new OleDbConnection();
        public AdminPrsanja()
        {
            InitializeComponent();
            String path = "\\Database1.accdb";
            String strAbsoluteFilePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).Replace("file:\\", "") + path;
            connection.ConnectionString = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={strAbsoluteFilePath};Persist Security Info=False;";
            button1.TabStop = false;
            button1.FlatStyle = FlatStyle.Flat;
            button1.BackColor = Color.Transparent;
            button1.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button1.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button1.FlatAppearance.BorderSize = 0;
            button4.TabStop = false;
            button4.FlatStyle = FlatStyle.Flat;
            button4.BackColor = Color.Transparent;
            button4.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button4.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button4.FlatAppearance.BorderSize = 0;
            button2.TabStop = false;
            button2.FlatStyle = FlatStyle.Flat;
            button2.BackColor = Color.Transparent;
            button2.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button2.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button2.FlatAppearance.BorderSize = 0;
            button3.TabStop = false;
            button3.FlatStyle = FlatStyle.Flat;
            button3.BackColor = Color.Transparent;
            button3.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button3.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button3.FlatAppearance.BorderSize = 0;
        }

        private void AdminPrsanja_Load(object sender, EventArgs e)
        {
            label1.Text = "Welcome " + Admin.SetValueForText1+"!";
            try
            {
                connection.Open();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.InitialDirectory = "C:\\";
            open.Filter = "Image Files (*.png)|*.png|(*.jpg)|*.jpg|(*.JPEG)|*.JPEG|All Files(*.*)|";


            if (open.ShowDialog() == DialogResult.OK)
            {
                string[] files = open.FileNames;


                String CorrectFileName = System.IO.Path.GetFileName(files[0]);
                label6.Text = "Image name: "+CorrectFileName;
                try
                {
                    connection.Open();
                    String query = "INSERT INTO Prasanja (picture1) VALUES ('\\Pictures\\" + CorrectFileName + "')";
                    OleDbCommand a = new OleDbCommand(query, connection);
                    a.ExecuteNonQuery();
                    String query1 = "SELECT id From Prasanja Where picture1='\\Pictures\\" + CorrectFileName + "'";
                    OleDbCommand b = new OleDbCommand(query1, connection);
                    OleDbDataAdapter adapter = new OleDbDataAdapter(b);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    ID1 = dt.Rows[0]["id"].ToString();



                    connection.Close();
                }
                catch (Exception b)
                {
                    MessageBox.Show("Error:" + b);
                }


                String strAbsoluteFilePath1 = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).Replace("file:\\", "");

                System.IO.File.Copy(files[0], strAbsoluteFilePath1 + "\\Pictures\\" + CorrectFileName);
                MessageBox.Show("Upload successful");

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog open = new OpenFileDialog();
                open.InitialDirectory = "C:\\";
                open.Filter = "Image Files (*.png)|*.png|(*.jpg)|*.jpg|(*.JPEG)|*.JPEG|All Files(*.*)|";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    String CorrectFileName = System.IO.Path.GetFileName(open.FileName);
                    label8.Text = "Corrent answer: " + CorrectFileName;
                    connection.Open();
                    string query = "Update Prasanja set tocna ='\\Pictures\\"+CorrectFileName+"' WHERE id = @ID1";
                    OleDbCommand a = new OleDbCommand(query, connection);
                    a.Parameters.AddWithValue("@ID", ID1);
                    a.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Upload successful");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                String query1 = "Update Prasanja set bodovi = @bodovi Where id = @ID1 ";
                OleDbCommand a = new OleDbCommand(query1, connection);
                a.Parameters.AddWithValue("@bodovi", Bodovi.Text);
                a.Parameters.AddWithValue("@ID", ID1);
                a.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Sucessfully saved");

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.InitialDirectory = "C:\\";
            open.Filter = "Image Files (*.png)|*.png|(*.jpg)|*.jpg|(*.JPEG)|*.JPEG|All Files(*.*)|";
            open.Multiselect = true;

            if (open.ShowDialog() == DialogResult.OK)
            {
                string[] files = open.FileNames;


                String CorrectFileName = System.IO.Path.GetFileName(files[0]);
                String CorrectFileName1 = System.IO.Path.GetFileName(files[1]);
                String CorrectFileName2 = System.IO.Path.GetFileName(files[2]);
                String CorrectFileName3 = System.IO.Path.GetFileName(files[3]);
                String CorrectFileName4 = System.IO.Path.GetFileName(files[4]);
                String CorrectFileName5 = System.IO.Path.GetFileName(files[5]);
                label7.Text = "Answers : " + CorrectFileName+","+CorrectFileName1+"," +CorrectFileName2 + "," + CorrectFileName3 + "," + CorrectFileName4 + "," + CorrectFileName5;
                try
                {
                    connection.Open();
                    String query = "Update Prasanja set odgovor1='\\Pictures\\" + CorrectFileName + "',odgovor2='\\Pictures\\" + CorrectFileName1 + "',odgovor3='\\Pictures\\" + CorrectFileName2 + "',odgovor4='\\Pictures\\" + CorrectFileName3 + "',odgovor5='\\Pictures\\" + CorrectFileName4 + "',odgovor6='\\Pictures\\" + CorrectFileName5 + "' WHERE id = @ID";
                    OleDbCommand a = new OleDbCommand(query, connection);
                    a.Parameters.AddWithValue("@ID", ID1);
                    a.ExecuteNonQuery();
                    connection.Close();
                   
                }
                catch (Exception b)
                {
                    MessageBox.Show("Error:" + b);
                }


                String strAbsoluteFilePath1 = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).Replace("file:\\", "");

                System.IO.File.Copy(files[0], strAbsoluteFilePath1 + "\\Pictures\\" + CorrectFileName);
                System.IO.File.Copy(files[1], strAbsoluteFilePath1 + "\\Pictures\\" + CorrectFileName1);
                System.IO.File.Copy(files[2], strAbsoluteFilePath1 + "\\Pictures\\" + CorrectFileName2);
                System.IO.File.Copy(files[3], strAbsoluteFilePath1 + "\\Pictures\\" + CorrectFileName3);
                System.IO.File.Copy(files[4], strAbsoluteFilePath1 + "\\Pictures\\" + CorrectFileName4);
                System.IO.File.Copy(files[5], strAbsoluteFilePath1 + "\\Pictures\\" + CorrectFileName5);
                MessageBox.Show("Upload successful");

            }
        }

        private void Bodovi_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
