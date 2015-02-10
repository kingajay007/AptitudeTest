using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Aptitude.Models
{
    [NotMapped]
    public class MapQuestionViewModel
    {
        
        public MapQuestionViewModel(int id)
        {
            this.ExamId = id;
        }
        public int Id { get; set; }
        public int ExamId { get; set; }
        public List<Question> Questions { get; set; }
    }
}