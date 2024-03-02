using System.Web.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.SqlClient;

namespace WEB_Project.Models.EF
{
    [Table("Customer")]
    public class Customer
    {
        public Customer()
        {

            this.Orders = new HashSet<Order>();

        }

        [Key]
        [StringLength(10)]
        public string CustomerID { get; set; }

        [Required(ErrorMessage = "Tên khách hàng không để trống")]
        [StringLength(50)]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Số điện thoại không để trống")]
        [StringLength(15)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Địa chỉ không để trống")]
        [StringLength(100)]
        public string Address { get; set; }
        [StringLength(100)]
        public string Email { get; set; }
        public ICollection<Order> Orders { get; set; }
    }

    class CustomerList
    {
        private ApplicationDbContext db1 = new ApplicationDbContext();
        
        DBConnection db;
        public int GetNumberOfInvoices(string customerId)
        {
            string countSql = "SELECT COUNT(*) FROM Orders WHERE CustomerID=@CustomerID";

            using (SqlConnection con = db.getConnection())
            using (SqlCommand cmd = new SqlCommand(countSql, con))
            {
                cmd.Parameters.AddWithValue("@CustomerID", customerId);
                con.Open();
                int numberOfInvoices = (int)cmd.ExecuteScalar();
                return numberOfInvoices;
            }
        }
        public CustomerList()
        {
            db = new DBConnection();
        }
        public List<Customer> getCustomer(string CusID)
        {
            string sql;
            if (string.IsNullOrEmpty(CusID))
            {
                sql = "SELECT * FROM Customer";
            }
            else
                sql = "SELECT * FROM Customer WHERE CustomerID= '" + CusID + "'";
            List<Customer> cusList = new List<Customer>();
            DataTable dt = new DataTable();
            SqlConnection con = db.getConnection();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            con.Open();
            da.Fill(dt);
            da.Dispose();
            Customer tmpCus;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                tmpCus = new Customer();
                tmpCus.CustomerID = dt.Rows[i]["CustomerID"].ToString();
                tmpCus.CustomerName = dt.Rows[i]["CustomerName"].ToString();
                tmpCus.Phone = dt.Rows[i]["Phone"].ToString();
                tmpCus.Address = dt.Rows[i]["Address"].ToString();
                tmpCus.Email = dt.Rows[i]["Email"].ToString();
                cusList.Add(tmpCus);
            }
            return cusList;
        }

        

        public void DeleteCustomer(Customer cus)
        {
            // Xóa chi tiết hóa đơn liên quan
            string deleteOrderDetailsSql = "DELETE FROM OrderDetail WHERE OrderId IN (SELECT OrderID FROM Orders WHERE CustomerID=@CustomerID)";
            using (SqlConnection conOrderDetails = db.getConnection())
            using (SqlCommand cmdOrderDetails = new SqlCommand(deleteOrderDetailsSql, conOrderDetails))
            {
                cmdOrderDetails.Parameters.AddWithValue("@CustomerID", cus.CustomerID);
                conOrderDetails.Open();
                cmdOrderDetails.ExecuteNonQuery();
            }

            // Xóa hóa đơn liên quan
            string deleteOrderSql = "DELETE FROM Orders WHERE CustomerID=@CustomerID";
            using (SqlConnection conOrder = db.getConnection())
            using (SqlCommand cmdOrder = new SqlCommand(deleteOrderSql, conOrder))
            {
                cmdOrder.Parameters.AddWithValue("@CustomerID", cus.CustomerID);
                conOrder.Open();
                cmdOrder.ExecuteNonQuery();
            }

            // Sau đó, xóa khách hàng
            string deleteCustomerSql = "DELETE FROM Customer WHERE CustomerID=@CustomerID";
            using (SqlConnection conCustomer = db.getConnection())
            using (SqlCommand cmdCustomer = new SqlCommand(deleteCustomerSql, conCustomer))
            {
                cmdCustomer.Parameters.AddWithValue("@CustomerID", cus.CustomerID);
                conCustomer.Open();
                cmdCustomer.ExecuteNonQuery();
            }
            //string sql = "DELETE FROM tb_Customer WHERE CustomerID='" + cus.CustomerID + "' ";
            //SqlConnection con = db.getConnection();
            //SqlCommand cmd = new SqlCommand(sql, con);
            //con.Open();
            //cmd.ExecuteNonQuery();
            //cmd.Dispose();
            //con.Close();
        }
    }
}