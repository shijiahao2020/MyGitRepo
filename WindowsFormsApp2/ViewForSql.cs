using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using WindowsFormsApp2.data;

namespace WindowsFormsApp2
{
    public partial class ViewForSql : Form
    {

        string connectStr = "server=127.0.0.1;port=3306;user=root;password=199711;database=metrodataprocess;";
        public ViewForSql()
        {
            InitializeComponent();
            Adapt();
            ConnectView();

        }

        private void ViewForSql_Load(object sender, EventArgs e)
        {
            
        }
        public void Adapt()
        {
            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            int width = 0;
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

        public void ConnectView()
        {
            MySqlConnection conn = new MySqlConnection(connectStr);
            try
            {
                conn.Open();
                MessageBox.Show("已经建立连接");
                string sqlCmd = "select * from inclinometer";
                MySqlCommand cmd = new MySqlCommand(sqlCmd, conn);
                MySqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    int index = this.dataGridView1.Rows.Add();
                    this.dataGridView1.Rows[index].Cells[0].Value = reader.GetString("区号");
                    this.dataGridView1.Rows[index].Cells[1].Value = reader.GetString("孔号");
                    this.dataGridView1.Rows[index].Cells[2].Value = reader.GetString("孔深");
                    this.dataGridView1.Rows[index].Cells[3].Value = reader.GetString("组号");
                    this.dataGridView1.Rows[index].Cells[4].Value = reader.GetString("正反测");
                    this.dataGridView1.Rows[index].Cells[5].Value = reader.GetString("最大孔深");
                    this.dataGridView1.Rows[index].Cells[6].Value = reader.GetString("电压");
                    this.dataGridView1.Rows[index].Cells[7].Value = reader.GetString("位移");
                    this.dataGridView1.Rows[index].Cells[8].Value = reader.GetString("时间");
                }
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























//try
//{
//    conn.Open();
//    MessageBox.Show("已经建立连接");

//    string sqlCmd = "select * from student";
//    MySqlCommand cmd = new MySqlCommand(sqlCmd, conn);

//    MySqlDataReader reader = cmd.ExecuteReader();


//    while (reader.Read())
//    {
//        int index = this.dataGridView1.Rows.Add();
//        this.dataGridView1.Rows[index].Cells[0].Value = reader.GetString("name");
//        this.dataGridView1.Rows[index].Cells[1].Value = reader.GetString("describe");
//        this.dataGridView1.Rows[index].Cells[2].Value = reader.GetString("price");
//        this.dataGridView1.Rows[index].Cells[3].Value = reader.GetString("salenumber");
//    }
//}
//catch (MySqlException ex)
//{
//    Console.WriteLine(ex.Message);
//}
//finally
//{
//    conn.Close();
//}