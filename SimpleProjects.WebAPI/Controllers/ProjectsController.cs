using Microsoft.AspNetCore.Mvc;
using SimpleProjects.Core.Entities;
using SimpleProjects.Core.Models;
using SimpleProjects.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleProjects.WebAPI.Controllers
{

    [ApiController, Route("[Controller]")]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectRepository repository;

        public ProjectsController(IProjectRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Project>> Get() => Ok(repository.Get());

        [HttpGet("full")]
        public ActionResult<IEnumerable<Project>> GetFull() => Ok(repository.GetFull());

        [HttpGet("{id}")]
        public ActionResult<Project> Get(int id) => repository.Get(id);

        [HttpPost]
        public ActionResult<Project> Add(ProjectAdd project) => repository.Add(project);

        [HttpPut]
        public ActionResult<Project> Update(ProjectUpdate project) => repository.Update(project);

        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id) => repository.Delete(id);

    }
}
