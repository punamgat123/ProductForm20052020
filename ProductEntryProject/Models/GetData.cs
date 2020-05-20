using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProductTest.Models
{
    public class GetData
    {
        string constr = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
        public List<Product> Get()
        {
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd;
            con.Open();
            cmd = new SqlCommand("select * from Product", con);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            List<Product> list = new List<Product>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Product pro = new Product();
                pro.Id = Convert.ToInt32(dr["Id"]);
                pro.Name = dr["Name"].ToString();
                pro.Price = Convert.ToDecimal(dr["price"]);
                pro.Quantity = Convert.ToInt32(dr["Quantity"]);
                pro.IsGSTApplicable = Convert.ToBoolean(dr["IsGSTApplicable"]);
                pro.Purchase_Date = Convert.ToDateTime(dr["PurchaseDate"]);
                pro.ExpiryDate = Convert.ToDateTime(dr["ExpiryDate"]);
                list.Add(pro);
            }
            con.Close();
            return list;
        }
        public List<Product> GetSearch(string Search)
        {
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd;
            con.Open();
            cmd = new SqlCommand("select * from Product where Name like('"+Search+"%')", con);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            List<Product> list = new List<Product>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Product pro = new Product();
                pro.Id = Convert.ToInt32(dr["Id"]);
                pro.Name = dr["Name"].ToString();
                pro.Price = Convert.ToDecimal(dr["price"]);
                pro.Quantity = Convert.ToInt32(dr["Quantity"]);
                pro.IsGSTApplicable = Convert.ToBoolean(dr["IsGSTApplicable"]);
                pro.Purchase_Date = Convert.ToDateTime(dr["PurchaseDate"]);
                pro.ExpiryDate = Convert.ToDateTime(dr["ExpiryDate"]);
                list.Add(pro);
            }
            con.Close();
            return list;
        }
        public List<Product> GetSearchDate(string date)
        {
           
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd;
            con.Open();
            cmd = new SqlCommand("select * from Product where PurchaseDate='" +date+ "'", con);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            List<Product> list = new List<Product>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Product pro = new Product();
                pro.Id = Convert.ToInt32(dr["Id"]);
                pro.Name = dr["Name"].ToString();
                pro.Price = Convert.ToDecimal(dr["price"]);
                pro.Quantity = Convert.ToInt32(dr["Quantity"]);
                pro.IsGSTApplicable = Convert.ToBoolean(dr["IsGSTApplicable"]);
                pro.Purchase_Date = Convert.ToDateTime(dr["PurchaseDate"]);
                pro.ExpiryDate = Convert.ToDateTime(dr["ExpiryDate"]);
                list.Add(pro);
            }
            con.Close();
            return list;
        }
    }
}