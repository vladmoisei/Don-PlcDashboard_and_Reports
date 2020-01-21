using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Don_PlcDashboard_and_Reports.Data;
using Don_PlcDashboard_and_Reports.Models;

namespace Don_PlcDashboard_and_Reports.Controllers
{
    public class PlcModelsController : Controller
    {
        private readonly RaportareDbContext _context;

        public PlcModelsController(RaportareDbContext context)
        {
            _context = context;
        }

        // GET: PlcModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.Plcs.ToListAsync());
        }

        // GET: PlcModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plcModel = await _context.Plcs
                .FirstOrDefaultAsync(m => m.PlcModelID == id);
            if (plcModel == null)
            {
                return NotFound();
            }

            return View(plcModel);
        }

        // GET: PlcModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PlcModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlcModelID,Name,CpuType,Ip,Rack,Slot")] PlcModel plcModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(plcModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(plcModel);
        }

        // GET: PlcModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plcModel = await _context.Plcs.FindAsync(id);
            if (plcModel == null)
            {
                return NotFound();
            }
            return View(plcModel);
        }

        // POST: PlcModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PlcModelID,Name,CpuType,Ip,Rack,Slot")] PlcModel plcModel)
        {
            if (id != plcModel.PlcModelID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(plcModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlcModelExists(plcModel.PlcModelID))
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
            return View(plcModel);
        }

        // GET: PlcModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plcModel = await _context.Plcs
                .FirstOrDefaultAsync(m => m.PlcModelID == id);
            if (plcModel == null)
            {
                return NotFound();
            }

            return View(plcModel);
        }

        // POST: PlcModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var plcModel = await _context.Plcs.FindAsync(id);
            _context.Plcs.Remove(plcModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlcModelExists(int id)
        {
            return _context.Plcs.Any(e => e.PlcModelID == id);
        }
    }
}
