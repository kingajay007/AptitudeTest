using Aptitude.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aptitude.Controllers
{
    public class PracticeController : Controller
    {
        private ApplicationDbContext context = new ApplicationDbContext();
        // GET: Practice
        public ActionResult Search()
        {
            //IEnumerable<Question> ques = context.Questions.Where(x => x.Tags.Contains(searchString));
            return View();
        }

        [HttpPost]
        public ActionResult Search(string searchString,Question q)
        {
            //IEnumerable<Question> ques = context.Questions.Where(x => x.Tags.Contains(searchString));
            return PartialView("SerachList", context.Questions.Where(x => x.Tags.Contains(q.Tags)));
        }

        public ActionResult SerachList(string searchString,IEnumerable<Question> Questions)
        {
            if (string.IsNullOrEmpty(searchString) || string.IsNullOrWhiteSpace(searchString))
            {
                searchString = "";
            }
            
            return PartialView(Questions);
        }
    }
}