using SimpleProjects.Core.Entities;
using SimpleProjects.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleProjects.Core.Mapping
{
    public static class ProjectTaskMappingExtensions
    {

        public static ProjectTask ToProjectTask(this ProjectTaskAdd add)
            => new ProjectTask {
                Title = add.Title,
                ProjectId = add.ProjectId,
                DeadLine = add.DeadLine,
                IsCompleted = add.IsCompleted
            };

        public static void SetFrom(this ProjectTask projectTask, ProjectTaskUpdate update)
        {
            projectTask.Title = update.Title;
            projectTask.DeadLine = update.DeadLine;
            projectTask.IsCompleted = update.IsCompleted;
        }

        public static ProjectTaskUpdate ToUpdate(this ProjectTask task)
            => new ProjectTaskUpdate
            {
                Id = task.Id,
                Title = task.Title,
                DeadLine = task.DeadLine,
                IsCompleted = task.IsCompleted
            };
    }
}
