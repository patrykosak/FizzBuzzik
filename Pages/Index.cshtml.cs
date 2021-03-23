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

namespace FizzBuzzik.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        [BindProperty]
        public FizzBuzz FizzBuzz { get; set; }
        public List<FizzBuzz> List { get; set; }
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
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
            HttpContext.Session.SetString("LastSearches", JsonConvert.SerializeObject(List));
            return Page();
        }
    }
}
