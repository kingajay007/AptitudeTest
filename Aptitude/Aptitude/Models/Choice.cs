using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Aptitude.Models
{
    public class Choice
    {
        public int Id { get; set; }
        [Display(Name = "Option")]
        [Required]
        public string Option { get; set; }
        [Display(Name = "Correct Option")]
        // [Required]
        public bool CorrectOption { get; set; }

        public virtual Question Question { get; set; }
        public int QuestionId { get; set; }
    }
}