using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Aptitude.Models
{
    public class Question
    {
        public int Id { get; set; }
        [Required]
        public string Query { get; set; }
        [Display(Name = "Number of Options")]

        [Required]
        public string Tags { get; set; }
        [NotMapped]
        public Choice[] Choice { get; set; }
        [NotMapped]
        public bool IsIncluded { get; set; }

        public virtual ICollection<Choice> Options { get; set; }

    }
}