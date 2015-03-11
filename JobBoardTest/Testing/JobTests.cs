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
    }
}
