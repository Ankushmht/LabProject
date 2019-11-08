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
        static List<BookTest> lstBooktest = null;
        readonly LabDataBaseEntities labEntity = new LabDataBaseEntities();
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
            //labEntity.BookTests.Add(bookTest);
            //labEntity.SaveChanges();
             lstBooktest = new List<BookTest>();
            lstBooktest.Add(bookTest);
            return 0;
        }
    }
}