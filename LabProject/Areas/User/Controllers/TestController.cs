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
    }
}