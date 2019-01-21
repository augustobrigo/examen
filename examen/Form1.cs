using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace examen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conexion = new MySqlConnection();
           conexion.ConnectionString = "server=johnny.heliohost.org;port=3306;" +
             "dataBase=profedi_examen;user=profedi_alumno;pwd=12345678";
            /*conexion.ConnectionString = "Server=sql7.freemysqlhosting.net;Port=3306;" +
          "DataBase=sql7261478;user=sql7261478;Pwd=b3xbpjVN6V";*/
            OpenFileDialog dialogo = new OpenFileDialog();
            dialogo.Title = "Exportar Base de datos medicamentos";
            dialogo.Filter = "Ficheros SQL | *.sql";
            dialogo.InitialDirectory = @"C:\Users\avanza\Desktop";
            if (dialogo.ShowDialog() == DialogResult.OK)
            {
                using (MySqlConnection conn = new MySqlConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        using (MySqlBackup mb = new MySqlBackup(cmd))
                        {
                            cmd.Connection = conexion;
                            conexion.Open();
                            mb.ImportFromFile(dialogo.FileName.ToString());
                            conexion.Close();
                        }
                    }
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlConnection conexion = new MySqlConnection();
            conexion.ConnectionString = "server=localhost;port=3306;" +
              "dataBase=augustobriga;user=root;pwd=''";
            /*conexion.ConnectionString = "Server=sql7.freemysqlhosting.net;Port=3306;" +
          "DataBase=sql7261478;user=sql7261478;Pwd=b3xbpjVN6V";*/
            OpenFileDialog dialogo = new OpenFileDialog();
            dialogo.Title = "Exportar Base de datos medicamentos";
            dialogo.Filter = "Ficheros SQL | *.sql";
            dialogo.InitialDirectory = @"C:\Users\avanza\Desktop";
            if (dialogo.ShowDialog() == DialogResult.OK)
            {
                using (MySqlConnection conn = new MySqlConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        using (MySqlBackup mb = new MySqlBackup(cmd))
                        {
                            cmd.Connection = conexion;
                            conexion.Open();
                            mb.ExportToFile(dialogo.FileName.ToString());
                            conexion.Close();
                        }
                    }
                }
            }

        }
    }
    }


