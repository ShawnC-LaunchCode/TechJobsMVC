﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechJobsMVC.Models;
using TechJobsMVC.Data;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobsMVC.Controllers
{
    public class SearchController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.columns = ListController.ColumnChoices;
            //ViewBag.jobs = JobData.FindAll();
            return View();
        }

        // TODO #3: Create an action method to process a search request and render the updated search view. 

        //[HttpPost]
        public IActionResult Results(string searchType, string searchTerm)
        {
            List<Job> output = new List<Job>();


            if (string.IsNullOrEmpty(searchTerm) ) { output = JobData.FindAll(); }
            else {output = JobData.FindByColumnAndValue(searchType, searchTerm);}

            ViewBag.jobs = output;

            ViewBag.columns = ListController.ColumnChoices;


            return View("Index");

        }

    }
}
