using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CardMaker.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult MakeCard()
        {
            return View();
        }
        [HttpPost]
        public ActionResult MakeCard(CardMaker.Models.CardBusiness cardbiz)
        {
            if (ModelState.IsValid)
            {
                return View("MyCard", cardbiz);
            }
            else {
                return View();
            }
        }
    }
}