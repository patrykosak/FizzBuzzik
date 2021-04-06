using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FizzBuzzik.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using FizzBuzzik.Data;

namespace FizzBuzzik.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly FizzBuzzContext _context;
        [BindProperty]
        public FizzBuzz FizzBuzz { get; set; }
        public List<FizzBuzz> List { get; set; }
        public IndexModel(ILogger<IndexModel> logger, FizzBuzzContext context)
        {
            _logger = logger;
            _context = context;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var ListSession = HttpContext.Session.GetString("LastSearches");
            if (ListSession != null)
            {
                List = JsonConvert.DeserializeObject<List<FizzBuzz>>(ListSession);
            }
            else
            {
                List = new List<FizzBuzz>();
            }
            FizzBuzz.Check();
            List.Add(FizzBuzz);
            _context.Add(FizzBuzz);
            _context.SaveChanges();
            HttpContext.Session.SetString("LastSearches", JsonConvert.SerializeObject(List));
            return Page();
        }
    }
}
