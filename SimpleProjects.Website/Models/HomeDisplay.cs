using SimpleProjects.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleProjects.Website.Models
{
    public class HomeDisplay
    {

        public IEnumerable<Project> Projects { get; set; }
        
    }
}
