using Aptitude.Models;
using Aptitude.Models;
using Aptitude.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aptitude.Controllers
{
    public class ExamController : Controller
    {
        private ApplicationDbContext context = new ApplicationDbContext();
        // GET: Exam
        public ActionResult Index()
        {
            return View(context.Exams);
        }

        // GET: Exam/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Exam/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Exam/Create
        [HttpPost]
        public ActionResult Create(Exam Exam)
        {
            try
            {
                // TODO: Add insert logic here
                new ExamService().CreateExam(Exam,context);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Exam/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Exam/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //Add questions to exam
        public ActionResult AddQuestionToExam()
        {
            var questions = context.Questions;
            List<Question> selectQuestions = new List<Question>();
            foreach (var item in questions)
            {
                selectQuestions.Add(item);
            }
            return View(selectQuestions);
        }
    }
}
