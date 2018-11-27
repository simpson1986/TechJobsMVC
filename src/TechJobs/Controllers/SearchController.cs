using System.Collections.Generic;
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
        [HttpGet]
        public IActionResult Results(string searchType, string searchTerm)
        {
            List<Dictionary<string, string>> jobs;

            if (string.IsNullOrEmpty(searchTerm))
            {
                return View("Index");
            }
            if (searchType.Equals("all"))
            {
                jobs = JobData.FindByValue(searchTerm);
            }
            else
            {
                jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
            }
            ViewData["jobs"] = jobs;
            ViewData["columns"] = ListController.columnChoices;
            return View("Index");
        }
    }
}
