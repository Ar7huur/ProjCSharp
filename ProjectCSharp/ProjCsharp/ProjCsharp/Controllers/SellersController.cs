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
    public class SellersController : Controller
    {
        private readonly DataContext _context;

        public SellersController(DataContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> SellersAjax() {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> obterSellers() { //pega os vendedores 
            if (_context.Sellers != null) {
                return Json(await _context.Sellers.ToListAsync());
            }
            return Problem("Problema com o BD, há algo NULL presente no back-end de Sellers.");
        }

        [HttpPost]
        public async Task<IActionResult> criarSellers(Seller sellers) { //cria um novo vendedor
            if (ModelState.IsValid) {
                _context.Add(sellers);
                await _context.SaveChangesAsync();
                return Json(sellers);
            }
            return Json(ModelState);
        }

        [HttpGet]
        public async Task<IActionResult> pegarSellersID(int Id) { //vendedores são listados por ID para uma melhor identificação, sendo assim.
            Seller sellers = await _context.Sellers.FindAsync(Id);
            if (sellers != null)
                return Json(sellers);
            return Json(new { mensagem = "O vendedor que o usuario desejou ainda nao se encontra cadastrado no SGBD." });
        }

        [HttpPost]
        public async Task<IActionResult> editarSellers(Seller sellers) { //edita os vendedores presentes no sistema
            if (ModelState.IsValid) {
                _context.Sellers.Update(sellers);
                await _context.SaveChangesAsync();
                return Json(sellers);
            }
            return Json(ModelState);
        }
        [HttpPost]
        public async Task<IActionResult> deletarSellers(int Id) {//recorde de vendas são litados por ID, sendo assim, opção viável para exclusão.
            Seller sellers = await _context.Sellers.FindAsync(Id);
            if (sellers != null) {
                _context.Sellers.Remove(sellers);
                await _context.SaveChangesAsync();
                return Json("O vendedor foi excluido com sucesso pelo usuario");
            }
            return Json(new { mensagem = "O vendedor nao foi encontrado, sendo assim, impossível a sua remoção!" });
        }


        //end
        // GET: Sellers
        public async Task<IActionResult> Index()
        {
              return _context.Sellers != null ? 
                          View(await _context.Sellers.ToListAsync()) :
                          Problem("Entity set 'DataContext.Sellers'  is null.");
        }

        // GET: Sellers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Sellers == null)
            {
                return NotFound();
            }

            var seller = await _context.Sellers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (seller == null)
            {
                return NotFound();
            }

            return View(seller);
        }

        // GET: Sellers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sellers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,CPF,BaseSalary")] Seller seller)
        {
            if (ModelState.IsValid)
            {
                _context.Add(seller);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(seller);
        }

        // GET: Sellers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Sellers == null)
            {
                return NotFound();
            }

            var seller = await _context.Sellers.FindAsync(id);
            if (seller == null)
            {
                return NotFound();
            }
            return View(seller);
        }

        // POST: Sellers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,CPF,BaseSalary")] Seller seller)
        {
            if (id != seller.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(seller);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SellerExists(seller.Id))
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
            return View(seller);
        }

        // GET: Sellers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Sellers == null)
            {
                return NotFound();
            }

            var seller = await _context.Sellers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (seller == null)
            {
                return NotFound();
            }

            return View(seller);
        }

        // POST: Sellers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Sellers == null)
            {
                return Problem("Entity set 'DataContext.Sellers'  is null.");
            }
            var seller = await _context.Sellers.FindAsync(id);
            if (seller != null)
            {
                _context.Sellers.Remove(seller);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SellerExists(int id)
        {
          return (_context.Sellers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
