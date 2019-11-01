using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabProject.Areas.User.Controllers
{
    public class LabController : Controller
    {
        LabDataBaseEntities labEntity = new LabDataBaseEntities();
        // GET: User/Lab
        public ActionResult Index()
        {
            List<LabDetail> LabView = labEntity.LabDetails.ToList(); 
            return View(LabView);
        }
    }
}