﻿#region using

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

#endregion

namespace WebApplication1.DataLayer
{
    public class JobRepository
    {
        private jobboardEntities _dbContext;

        #region Constructor

        public JobRepository(jobboardEntities dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion


        #region Read Methods

        public Job GetJob(int jobId)
        {
            Job result = null;

            result = (from c in _dbContext.Jobs
                      where c.jobid == jobId
                      select c).FirstOrDefault();

            return result;
        }

        public List<Job> GetJobListing()
        {
            List<Job> result = null;

            result = (from c in _dbContext.Jobs
                      select c).ToList();

            return result;
        }

        #endregion


        #region Create Methods

        public Job CreateJob(string jobTitle, string jobDescription)
        {
            Job job = new Job()
            {
                JobTitle = jobTitle
                , JobDescription = jobDescription
            };

            try
            {
                _dbContext.Jobs.Add(job);
                _dbContext.SaveChanges();
                return job;
            }
            catch
            {

            }

            return null;
        }

        #endregion


        #region Update Methods

        #endregion


        #region Delete Methods

        public bool DeleteJob(int jobid)
        {
            Job j = (from x in _dbContext.Jobs
                         where x.jobid == jobid
                         select x).SingleOrDefault();
            if (j != null)
            {
                try
                {
                    _dbContext.Jobs.Remove(j);
                    _dbContext.SaveChanges();
                    return true;
                }
                catch
                {

                }
            }
            return false;
        }

        #endregion
    }
}