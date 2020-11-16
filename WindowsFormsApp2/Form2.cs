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

namespace WindowsFormsApp2
{
    public partial class Form2 : Form
    {
        string connectStr = "server=127.0.0.1;port=3306;user=root;password=199711;database=metrodataprocess;";
        public Form2()
        {
            InitializeComponent();
            AutoConnectView();
            Adapt();
            //AutoSizeColumn(dataGridView1);
        }

        

        public void Adapt()
        {
            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            int width = 0;  //整个view的宽度
            //dataGridView.col
            for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
            {
                this.dataGridView1.AutoResizeColumn(i, DataGridViewAutoSizeColumnMode.AllCells);
                width += this.dataGridView1.Columns[i].Width;
            }
            if (width > this.dataGridView1.Size.Width)
            {
                this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            }
            else
            {
                this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            //dataGridView1.Columns[1].Frozen = true;

        }

        public void AutoConnectView()
        {
            MySqlConnection conn = new MySqlConnection(connectStr);
            try
            {
                conn.Open();
                MessageBox.Show("已经建立连接");
                string sqlCmd = "select * from inclinometer";
                MySqlCommand cmd = new MySqlCommand(sqlCmd, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                BindingSource bs = new BindingSource();
                bs.DataSource = reader;
                this.dataGridView1.DataSource = bs;

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

    }
}
