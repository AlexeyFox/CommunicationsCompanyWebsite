using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Web3PonApplication.Models;
using Web3PonApplication.Dal;
using Web3PonApplication.ModelView;
using System.Threading;
using System.Runtime.Remoting.Contexts;
using System.Web.Security;
using System;

namespace Web3PonApplication.Controllers
{

    public class WorkerController : Controller
    {
 
        [Authorize]
        public ActionResult Index()
        {         
            return View();
        }

        [Authorize]
        public ActionResult WorkerMenu()
        {
            return View();
        }

        [Authorize]
        public ActionResult ChangeInfo()
        {
            
            if (User.Identity.Name.Split('|')[2].Equals("2") || User.Identity.Name.Split('|')[2].Equals("1"))
            {
                string name = User.Identity.Name.Split('|')[0].ToString();
                DBDal dal = new DBDal();
                List<Worker> workerinfo = (from u in dal.Workers
                                            where (u.UserName.Equals(name))
                                            select u).ToList();
                List<User> userinfo = (from u in dal.Users
                                 where (u.UserName.Equals(name))
                                 select u).ToList();
                if(workerinfo.Count == 1 && userinfo.Count == 1)
                {
                    dal.Workers.Remove(workerinfo.First());
                    dal.Users.Remove(userinfo.First());
                    dal.SaveChanges();
                    WorkerViewModel workervm = new WorkerViewModel();
                    workervm.worker = workerinfo.First();
                    workervm.user = userinfo.First();
                    return View("ChangeInfo",workervm);
                }
                else
                {
                    return RedirectToRoute("DefaultPage");
                }             
            }
            else {
                return RedirectToRoute("DefaultPage");
            }
        }

        [Authorize]
        public ActionResult GetCustomers()
        {
            DBDal dal = new DBDal();
            Thread.Sleep(7000);
            List<Worker> objWorkers = dal.Workers.ToList<Worker>();
            return Json(objWorkers,JsonRequestBehavior.AllowGet);
        }
        [Authorize]
        public ActionResult Add(string submit)
        {
            WorkerViewModel workervm = new WorkerViewModel();
            Worker objWorker = new Worker();
            User objUser = new User();
            objWorker.ID = Request.Form["worker.ID"].ToString();
            objWorker.FirstName = Request.Form["worker.FirstName"].ToString();
            objWorker.LastName = Request.Form["worker.LastName"].ToString();
            objWorker.Phone = Request.Form["worker.Phone"].ToString();
            objWorker.Gender = Request.Form["worker.Gender"].ToString();
            objWorker.Email = Request.Form["worker.Email"].ToString();
            objWorker.DateOfBirth = Request.Form["worker.DateOfBirth"].ToString();
            objWorker.Profession = Request.Form["worker.Profession"].ToString();
            objWorker.UserName = Request.Form["worker.UserName"];
            objUser.UserName = Request.Form["worker.UserName"];
            objUser.Password = Request.Form["user.Password"];
            objUser.Permission = Int32.Parse(Request.Form["user.Permission"]);
            DBDal dal = new DBDal();
            if (ModelState.IsValid)
            {
                dal.Workers.Add(objWorker);
                dal.Users.Add(objUser);
                dal.SaveChanges();  //Username
                workervm.worker = new Worker();

            }
            else
                workervm.worker = objWorker;

            workervm.workers = dal.Workers.ToList<Worker>();
            switch (submit)
            {
                case "Change":
                    {
                        FormsAuthentication.SetAuthCookie("" + objWorker.UserName + "|" + objWorker.FirstName + " " + objWorker.LastName + "|" + objUser.Permission.ToString(), true);
                        return View("WorkerMenu"); }
                    break;
                case "Add":
                    { return View("ManagementOfWorkers", workervm); }              
                    break;
            }
            return RedirectToRoute("DefaultPage");
        }


        [Authorize]
        public ActionResult ManagementOfWorkers()
        {
   
            if (User.Identity.Name.Split('|')[2].Equals("2"))
            {
                DBDal dal = new DBDal();
                List<Worker> objWorkers = dal.Workers.ToList<Worker>();
                WorkerViewModel workervm = new WorkerViewModel();
                workervm.worker = new Worker();
                workervm.user = new User();
                workervm.workers = objWorkers;
                return View(workervm);
            }
            else
            {
                return RedirectToRoute("DefaultPage");
            }
        }

