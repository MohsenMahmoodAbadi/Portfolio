using DataLayer;
using DataLayer1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyCms.Controllers
{
    public class NewsController : Controller
    {

        MyCmsContext db = new MyCmsContext();
        private IPageGroupRepository pageGroupRepository;
        private IPageRepository pageRepository;
        private IPageCommentRepository pageCommentRepository;

        public NewsController()
        {
            pageGroupRepository = new PageGroupRepository(db);
            pageRepository = new PageRepository(db);
            pageCommentRepository = new PageCommentRepository(db);
        }
        // GET: News
        public ActionResult ShowGroups()
        {

            return PartialView(pageGroupRepository.GetGroupsForView());
        }


        public ActionResult ShowGroupsInMenu()
        {
            return PartialView(pageGroupRepository.GetAllGroups());
        }

        public ActionResult ShowTopNews()
        {
            return PartialView(pageRepository.TopNews());
        }

        public ActionResult LatestNews()
        {
            return PartialView(pageRepository.LatestNews());
        }

        [Route("Archive")]
        public ActionResult ArchiveNews()
        {
            return View(pageRepository.GetAllPages());
        }

        [Route("Group/{id}/{title}")]
        public ActionResult ShowNewsByGroupId(int id, string title)
        {
            ViewBag.name = title;
            return View(pageRepository.ShowPageByGroupId(id));
        }

        [Route("News/{id}")]
        public ActionResult ShowNews(int id)
        {
            var news = pageRepository.GetPageById(id);

            if(news == null)
            {
                return HttpNotFound();
            }

            news.Visit += 1;
            pageRepository.UpdatePage(news);
            pageRepository.Save();


            return View(news);
        }


        public ActionResult AddComment(int id , string name, string email, string comment)
        {
            PageComment addcomment = new PageComment()
            {
                 Comment = comment,
                 CreateDate = DateTime.Now, 
                 Email = email,
                 Name = name,
                 PageID = id,
                 
            };

            pageCommentRepository.AddComment(addcomment);
            return PartialView("ShowComments" , pageCommentRepository.GetCommentsByPageId(id));
        }


        public ActionResult ShowComments(int id)
        {
            return PartialView(pageCommentRepository.GetCommentsByPageId(id));
        }
    }
}