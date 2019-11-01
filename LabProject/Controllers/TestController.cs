    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LabProject.Models.ViewModel;

namespace LabProject.Controllers
{
    public class TestController : Controller
    {
       
        LabDataBaseEntities labEnity = new LabDataBaseEntities();
        // GET: Test
        public ActionResult Index()
        {
            List<Test> tests = labEnity.Tests.ToList();
            return View(tests);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create(Test test)
        {
            labEnity.Tests.Add(test);
            labEnity.SaveChanges();
            return View();
        }

        [HttpGet]
        public ActionResult Index(string Search_Data)
        {

            List<Test> testView = null;
            if (Search_Data == "" || Search_Data == null)
            {
                testView = labEnity.Tests.ToList();

            }
            else
            {
                testView = labEnity.Tests.Where(x => x.TestName.StartsWith(Search_Data)).ToList();
            }
            return View(testView);
        }

        [HttpGet]
        public ActionResult Edit(int testId)
        {
           VMTest tests = (from t in labEnity.Tests
                                where t.Testid == testId
                                select new VMTest
                                {
                                    TestName = t.TestName,
                                    TestReportDuration = t.TestReportDuration,
                                    PreRequisite = t.PreRequisite
                                }).ToList().FirstOrDefault();
            return View(tests);
        }


        [HttpPost]
        public ActionResult Edit(Test tst)
        {
            Test test = labEnity.Tests.FirstOrDefault(x => x.Testid == tst.Testid);
            test.TestName = tst.TestName;
            test.TestReportDuration = tst.TestReportDuration;
           
            return RedirectToAction("Index");
        }
    }


}