using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Time_Management.Areas.Identity.Data;
using Time_Management.Models;

namespace Time_Management.Controllers
{

    // (Hernandez, 2021) available at   https://www.freecodecamp.org/news/the-model-view-controller-pattern-mvc-architecture-and-frameworks-explained/
    
    public class Module_PlanningController : Controller
    {
        private readonly ApplicationDBContext _context;

        public Module_PlanningController(ApplicationDBContext context)
        {
            _context = context;
        }

        //AUTHORIZE USER TO LOGIN BEFORE USER CAN PERFORM ACTION  
        // (Sign, 2021) available at https://www.c-sharpcorner.com/UploadFile/56fb14/custom-authorization-in-mvc/
        [Authorize]
        // GET: Module_Planning
        public async Task<IActionResult> Index()
        {
              return View(await _context.Module_Planning.ToListAsync());
        }

        //AUTHORIZE USER TO LOGIN BEFORE USER CAN PERFORM ACTION  
        [Authorize]
        // Post:  Planning
        public async Task<IActionResult> Planning()
        {
            return View();
        }




        // Post:   ShowPlanningResults
        //AUTHORIZE USER TO LOGIN BEFORE USER CAN PERFORM ACTION  
        [Authorize]

        // method to display modules when user search for a day
        public async Task<IActionResult> ShowPlanningResults(String SearchDay)
        {
            return View("Index",await _context.Module_Planning.Where(j=>j.ModuleDay.Contains(SearchDay)).ToListAsync());
        }


        // GET: Module_Planning/Details/5
  
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Module_Planning == null)
            {
                return NotFound();
            }

            var module_Planning = await _context.Module_Planning
                .FirstOrDefaultAsync(m => m.Id == id);
            if (module_Planning == null)
            {
                return NotFound();
            }

            return View(module_Planning);
        }

        // GET: Module_Planning/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Module_Planning/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ModuleDay")] Module_Planning module_Planning)
        {
            if (ModelState.IsValid)
            {
                _context.Add(module_Planning);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(module_Planning);
        }

        // GET: Module_Planning/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Module_Planning == null)
            {
                return NotFound();
            }

            var module_Planning = await _context.Module_Planning.FindAsync(id);
            if (module_Planning == null)
            {
                return NotFound();
            }
            return View(module_Planning);
        }

        // POST: Module_Planning/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ModuleDay")] Module_Planning module_Planning)
        {
            if (id != module_Planning.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(module_Planning);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Module_PlanningExists(module_Planning.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(module_Planning);
        }

        // GET: Module_Planning/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Module_Planning == null)
            {
                return NotFound();
            }

            var module_Planning = await _context.Module_Planning
                .FirstOrDefaultAsync(m => m.Id == id);
            if (module_Planning == null)
            {
                return NotFound();
            }

            return View(module_Planning);
        }

        // POST: Module_Planning/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Module_Planning == null)
            {
                return Problem("Entity set 'ApplicationDBContext.Module_Planning'  is null.");
            }
            var module_Planning = await _context.Module_Planning.FindAsync(id);
            if (module_Planning != null)
            {
                _context.Module_Planning.Remove(module_Planning);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Module_PlanningExists(int id)
        {
          return _context.Module_Planning.Any(e => e.Id == id);
        }
    }
}
