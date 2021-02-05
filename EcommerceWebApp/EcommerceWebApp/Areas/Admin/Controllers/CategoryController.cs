using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceWebApp.Data;
using EcommerceWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcommerceWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public CategoryController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            var category = await _dbContext.Category.ToListAsync();
            return View(category);
        }
        //GET - CREATE
        public IActionResult Create()
        {
            return View();
        }

        // POST Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            if (ModelState.IsValid)
            {
                // if valid
                _dbContext.Add(category);
                await _dbContext.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(category);
        
        }

        //GET -EDIT

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();

            }
            var category = await _dbContext.Category.FindAsync(id);

            if (category ==  null)
            {
                return NotFound();

            }

            return View(category);
        
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Update(category);
                await _dbContext.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(category);
        }


        //GET -DELETE

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();

            }
            var category = await _dbContext.Category.FindAsync(id);

            if (category == null)
            {
                return NotFound();

            }

            return View(category);

        }

        [HttpPost, ActionName(nameof(Delete))]//change this is "Delete"
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var category = await _dbContext.Category.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            _dbContext.Category.Remove(category);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            var category = await _dbContext.Category.FindAsync(id);

            if (category == null)
            {
                return NotFound();

            }

            return View(category);
        
        }
    }
}
