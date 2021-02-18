using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EcommerceWebApp.Data;
using EcommerceWebApp.Models.ViewModels;
using EcommerceWebApp.Utility;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcommerceWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MenuItemController : Controller
    {
        private readonly ApplicationDbContext _dBContext;
        private readonly IWebHostEnvironment _hostEnvironment;

        [BindProperty]
        public MenuItemViewModel MenuItemVM { get; set; }

        public MenuItemController(IWebHostEnvironment hostEnvironment, ApplicationDbContext dBContext)
        {
            _hostEnvironment = hostEnvironment;
            _dBContext = dBContext;
            MenuItemVM = new MenuItemViewModel()
            { 
                Category = _dBContext.Category,
                MenuItem = new Models.MenuItem()
            
            };
        }
        public async Task<IActionResult> Index()
        {
            var menuItem = await _dBContext.MenuItem.Include(m=>m.Category).Include(m=>m.SubCategory).ToListAsync();
            return View(menuItem);
        }
        //GET Create
        public IActionResult Create() 
        {
            return View(MenuItemVM);
        }

        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePOST()
        {
            MenuItemVM.MenuItem.SubCategoryId = Convert.ToInt32(Request.Form["SubCategoryId"].ToString());
            if (!ModelState.IsValid)
            {
                return View(MenuItemVM);

            }
            _dBContext.MenuItem.Add(MenuItemVM.MenuItem);
            await _dBContext.SaveChangesAsync();

            //Work on the image saving section

            string webRootPath = _hostEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;

            var menuItemFromDb = await _dBContext.MenuItem.FindAsync(MenuItemVM.MenuItem.ID);

            if (files.Count>0)
            {
                //file has been uploaded
                var uploads = Path.Combine(webRootPath, "images");
                var extension = Path.GetExtension(files[0].FileName);

                using (var fileStream = new FileStream(Path.Combine(uploads, MenuItemVM.MenuItem.ID + extension), FileMode.Create))
                {
                    files[0].CopyTo(fileStream);

                }
                menuItemFromDb.Image = @"\images\" + MenuItemVM.MenuItem.ID + extension;
            }
            else
            {

                var uploads = Path.Combine(webRootPath, @"images\" + SD.DefaultFoodImage);
                System.IO.File.Copy(uploads, webRootPath + @"\images\" + MenuItemVM.MenuItem.ID + ".png");
                menuItemFromDb.Image = @"\images\" + MenuItemVM.MenuItem.ID + ".png";

            }

            await _dBContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        //EDIT MENU
        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null)
            {
                NotFound();
            }

            MenuItemVM.MenuItem = await _dBContext.MenuItem.Include(m => m.Category).Include(m => m.SubCategory).SingleOrDefaultAsync(m=>m.ID ==id);
            MenuItemVM.SubCategory = await _dBContext.SubCategory.Where(s => s.CategoryId == MenuItemVM.MenuItem.CategoryId).ToListAsync();

            if (MenuItemVM.MenuItem == null)
            {
                return NotFound();
            }
            return View(MenuItemVM);
        }

        //EDIT POST
        [HttpPost,ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPOST(int? id)
        {
            if (id == null)
            {
                NotFound();
            }

            MenuItemVM.MenuItem.SubCategoryId = Convert.ToInt32(Request.Form["SubCategoryId"].ToString());

            if (!ModelState.IsValid)
            {
                MenuItemVM.SubCategory = await _dBContext.SubCategory.Where(s => s.CategoryId == MenuItemVM.MenuItem.CategoryId).ToListAsync();
                return View(MenuItemVM);

            }
       
            //Work on the image saving section

            string webRootPath = _hostEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;

            var menuItemFromDb = await _dBContext.MenuItem.FindAsync(MenuItemVM.MenuItem.ID);

            if (files.Count > 0)
            {
                //New file has been uploaded
                var uploads = Path.Combine(webRootPath, "images");
                var extension_new = Path.GetExtension(files[0].FileName);

                //Delete the previous image 

                var imagePath = Path.Combine(webRootPath, menuItemFromDb.Image.TrimStart('\\'));

                if(System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
                //we will upload the new file

                using (var fileStream = new FileStream(Path.Combine(uploads, MenuItemVM.MenuItem.ID + extension_new), FileMode.Create))
                {
                    files[0].CopyTo(fileStream);

                }
                menuItemFromDb.Image = @"\images\" + MenuItemVM.MenuItem.ID + extension_new;
            }

            menuItemFromDb.Name = MenuItemVM.MenuItem.Name;
            menuItemFromDb.Description = MenuItemVM.MenuItem.Description;
            menuItemFromDb.Price = MenuItemVM.MenuItem.Price;
            menuItemFromDb.Stock = MenuItemVM.MenuItem.Stock;
            menuItemFromDb.CategoryId = MenuItemVM.MenuItem.CategoryId;
            menuItemFromDb.SubCategoryId = MenuItemVM.MenuItem.SubCategoryId;

            await _dBContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            var subCategory = await _dBContext.MenuItem.FindAsync(id);

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
            var subCategory = await _dBContext.MenuItem.FindAsync(id);

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
            var subCategory = await _dBContext.SubCategory.FindAsync(id);
            if (subCategory == null)
            {
                return NotFound();
            }
            _dBContext.SubCategory.Remove(subCategory);
            await _dBContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
