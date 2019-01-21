using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SimpleProjects.Core.Entities
{
    public class ProjectTask
    {

        public int Id { get; set; }

        [Required, MaxLength(60)]
        public string Title { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }

        public bool IsCompleted { get; set; }

        [Required, DataType(DataType.Date)]
        public DateTime? DeadLine { get; set; }

    }
}
