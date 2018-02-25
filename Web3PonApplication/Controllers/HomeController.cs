using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web3PonApplication.Models;
using Web3PonApplication.Dal;
using Web3PonApplication.ModelView;
using System.Threading;

namespace Web3PonApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult MainLogin()
        {
            if (Session["user"] == null)
                return RedirectToAction("Login", "Worker");

            return View();
        }

        public ActionResult Careers()
        {
            return View();
        }


        public ActionResult GetJobs()
        {
            DBDal dal = new DBDal();
            Thread.Sleep(7000);
            List<Job> jobs = dal.Jobs.ToList<Job>();
            return Json(jobs, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ProductsAmdServices()
        {
            DBDal dal = new DBDal();
            List<Service> objServices = dal.Services.ToList<Service>();
            ServicesViewModel servicevm = new ServicesViewModel();
            servicevm.service = new Service();
            servicevm.services = objServices;
            return View(servicevm);
        }


        public ActionResult Activities()
        {
            return View();
        }
    }
}