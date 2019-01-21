using SimpleProjects.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SimpleProjects.Core.Models
{
    public class ProjectAdd
    {

        [Required, MaxLength(50)]
        public string Title { get; set; }

        [MaxLength(200), DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public bool IsCompleted { get; set; }

        [Required, DataType(DataType.Date)]
        public DateTime? StartingDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ClosingDate { get; set; }

    }
}
