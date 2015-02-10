using Aptitude.Models;
using Aptitude.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aptitude.Controllers
{
    public class QuestionBankController : Controller
    {
        // GET: QuestionBank
        public ActionResult Qbank(int? Id)
        {
            IEnumerable<Question> questions;
            QuestionService service = new QuestionService();
            if (Id.HasValue)
            {
                questions = service.GetQuestions(Id.Value);
            }
            else
            {
                questions = service.GetQuestions();
            }
            return View(questions);
        }
    }
}