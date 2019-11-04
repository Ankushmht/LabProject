using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabProject.Areas.User.Controllers
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


    }
}