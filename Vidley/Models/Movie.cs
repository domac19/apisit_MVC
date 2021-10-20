using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

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
        
        public Genre Genre { get; set; }
        
        [Required]
        [Display(Name = "Genre")]
        public int GenreType { get; set; }
    }
}