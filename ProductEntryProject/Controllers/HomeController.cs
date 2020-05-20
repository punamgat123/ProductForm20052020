using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductTest.Models;

namespace ProductEntryProject.Controllers
{
    public class HomeController : Controller
    {
        string constr = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
        //
        // GET: /Home/

        public ActionResult Index(string Search, string data)
        {
            GetData data1 = new GetData();

            if (Search != null && data == "Name")
            {
                var listsearch = data1.GetSearch(Search);
                ViewBag.List = listsearch;
            }
            if (Search != null && data == "Date")
            {
                DateTime a = Convert.ToDateTime(Search);
                string b = a.ToString("yyyy-dd-MM 00:00:00");
                var listsearch = data1.GetSearchDate(b);
                ViewBag.List = listsearch;
            }
            if (Search == null)
            {
                var list = data1.Get();
                ViewBag.List = list;
            }
            return View();
        }
        [HttpPost]
        public ActionResult Index(Product product)
        {
            if (ModelState.IsValid)
            {

                SqlConnection con = new SqlConnection(constr);
                SqlCommand cmd;
                con.Open();
                cmd = new SqlCommand("select count(*) from Product where Name like('" + product.Name + "')", con);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count == 0)
                {

                    DateTime ExpiryDate = DateTime.Now.AddDays(7);
                    cmd = new SqlCommand("insert into Product(Name,price,Quantity,IsGSTApplicable,PurchaseDate,ExpiryDate)values('" + product.Name + "','" + product.Price + "','" + product.Quantity + "','" + product.IsGSTApplicable + "','" + product.Purchase_Date + "','" + ExpiryDate + "')", con);
                    cmd.ExecuteNonQuery();
                    GetData data = new GetData();
                    var list = data.Get();
                    ViewBag.List = list;
                    return View();
                }
                else
                {
                    ViewBag.name = "This Product Name already Exist";
                    GetData data = new GetData();
                    var list = data.Get();
                    ViewBag.List = list;
                    return View();
                }
                con.Close();


            }
            return View();

        }

    }
}
