using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aptitude.Models
{
    public class QuestionCategory
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int QuestionId { get; set; }

        public virtual Question Question { get; set; }
        public virtual Category Category { get; set; }
    }
}