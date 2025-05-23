using E_Pet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace E_Pet.Pages
{
    public class Hayvanlar: PageModel
    {
        private readonly AppDbContext _appDbContext;

        [BindProperty]
        public List<Animals> AnimalList { get; set; } = new List<Animals>();

        public string ErrorMessage { get; set; }

        public Hayvanlar(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext; 
        }

        public IActionResult OnGet()
        {
            try
            {
                AnimalList = _appDbContext.Animals.ToList();
                return Page();
            }
            catch (System.Exception ex)
            {
                ErrorMessage = $"Hayvanları yüklerken hata oluştu: {ex.Message}";
                return Page();
            }
        }
    }
}