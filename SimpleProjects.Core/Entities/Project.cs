using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SimpleProjects.Core.Entities
{
    public class Project
    {

        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Title { get; set; }

        [MaxLength(200), DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public bool IsCompleted { get; set; }

        [Required, DataType(DataType.Date)]
        public DateTime? StartingDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ClosingDate { get; set; }

        public IEnumerable<ProjectTask> ProjectTasks { get; set; }
    } 
}
