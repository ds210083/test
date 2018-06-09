using MVC4.EntityModel;
using MVC4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC4.Controllers
{
    public class EmpController : Controller
    {
        // GET: Emp
        public ActionResult Index()
        {
            Employee a = new Employee();
            return View(a.GetAllList());
        }
        public ActionResult Create()
        {
            ViewBag.Ispost = false;
            if (HttpContext.Request.RequestType == "POST")
            {
                var Name = Request.Form["Name"];
                var City = Request.Form["City"];
                Employee a = new Employee();
                a.Name = Name;
                a.City = City;
                a = a.AddUpdate(a);
                ViewBag.Ispost = true;
                ViewBag.Message = a.mesage;
            }
            return View();
        }
        public ActionResult Update(int id)
        {
            ViewBag.Ispost = false;

            if (HttpContext.Request.RequestType == "POST")
            {
                var Name = Request.Form["Name"];
                var City = Request.Form["City"];
                Employee a = new Employee();
                a.Id = id;
                a.Name = Name;
                a.City = City;
                a = a.AddUpdate(a);
                ViewBag.Ispost = a.Status;
                ViewBag.Message = a.mesage;
                return RedirectToAction("Index");
            }

            Employee obj = new Employee();
            obj = obj.GetList(id);
            return PartialView("UpdatePartial", obj);
            ///return View(obj);
        }
        public ActionResult Delete(int id)
        {
            Employee a = new Employee();
            a = a.Delete(id);
            ViewBag.Ispost = a.Status;
            ViewBag.Message = a.mesage;
            return View();
        }
    }
}