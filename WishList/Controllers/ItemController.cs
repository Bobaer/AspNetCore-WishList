using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WishList.Data;

namespace WishList.Controllers
{
    
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ItemController(ApplicationDbContext context)
        { _context = context; }
        public IActionResult Index()
        {
            var model = _context.Items.ToList();
            return View();
        }
        [HttpGet]
        public IActionResult create ()
        {
            return View("Create");
        }
        [HttpPost]
        public IActionResult create(Models.Item item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
