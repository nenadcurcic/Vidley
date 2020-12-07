using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

       
        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes,
            };

            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                CustomerFormViewModel viewModel = new CustomerFormViewModel()
                {
                    MembershipTypes = _context.MembershipTypes.ToList(),
                    Customer = customer,
                };
                return View("CustomerForm", viewModel);
            }
            if(customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerFromDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerFromDb.Name = customer.Name;
                customerFromDb.Birthday = customer.Birthday;
                customerFromDb.MembershipTypeId = customer.MembershipTypeId;
                customerFromDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

        // GET: Customers
        [Authorize]
        public ActionResult Index()
        {
            ExcerciseListCostumersViewModel listCustomers = new ExcerciseListCostumersViewModel()
            {
                Customers = _context.Customers.Include(c => c.MembershipType).ToList(),
            };

            //ExcerciseListCostumersViewModel listCustomers = _context.Customers;

            return View(listCustomers);
        }

        [Route("customers/details/{Id}")]
        public ActionResult Details(int Id)
        {
            //List<Customer> customerList = new List<Customer>(_context.Customers);

            try
            {
                Customer customerDetails = _context.Customers.Include(c => c.MembershipType).Single(m => m.Id ==Id);
                return View(customerDetails);
            }
            catch (InvalidOperationException e)
            {
                return RedirectToAction("NonExistingCustomer", "Customers");
            };            
        }

        public ActionResult Edit(int Id)
        {
            var customer = _context.Customers.SingleOrDefault(C  => C.Id == Id);

            if (customer == null)
            {
                return HttpNotFound();
            }

            var viewModel = new CustomerFormViewModel()
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList(),
            };

            return View("CustomerForm", viewModel);
        }
        
        //[Route("customers/NonExistingCustomer")]
        public ActionResult NonExistingCustomer()
        {
            return View();
        }
    }
}