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
    public class DepartamentsController : Controller
    {
        private readonly DataContext _context;

        public DepartamentsController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> DepartamentsAjax() { //exibe os departamentos através do "index" pela return view.
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> obterDepartamentos() { //pega os departamentos
            if (_context.Departaments != null) {
                return Json(await _context.Departaments.ToListAsync());
            }
            return Problem("Problema com o BD, há algo NULL presente no back-end de Departaments.");
        }

        [HttpPost]
        public async Task<IActionResult> criarDepartamento(Departament departament) { //cria um novo departamento
            if (ModelState.IsValid) {
                _context.Add(departament);
                await _context.SaveChangesAsync();
                return Json(departament);
            }
            return Json(ModelState);
        }

        [HttpGet]
        public async Task<IActionResult> pegarDepartamentID(int Id) { //departamentos são listados por ID para uma melhor identificação, sendo assim.
            Departament departament = await _context.Departaments.FindAsync(Id);
            if (departament != null)
                return Json(departament);
            return Json(new { mensagem = "O departamento que o usuario desejou ainda nao se encontra cadastro no SGBD." });
        }

        [HttpPost]
        public async Task<IActionResult> editarDepartament(Departament departament) { //edita os departamentos presentes no sistema
            if (ModelState.IsValid) {
                _context.Departaments.Update(departament);
                await _context.SaveChangesAsync();
                return Json(departament);
            }
            return Json(ModelState);
        }
        [HttpPost]
        public async Task<IActionResult> deletarDepartament(int Id) {//departamento são litados por ID, sendo assim, opção viável para exclusão.
            Departament departament = await _context.Departaments.FindAsync(Id);
            if (departament != null) {
                _context.Departaments.Remove(departament);
                await _context.SaveChangesAsync();
                return Json("Departamento foi excluido com sucesso pelo usuario");
            }
            return Json(new { mensagem = "Departamento nao foi encontrado, sendo assim, impossível a sua remoção!" });
        }




        // GET: Departaments
        public async Task<IActionResult> Index()
        {
              return _context.Departaments != null ? 
                          View(await _context.Departaments.ToListAsync()) :
                          Problem("Entity set 'DataContext.Departaments'  is null.");
        }

        // GET: Departaments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Departaments == null)
            {
                return NotFound();
            }

            var departament = await _context.Departaments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (departament == null)
            {
                return NotFound();
            }

            return View(departament);
        }

        // GET: Departaments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Departaments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Departament departament)
        {
            if (ModelState.IsValid)
            {
                _context.Add(departament);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(departament);
        }

        // GET: Departaments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Departaments == null)
            {
                return NotFound();
            }

            var departament = await _context.Departaments.FindAsync(id);
            if (departament == null)
            {
                return NotFound();
            }
            return View(departament);
        }

        // POST: Departaments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Departament departament)
        {
            if (id != departament.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(departament);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartamentExists(departament.Id))
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
            return View(departament);
        }

        // GET: Departaments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Departaments == null)
            {
                return NotFound();
            }

            var departament = await _context.Departaments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (departament == null)
            {
                return NotFound();
            }

            return View(departament);
        }

        // POST: Departaments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Departaments == null)
            {
                return Problem("Entity set 'DataContext.Departaments'  is null.");
            }
            var departament = await _context.Departaments.FindAsync(id);
            if (departament != null)
            {
                _context.Departaments.Remove(departament);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DepartamentExists(int id)
        {
          return (_context.Departaments?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
