using Bdd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBlogMvc5.Models;

namespace WebBlogMvc5.Controllers
{
    // [RoutePrefix("accueil")]
    public class HomeController : Controller
    {
        //public ActionResult Index()
        //{
        //    return View();
        //}


        //[Route("good")]
        public ActionResult Index()
        {
            ListPost lst = new ListPost();
            List<BlogPostModel> lstBlogs = new List<BlogPostModel>();
            // Ajout manuel d'article
            lstBlogs.Add(
                new BlogPostModel()
            {
                Id = 10,
                Titre = "super Blogpost0",
                Libelle = "Aliquam erat volutpat. Vestibulum eleifend pellentesque urna, at sodales est faucibus sit amet. Praesent in mi dui. <q>Aliquam sed    bibendum nisl. Mauris pharetra enim sit amet ipsum dictum placerat. Sed    lacinia pulvinar iaculis. Nam sit amet hendrerit purus.</q> Sed a urna    laoreet lorem pulvinar fermentum. Aenean vel luctus libero. Ut tincidunt    metus sagittis ante viverra feugiat.",
                DatePublication = DateTime.Now
            });
            lstBlogs.Add(new BlogPostModel()
            {
                Id = 20,
                Titre = "Blogpost 20",
                Libelle = @"Nulla quis lacus non quam luctus vestibulum. Pellentesque imperdiet
                            risus gravida ante consectetur fermentum. Vivamus et est nec risus volutpat
                            elementum. Ut faucibus, lectus consectetur volutpat dapibus, quam diam
                                luctus enim, vitae mollis enim purus non ante.",
                DatePublication = DateTime.Now
            });
            lstBlogs.Add(new BlogPostModel()
            {
                Id = 30,
                Titre = "super Blogpost 30",
                Libelle = @"Curabitur dignissim lorem a CSS diam posuere tempor. Nam hendrerit,
                            eros vel condimentum tempor, ipsum justo cursus justo, quis vestibulum
                            turpis turpis sit amet tellus. Quisque quis PHP magna eget ipsum faucibus
                            bibendum at non diam. Sed sapien est, cursus ac ullamcorper id, egestas vel
                            urna JavaScript. Nullam aliquam dolor vitae quam pharetra auctor.",
                DatePublication = DateTime.Now
            });

            // from BDD
            using (var context = new Bdd.Entities())
            {
                //Bdd.Articles art = context.Articles. f FirstOrDefault();
                var requete = from p in context.Articles
                              select p;

                requete.ToList().ForEach((Articles art) =>
                    {
                        lstBlogs.Add(new BlogPostModel()
                        {
                            Id = art.Id,
                            Titre = art.Titre,
                            Libelle = art.Libelle,
                            DatePublication = DateTime.Parse(art.DatePublication.ToString())
                        });
                    });
            }

            lst.ListBlogsPost = lstBlogs;
            return View(lst);

        }

        //[Authorize(Roles = "admin")]
        //[Authorize(Users="damien")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        // Home/details/5
        public ActionResult Details(int id)
        {
            BlogPostModel postBlog = new BlogPostModel();

            try
            {
                // from BDD
                using (var context = new Bdd.Entities())
                {
                    //Bdd.Articles art = context.Articles. f FirstOrDefault();
                    var requete = from p in context.Articles
                                  where p.Id == id
                                  select p;

                    Bdd.Articles art = requete.FirstOrDefault();

                    postBlog.Id = art.Id;
                    postBlog.Titre = art.Titre;
                    postBlog.Libelle = art.Libelle;
                    postBlog.DatePublication = DateTime.Parse(art.DatePublication.ToString());

                }
            }
            catch
            {
                return View(postBlog);

            }

            return View(postBlog);
        }

    }
}