using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Don_PlcDashboard_and_Reports.Data;
using Don_PlcDashboard_and_Reports.Models;
using Microsoft.AspNetCore.Http;
using Don_PlcDashboard_and_Reports.Services;

namespace Don_PlcDashboard_and_Reports.Controllers
{
    public class DefectsController : Controller
    {
        private readonly RaportareDbContext _context;
        private readonly DefectService _defectService;

        public DefectsController(RaportareDbContext context, DefectService defectService)
        {
            _context = context;
            _defectService = defectService;
        }

        // GET: Defects
        public async Task<IActionResult> Index()
        {
            var raportareDbContext = _context.Defects.Include(d => d.PlcModel);
            return View(await raportareDbContext.ToListAsync());
        }

        // GET: Defects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var defect = await _context.Defects
                .Include(d => d.PlcModel)
                .FirstOrDefaultAsync(m => m.DefectID == id);
            if (defect == null)
            {
                return NotFound();
            }

            return View(defect);
        }

        // GET: Defects/Create
        public IActionResult Create()
        {
            ViewData["PlcModelID"] = new SelectList(_context.Plcs, "PlcModelID", "Name");
            return View();
        }

        // POST: Defects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DefectID,PlcModelID,TimpStartDefect,TimpStopDefect,IntervalStationare,MotivStationare,DefectFinalizat")] Defect defect)
        {
            if (ModelState.IsValid)
            {
                _context.Add(defect);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PlcModelID"] = new SelectList(_context.Plcs, "PlcModelID", "Name", defect.PlcModelID);
            return View(defect);
        }

        // GET: Defects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var defect = await _context.Defects.FindAsync(id);
            if (defect == null)
            {
                return NotFound();
            }
            ViewData["PlcModelID"] = new SelectList(_context.Plcs, "PlcModelID", "Name", defect.PlcModelID);
            return View(defect);
        }

        // POST: Defects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DefectID,PlcModelID,TimpStartDefect,TimpStopDefect,IntervalStationare,MotivStationare,DefectFinalizat")] Defect defect)
        {
            if (id != defect.DefectID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(defect);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DefectExists(defect.DefectID))
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
            ViewData["PlcModelID"] = new SelectList(_context.Plcs, "PlcModelID", "Name", defect.PlcModelID);
            return View(defect);
        }

        // GET: Defects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var defect = await _context.Defects
                .Include(d => d.PlcModel)
                .FirstOrDefaultAsync(m => m.DefectID == id);
            if (defect == null)
            {
                return NotFound();
            }

            return View(defect);
        }

        // POST: Defects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var defect = await _context.Defects.FindAsync(id);
            _context.Defects.Remove(defect);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DefectExists(int id)
        {
            return _context.Defects.Any(e => e.DefectID == id);
        }

        // Methods to import data from Csv Files
        // GET: Defects/Create
        public IActionResult AddDataromCsvFile()
        {
            ViewData["PlcModelID"] = new SelectList(_context.Plcs, "PlcModelID", "Name");
            return View();
        }

        // POST: Defects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddDataromCsvFile(int PlcModelID, IFormFile file)
        {
            if (file != null)
            {
                string numeFisier = file.FileName;
                List<Defect> defects = _defectService.GetListOfDefectsFromFileCSV(file, PlcModelID);
                _context.Defects.AddRange(defects);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PlcModelID"] = new SelectList(_context.Plcs, "PlcModelID", "Name", PlcModelID);
            return View();
        }
    }
}
