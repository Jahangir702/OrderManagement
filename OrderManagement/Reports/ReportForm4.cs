using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderManagement.Reports
{
    public partial class ReportForm4 : Form
    {
        public ReportForm4()
        {
            InitializeComponent();
        }

        private void ReportForm4_Load(object sender, EventArgs e)
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
                    Report4 rpt= new Report4();
                    rpt.SetDataSource(ds);
                    this.crystalReportViewer1.ReportSource= rpt;
                    this.crystalReportViewer1.Refresh();
                }
            }
        }
    }
}
