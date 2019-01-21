using SimpleProjects.Core.Entities;
using SimpleProjects.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleProjects.Core.Mapping
{
    public static class ProjectMappingExtensions
    {

        public static Project ToProject(this ProjectAdd add)
            => new Project {
                Title = add.Title,
                Description = add.Description,
                IsCompleted = add.IsCompleted,
                ClosingDate = add.ClosingDate,
                StartingDate = add.StartingDate
            };

        public static void SetFrom(this Project project, ProjectUpdate update)
        {
            project.Title = update.Title;
            project.Description = update.Description;
            project.IsCompleted = update.IsCompleted;
            project.StartingDate = update.StartingDate;
            project.ClosingDate = update.ClosingDate;
        }

        public static ProjectUpdate ToUpdate(this Project project)
          =>  new ProjectUpdate {
                Id = project.Id,
                Title = project.Title,
                Description = project.Description,
                IsCompleted = project.IsCompleted,
                ClosingDate = project.ClosingDate,
                StartingDate = project.StartingDate
            };

}
}
