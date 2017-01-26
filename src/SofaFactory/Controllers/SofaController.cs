using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SofaFactory.Data;
using Microsoft.EntityFrameworkCore;

namespace SofaFactory.Controllers
{
    public class SofaController : Controller
    {
        private readonly StoreContext _context;

        public SofaController(StoreContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Sofas.Where(s => s.SaleImagePath.Trim() != "").ToListAsync());
        }

        public async Task<IActionResult> Measurement(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            return View(await _context.Sofas.SingleOrDefaultAsync(s => s.Id == id));
        }

        public async Task<IActionResult> Samples()
        {
            return View(await _context.Sofas.Where(s => s.ConfigurationImagePath.Trim() != "").ToListAsync());
        }
    }
}
