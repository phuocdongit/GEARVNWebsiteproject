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
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("/admin/Thongke");
        }

        protected void btnLoc_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            // Kết nối đến cơ sở dữ liệu
            using (SqlConnection connection = new SqlConnection(@"Data Source=EAST\SQLEXPRESS;Initial Catalog=ProjectWebsite;Integrated Security=True;MultipleActiveResultSets=True"))
            {
                // Tạo câu truy vấn với điều kiện khoảng thời gian
                string query = "SELECT * FROM DoanhThuTheoNgay WHERE NgayLapHD BETWEEN @TuNgay AND @DenNgay";
                SqlCommand cm = new SqlCommand(query, connection);

                // Thiết lập giá trị cho tham số
                cm.Parameters.AddWithValue("@TuNgay", txtTuNgay.Text);
                cm.Parameters.AddWithValue("@DenNgay", txtDenNgay.Text);

                // Mở kết nối và thực hiện truy vấn
                connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(cm);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Hiển thị dữ liệu trong ReportViewer
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportDataSource rds = new ReportDataSource("DS_DoanhThuTheoNgay", dt);
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("RP_DoanhThu.rdlc");
                ReportViewer1.LocalReport.DataSources.Add(rds);
                ReportViewer1.LocalReport.Refresh();
            }
        }
    }
}