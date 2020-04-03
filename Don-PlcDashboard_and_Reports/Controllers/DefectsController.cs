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
using OfficeOpenXml;
using System.IO;

namespace Don_PlcDashboard_and_Reports.Controllers
{
    public class DefectsController : Controller
    {
        private readonly RaportareDbContext _context;
        private readonly DefectService _defectService;
        private readonly PlcService _plcService;
        private readonly ReportService _reportService;

        public DefectsController(RaportareDbContext context, DefectService defectService, PlcService plcService, ReportService reportService)
        {
            _context = context;
            _defectService = defectService;
            _plcService = plcService;
            _reportService = reportService;
        }

        // GET: Defects
        public async Task<IActionResult> Index()
        {
            DateTime dataFrom = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 00, 00, 00);
            DateTime dataTo = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 00, 00, 00);
            dataTo = dataTo.AddDays(1);
            var raportareDbContext = await _context.Defects.Include(d => d.PlcModel).ToListAsync();
            ViewBag.Utilaje = new SelectList(_plcService.ListPlcs, "PlcModelID", "Name");
            ViewBag.dataFrom = dataFrom.ToString("yyyy-MM-dd");
            ViewBag.dataTo = dataTo.ToString("yyyy-MM-dd");
            return View(_reportService.GetListGroupBySingleProperty(_defectService.GetListOfDefectsBetweenDates(raportareDbContext, dataFrom, dataTo)));
        }

        // POST: Defects
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(int PlcModelID, DateTime dataFrom, DateTime dataTo, string utilaj, string btnAfiseaza, string btnExtrageExcel)
        {
            ViewBag.Utilaje = new SelectList(_plcService.ListPlcs, "PlcModelID", "Name", PlcModelID);
            ViewBag.dataFrom = dataFrom.ToString("yyyy-MM-dd");
            ViewBag.dataTo = dataTo.ToString("yyyy-MM-dd");
            // Get List Of defects By PlcModelID
            List<Defect> raportareDbContext = await _defectService.GetListOfDefectsByPlcModelIdAsync(_context, PlcModelID);
            // Show data between dates and selected by Plc
            var listaDeAfisat = _defectService.GetListOfDefectsBetweenDates(raportareDbContext, dataFrom, dataTo);
            if (String.IsNullOrEmpty(btnExtrageExcel))
                return View(_reportService.GetListGroupBySingleProperty(listaDeAfisat));
            return ExportToExcelListOfDefects(_reportService.GetListGroupBySingleProperty(listaDeAfisat));

        }

        // Functie exportare data to excel file
        public IActionResult ExportToExcelListOfDefects(List<Defect> listaDeAfisat)
        {
            var stream = new MemoryStream();

            using (var pck = new ExcelPackage(stream))
            {
                ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Lista defecte");
                ws.Cells["A1:Z1"].Style.Font.Bold = true;

                ws.Cells["A1"].Value = "Denumire utilaj";
                ws.Cells["B1"].Value = "Timp Start Defect";
                ws.Cells["C1"].Value = "Timp Stop Defect";
                ws.Cells["D1"].Value = "Motiv Stationare";
                ws.Cells["E1"].Value = "Interval Stationare";

                int rowStart = 2;
                foreach (var elem in listaDeAfisat)
                {
                    ws.Cells[string.Format("A{0}", rowStart)].Value = elem.PlcModel.Name;
                    ws.Cells[string.Format("B{0}", rowStart)].Value = elem.TimpStartDefect.ToString("dd.MM.yyyy HH:mm");
                    ws.Cells[string.Format("C{0}", rowStart)].Value = elem.TimpStopDefect.ToString("dd.MM.yyyy HH:mm");
                    ws.Cells[string.Format("D{0}", rowStart)].Value = elem.MotivStationare;
                    ws.Cells[string.Format("E{0}", rowStart)].Value = elem.IntervalStationare.ToString("hh\\:mm\\:ss");
                    rowStart++;
                }

                ws.Cells["A:AZ"].AutoFitColumns();

                pck.Save();
            }
            stream.Position = 0;
            string excelName = "RaportGazGaddaF2.xlsx";
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName);

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
                List<Defect> defects = _defectService.GetListOfDefectsFromFileCSV(file, PlcModelID);
                _context.Defects.AddRange(defects);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PlcModelID"] = new SelectList(_context.Plcs, "PlcModelID", "Name", PlcModelID);
            return View();
        }
    }
}
