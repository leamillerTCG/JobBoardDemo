using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            JobListModel model = new JobListModel();
            model.Jobs = new List<Job>
            {
                new Job { JobId = 1, Description = "desc 1", Title = "title 1" },
                new Job { JobId = 2, Description = "desc 2", Title = "title 2" },
                new Job { JobId = 3, Description = "desc 3", Title = "title 3" }
            };
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}