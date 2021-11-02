using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Rental
    {
        public int Id { get; set; }
        [Required]
        public Movie Movie { get; set; }
        [Required]
        [StringLength(500)]
        public Customer Customer { get; set; }
        public DateTime? RentDate { get; set; }
        public DateTime? RentReturn { get; set; }
    }
}