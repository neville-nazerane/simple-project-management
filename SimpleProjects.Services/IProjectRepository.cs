using SimpleProjects.Core.Entities;
using SimpleProjects.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleProjects.Services
{
    public interface IProjectRepository
    {

        Project Add(ProjectAdd project);

        Project Update(ProjectUpdate project);

        Project Get(int id);
        ProjectUpdate GetUpdate(int id);
        string GetTitle(int id);

        IEnumerable<Project> Get();
        IEnumerable<Project> GetFull();

        bool Delete(int id);
    }
}
