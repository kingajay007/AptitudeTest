using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aptitude.Models
{
  
    public class QuestionMap
    {
        private int? id;

        
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public int ExamId { get; set; }
        [NotMapped]
        public List<SelectListItem> Questions { get; set; }
        [NotMapped]
        public List<SelectListItem> Exams { get; set; }

        public virtual Exam Exam { get; set; }
        public virtual Question Question { get; set; }
    }
}