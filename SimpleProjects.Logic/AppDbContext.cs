using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using SimpleProjects.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleProjects.Logic
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Project> Projects { get; set; }

        public DbSet<ProjectTask> ProjectTasks { get; set; }

    }
}
