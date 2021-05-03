using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FizzBuzzik.Data;
using FizzBuzzik.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace FizzBuzzik
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly FizzBuzzik.Data.FizzBuzzContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public DeleteModel(FizzBuzzik.Data.FizzBuzzContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [BindProperty]
        public FizzBuzz FizzBuzz { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FizzBuzz = await _context.FizzBuzz.FirstOrDefaultAsync(m => m.Id == id);


            if (FizzBuzz == null || FizzBuzz.OwnerID == null || !FizzBuzz.OwnerID.Equals(_userManager.GetUserId(User)))
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FizzBuzz = await _context.FizzBuzz.FindAsync(id);

            if (FizzBuzz != null)
            {
                _context.FizzBuzz.Remove(FizzBuzz);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