        [Authorize]
        public ActionResult PrintSuggests()
        {
            if (User.Identity.Name.Split('|')[2].Equals("2"))
            {
                DBDal dal = new DBDal();
                List<Suggestion> objSuggests = dal.Suggestions.ToList<Suggestion>();
                SuggestionViewModel suggestionvm = new SuggestionViewModel();
                suggestionvm.suggestion = new Suggestion();
                suggestionvm.suggestions = objSuggests;
                return View(suggestionvm);
            }
            else
            {
                return RedirectToRoute("DefaultPage");
            }
        }

        [Authorize]
        public ActionResult Delete(Suggestion obj)
        {
            if (User.Identity.Name.Split('|')[2].Equals("2"))
            {
                DBDal dal = new DBDal();
                if (obj != null)
                {
                    List<Suggestion> suggest = (from u in dal.Suggestions
                                                where (u.ID == obj.ID)
                                                select u).ToList();
                    dal.Suggestions.Remove(suggest.First());
                    dal.SaveChanges();
                }
                List<Suggestion> objSuggests = dal.Suggestions.ToList<Suggestion>();
                SuggestionViewModel suggestionvm = new SuggestionViewModel();
                suggestionvm.suggestions = objSuggests;
                return View("PrintSuggests", suggestionvm);
            }
            else
            {
                return RedirectToRoute("DefaultPage");
            }
        }
        [Authorize]
        public ActionResult Details(Suggestion obj)
        {
            if (User.Identity.Name.Split('|')[2].Equals("2"))
            {
                if (obj.ID != null)
                {
                    TempData["details"] = obj;
                    return View();
                }
                else
                    return RedirectToRoute("DefaultPage");
            }
            else
            {
                return RedirectToRoute("DefaultPage");
            }
        }

        public ActionResult SuggestProject()
        {
            
            DBDal dal = new DBDal();
            SuggestionViewModel suggestionvm = new SuggestionViewModel();
            suggestionvm.suggestion = new Suggestion();
            return View(suggestionvm);
        }

        [HttpPost]
        public ActionResult Send(int[] types)
        {
            int flag = 0;
            SuggestionViewModel suggestvm = new SuggestionViewModel();
            Suggestion objSuggestion = new Suggestion();
            objSuggestion.ID = Request.Form["suggestion.ID"].ToString();
            objSuggestion.FirstName = Request.Form["suggestion.FirstName"].ToString();
            objSuggestion.LastName = Request.Form["suggestion.LastName"].ToString();
            objSuggestion.Description = Request.Form["suggestion.Description"].ToString();
            objSuggestion.Location = Request.Form["suggestion.Location"].ToString();
            objSuggestion.Area = Request.Form["suggestion.Area"].ToString();
            objSuggestion.Phone = Request.Form["suggestion.Phone"].ToString();
            objSuggestion.ProjectName = Request.Form["suggestion.ProjectName"].ToString();
            if (types != null && types.Length == 1)
            {
                flag = types[0];
            }
            else if(types != null && types.Length == 2)
            {
                flag = 3;
            }
 
            DBDal dal = new DBDal();
            if (ModelState.IsValid && flag != 0)
            {
                objSuggestion.Type = flag;
                dal.Suggestions.Add(objSuggestion);
                dal.SaveChanges();
                suggestvm.suggestion = new Suggestion();
            }
            else
                suggestvm.suggestion = objSuggestion;

            return View("SuggestProject", suggestvm);
        }


        [HttpPost]
        public JsonResult IDExist([Bind(Prefix = "worker.ID")]string ID)
        {
            DBDal dal = new DBDal();
            return Json(!dal.Workers.Any(user => user.ID == ID), JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult UserNameExist([Bind(Prefix = "worker.UserName")]string UserName)
        {       
            DBDal dal = new DBDal();
            return Json(!dal.Users.Any(user => user.UserName == UserName),JsonRequestBehavior.AllowGet);
        }
    }
}