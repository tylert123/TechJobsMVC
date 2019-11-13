using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            return View();
        }

        // TODO #1 - Create a Results action method to process 
        // search request and display results

        //[Route ("/Search/Index")]
        public IActionResult Results(string searchType, string searchTerm)
        {
            ViewBag.columns = ListController.columnChoices;

            if (searchType.Equals("all"))
            {
                List<Dictionary<string, string>> jobs = JobData.FindByValue(searchTerm);
                ViewBag.title = "All " + searchTerm.First().ToString().ToUpper() + searchTerm.Substring(1) + " Jobs";
                ViewBag.searchType = searchType;
                ViewBag.jobs = jobs;
                return View("Index");
            }
            else
            {
                List<Dictionary<string, string>> jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
                ViewBag.title = searchTerm.First().ToString().ToUpper() + searchTerm.Substring(1) + " " + ListController.columnChoices[searchType] + " Jobs";
                ViewBag.searchType = searchType;
                ViewBag.jobs = jobs;
                return View("Index");
            }
        }

    }
}
