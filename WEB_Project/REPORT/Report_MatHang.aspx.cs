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
    public partial class Report_MatHang : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlConnection connection = new SqlConnection(@"Data Source=EAST\SQLEXPRESS;Initial Catalog=ProjectWebsite;Integrated Security=True;MultipleActiveResultSets=True");
                SqlCommand cm = new SqlCommand($"SELECT * FROM MatHang", connection);

                // Thiết lập giá trị cho tham số
                cm.Parameters.AddWithValue("@TuNgay", txtTu.Text);
                cm.Parameters.AddWithValue("@DenNgay", txtDen.Text);
                SqlDataAdapter da = new SqlDataAdapter(cm);
                DataTable dt = new DataTable();
                da.Fill(dt);

                BindReport(dt);
            }
        }

        private void LoadData()
        {
            SqlConnection connection = new SqlConnection(@"Data Source=EAST\SQLEXPRESS;Initial Catalog=ProjectWebsite;Integrated Security=True;MultipleActiveResultSets=True");
            SqlCommand cm = new SqlCommand($"SELECT * FROM MatHang WHERE NgayBan BETWEEN @TuNgay AND @DenNgay", connection);

            // Thiết lập giá trị cho tham số
            cm.Parameters.AddWithValue("@TuNgay", txtTu.Text);
            cm.Parameters.AddWithValue("@DenNgay", txtDen.Text);
            SqlDataAdapter da = new SqlDataAdapter(cm);
            DataTable dt = new DataTable();
            da.Fill(dt);

            BindReport(dt);
        }

        private void LoadDataSortedByViewCount()
        {
            SqlConnection connection = new SqlConnection(@"Data Source=EAST\SQLEXPRESS;Initial Catalog=ProjectWebsite;Integrated Security=True;MultipleActiveResultSets=True");
            SqlCommand cm = new SqlCommand($"SELECT * FROM MatHang WHERE NgayBan BETWEEN @TuNgay AND @DenNgay ORDER BY LuotXem DESC", connection);
            cm.Parameters.AddWithValue("@TuNgay", txtTu.Text);
            cm.Parameters.AddWithValue("@DenNgay", txtDen.Text);
            SqlDataAdapter da = new SqlDataAdapter(cm);
            DataTable dt = new DataTable();
            da.Fill(dt);

            BindReport(dt);
        }
        private void LoadDataSortedByQuantity()
        {
            SqlConnection connection = new SqlConnection(@"Data Source=EAST\SQLEXPRESS;Initial Catalog=ProjectWebsite;Integrated Security=True;MultipleActiveResultSets=True");
            SqlCommand cm = new SqlCommand($"SELECT * FROM MatHang WHERE NgayBan BETWEEN @TuNgay AND @DenNgay AND Soluong < 20", connection);
            cm.Parameters.AddWithValue("@TuNgay", txtTu.Text);
            cm.Parameters.AddWithValue("@DenNgay", txtDen.Text);
            SqlDataAdapter da = new SqlDataAdapter(cm);
            DataTable dt = new DataTable();
            da.Fill(dt);

            BindReport(dt);
        }

        protected void ddlMatHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = ddlMatHang.SelectedValue;

            if (selectedValue == "1")
            {
                LoadData();
            }
            if (selectedValue == "2")
            {
                LoadDataSortedByViewCount();
            }
            else if (selectedValue == "3")
            {
                LoadDataSortedByQuantity();
            }
        }
        private void BindReport(DataTable dt)
        {
            this.ReportMatHang.LocalReport.DataSources.Clear();
            ReportDataSource rds = new ReportDataSource("DS_MatHang", dt);
            ReportMatHang.LocalReport.ReportPath = Server.MapPath("RP_MatHang.rdlc");
            this.ReportMatHang.LocalReport.DataSources.Add(rds);
            this.ReportMatHang.LocalReport.Refresh();
        }
      

        protected void btnQuayLai_Click(object sender, EventArgs e)
        {
            Response.Redirect("/admin/Thongke");
        }
    }
}