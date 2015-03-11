using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.DataLayer;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly JobRepository jobRepository;
        
        public HomeController()
        {
            jobboardEntities context = new jobboardEntities();
            jobRepository = new JobRepository(context);
        }

        public ActionResult Index()
        {

            JobListModel model = new JobListModel();
            model.Jobs = jobRepository.GetJobListing()
                .Select(x => new Models.Job
                {
                    Description = x.JobDescription,
                    JobId = x.jobid,
                    Title = x.JobTitle
                }).ToList();


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


        [HttpPost]
        public ActionResult CreateJob()
        {
            string JobTitle = Request.Form["JobTitle"];
            string JobDescription = Request.Form["JobDescription"];
            
            // Save the Job
            bool bSaved = true;
            // TODO: Call the repository Method here

            if (bSaved)
                ViewBag.Message = "Succeeded";
            else
                ViewBag.Message = "Failed";

            return RedirectToAction("Index", "Home");
        }

    }
}