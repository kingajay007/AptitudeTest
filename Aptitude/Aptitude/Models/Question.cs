using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Aptitude.Models
{
    public class Question
    {

        public Question()
        {
        }

        public int Id { get; set; }

        public string Directions { get; set; }
        [Required]
        public string Query { get; set; }
        [Display(Name = "Number of Options")]
        public int NumberOfOptions { get; set; }
        [Required]
        public string Tags { get; set; }
        [NotMapped]
        public Choice[] Choice { get; set; }
        [NotMapped]
        public Category[] Category { get; set; }
        [NotMapped]
        public bool IsIncluded { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<Choice> Options { get; set; }

    }
}