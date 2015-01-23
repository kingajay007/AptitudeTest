using Aptitude.Models;
using Aptitude.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aptitude.Controllers
{
    public class QuestionController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Question
        public ActionResult Index()
        {
            return View(db.Questions);
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
            return View();
        }

        // POST: Question/Create
        [Authorize]
        [HttpPost]
        public ActionResult Create(Question Question)
        {
            try
            {
                 //TODO: Add insert logic here
                QuestionService service = new QuestionService();
                service.CreateQuestion(Question);
                //db.Questions.Add(Question);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Question/Edit/5
        public ActionResult Edit(int id)
        {
            Question question = db.Questions.Find(id);
            var choices = db.Choices.Where(x=>x.QuestionId ==id);
            foreach (Choice item in choices)
            {
                question.Options.Add(item);
            }
            return View(question);
        }

        // POST: Question/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Question Question)
        {
            try
            {
                new QuestionService().UpdateQuestion(Question);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("Edit");
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
