#region using

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using WebApplication1.DataLayer;

#endregion

namespace Testing
{
    [TestClass]
    public class JobTests
    {
        [TestMethod]
        public void GetJobListsSuccess()
        {
            jobboardEntities dbContext = new jobboardEntities();

            JobRepository jobRepository = new JobRepository(dbContext);

            List<Job> jobs = jobRepository.GetJobListing();

            Assert.IsNotNull(jobs);
        }

        [TestMethod]
        public void CreateJobSuccess()
        {
            jobboardEntities dbContext = new jobboardEntities();

            JobRepository jobRepository = new JobRepository(dbContext);

            string title = "Test Title";
            string description = "Test Description";

            Assert.IsNotNull(jobRepository.CreateJob(title, description));

            //Assert.IsTrue(jobRepository.CreateJob(title, description));
        }

        [TestMethod]
        public void DeleteJobSuccess()
        {
            jobboardEntities dbContext = new jobboardEntities();
            
            JobRepository jobRepository = new JobRepository(dbContext);

            string title = "Test Title - Delete";
            string description = "Test Description - Delete";
            Job j = jobRepository.CreateJob(title, description);
            int jobid = j.jobid;

            //Assert.IsTrue(jobRepository.DeleteJob(j.jobid));

            jobRepository.DeleteJob(j.jobid);

            Assert.IsNull(jobRepository.GetJob(jobid));

        }
    }
}
