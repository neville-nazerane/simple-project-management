using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SimpleProjects.Core.Models
{
    public class ProjectTaskAdd
    {

        [Required, MaxLength(60)]
        public string Title { get; set; }

        public int ProjectId { get; set; }

        public bool IsCompleted { get; set; }

        [Required, DataType(DataType.Date)]
        public DateTime? DeadLine { get; set; }


    }
}
