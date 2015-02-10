using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Aptitude.Models
{
    [NotMapped]
    public class AddQuestion
    {
        public Question Question { get; set; }
        public List<Choice> Choices  { get; set; }
        public List<Category> Categories { get; set; }
    }
}