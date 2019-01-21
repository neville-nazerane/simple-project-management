using SimpleProjects.Core.Entities;
using SimpleProjects.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleProjects.Services
{
    public interface IProjectTaskRepository
    {

        ProjectTask Add(ProjectTaskAdd project);

        ProjectTask Update(ProjectTaskUpdate project);

        ProjectTask Get(int id);
        ProjectTask GetWithProject(int id);

        IEnumerable<ProjectTask> GetByProject(int projectId);

        bool Delete(int id);

        ProjectTaskUpdate GetUpdate(int id);

        string GetProjectTitle(int id);
    }
}
