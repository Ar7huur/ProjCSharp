using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjCsharp.Context;
using ProjCsharp.Models;

namespace ProjCsharp.Controllers
{
    public class SalesRecordsController : Controller
    {
        private readonly DataContext _context;

        public SalesRecordsController(DataContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> SalesRecordsAjax() {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> obterSalesRecords() { //pega os recordes de vendas
            if (_context.SelesRecords != null) {
                return Json(await _context.SelesRecords.ToListAsync());
            }
            return Problem("Problema com o BD, há algo NULL presente no back-end de Sales Records.");
        }

        [HttpPost]
        public async Task<IActionResult> criarSalesRecords(SalesRecord salesRecords) { //cria um novo recorde de venda que ocorreu
            if (ModelState.IsValid) {
                _context.Add(salesRecords);
                await _context.SaveChangesAsync();
                return Json(salesRecords);
            }
            return Json(ModelState);
        }

        [HttpGet]
        public async Task<IActionResult> pegarSalesRecordsID(int Id) { //recorde de vendas são listados por ID para uma melhor identificação, sendo assim.
            SalesRecord salesRecords = await _context.SelesRecords.FindAsync(Id);
            if (salesRecords != null)
                return Json(salesRecords);
            return Json(new { mensagem = "O recorde de venda que o usuario desejou ainda nao se encontra cadastrado no SGBD." });
        }

        [HttpPost]
        public async Task<IActionResult> editarSalesRecords(SalesRecord salesRecords) { //edita os recordes de vendas presentes no sistema
            if (ModelState.IsValid) {
                _context.SelesRecords.Update(salesRecords);
                await _context.SaveChangesAsync();
                return Json(salesRecords);
            }
            return Json(ModelState);
        }
        [HttpPost]
        public async Task<IActionResult> deletarSalesRecords(int Id) {//recorde de vendas são litados por ID, sendo assim, opção viável para exclusão.
            SalesRecord salesRecords = await _context.SelesRecords.FindAsync(Id);
            if (salesRecords != null) {
                _context.SelesRecords.Remove(salesRecords);
                await _context.SaveChangesAsync();
                return Json("Recorde de venda foi excluido com sucesso pelo usuario");
            }
            return Json(new { mensagem = "O recorde de venda nao foi encontrado, sendo assim, impossível a sua remoção!" });
        }

        //Ent
        // GET: SalesRecords
        public async Task<IActionResult> Index()
        {
              return _context.SelesRecords != null ? 
                          View(await _context.SelesRecords.ToListAsync()) :
                          Problem("Entity set 'DataContext.SelesRecords'  is null.");
        }

        // GET: SalesRecords/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SelesRecords == null)
            {
                return NotFound();
            }

            var salesRecord = await _context.SelesRecords
                .FirstOrDefaultAsync(m => m.Id == id);
            if (salesRecord == null)
            {
                return NotFound();
            }

            return View(salesRecord);
        }

        // GET: SalesRecords/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SalesRecords/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,Amount")] SalesRecord salesRecord)
        {
            if (ModelState.IsValid)
            {
                _context.Add(salesRecord);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(salesRecord);
        }

        // GET: SalesRecords/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SelesRecords == null)
            {
                return NotFound();
            }

            var salesRecord = await _context.SelesRecords.FindAsync(id);
            if (salesRecord == null)
            {
                return NotFound();
            }
            return View(salesRecord);
        }

        // POST: SalesRecords/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,Amount")] SalesRecord salesRecord)
        {
            if (id != salesRecord.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salesRecord);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalesRecordExists(salesRecord.Id))
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
            return View(salesRecord);
        }

        // GET: SalesRecords/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SelesRecords == null)
            {
                return NotFound();
            }

            var salesRecord = await _context.SelesRecords
                .FirstOrDefaultAsync(m => m.Id == id);
            if (salesRecord == null)
            {
                return NotFound();
            }

            return View(salesRecord);
        }

        // POST: SalesRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SelesRecords == null)
            {
                return Problem("Entity set 'DataContext.SelesRecords'  is null.");
            }
            var salesRecord = await _context.SelesRecords.FindAsync(id);
            if (salesRecord != null)
            {
                _context.SelesRecords.Remove(salesRecord);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalesRecordExists(int id)
        {
          return (_context.SelesRecords?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
