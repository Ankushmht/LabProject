using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabProject.Controllers
{
    public class LabController : Controller
    {
        LabDataBaseEntities labEntity = new LabDataBaseEntities();
        [HttpGet]
        public ActionResult Index()
        {
            return View();

           
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.State = new SelectList(labEntity.States, "StateId", "StateName");
            return View("AddLab");
        }
        [HttpPost]
        public JsonResult  Create1(LabDetail LabDetails)
        {
            using (LabDataBaseEntities labEntity=new LabDataBaseEntities())
            {
                labEntity.LabDetails.Add(LabDetails);
                labEntity.SaveChanges();
            }
            return Json(LabDetails);
        }


        [HttpPost]
        public ActionResult Create(LabDetail LabDetails)
        {
            using (LabDataBaseEntities labEntity = new LabDataBaseEntities())
            {
                labEntity.LabDetails.Add(LabDetails);
                labEntity.SaveChanges();
            }
            return View();
        }
        public ActionResult UpdateLab(LabDetail lab)
        {
            using (LabDataBaseEntities entity = new LabDataBaseEntities())
            {
                LabDetail labd = entity.LabDetails.FirstOrDefault(x => x.LabId == lab.LabId);
                labd.LabName = lab.LabName;
                labd.LabOwnerName = lab.LabOwnerName;
                labd.Email = lab.Email;
                labd.ContactNumber = lab.ContactNumber;
                labd.About = lab.About;
                entity.SaveChanges();
            }
            return new EmptyResult();
        }
    }
}