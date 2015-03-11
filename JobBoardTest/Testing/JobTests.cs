#region using

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication1.DataLayer;

#endregion

namespace Testing
{
    [TestClass]
    public class JobTests
    {
        [TestMethod]
        public void GetJobsSuccess()
        {
            jobboardEntities dbContext = new jobboardEntities();

            JobRepository jobRepository = new JobRepository(dbContext);

            var x = jobRepository.GetJobListing();
        }
    }
}
