//using System;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using NudeApp.Data;
//using NudeApp.Models;

//namespace NudeApp.Controllers
//{
//    public class HighValueItemsController : Controller
//    {
//        private readonly NudeAppContext _context;

//        public HighValueItemsController(NudeAppContext context)
//        {
//            _context = context;
//        }

//        // GET: HighValueItems
//        public async Task<IActionResult> Index()
//        {
//            return View(await _context.HighValueItem.ToListAsync());
//        }

//        // GET: HighValueItems/Details/5
//        public async Task<IActionResult> Details(Guid? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var highValueItem = await _context.HighValueItem
//                .FirstOrDefaultAsync(m => m.Id == id);
//            if (highValueItem == null)
//            {
//                return NotFound();
//            }

//            return View(highValueItem);
//        }

//        // GET: HighValueItems/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        // POST: HighValueItems/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
//        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("Id,Name,Value,Category")] HighValueItem highValueItem)
//        {
//            if (ModelState.IsValid)
//            {
//                highValueItem.Id = Guid.NewGuid();
//                _context.Add(highValueItem);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            return View(highValueItem);
//        }

//        // GET: HighValueItems/Edit/5
//        public async Task<IActionResult> Edit(Guid? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var highValueItem = await _context.HighValueItem.FindAsync(id);
//            if (highValueItem == null)
//            {
//                return NotFound();
//            }
//            return View(highValueItem);
//        }

//        // POST: HighValueItems/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
//        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Value,Category")] HighValueItem highValueItem)
//        {
//            if (id != highValueItem.Id)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(highValueItem);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!HighValueItemExists(highValueItem.Id))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index));
//            }
//            return View(highValueItem);
//        }

//        // GET: HighValueItems/Delete/5
//        public async Task<IActionResult> Delete(Guid? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var highValueItem = await _context.HighValueItem
//                .FirstOrDefaultAsync(m => m.Id == id);
//            if (highValueItem == null)
//            {
//                return NotFound();
//            }

//            return View(highValueItem);
//        }

//        // POST: HighValueItems/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(Guid id)
//        {
//            var highValueItem = await _context.HighValueItem.FindAsync(id);
//            _context.HighValueItem.Remove(highValueItem);
//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool HighValueItemExists(Guid id)
//        {
//            return _context.HighValueItem.Any(e => e.Id == id);
//        }
//    }
//}
