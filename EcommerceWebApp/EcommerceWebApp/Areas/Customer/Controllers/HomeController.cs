using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EcommerceWebApp.Models;
using EcommerceWebApp.Models.ViewModels;
using EcommerceWebApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using EcommerceWebApp.Utility;

namespace EcommerceWebApp.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            IndexViewModel indexViewModel = new IndexViewModel()
            {
                MenuItem = await _db.MenuItem.Include(m => m.Category).Include(m => m.SubCategory).ToListAsync(),
                Category = await _db.Category.ToListAsync(),
                Coupon = await _db.Coupon.Where(c=>c.IsActive == true).ToListAsync()

            };
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            if (claim != null)
            {
                var cnt = _db.ShoppingCart.Where(u => u.ApplicationUserId == claim.Value).ToList().Count;
                HttpContext.Session.SetInt32(SD.ssShoppingCartCount, cnt);

            }
            return View(indexViewModel);
        }
        [Authorize]
        public async Task<IActionResult> Details(int id)
        {
            var menuItemFromDb = await _db.MenuItem.Include(m => m.Category)
                                       .Include(m => m.SubCategory)
                                       .Where(m => m.ID == id).FirstOrDefaultAsync();
            ShoppingCart shoppingCart = new ShoppingCart()
            {
                MenuItem = menuItemFromDb,
                MenuItemId = menuItemFromDb.ID
            
            };
            return View(shoppingCart);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Details(ShoppingCart shoppingCart) 
        {
            shoppingCart.Id = 0;

            if (ModelState.IsValid)
            {
                var claimsIdentity = (ClaimsIdentity)this.User.Identity;

                var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

                shoppingCart.ApplicationUserId = claim.Value;

                ShoppingCart shoppingCartFromDB = await _db.ShoppingCart.Where(c => c.ApplicationUserId == shoppingCart.ApplicationUserId
                                                        && c.MenuItemId == shoppingCart.MenuItemId).FirstOrDefaultAsync();

                if (shoppingCartFromDB == null)
                {
                    await _db.ShoppingCart.AddAsync(shoppingCart);

                }
                else 
                {
                    shoppingCartFromDB.Count += shoppingCart.Count;
                }
                await _db.SaveChangesAsync();

                var count = _db.ShoppingCart.Where(c => c.ApplicationUserId == shoppingCart.ApplicationUserId).ToList().Count();

                HttpContext.Session.SetInt32("SD.ssShoppingCartCount", count);

                return RedirectToAction("Index");


            }
            else
            {
                var menuItemFromDb = await _db.MenuItem.Include(m => m.Category)
                                       .Include(m => m.SubCategory)
                                       .Where(m => m.ID == shoppingCart.MenuItemId).FirstOrDefaultAsync();
                ShoppingCart CartObj = new ShoppingCart()
                {
                    MenuItem = menuItemFromDb,
                    MenuItemId = menuItemFromDb.ID

                };

                return View(CartObj);

            }
        }

    }
}
