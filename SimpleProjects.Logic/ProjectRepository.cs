using SimpleProjects.Core.Entities;
using SimpleProjects.Core.Models;
using SimpleProjects.Services;
using System;
using System.Collections.Generic;
using System.Text;
using SimpleProjects.Core.Mapping;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SimpleProjects.Logic
{
    class ProjectRepository : IProjectRepository
    {
        private readonly AppDbContext context;

        public ProjectRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Project Add(ProjectAdd project)
        {
            var toAdd = project.ToProject();
            context.Add(toAdd);
            context.SaveChanges();
            return toAdd;
        }

        public Project Update(ProjectUpdate project)
        {
            var toEdit = context.Projects.SingleOrDefault(p => p.Id == project.Id);
            if (toEdit != null)
            {
                toEdit.SetFrom(project);
                context.SaveChanges();
            }
            return toEdit;
        }

        public bool Delete(int id)
        {
            var toDelete = context.Projects.SingleOrDefault(p => p.Id == id);
            if (toDelete == null) return false;
            context.Remove(toDelete);
            context.SaveChanges();
            return true;
        }

        public Project Get(int id) => context.Projects.AsNoTracking().SingleOrDefault(p => p.Id == id);

        public IEnumerable<Project> Get() => context.Projects.AsNoTracking().ToArray();

        public IEnumerable<Project> GetFull()
            => context.Projects.Include(p => p.ProjectTasks).AsNoTracking().ToArray();

        public string GetTitle(int id)
            => (from p in context.Projects
                where p.Id == id
                select p.Title).SingleOrDefault();

        public ProjectUpdate GetUpdate(int id) => Get(id).ToUpdate();
    }
}
