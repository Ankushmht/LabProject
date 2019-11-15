using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LabProject.Models.ViewModel;

namespace LabProject.Areas.User.Controllers
{


    public class CartController : Controller
    {
        readonly LabDataBaseEntities labEntity = new LabDataBaseEntities();
        // GET: Cart
        [HttpGet]
        public ActionResult GetCart()
        {
            List<BookTest> lstBooktest =(List<BookTest>)Session["lstBookTest"];
            lstBooktest=lstBooktest.Where(x => x.UserId == Convert.ToInt32(Request.Cookies["userId"].Value)).ToList();
            List<TestLabPrice> lsttlp = new List<TestLabPrice>();

            foreach (var x in lstBooktest) {
                TestLabPrice tlp = new TestLabPrice();
                tlp=labEntity.TestLabPrices.Where(xx => xx.TestLabId == x.TestLabId).FirstOrDefault();
                lsttlp.Add(tlp);
            }
            return View(lsttlp);
        }
    }
}