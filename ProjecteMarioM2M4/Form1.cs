using ProjecteMarioM2M4.Database;
using ProjecteMarioM2M4.Model;
using System;
using System.Windows.Forms;

namespace ProjecteMarioM2M4
{
    public partial class Form1 : Form
    {
        private DatabaseConnection dbConnection;
        private string connectionString;

        public Form1()
        {
            InitializeComponent();
            const string server = "db4free.net";
            const string port = "3306";
            const string database = "esports";
            const string username = "mariomunteanu";
            const string password = "Mario123";
            connectionString = $"Server={server};Port={port};Database={database};Uid={username};Pwd={password};OldGuids=true;";
            dbConnection = new DatabaseConnection(connectionString);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void onClick(object sender, EventArgs e)
        {
            button1.Enabled = false;
            openFileDialog.Filter = "File XML (*.xml)|*.xml";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog.FileName;

                if (dbConnection.OpenConnection())
                {
                    bool success = EsportsManager.CarregarModel(textBox1.Text, dbConnection);

                    dbConnection.CloseConnection();

                    if (success)
                    {
                        MessageBox.Show("Data loaded successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Failed to load data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Unable to establish a connection to the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                button1.Enabled = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}