using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LabProject.Models.ViewModel;

namespace LabProject.Controllers
{
    public class LabController : Controller
    {
        LabDataBaseEntities labEntity = new LabDataBaseEntities();
      

        public ActionResult Create()
        {
            ViewBag.State = new SelectList(labEntity.States, "StateId", "StateName", "--Select One--");

            return View("AddLab");
        }

        public ActionResult Edit(int? LabId)
        {
           
            var LabView = (from lab in labEntity.LabDetails
                           join st in labEntity.States on lab.State equals st.StateId
                           join ct in labEntity.Cities on lab.City equals ct.CityId
                           where lab.LabId == LabId
                           select new VMLabDetails
                           {
                               LabName = lab.LabName,
                               LabOwnerName = lab.LabOwnerName,
                               ContactNumber = lab.ContactNumber,
                               Email=lab.Email,
                               About = lab.About,
                               StateName = st.StateName,
                               CityName = ct.CityName,
                               Add1=lab.Add1,
                               Add2=lab.Add2,
                               Add3=lab.Add3,
                               
                           }).ToList().FirstOrDefault();
            // ViewBag.State = new SelectList(labEntity.States, "StateId", "StateName","Punjab");

            ViewBag.State = new SelectList(labEntity.States, "StateId", "StateName", "--Select One--");
            ViewBag.Cities = new SelectList(labEntity.Cities, "CityId", "CityName", "--Select One--");

            return View(LabView);
        }
        [HttpPost]
        public void Create(LabDetail LabDetails)
        {
            using (LabDataBaseEntities labEntity = new LabDataBaseEntities())
            {
                labEntity.LabDetails.Add(LabDetails);
                labEntity.SaveChanges();
            }

        }
        [HttpPost]
        public ActionResult Edit(LabDetail lab)
        {
            using (LabDataBaseEntities entity = new LabDataBaseEntities())
            {
                LabDetail labd = entity.LabDetails.FirstOrDefault(x => x.LabId == lab.LabId);
                labd.LabName = lab.LabName;
                labd.LabOwnerName = lab.LabOwnerName;
                labd.Email = lab.Email;
                labd.ContactNumber = lab.ContactNumber;
                labd.About = lab.About;
                labd.Add1 = lab.Add1;
                labd.Add2 = lab.Add2;
                labd.Add3 = lab.Add3;
                entity.SaveChanges();
            }
            return RedirectToAction("Index");

        }

        public ActionResult FillCity(int state)
        {
            var cities = (from x in labEntity.Cities
                          where x.StateId == state
                          select new
                          {
                              CityId = x.CityId,
                              CityName = x.CityName
                          }).ToList();

            return Json(cities, JsonRequestBehavior.AllowGet);
        }


        public ActionResult LabDetail(int labId)
        {
            var LabView = (from lab in labEntity.LabDetails
                           join st in labEntity.States on lab.State equals st.StateId
                           join ct in labEntity.Cities on lab.City equals ct.CityId
                           where lab.LabId == labId
                           select new VMLabDetails
                           {
                               LabName = lab.LabName,
                               LabOwnerName = lab.LabOwnerName,
                               ContactNumber = lab.ContactNumber,
                               About = lab.About,
                               StateName = st.StateName,
                               CityName = ct.CityName
                           }).ToList().FirstOrDefault();
            return View(LabView);
        }
       [HttpGet]
        public ActionResult Index(string Search_Data)
       {
            
            List<LabDetail> LabView = null;
            if (Search_Data == "" || Search_Data == null)
            {
                LabView = labEntity.LabDetails.ToList();
               
            }
            else
            {
                LabView = labEntity.LabDetails.Where(x => x.LabName.StartsWith(Search_Data)).ToList();  
            }
            return View(LabView);
        }
    }
}