using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBlogMvc5.Models;
using Bdd;

namespace WebBlogMvc5.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Index(BlogPostModel blogPostModel)
        {
            if (ModelState.IsValid)
            {
                using (var context = new Entities())
                {
                    context.Articles.Add(new Bdd.Articles()
                    {
                        Titre = blogPostModel.Titre,
                        Libelle = blogPostModel.Libelle,
                        DatePublication = DateTime.Now, //blogPostModel.DatePublication,
                        Commentaire = "bla bla"
                    }
                    );
                    context.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
            }

            return View(blogPostModel);
        }


    }
}
