using LabProject.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabProject.Areas.User.Controllers
{
    public class SimilarTestLabsController : Controller
    {
        static List<BookTest> lstBooktest = new List<BookTest>();
        readonly LabDataBaseEntities labEntity = new LabDataBaseEntities();
        Random rnd = new Random();
        [HttpGet]
        // GET: User/SimilarTestLabs
        public ActionResult Index(int testId)
        {
            List<TestLab> testlab;
            testlab = (from labt in labEntity.TestLabPrices
                       join lab in labEntity.LabDetails on labt.LabId equals lab.LabId
                       join t in labEntity.Tests on labt.TestId equals t.Testid
                       where labt.TestId == testId
                       select new TestLab
                       {
                           testLabId = labt.TestLabId,
                           tests = t,
                           Labs = lab,
                           Price = labt.Price
                       }).ToList();
            return View(testlab);
        }

        public ActionResult RegisterOrLogin()
        {
            return View();
        }

        public int BookTest(BookTest bookTest)
        {
            bookTest.UserId =Convert.ToInt32(Request.Cookies["userId"].Value);
            lstBooktest.Add(bookTest);
            Session["lstBookTest"] = lstBooktest;
            return 0;
        }
    }
}