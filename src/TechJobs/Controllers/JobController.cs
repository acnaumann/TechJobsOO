using Microsoft.AspNetCore.Mvc;
using TechJobs.Data;
using TechJobs.Models;
using TechJobs.ViewModels;

namespace TechJobs.Controllers
{
    public class JobController : Controller
    {

        // Our reference to the data store
        private static JobData jobData;

        static JobController()
        {
            jobData = JobData.GetInstance();
        }

        // The detail display for a given Job at URLs like /Job?id=17
        public IActionResult Index(int id)
        {
            // TODO #1 - get the Job with the given ID and pass it into the view

            Job job = jobData.Find(id);
            return View(job);
        }

        public IActionResult New()
        {
            NewJobViewModel newJobViewModel = new NewJobViewModel();
            return View(newJobViewModel);
        }

        [HttpPost]
        public IActionResult New(NewJobViewModel newJobViewModel)
        {
            Job job = new Job();

            ///start
            if (ModelState.IsValid)
            {
                
                job.Name = newJobViewModel.Name;
                Employer employer = jobData.Employers.Find(newJobViewModel.EmployerID);
                //job.Employer = newJobViewModel.Employer;
                //job.Location = newJobViewModel.Location;
                //job.CoreCompetency = newJobViewModel.CoreCompetency;





                //    //Employer thisEmployer = new Employer();

                //    //foreach (var testEmployer in newJobViewModel.Employers)
                //    //{
                //    //    if (testEmployer.Value == newJobViewModel.EmployerID.ToString())
                //    //    {
                //    //        thisEmployer.ID = newJobViewModel.EmployerID;
                //    //        thisEmployer.Value = newJobViewModel.Name;
                //    //    }
                //    //}

                //    //job.Employer = thisEmployer;
                //    //// end


                //    
                //    job.Location = newJobViewModel.Location;

                jobData.Jobs.Add(job);
                //    return Redirect("Index");
            }
            // TODO #6 - Validate the ViewModel and if valid, create a 
            // new Job and add it to the JobData data store. Then
            // redirect to the Job detail (Index) action/view for the new Job.

            return Redirect("Index" + job);
            //return View(newJobViewModel);
        }
    }
}
