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
            if (Request.Cookies["userId"].Value != "")
            {
                List<BookTest> lstBooktest = (List<BookTest>)Session["lstBookTest"];


                lstBooktest = lstBooktest.Where(x => x.UserId == Convert.ToInt32(Request.Cookies["userId"].Value)).ToList();
                List<TestLabPrice> lsttlp = new List<TestLabPrice>();

                foreach (var x in lstBooktest) {
                    TestLabPrice tlp = new TestLabPrice();
                    tlp = labEntity.TestLabPrices.Where(xx => xx.TestLabId == x.TestLabId).FirstOrDefault();
                    lsttlp.Add(tlp);
                }

                List<TestLab> testlab;
                testlab = (from labt in lsttlp
                           join lab in labEntity.LabDetails on labt.LabId equals lab.LabId
                           join t in labEntity.Tests on labt.TestId equals t.Testid
                           select new TestLab
                           {
                               testLabId = labt.TestLabId,
                               tests = t,
                               Labs = lab,
                               Price = labt.Price
                           }).ToList();
                ViewBag.Total = testlab.Sum(data => data.Price);
                return View(testlab);
            }
            else
            {
                return View();
            }

        }
    }
}