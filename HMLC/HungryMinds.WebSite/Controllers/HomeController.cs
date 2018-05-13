using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HungryMinds.Business;
using HungryMinds.WebSite.Models;

namespace HungryMinds.WebSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICourseManager courseManager;
        private readonly IUserManager userManager;
        private readonly IEnrollmentManager enrollmentManager;
       
        public HomeController(ICourseManager courseManager, IUserManager userManager, IEnrollmentManager enrollmentManger)
        {
            this.courseManager = courseManager;
            this.userManager = userManager;
           
        }
        public ActionResult Index()
        {
            var courses = courseManager.Courses
                                      .Select(t => new HungryMinds.WebSite.Models.CourseModel(t.Id, t.Name))
                                      .ToArray();
            var model = new IndexModel { Courses = courses };
            return View(model);

            

        }

        public ActionResult CourseListings()
        {
            var courses = courseManager.Courses
                                  .Select(t => new HungryMinds.WebSite.Models.CourseModel(t.Id, t.Name))
                                  .ToArray();
            var model = new IndexModel { Courses = courses };
            return View(model);
        }

        public ActionResult LogIn()
        {
            return View();
        }

        public ActionResult CourseListingsPerUser()
        {
            var courses = courseManager.Courses
                                 .Select(t => new HungryMinds.WebSite.Models.CourseModel(t.Id, t.Name))
                                 .ToArray();
            var user = (LoginModel)Session["User"];
            var model = new IndexModel { Courses = courses };

           
            return View(model);
        }

        [HttpPost]
        public ActionResult EnrollInCourse()
        {
            var user = (LoginModel)Session["User"];
            if (user == null)
            {
                ModelState.AddModelError("", "Please log in.");
            }
            else
            {

                var enrolled = userManager.GetEnrolledCourses(user.UserName).ToList();
               
              //  var model = new IndexModel { Courses = enrolled};
            }
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(LoginModel loginModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = userManager.LogIn(loginModel.UserName, loginModel.Password);
                                

                if (user == null)
                {
                    ModelState.AddModelError("", "User name and password do not match.");
                }
                else
                {
                    Session["User"] = new Models.LoginModel { Id = user.Id, UserName = user.Name };

                    System.Web.Security.FormsAuthentication.SetAuthCookie(loginModel.UserName, false);

                    return Redirect(returnUrl ?? "~/");
                }
            }

            return View(loginModel);
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(LoginModel loginModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = userManager.Register(loginModel.UserName, loginModel.Password);

                if (user == null)
                {
                    ModelState.AddModelError("", "User name and password do not match.");
                }
                else
                {
                    Session["User"] = new Models.LoginModel { Id = user.Id, UserName = user.Name };

                    System.Web.Security.FormsAuthentication.SetAuthCookie(loginModel.UserName, false);

                    return Redirect(returnUrl ?? "~/");
                }
            }
            return View(loginModel);
        }

        public ActionResult LogOff()
        {
            Session["User"] = null;
            System.Web.Security.FormsAuthentication.SignOut();

            return Redirect("~/");
        }

     
    }
}