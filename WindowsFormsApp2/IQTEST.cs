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
using System.Linq;
using System.Threading;

namespace WindowsFormsApp2
{
    public partial class IQTEST : Form
    {
        OleDbConnection connection = new OleDbConnection();
        public static int id=0;
        DataTable dt1 = new DataTable();
        public static int poeni = 0;
        public static int prasanje = 0;
        public static int odgovor = 0;
        int[] lista = new int[40];
        private System.Windows.Forms.Timer timer;
        private int elapsedSeconds;
        public static string vreme;
        private static Random rng = new Random();
        private Thread th;

        public IQTEST()
        {
            
            InitializeComponent();
            String path = "\\Database1.accdb";
            String strAbsoluteFilePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).Replace("file:\\", "") + path;
            connection.ConnectionString = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={strAbsoluteFilePath};Persist Security Info=False;";
           
        }

        private void IQTEST_Load(object sender, EventArgs e)
        {
            try
            {
                

                lista = Enumerable.Range(1,40).OrderBy(X => rng.Next()).ToArray();
                IQTest();
                timer = new System.Windows.Forms.Timer
                {

                    Interval = 1000,
                    Enabled = true

                };
                 timer.Tick += (sender1, args) =>
                {
                    elapsedSeconds++;
                    TimeSpan time = TimeSpan.FromSeconds(elapsedSeconds);
                    label6.Text = "Time: "+time.ToString(@"hh\:mm\:ss");
                };
                
                
                


            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }

        }


        public void IQTest()
        {
            
            prasanje += 1;
            odgovor += 1;
            label3.Text ="Question: "+prasanje.ToString()+" from "+"40";
            label9.Text = "Answer: " + odgovor.ToString()+" from " + "40";
            connection.Open();
            String path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).Replace("file:\\", "");
            OleDbCommand command = new OleDbCommand("SELECT * From Prasanja Where id = @ID", connection);
            command.Parameters.AddWithValue("@ID", lista[id]);
            OleDbDataAdapter adapter = new OleDbDataAdapter(command);
            adapter.Fill(dt1);
            pictureBox1.Image = Image.FromFile(path + dt1.Rows[0]["picture1"].ToString());
            pictureBox7.Image = Image.FromFile(path + dt1.Rows[0]["odgovor1"].ToString());
            pictureBox8.Image = Image.FromFile(path + dt1.Rows[0]["odgovor2"].ToString());
            pictureBox9.Image = Image.FromFile(path + dt1.Rows[0]["odgovor3"].ToString());
            pictureBox10.Image = Image.FromFile(path + dt1.Rows[0]["odgovor4"].ToString());
            pictureBox11.Image = Image.FromFile(path + dt1.Rows[0]["odgovor5"].ToString());
            pictureBox12.Image = Image.FromFile(path + dt1.Rows[0]["odgovor6"].ToString());
            
            connection.Close();
            id = id + 1;
            
            

        }

        public void randomid()
        {
            


        }

       

        private void label4_Click(object sender, EventArgs e)
        {

        }

        public bool checkPrasanje()
        {
            if(prasanje==40)
            {
                timer.Stop();
                vreme = label6.Text;
                MessageBox.Show("Finish");
                this.Close();
                th = new Thread(opennewform);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
                return true;

                
            }

            return false;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            proveri1();
            if (!checkPrasanje())
            {
                dt1.Rows.Clear();
                dt1.Clear();

                IQTest();
            }

        }

        public void proveri4()
        {
            string a1 = "";
            string tocenodgovor = "";
            int bodovi = 0;
            tocenodgovor = dt1.Rows[0]["tocna"].ToString();
            a1 = dt1.Rows[0]["odgovor4"].ToString();
            bodovi = Int32.Parse(dt1.Rows[0]["bodovi"].ToString());
            if (tocenodgovor.Equals(a1))
            {
                poeni += bodovi;
                

            }

        }
        public void proveri1()
        {
            string a1 = "";
            string tocenodgovor = "";
            int bodovi = 0;
            tocenodgovor = dt1.Rows[0]["tocna"].ToString();
            a1 = dt1.Rows[0]["odgovor1"].ToString();
            bodovi = Int32.Parse(dt1.Rows[0]["bodovi"].ToString());
            if (tocenodgovor.Equals(a1))
            {
                poeni += bodovi;
                

            }

        }
        public void proveri3()
        {
            string a1 = "";
            string tocenodgovor = "";
            int bodovi = 0;
            tocenodgovor = dt1.Rows[0]["tocna"].ToString();
            a1 = dt1.Rows[0]["odgovor3"].ToString();
            bodovi = Int32.Parse(dt1.Rows[0]["bodovi"].ToString());
            if (tocenodgovor.Equals(a1))
            {
                poeni += bodovi;
                

            }

        }
        public void proveri2()
        {
            string a1 = "";
            string tocenodgovor = "";
            int bodovi = 0;
            tocenodgovor = dt1.Rows[0]["tocna"].ToString();
            a1 = dt1.Rows[0]["odgovor2"].ToString();
            bodovi = Int32.Parse(dt1.Rows[0]["bodovi"].ToString());
            if (tocenodgovor.Equals(a1))
            {
                poeni += bodovi;
                

            }

        }
        public void proveri5()
        {
            string a1 = "";
            string tocenodgovor = "";
            int bodovi = 0;
            tocenodgovor = dt1.Rows[0]["tocna"].ToString();
            a1 = dt1.Rows[0]["odgovor5"].ToString();
            bodovi = Int32.Parse(dt1.Rows[0]["bodovi"].ToString());
            if (tocenodgovor.Equals(a1))
            {
                poeni += bodovi;
                

            }

        }
        public void proveri6()
        {
            string a1 = "";
            string tocenodgovor = "";
            int bodovi = 0;
            tocenodgovor = dt1.Rows[0]["tocna"].ToString();
            a1 = dt1.Rows[0]["odgovor6"].ToString();
            bodovi = Int32.Parse(dt1.Rows[0]["bodovi"].ToString());
            if (tocenodgovor.Equals(a1))
            {
                poeni += bodovi;
                

            }

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            proveri4();
            if (!checkPrasanje())
            {
                dt1.Rows.Clear();
                dt1.Clear();

                IQTest();
            }
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            proveri3();
            if (!checkPrasanje())
            {
                dt1.Rows.Clear();
                dt1.Clear();

                IQTest();
            }
            
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            proveri2();
            if (!checkPrasanje())
            {
                dt1.Rows.Clear();
                dt1.Clear();

                IQTest();
            }
        }


        private void pictureBox11_Click(object sender, EventArgs e)
        {
            proveri5();
            if (!checkPrasanje())
            {
                dt1.Rows.Clear();
                dt1.Clear();

                IQTest();
            }
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            proveri6();
            if (!checkPrasanje())
            {
                dt1.Rows.Clear();
                dt1.Clear();

                IQTest();
            }
        }
        public void opennewform(object obj)
        {
            Application.Run(new Mail());
        }



    }
}
