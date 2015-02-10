using Aptitude.Models;
using Aptitude.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Aptitude.Controllers
{
    [Authorize]
    public class QuestionController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Question
        public ActionResult Index( string searchString)
        {

            if (string.IsNullOrEmpty(searchString) && string.IsNullOrWhiteSpace(searchString))
            {
                searchString = "";
            }
            return View(db.Questions.Where(x=>x.Query.Contains(searchString)));
        }

        // GET: Question/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [Authorize]
        // GET: Question/Create
        public ActionResult Create()
        {
            ViewBag.Categories = db.Categories.ToList();
            return View();
        }

        // POST: Question/Create
        [Authorize]
        [HttpPost]
        public ActionResult Create(Question Question)
        {
            try
            {
                var categories = db.Categories.ToArray();
                for (int i = 0; i < Question.Category.Length;i++ )
                {
                    Question.Category[i].Id = categories[i].Id;
                }

                
                QuestionService service = new QuestionService();
                service.CreateQuestion(Question);
               
                service.AddCategoryToQuestion(Question.Category, Question.Id, db);
                ViewBag.Question = Question;
                TempData["Question"] = ViewBag.Question as Question;
                return RedirectToAction("AddChoice");
                
            }
            catch
            {
                return View();
            }
        }

        
        [HttpGet]
        public ActionResult AddChoice()
        {
            Question Question = TempData["Question"] as Question;
            return View(Question);
        }

        [HttpPost]
        public ActionResult AddChoice(Question Question)
        {
            QuestionService service = new QuestionService();
            service.AddChoiceToQuestion(Question.Choice,Question.Id,db);
            TempData["Question"] = null;
            return View("Index",db.Questions);
        }

        // GET: Question/Edit/5
        public ActionResult Edit(int id)
        {
            Question question = db.Questions.Find(id);
            //question.Choice = db.Choices.Where(x => x.QuestionId == id).ToArray() ;
            var questionCategory = db.QuestionCategories.Where(x => x.QuestionId == question.Id).ToList();

            //foreach (var item in question.Categories)
            //{
            //    item.IsIncluded = true;
            //}
            var Categories = db.Categories.ToList() ;
            foreach (var item in Categories)
            {

                if (questionCategory.Any(x=>x.CategoryId==item.Id))
                {
                    item.IsIncluded = true;
                    
                }
                item.Questions = null;
                
                
            }

            question.Category = Categories.ToArray();
           
            return View(question);
        }

        // POST: Question/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Question Question)
        {
            try
            {
                
                var categories = db.Categories.ToArray();
                for (int i = 0; i < Question.Category.Count(); i++)
                {
                    Question.Category[i].Id = categories[i].Id;
                    
                }
                QuestionService service = new QuestionService();
                service.UpdateQuestion(Question,db);
                //EditQuestion.Choice = db.Choices.Where(x => x.QuestionId == Question.Id).ToArray(); ;
                service.UpdateCategoryToQuestion(Question,db);
                //TempData["EditQuestion"] = EditQuestion;
                
                return RedirectToAction("EditChoice",Question);
            }
            catch
            {
                return View("Edit");
            }
        }

        [HttpGet]
        public ActionResult EditChoice(int Id)
        {
            //Question Question = TempData["EditQuestion"] as Question;
            Question Question = db.Questions.Find(Id);
            Question.Choice = db.Choices.Where(x => x.QuestionId == Id).ToArray(); ;
            if (Question.Choice.ToArray().Count()==0 || (Question.Choice.ToArray().Count()<Question.NumberOfOptions))
            {
                Question.Choice = new Choice[Question.NumberOfOptions];
                for (int i = 0; i < Question.NumberOfOptions; i++)
                {
                    
                  Question.Choice[i]= new  Choice {CorrectOption=false,Option=" " };
                }
            }
            return View(Question);
        }

        [HttpPost]
        public ActionResult EditChoice(int Id, Question Question)
        {
            try
            {
                new QuestionService().UpdateChoiceToQuestion(Question, db);
                //TempData["EditQuestion"] = null;
                return View("Index",db.Questions);
            }
            catch (Exception ex)
            {
                return View("EditChoice",Question);
            }
            
        }

        // GET: Question/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Question/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
