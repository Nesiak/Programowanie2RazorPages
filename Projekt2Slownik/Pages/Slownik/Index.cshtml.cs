using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Projekt2Slownik.Model;

namespace Projekt2Slownik.Pages.Slownik
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public IEnumerable<Words> Wordss { get; set; }

        [TempData]
        public string Message { get; set; }

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task OnGetAsync()
        {
            Wordss = await _db.Words.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var slowo = await _db.Words.FindAsync(id);
            if (slowo == null)
            {
                return NotFound();
            }
            _db.Words.Remove(slowo);
            await _db.SaveChangesAsync();
            Message = "Słowo zostało usunięte.";
            return RedirectToPage("Index");
        }
    }
}
