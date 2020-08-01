using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace AppendManyToMany.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MyDbContext _context;

        public HomeController(ILogger<HomeController> logger, MyDbContext myDbcontext)
        {
            _logger = logger;
            _context = myDbcontext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create()
        {
            Person person = new Person() { FirstName = "Abdeldjalil", LastName = "Ziraoui" };
            _context.People.Add(person);

            Address address = new Address() { City = "Blida" };
            _context.Addresses.Add(address);

            Status status = new Status() { StatusType = StatusType.Owner};
            _context.Statuses.Add(status);

            PersonAddress personAddress = new PersonAddress() { Date = DateTime.Now };
            _context.PersonAddresses.Add(personAddress);

            //Comment this instruction for a try.
            _context.AppendAssociativeEntity(personAddress, person, address, status);

            _context.SaveChanges();

             return RedirectToAction("Index", "PersonAddresses");
        }

    }
}
