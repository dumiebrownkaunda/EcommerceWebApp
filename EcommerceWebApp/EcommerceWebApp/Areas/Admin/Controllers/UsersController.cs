using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using EcommerceWebApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcommerceWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public UsersController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            return View(await _dbContext.ApplicationUser.Where(u=>u.Id != claim.Value).ToListAsync());
        }

        public async Task<IActionResult> Lock(string id) 
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationUser = await _dbContext.ApplicationUser.Where(m => m.Id == id).FirstOrDefaultAsync();
            if (applicationUser == null)
            {
                return NotFound();

            }

            applicationUser.LockoutEnd = DateTime.Now.AddYears(1000);

           await  _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> UnLock(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationUser = await _dbContext.ApplicationUser.Where(m => m.Id == id).FirstOrDefaultAsync();
            if (applicationUser == null)
            {
                return NotFound();

            }

            applicationUser.LockoutEnd = DateTime.Now;

            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
