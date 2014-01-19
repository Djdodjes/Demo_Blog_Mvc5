using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebBlogMvc5.Models
{
    public class BlogPostModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(150, ErrorMessage = "La chaîne {0} doit comporter au moins {2} caractères.", MinimumLength = 6)]
        [DataType(DataType.Text)]
        [Display(Name = "Titre")]
        public string Titre { get; set; }
        
        [DataType(DataType.DateTime)]
        [Display(Name = "Date de publication")]
        public DateTime DatePublication { get; set; }
        public string Libelle { get; set; }
        public string Commentaire { get; set; }
    }

    public class ListPost
    {
        public List<BlogPostModel> ListBlogsPost { get; set; } 
    }
}