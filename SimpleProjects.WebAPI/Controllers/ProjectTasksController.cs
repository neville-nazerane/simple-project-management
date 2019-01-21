using Microsoft.AspNetCore.Mvc;
using SimpleProjects.Services;
using SimpleProjects.Core.Entities;
using SimpleProjects.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleProjects.WebAPI.Controllers
{

    [ApiController, Route("[controller]")]
    public class ProjectTasksController : Controller
    {
        private readonly IProjectTaskRepository repository;

        public ProjectTasksController(IProjectTaskRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProjectTask>> GetByProject(int projectId) => Ok(repository.GetByProject(projectId));

        [HttpGet("{id}")]
        public ActionResult<ProjectTask> Get(int id) => repository.Get(id);

        [HttpPost]
        public ActionResult<ProjectTask> Add(ProjectTaskAdd task) => repository.Add(task);

        [HttpPut]
        public ActionResult<ProjectTask> Update(ProjectTaskUpdate task) => repository.Update(task);

        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id) => repository.Delete(id);

    }
}
