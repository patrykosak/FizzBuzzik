using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FizzBuzzik.Data;
using FizzBuzzik.Models;

namespace FizzBuzzik
{
    public class IndexModel : PageModel
    {
        private readonly FizzBuzzik.Data.FizzBuzzContext _context;

        public IndexModel(FizzBuzzik.Data.FizzBuzzContext context)
        {
            _context = context;
        }

        public IList<FizzBuzz> FizzBuzz { get;set; }

        public async Task OnGetAsync()
        {
            FizzBuzz = await _context.FizzBuzz.ToListAsync();
        }
    }
}
