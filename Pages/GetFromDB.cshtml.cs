using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FizzBuzzik.Data;
using FizzBuzzik.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FizzBuzzik
{
    [Authorize]
    public class GetFromDBModel : PageModel
    {
        private readonly FizzBuzzContext _context;
        public GetFromDBModel(FizzBuzzContext context)
        {
            _context = context;
        }
        public IList<FizzBuzz> List { get; set; }
        public void OnGet()
        {
            //var FizzBuzzQuery = from FizzBuzz in _context.FizzBuzz select FizzBuzz;
            //var Last10 = FizzBuzzQuery.TakeLast(2);
            //List = Last10.ToList();


            //List = _context.FizzBuzz.ToList();
            List = _context.FizzBuzz.ToList().TakeLast(20).OrderByDescending(x => x.date).ToList();
        }
    }
}