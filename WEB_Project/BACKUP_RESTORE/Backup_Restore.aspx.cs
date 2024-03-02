using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace WEB_Project.BACKUP_RESTORE
{
    public partial class Backup_Restore : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void btnFileBackup_Click(object sender, EventArgs e)
        {
            //fileBackupHidden.Attributes["style"] = "display: none;";
            ////fileBackupHidden.Add("display", "none");
            //fileBackupHidden.Focus();
        }

        //protected void btnFileRestore_Click(object sender, EventArgs e)
        //{
        //    fileRestore.Attributes["style"] = "display: none;";
        //    fileRestore.Style.Add("display", "block");
        //    fileRestore.Focus();
        //}

        protected void btnBackUp_Click(object sender, EventArgs e)
        {
            string backupPath = @"D:\WEB\PROJECT\WEB_Project\Back_Res";

            // Kiểm tra xem đường dẫn backup có hợp lệ không
            if (Directory.Exists(backupPath))
            {
                using (SqlConnection connection = new SqlConnection(@"Data Source=EAST\SQLEXPRESS;Initial Catalog=ProjectWebsite;Integrated Security=True;MultipleActiveResultSets=True"))
                {
                    string database = connection.Database.ToString();
                    connection.Open();

                    // Tạo command để thực hiện backup
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "BACKUP DATABASE [" + database + "] TO DISK='" + @"D:\" + "\\GearvnBackUpFile" + "-" + DateTime.Now.ToString("dd-MM-yyyy--HH-mm-ss") + ".bak'";
                        command.ExecuteNonQuery();
                    }
                }
                Response.Write("<p>Backup thành công!</p>");
                Response.Write("<p>(Lưu ý: File sẽ được lưu mặc định ở ổ đĩa D)</p>");
            }
            else
            {
                Response.Write("Đường dẫn không hợp lệ!");
            }
        }

        protected void btnRestore_Click(object sender, EventArgs e)
        {
            string restorePath = txtRestore.Text;
            if (!string.IsNullOrEmpty(restorePath))
            {
                using (SqlConnection connection = new SqlConnection(@"Data Source=EAST\SQLEXPRESS;Initial Catalog=ProjectWebsite;Integrated Security=True;MultipleActiveResultSets=True"))
                {
                    connection.Open();
                    string database = connection.Database.ToString();

                    try
                    {
                        // Đặt cơ sở dữ liệu vào chế độ single user để ngắt kết nối người dùng
                        string str1 = string.Format("ALTER DATABASE [" + database + "] SET SINGLE_USER WITH ROLLBACK IMMEDIATE");
                        SqlCommand cmd1 = new SqlCommand(str1, connection);
                        cmd1.ExecuteNonQuery();

                        // Khôi phục cơ sở dữ liệu từ file đã chọn
                        string str2 = "USE MASTER RESTORE DATABASE [" + database + "] FROM DISK='"+@"D:\" + restorePath + "' WITH REPLACE;";
                        SqlCommand cmd2 = new SqlCommand(str2, connection);
                        cmd2.ExecuteNonQuery();

                        // Đặt cơ sở dữ liệu trở lại chế độ multi-user
                        string str3 = "ALTER DATABASE [" + database + "] SET MULTI_USER";
                        SqlCommand cmd3 = new SqlCommand(str3, connection);
                        cmd3.ExecuteNonQuery();

                        // Hiển thị thông báo hoặc thực hiện các hành động khác sau khi restore
                        Response.Write("Restore thành công!");
                    }
                    catch (Exception ex)
                    {
                        // Xử lý lỗi nếu có
                        Response.Write("Lỗi khi thực hiện restore: " + ex.Message);
                    }

                }
            }
            else
            {
                // Hiển thị thông báo nếu không có file được chọn
                Response.Write("Vui lòng chọn file để phục hồi.");
            }
        }


        protected void btnFileBackup_Click1(object sender, EventArgs e)
        {

        }
    }

}