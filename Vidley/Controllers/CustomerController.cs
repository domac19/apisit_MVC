using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidley.Models;
using System.Data.Entity;
using Vidley.ViewModels;

namespace Vidley.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _dbContext;
        public CustomersController()
        {
            _dbContext = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _dbContext.Dispose();
        }
        public ActionResult Add()
        {
            var membeshipType = _dbContext.MembershipTypes.ToList();
            var viewModel = new AddCustomerViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membeshipType
            };
            return View("Add",viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new AddCustomerViewModel
                {
                    Customer = customer,
                    MembershipTypes = _dbContext.MembershipTypes.ToList()
                };
                return View("Add", viewModel);
            }
            
            if (customer.Id == 0)
                _dbContext.Customers.Add(customer);
            else
            {
                var customerDb = _dbContext.Customers.Single(c => c.Id == customer.Id);

                customerDb.Name = customer.Name;
                customerDb.Birthdate = customer.Birthdate;
                customerDb.IsSubscribed = customer.IsSubscribed;
            }
                _dbContext.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }
        public ActionResult Edit(int id)
        {
            var customer = _dbContext.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();

            var viewModel = new AddCustomerViewModel
            {
                Customer = customer,
                MembershipTypes = _dbContext.MembershipTypes.ToList()
            };

            return View("Add", viewModel);
        }
        public ViewResult Index()
        {
            var customers = _dbContext.Customers.Include(c => c.MembershipType).ToList();

            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = _dbContext.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }
    }
}