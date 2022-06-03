using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projekt2Slownik.Model;

namespace Projekt2Slownik.Pages.Slownik
{
    public class EditModel : PageModel
    {
        private ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Words Words { get; set; }

        [TempData]
        public string Message { get; set; }
        public async Task OnGet(int id)
        {
            Words = await _db.Words.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return RedirectToPage();
            }

            var WordFromDb = await _db.Words.FindAsync(Words.Id);
            WordFromDb.Pl = Words.Pl;
            WordFromDb.No = Words.No;

            await _db.SaveChangesAsync();

            Message = "Słowo zostało poprawione.";

            return RedirectToPage("Index");
        }
    }
}
