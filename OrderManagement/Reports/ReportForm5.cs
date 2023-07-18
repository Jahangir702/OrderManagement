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

namespace OrderManagement.Reports
{
    public partial class ReportForm5 : Form
    {
        public ReportForm5()
        {
            InitializeComponent();
        }

        private void ReportForm5_Load(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Products", con))
                {
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Products");
                    da.SelectCommand.CommandText = "SELECT * FROM Customers";
                    da.Fill(ds, "Customers");
                    da.SelectCommand.CommandText = "SELECT * FROM Orders";
                    da.Fill(ds, "Orders");
                    da.SelectCommand.CommandText = "SELECT * FROM OrderItems";
                    da.Fill(ds, "OrderItems");
                    CrystalReport1 rpt = new CrystalReport1();
                    rpt.SetDataSource(ds);
                    this.crystalReportViewer1.ReportSource = rpt;
                    this.crystalReportViewer1.Refresh();
                }
            }
        }
    }
}
