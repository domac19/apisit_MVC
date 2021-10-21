using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vidley.Models
{
    public class Movie
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name ="Relese date")]
        public DateTime ReleseDate { get; set; }
        
        [Display(Name ="Date Added")]
        public DateTime DateAdded { get; set; }
        
        [Display(Name ="Number in Stock")]
        public int NumberInStock { get; set; }
        
        [ForeignKey("Genre_Id")]
        public Genre Genre { get; set; }
        
        [Display(Name = "Genre")]
        public int Genre_Id { get; set; }
    }
}