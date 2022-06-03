using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projekt2Slownik.Model;
using System.Threading.Tasks;

namespace Projekt2Slownik.Pages.Slownik
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Words Words { get; set; }

        [TempData]
        public string Message { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _db.Words.Add(Words);
            await _db.SaveChangesAsync();
            Message = "Nowe słowo zostało dodane do słownika.";

            return RedirectToPage("Index");
        }
    }
}
