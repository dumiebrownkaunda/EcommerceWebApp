using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceWebApp.Data;
using EcommerceWebApp.Models;
using EcommerceWebApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EcommerceWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SubCategoryController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
         
        [TempData]
        public string StatusMessage { get; set; }
        public SubCategoryController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        //GET INDEX
        public async Task<IActionResult> Index()
        {
            var subCategory = await _dbContext.SubCategory.Include(s => s.Category).ToListAsync();
            return View(subCategory);
        }

        //GET CREATE
        public async Task<IActionResult> Create()
        {
            SubCategoryAndCategoryViewModel model = new SubCategoryAndCategoryViewModel()
            {
                CategoryList = await _dbContext.Category.ToListAsync(),
                StatusMessage = "",
                SubCategory = new SubCategory(),
                SubCategoryList = await _dbContext.SubCategory.OrderBy(p => p.Name).Select(p => p.Name).Distinct().ToListAsync()
            };

            return View(model);

        }
        //POST -CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SubCategoryAndCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var doesSubCategoryExist = _dbContext.SubCategory.Include(s => s.Category).Where(s => s.Name == model.SubCategory.Name && s.Category.ID == model.SubCategory.CategoryId);

                if (doesSubCategoryExist.Count()> 0)
                {
                    StatusMessage = "Error: Sub Category exists under " + doesSubCategoryExist.First().Category.Name + "Category. Please use another name.";

                }
                else
                {
                    _dbContext.SubCategory.Add(model.SubCategory);
                    await _dbContext.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
            }

            SubCategoryAndCategoryViewModel modelVM = new SubCategoryAndCategoryViewModel()
            {
                CategoryList = await _dbContext.Category.ToListAsync(),
                SubCategory = model.SubCategory,
                SubCategoryList = await _dbContext.SubCategory.OrderBy(p => p.Name).Select(p => p.Name).ToListAsync(),
                StatusMessage = StatusMessage
            };

            return View(modelVM);

        }

        [ActionName("GetSubCategory")]
        public async Task<IActionResult> GetSubCtaegory(int id)
        {
            List<SubCategory> subCategories = new List<SubCategory>();

            subCategories = await (from subCategory in _dbContext.SubCategory
                             where subCategory.CategoryId == id
                             select subCategory).ToListAsync();
            return Json(new SelectList(subCategories, "ID", "Name"));
        }

        //GET -EDIT
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();

            }
            var subCategory = await _dbContext.SubCategory.SingleOrDefaultAsync(m => m.ID == id);

            if (subCategory == null)
            {
                return NotFound();
            }
            
            SubCategoryAndCategoryViewModel model = new SubCategoryAndCategoryViewModel()
            {
                CategoryList = await _dbContext.Category.ToListAsync(),
                StatusMessage = "",
                SubCategory = subCategory,
                SubCategoryList = await _dbContext.SubCategory.OrderBy(p => p.Name).Select(p => p.Name).Distinct().ToListAsync()
            };

            return View(model);

        }
        //POST -EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SubCategoryAndCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var doesSubCategoryExist = _dbContext.SubCategory.Include(s => s.Category).Where(s => s.Name == model.SubCategory.Name && s.Category.ID == model.SubCategory.CategoryId);

                if (doesSubCategoryExist.Count() > 0)
                {
                    StatusMessage = "Error: Sub Category exists" + doesSubCategoryExist.First().Category.Name + "category. Please use another name.";

                }
                else
                {
                    var subCatFromDB = await _dbContext.SubCategory.FindAsync(model.SubCategory.ID);
                    subCatFromDB.Name = model.SubCategory.Name;

                    _dbContext.SubCategory.Add(model.SubCategory);
                    await _dbContext.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
            }

            SubCategoryAndCategoryViewModel modelVM = new SubCategoryAndCategoryViewModel()
            {
                CategoryList = await _dbContext.Category.ToListAsync(),
                SubCategory = model.SubCategory,
                SubCategoryList = await _dbContext.SubCategory.OrderBy(p => p.Name).Select(p => p.Name).ToListAsync(),
                StatusMessage = StatusMessage
            };
            //modelVM.SubCategory.ID = id;
            return View(modelVM); 

        }

        public async Task<IActionResult> Details(int? id)
        {
            var subCategory = await _dbContext.SubCategory.FindAsync(id);

            if (subCategory == null)
            {
                return NotFound();

            }

            return View(subCategory);

        }

        //GET -DELETE
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();

            }
            var subCategory = await _dbContext.SubCategory.FindAsync(id);

            if (subCategory == null)
            {
                return NotFound();

            }

            return View(subCategory);

        }

        [HttpPost, ActionName(nameof(Delete))]//change this is "Delete"
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subCategory = await _dbContext.SubCategory.FindAsync(id);
            if (subCategory == null)
            {
                return NotFound();
            }
            _dbContext.SubCategory.Remove(subCategory);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

    }
}
 
      