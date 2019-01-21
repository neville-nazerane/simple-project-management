using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleProjects.Services;
using SimpleProjects.Website.Models;

namespace SimpleProjects.Website.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProjectRepository projectRepository;

        public HomeController(IProjectRepository projectRepository)
        {
            this.projectRepository = projectRepository;
        }

        public IActionResult Index() 
            => View(new HomeDisplay {
                Projects = projectRepository.GetFull()
            });

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
