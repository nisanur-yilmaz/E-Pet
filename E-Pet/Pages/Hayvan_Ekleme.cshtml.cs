using E_Pet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_Pet.Pages
{
    public class Hayvan_Ekleme : PageModel
    {
        private readonly AppDbContext _appDbContext;

        [BindProperty] public Animals Animals { get; set; }

        public Hayvan_Ekleme(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void OnGet()
        {
            // Sayfa yüklendiğinde yapılacak işlemler
        }

        public IActionResult OnPost()
        {

            if (string.IsNullOrEmpty(Animals.Type))
            {
                TempData["TypeError"] = "Hayvan türü boş olamaz.";
                return Page();
            }

            if (string.IsNullOrEmpty(Animals.ImgUrl))
            {
                TempData["ImgUrlError"] = "Fotoğraf URL'si boş olamaz.";
                return Page();
            }

            if (string.IsNullOrEmpty(Animals.Gender))
            {
                TempData["GenderError"] = "Hayvanın cinsiyeti boş olamaz.";
                return Page();
            }

            try
            {
                _appDbContext.Animals.Add(Animals);
                _appDbContext.SaveChanges();
                return RedirectToPage("Hayvanlar");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Bir hata oluştu: {ex.Message}";
                return Page();
            }
        }
    }
}