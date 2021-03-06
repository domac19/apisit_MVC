using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data.Entity;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.API
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _dbContext;
        public CustomersController()
        {
            _dbContext = new ApplicationDbContext();
        }

        // GET/api/customers
        public IHttpActionResult GetCustomers(string query = null)
        {
            var customersQuery = _dbContext.Customers.Include(c => c.MembershipType);

            if (!String.IsNullOrEmpty(query))
                customersQuery = customersQuery.Where(c => c.Name.Contains(query));
            
            var customersDto = customersQuery.ToList().Select(Mapper.Map<Customer, CustomerDto>);

            return Ok(customersDto);
        }

        // GET/customer/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _dbContext.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return NotFound();

            return Ok(Mapper.Map<Customer,CustomerDto>(customer));
        }

        // POST/api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);

            _dbContext.Customers.Add(customer);
            _dbContext.SaveChanges();

            customer.Id = customerDto.Id;

            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
        }

        // PUT/api/customers
        public void UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerDb = _dbContext.Customers.SingleOrDefault(c => c.Id == id);

            if (customerDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(customerDto, customerDb);

            _dbContext.SaveChanges();
        }

        // DELETE/api/customers/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerDb = _dbContext.Customers.SingleOrDefault(c => c.Id == id);

            if (customerDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _dbContext.Customers.Remove(customerDb);
            _dbContext.SaveChanges();
        }
    }
}
