using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Vidley.Models;

namespace Vidley.Models
{
    public class MovieDto
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public DateTime ReleseDate { get; set; }
        
        public DateTime DateAdded { get; set; }
        
        [Range(1,20, ErrorMessage ="Please enter number between 1 and 20.")]
        public int NumberInStock { get; set; }
        
        public int Genre_Id { get; set; }
    }
}