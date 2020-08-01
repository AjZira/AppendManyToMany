using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppendManyToMany.Controllers
{
    public class PersonAddressesController : Controller
    {
        private readonly MyDbContext _context;

        public PersonAddressesController(MyDbContext context)
        {
            _context = context;
        }

        // GET: PersonAddresses
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.PersonAddresses.Include(p => p.Address).Include(p => p.Person).Include(p => p.Status);
            return View(await myDbContext.ToListAsync());
        }

        // GET: PersonAddresses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personAddress = await _context.PersonAddresses
                .Include(p => p.Address)
                .Include(p => p.Person)
                .Include(p => p.Status)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personAddress == null)
            {
                return NotFound();
            }

            return View(personAddress);
        }
 
    }
}
