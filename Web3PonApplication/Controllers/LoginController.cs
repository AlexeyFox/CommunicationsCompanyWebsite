using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web3PonApplication.Models;
using Web3PonApplication.Dal;
using System.Web.Security;
using System.Security.Principal;

namespace Web3PonApplication.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View("Login");
        }

        public ActionResult Authentication(User user)
        {
            DBDal dal = new DBDal();
            /*
            if (ModelState.I)
            {*/
                List<User> userVal = (from u in dal.Users
                                      where (u.UserName == user.UserName) && (u.Password == user.Password)
                                      select u).ToList<User>();
                if(userVal.Count == 1)
                {     
                    List<Worker> workerVal = (from u in dal.Workers
                                          where (u.UserName == user.UserName)
                                          select u).ToList<Worker>();

                    if(workerVal.Count == 1)
                    {
                        FormsAuthentication.SetAuthCookie("" + userVal.Last().UserName + "|" + workerVal.Last().FirstName + " " + workerVal.Last().LastName + "|" + userVal.Last().Permission.ToString(), true);
                    }
                    return RedirectToRoute("DefaultPage");
                }
                return View("Login", user);
                /*
            }
            else
                return View("Login",user);
                */
        }

        public ActionResult Singout()
        {
            return View("Logout");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToRoute("DefaultPage");
        }



        void GetUserData()
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if(authCookie != null)
            {
                FormsAuthenticationTicket aticket = FormsAuthentication.Decrypt(authCookie.Value);
                var identity = new GenericIdentity(aticket.Name, "Forms");

            }
            
        }
    }
}