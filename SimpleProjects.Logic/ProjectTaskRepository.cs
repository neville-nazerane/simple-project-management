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
    class ProjectTaskRepository : IProjectTaskRepository
    {
        private readonly AppDbContext context;

        public ProjectTaskRepository(AppDbContext context)
        {
            this.context = context;
        }

        public ProjectTask Add(ProjectTaskAdd project)
        {
            var toAdd = project.ToProjectTask();
            context.Add(toAdd);
            context.SaveChanges();
            return toAdd;
        }

        public ProjectTask Update(ProjectTaskUpdate project)
        {
            var toEdit = context.ProjectTasks.SingleOrDefault(p => p.Id == project.Id);
            if (toEdit != null)
            {
                toEdit.SetFrom(project);
                context.SaveChanges();
            }
            return toEdit;
        }

        public bool Delete(int id)
        {
            var toDelete = context.ProjectTasks.SingleOrDefault(p => p.Id == id);
            if (toDelete == null) return false;
            context.Remove(toDelete);
            context.SaveChanges();
            return true;
        }

        public ProjectTask Get(int id) => context.ProjectTasks.AsNoTracking().SingleOrDefault(p => p.Id == id);

        public IEnumerable<ProjectTask> GetByProject(int projectId)
            => context.ProjectTasks.AsNoTracking().Where(t => t.ProjectId == projectId).ToArray();

        public ProjectTaskUpdate GetUpdate(int id) => Get(id).ToUpdate();

        public string GetProjectTitle(int id)
            => (from t in context.ProjectTasks
               where t.Id == id
               select t.Project.Title).SingleOrDefault();

        public ProjectTask GetWithProject(int id)
            => context.ProjectTasks.AsNoTracking()
                        .Include(p => p.Project).SingleOrDefault(p => p.Id == id);

    }
}
