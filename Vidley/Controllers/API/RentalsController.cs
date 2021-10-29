using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;
using Vidly.Dtos;

namespace Vidly.Controllers.API
{
    public class RentalsController : ApiController
    {
        //POST/api/rentals
        [HttpPost]
        private IHttpActionResult PostRental(RentalDto rentalDto)
        {
            throw new NotImplementedException();
        }
    }
}
