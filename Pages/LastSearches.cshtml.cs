using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using FizzBuzzik.Models;

namespace FizzBuzzik
{
    public class LastSearchesModel : PageModel
    {
        public List<FizzBuzz> List { get; set; }

        public void OnGet()
        {
            var LastSearches = HttpContext.Session.GetString("LastSearches");
            if (LastSearches != null)
                List = JsonConvert.DeserializeObject<List<FizzBuzz>>(LastSearches);
            else
                List = new List<FizzBuzz>();
        }
    }
}
