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

        [HttpGet]
        public ActionResult Create()
        {
            return View("CreateJob");
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {

            JobListModel model = new JobListModel();
            model.JobInfo = jobRepository.GetJob(id);
         
            return View(model);
        }


        [HttpPost]
        public ActionResult EditJob()
        {
            string JobTitle = Request.Form["JobTitle"];
            string JobDescription = Request.Form["JobDescription"];
            int Jobid =Convert.ToInt32(Request.Form["JobID"]);
            // Save the Job

            bool bSaved = jobRepository.UpdateJob(JobTitle, JobDescription,Jobid);

            if (bSaved)
                ViewBag.Message = "Succeeded";
            else
                ViewBag.Message = "Failed";

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult CreateJob()
        {
            string JobTitle = Request.Form["JobTitle"];
            string JobDescription = Request.Form["JobDescription"];
            
            // Save the Job
            
            WebApplication1.DataLayer.Job _job = jobRepository.CreateJob(JobTitle,JobDescription);

            if (_job != null)
                ViewBag.Message = "Succeeded";
            else
                ViewBag.Message = "Failed";

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            bool bDeleted = jobRepository.DeleteJob(id);
            if (bDeleted)
                ViewBag.Message = "Succeeded";
            else
                ViewBag.Message = "Failed";

            return RedirectToAction("Index", "Home");
        }

    }
}