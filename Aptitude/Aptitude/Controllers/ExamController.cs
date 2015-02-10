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
    [Authorize]
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
            QuestionMap questionMap = new Models.QuestionMap();
            //if (id.HasValue && id > 0)
            //{
            //    questionMap.Exam = context.Exams.Find(id.GetValueOrDefault());
            //    questionMap.ExamId = id.GetValueOrDefault();
            //    ViewBag.ExamId = id;
            //}
            //else
            questionMap.Exams = new List<SelectListItem>();
            questionMap.Questions = new List<SelectListItem>();

            List<Exam> ExamList = context.Exams.ToList();
            foreach (Exam exam in ExamList)
            {
                questionMap.Exams.Add(new SelectListItem() {Text=exam.Code,Value=exam.Id.ToString() });
            }

            List<Question> QuestionList = context.Questions.ToList();
            foreach (Question question in QuestionList)
            {
                questionMap.Questions.Add(new SelectListItem() {Text=question.Query,Value=question.Id.ToString() });
            }

            
            //var questions = context.Questions;
            //List<Question> selectQuestions = new List<Question>();
            //foreach (var item in questions)
            //{
            //    selectQuestions.Add(item);
            //}
            return View(questionMap);
        }

        [HttpPost]
        public ActionResult AddQuestionToExam(QuestionMap questioMap)
        {

            try
            {
                if (!context.QuestionMaps.Any(x => x.QuestionId == questioMap.QuestionId && x.ExamId == questioMap.ExamId))
                {
                    context.QuestionMaps.Add(new QuestionMap { ExamId = questioMap.ExamId, QuestionId = questioMap.QuestionId });
                }
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                return View("AddQuestionToExam");
            }
        }

        public ActionResult AddQuestion(int Id)
        {

            List<Question> AllQuestions = context.Questions.ToList();
            var AlreadyPresentQuestions = context.QuestionMaps.Where(x=>x.ExamId==Id);
            List<Question> QuestionList = new List<Models.Question>();
            foreach (Question q in AllQuestions)
            {
                if (!AlreadyPresentQuestions.Any(x=>x.QuestionId==q.Id))
                {
                    QuestionList.Add(q);
                }
            }
            return View(QuestionList);
        }

        [HttpPost]
        public ActionResult AddQuestion(int Id, List<Question> QuestionList)
        {
            try
            {
                foreach (var item in QuestionList)
                {
                    if (item.IsIncluded)
                    {
                        context.QuestionMaps.Add(new QuestionMap { ExamId=Id,QuestionId=item.Id});
                    }
                }
                context.SaveChanges();
                return View("Index",context.Exams);
            }
            catch (Exception)
            {
                
               return View("AddQuestion",QuestionList);
            }
            
        }
    }
}
