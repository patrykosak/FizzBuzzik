using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FizzBuzzik.Models
{
    public class FizzBuzz
    {
        public int Id { get; set; }
        [Display(Name = "Liczba: ")]
        [Required(), Range(1, 1000, ErrorMessage = "Liczba musi być z przedziału 1-1000")]
        public int value { get; set; }
        [Display(Name = "Wynik: ")]
        public string result { get; set; }
        [Display(Name = "Data: ")]
        public DateTime date { get; set; }

        public void Check()
        {
            result = "";
            if(value % 3 == 0)
            {
                result += "Fizz";
            }
            if(value % 5 == 0)
            {
                result += "Buzz";
            }
            if(value % 3 != 0 && value % 5 != 0)
            {
                result = "Liczba: " + value + " nie spełnia kryteriów Fizz / Buzz";
            }
            date = DateTime.Now;
        }
    }
}
