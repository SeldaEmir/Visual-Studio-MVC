using aspnet_mvc_ef_codefirst.Models;
using aspnet_mvc_ef_codefirst.Models.Manages;
using aspnet_mvc_ef_codefirst.ViewModels.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace aspnet_mvc_ef_codefirst.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult homepage()
        {
            DatabaseContext db = new DatabaseContext();
            //List<Kisiler> kisiler = db.Kisiler.ToList();  //select * from kisiler
           

            HomePageViewModel model = new HomePageViewModel();
            model.Kisiler = db.Kisiler.ToList();
            model.Adresler = db.Adresler.ToList();
            return View(model);
        }
    }
}