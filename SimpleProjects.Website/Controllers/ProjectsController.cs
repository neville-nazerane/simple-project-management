using Microsoft.AspNetCore.Mvc;
using SimpleProjects.Core.Models;
using SimpleProjects.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleProjects.Website.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly IProjectRepository repository;

        public ProjectsController(IProjectRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IActionResult Add() => View(new ProjectAdd { StartingDate = DateTime.Now });

        [HttpPost]
        public IActionResult Add(ProjectAdd project)
        {
            if (!ModelState.IsValid) return View(project);
            repository.Add(project);
            return Redirect("~/");
        }

        [HttpGet]
        public IActionResult Update(int id) => View(repository.GetUpdate(id));

        [HttpPost]
        public IActionResult Update(ProjectUpdate project)
        {
            if (!ModelState.IsValid) return View(project);
            repository.Update(project);
            return Redirect("~/");
        }

        [HttpGet]
        public IActionResult Delete(int id) => View(repository.Get(id));

        [HttpPost, ActionName(nameof(Delete))]
        public IActionResult DeletePost(int id)
        {
            repository.Delete(id);
            return Redirect("~/");
        }

    }
}
