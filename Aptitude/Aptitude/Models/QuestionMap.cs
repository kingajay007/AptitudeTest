using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Aptitude.Models
{
    /// <summary>
    /// class for Question
    /// </summary>
    

    /// <summary>
    /// Class for Choice
    /// </summary>
    

    

    /// <summary>
    /// class for Exam
    /// </summary>
    

    /// <summary>
    /// Exam-Question Mapping Class
    /// </summary>
    public class QuestionMap
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public int ExamId { get; set; }

        public virtual Exam Exam { get; set; }
        public virtual Question Question { get; set; }
    }
}