using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.SqlClient;

namespace WEB_Project.Models.EF
{
    [Table("Provider")]
    public class Provider
    {
        public Provider()
        {
  
            Products = new HashSet<Product>();
        }
        [Display(Name = "Mã nhà cung cấp")]
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.None)]
        public int ProID { get; set; }
        [Display(Name = "Tên nhà cung cấp")]
        [StringLength(100)]
        [Required]
        public string ProName { get; set; }
        [Display(Name = "SĐT")]
        [StringLength(15)]
        public string Phone { get; set; }
        [Display(Name = "Địa chỉ")]
        [StringLength(200)]
        [Required]
        public string Address { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
    
    class ProviderList
    {
        DBConnection db;
        public ProviderList()
        {
            db = new DBConnection();
        }
        public List<Provider> getProvider(string ProID)
        {
            string sql;
            if (string.IsNullOrEmpty(ProID))
            {
                sql = "SELECT * FROM Provider";
            }
            else
                sql = "SELECT * FROM Provider WHERE ProID= '" + ProID + "'";
            List<Provider> proList = new List<Provider>();
            DataTable dt = new DataTable();
            SqlConnection con = db.getConnection();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            con.Open();
            da.Fill(dt);
            da.Dispose();
            Provider tmpPro;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                tmpPro = new Provider();
                tmpPro.ProID = Convert.ToInt32(dt.Rows[i]["ProID"]);
                tmpPro.ProName = dt.Rows[i]["ProName"].ToString();
                tmpPro.Phone = dt.Rows[i]["Phone"].ToString();
                tmpPro.Address = dt.Rows[i]["Address"].ToString();
                proList.Add(tmpPro);
            }
            return proList;
        }

        public void AddProvider(Provider pro)
        {
            string sql = "INSERT INTO Provider(ProID,ProName,Phone,Address) " +
                "values('" + pro.ProID + "',N'" + pro.ProName + "','" + pro.Phone + "',N'" + pro.Address + "')";
            SqlConnection con = db.getConnection();
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }

        public void UpdateProvider(Provider pro)
        {
            string sql = "UPDATE Provider SET ProName=N'" + pro.ProName + "', Phone='" + pro.Phone + "', Address=N'" + pro.Address + "' where ProID='" + pro.ProID + "' ";
            SqlConnection con = db.getConnection();
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }

        public void DeleteProvider(Provider pro)
        {
            string sql = "DELETE FROM Provider WHERE ProID='" + pro.ProID + "' ";
            SqlConnection con = db.getConnection();
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }
    }
}