using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class JobListModel
    {
        public List<Job> Jobs { get; set; }
        public DataLayer.Job JobInfo { get; set; }
    }

    public class Job
    {
        public int JobId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}