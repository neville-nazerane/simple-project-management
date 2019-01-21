using Microsoft.AspNetCore.Mvc;
using SimpleProjects.Core.Models;
using SimpleProjects.Services;
using SimpleProjects.Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleProjects.Website.Controllers
{
    public class ProjectTasksController : Controller
    {
        private readonly IProjectTaskRepository repository;
        private readonly IProjectRepository projectRepository;

        public ProjectTasksController(IProjectTaskRepository repository, IProjectRepository projectRepository)
        {
            this.repository = repository;
            this.projectRepository = projectRepository;
        }

        [HttpGet]
        public IActionResult Add(int projectId) => View(new ProjectTaskAddDisplay {
            ProjectTitle = projectRepository.GetTitle(projectId),
            Data = new ProjectTaskAdd {
                ProjectId = projectId
            }
        });

        [HttpPost]
        public IActionResult Add(ProjectTaskAddDisplay display)
        {
            if (!ModelState.IsValid) return View(display);
            repository.Add(display.Data);
            return Redirect("~/");
        }

        [HttpGet]
        public IActionResult Update(int id) => View(new ProjectTaskUpdateDisplay {
            ProjectTitle = repository.GetProjectTitle(id),
            Data = repository.GetUpdate(id)
        });

        [HttpPost]
        public IActionResult Update(ProjectTaskUpdateDisplay display)
        {
            if (!ModelState.IsValid) return View();
            repository.Update(display.Data);
            return Redirect("~/");
        }

        [HttpGet]
        public IActionResult Delete(int id) => View(repository.GetWithProject(id));

        [HttpPost, ActionName(nameof(Delete))]
        public IActionResult DeletePost(int id)
        {
            repository.Delete(id);
            return Redirect("~/");
        }

    }
}
