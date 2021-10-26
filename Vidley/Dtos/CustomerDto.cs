using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidley.Models;

namespace Vidley.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(500)]
        public string Name { get; set; }

        public bool IsSubscribed { get; set; }

        public MembershipTypeDto MembershipType { get; set; }

        //[Min18YearsMember]
        public DateTime? Birthdate { get; set; }

        public byte MembershipTypeId { get; set; }
    }
}