using Microsoft.Reporting;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ReportView
{
    public partial class Default : System.Web.UI.Page
    {
        String ConnectionString = @"Data Source=LAPTOP-D86A2RRO\SQLEXPRESS;Initial Catalog=DemoReport;Integrated Security=True;";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnClick_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand cmd =new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "PR_STUDENT_SELECTALL";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            conn.Close();

            rv.LocalReport.DataSources.Add(new ReportDataSource("DataSet1",dt));
            rv.LocalReport.ReportPath = Server.MapPath("~/Report/Report.rdlc");
            rv.LocalReport.EnableHyperlinks = true;

        }
    }
}