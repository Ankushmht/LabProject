using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LabProject.Models.ViewModel;

namespace LabProject.Controllers
{
    public class TestLabController : Controller
    {
        LabDataBaseEntities labEntity = new LabDataBaseEntities();
        // GET: TestLab
        public ActionResult Index()
        {
            List<TestLab> testlab;
            testlab = (from labt in labEntity.TestLabPrices
                       join lab in labEntity.LabDetails on labt.LabId equals lab.LabId
                       join t in labEntity.Tests on labt.TestId equals t.Testid
                       select new TestLab
                       {
                           testLabId=labt.TestLabId,
                           tests = t,
                           Labs =lab,
                           Price=labt.Price
                           }).ToList();
           return View(testlab);
        }

        public ActionResult Create()
        {
            ViewBag.labId = new SelectList(labEntity.LabDetails, "LabId", "LabName", "--Select One--");
            ViewBag.testid = new SelectList(labEntity.Tests, "TestId", "testName", "--Select One--");
            return View();
        }

        [HttpPost]
        public ActionResult Create(TestLabPrice testLab)
        {
            ViewBag.labId = new SelectList(labEntity.LabDetails, "LabId", "LabName", "--Select One--");
            ViewBag.testid = new SelectList(labEntity.Tests, "TestId", "testName", "--Select One--");
            labEntity.TestLabPrices.Add(testLab);
            labEntity.SaveChanges();
            return View();
        }

        public ActionResult Edit(int testLabId)
        {
            ViewBag.labs = new SelectList(labEntity.LabDetails, "LabId", "LabName", "--Select One--");
            ViewBag.tests = new SelectList(labEntity.Tests, "TestId", "testName", "--Select One--");
            TestLab testlab;
            testlab = (from labt in labEntity.TestLabPrices
                       join lab in labEntity.LabDetails on labt.LabId equals lab.LabId
                       join t in labEntity.Tests on labt.TestId equals t.Testid
                       where labt.TestLabId== testLabId
                       select new TestLab
                       {
                           testLabId=labt.TestLabId,
                           tests = t,
                           Labs = lab,
                           Price = labt.Price
                       }).ToList().FirstOrDefault();
            return View(testlab);
           
        }

        [HttpPost]
        public ActionResult Edit(TestLab testLab)
        {
            TestLabPrice tl =labEntity.TestLabPrices.FirstOrDefault(x => x.TestLabId == testLab.testLabId);
            tl.Price = testLab.Price;
            labEntity.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}