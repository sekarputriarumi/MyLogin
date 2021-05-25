using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MyLogin
{
    public partial class Form2 : Form
    {
        SqlConnection con = new SqlConnection(@"Integrated Security=true; Data Source=LAPTOP-2F1SV60V\MSSQLSERVER01; Initial Catalog=MyPractice");
        public Form2()
        {
            InitializeComponent();
        }
        DataClasses2DataContext db = new DataClasses2DataContext();

        private void Form2_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select isnull (max (cast (ID as int)), 0) + 1 from TB_M_Product", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            txtProductID.Text = dt.Rows[0][0].ToString();
            LoadData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var st = from s in db.TB_M_PRODUCTs where s.itemName == txtItem1.Text || s.design == txtDesign1.Text select s;
            dataGridView1.DataSource = st;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtProductID.Text);
            string item = txtItem2.Text;
            string design = txtDesign2.Text;
            string color = txtColor.Text;
            DateTime expiredDate = DateTime.Parse(dtExpendDate.Text);

            var data = new TB_M_PRODUCT
            {
                ID = id,
                itemName = item,
                color = color,
                design = design,
                expiredDate = expiredDate
            };
            db.TB_M_PRODUCTs.InsertOnSubmit(data);
            db.SubmitChanges();
            MessageBox.Show("Save Successfully");
            txtDesign2.Clear();
            txtItem2.Clear();
            txtColor.Clear();
            LoadData();
        }

        void LoadData()
        {
            var st = from tb in db.TB_M_PRODUCTs select tb;
            dataGridView1.DataSource = st;
        }
    }
}
