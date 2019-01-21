using Microsoft.EntityFrameworkCore;
using SimpleProjects.Logic;
using SimpleProjects.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class LogicExtensions
    {

        public static IServiceCollection AddDbContext(this IServiceCollection services,
                                                            Action<DbContextOptionsBuilder> options) 
            => services.AddDbContext<AppDbContext>(options);

        public static IServiceCollection AddLogic(this IServiceCollection services)
            => services.AddScoped<IProjectRepository, ProjectRepository>()
                       .AddScoped<IProjectTaskRepository, ProjectTaskRepository>();

    }
}
