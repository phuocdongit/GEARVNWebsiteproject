using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WEB_Project.REPORT
{
    public partial class Report_KhachHang : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData("KhachHang");
            }
        }

        protected void btnBackKH_Click(object sender, EventArgs e)
        {
            Response.Redirect("/admin/Thongke");
        }


        private void LoadData(string tableName)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=EAST\SQLEXPRESS;Initial Catalog=ProjectWebsite;Integrated Security=True;MultipleActiveResultSets=True");
            SqlCommand cm = new SqlCommand($"SELECT * FROM {tableName}", connection);
            SqlDataAdapter da = new SqlDataAdapter(cm);
            DataTable dt = new DataTable();
            da.Fill(dt);

            BindReport(dt);
        }

        private void LoadDataSortedBySLHoaDon(string tableName)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=EAST\SQLEXPRESS;Initial Catalog=ProjectWebsite;Integrated Security=True;MultipleActiveResultSets=True");
            SqlCommand cm = new SqlCommand($"SELECT * FROM {tableName} ORDER BY SLHoaDon DESC", connection);
            SqlDataAdapter da = new SqlDataAdapter(cm);
            DataTable dt = new DataTable();
            da.Fill(dt);

            BindReport(dt);
        }

        private void BindReport(DataTable dt)
        {
            this.ReportKhachHang.LocalReport.DataSources.Clear();
            ReportDataSource rds = new ReportDataSource("DS_KhachHang", dt);
            ReportKhachHang.LocalReport.ReportPath = Server.MapPath("RP_KhachHang.rdlc");
            this.ReportKhachHang.LocalReport.DataSources.Add(rds);
            this.ReportKhachHang.LocalReport.Refresh();
        }

        protected void DropDownList1_SelectedIndexChanged1(object sender, EventArgs e)
        {
            string selectedValue = ddlEast.SelectedValue;

            if (selectedValue == "1")
            {
                LoadData("KhachHang");
            }
            else if (selectedValue == "2")
            {
                LoadDataSortedBySLHoaDon("KhachHang");
            }
        }

    }
}