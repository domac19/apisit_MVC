using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidley.Models
{
    public class Customer
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(500)]
        public string Name { get; set; }
        
        public bool IsSubscribed { get; set; }

        [Display (Name="Date of Birth")]
        public DateTime? Birthdate { get; set; }
        
        public MembershipType MembershipType { get; set; }
        
        [Display(Name ="Membership Types")]
        public byte MembershipTypeId { get; set; }
    }
}