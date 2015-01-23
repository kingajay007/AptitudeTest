using Aptitude.Models;
using Aptitude.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aptitude.Services
{
    public class QuestionService
    {
        /// <summary>
        /// method to create a question with options
        /// </summary>
        /// <param name="Question"></param>
        /// <returns></returns>
        public bool CreateQuestion(Question Question)
        {
            try
            {
                using (ApplicationDbContext context = new ApplicationDbContext())
                {
                    if (Question.Choice.Where(x => x.CorrectOption == true).Count() >0)
                    {
                        context.Questions.Add(Question);
                        context.SaveChanges();
                        foreach (Choice choice in Question.Choice)
                        {
                            choice.QuestionId = Question.Id;
                            context.Choices.Add(choice);
                        }
                        context.Questions.Add(Question);
                        context.SaveChanges();
                        return true;
                    }
                    else throw new Exception("Atleast One option must be correct");
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public bool UpdateQuestion(Question Question)
        {

            try
            {
                using (ApplicationDbContext context = new ApplicationDbContext())
                {
                    Question question = context.Questions.Find(Question.Id);
                    var choices = context.Choices.Where(x=>x.QuestionId==Question.Id).ToArray();
                    if (Question.Choice.Where(x => x.CorrectOption == true).Count() > 0)
                    {
                        question.Query = Question.Query;
                        for (int i = 0; i < choices.Length; i++)
                        {
                            choices[i].Option = Question.Choice[i].Option;
                            choices[i].CorrectOption = Question.Choice[i].CorrectOption;
                        }

                        //foreach (Choice choice in Question.Choice)
                        //{
                        //    choice.QuestionId = Question.Id;
                        //    context.Choices.Add(choice);
                        //}
                        //context.Questions.Add(Question);
                        context.SaveChanges();
                        return true;
                    }
                    else throw new Exception("Atleast One option must be correct");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }

    
}