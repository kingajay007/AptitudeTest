using Aptitude.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aptitude.Services
{
    public class ExamService
    {
        /// <summary>
        /// Method to add questionsin an exam
        /// </summary>
        /// <param name="Questions"></param>
        /// <param name="Exam"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public bool AddQuestionsToExam(List<Question> Questions, Exam Exam, ApplicationDbContext context)
        {
            try
            {
                if (Questions.Where(x => x.IsIncluded == true).Count() > 0)
                {
                    List<QuestionMap> questionMappings = new List<QuestionMap>();
                    foreach (var question in Questions)
                    {
                        context.QuestionMaps.Add(new QuestionMap()
                        {
                            QuestionId = question.Id,
                            ExamId = Exam.Id
                        });
                        context.SaveChanges();
                        return true;
                    }
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    throw new Exception("Select Atleast 1 Question");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool CreateExam(Exam exam, ApplicationDbContext context)
        {
            try
            {
                context.Exams.Add(exam);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                context.Dispose();
                throw ex;
            }
        }
    }
}