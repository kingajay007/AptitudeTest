using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Aptitude.Models
{
    [Table("Exams", Schema = "dbo")]
    public class Exam
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Code")]
        public String Code { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        public TimeSpan Duration { get; set; }
        [Required]
        [Display(Name = "Maximum Marks")]
        public decimal MaximumMarks { get; set; }
        [Required]
        [Display(Name = "Marks to pass")]
        public decimal MarksToPass { get; set; }
        [Required]
        [Display(Name = "Negative Marking Allowed")]
        public bool IsNegativeMarkingAllowed { get; set; }

        //public ICollection<Question> Questions { get; set; }
    }
}