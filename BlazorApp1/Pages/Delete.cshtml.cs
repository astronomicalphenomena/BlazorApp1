using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BlazorApp1.Data;

namespace BlazorApp1.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly BlazorApp1.Data.BlazorApp1Context _context;

        public DeleteModel(BlazorApp1.Data.BlazorApp1Context context)
        {
            _context = context;
        }

        [BindProperty]
      public OCRbook OCRbook { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.OCRbook == null)
            {
                return NotFound();
            }

            var ocrbook = await _context.OCRbook.FirstOrDefaultAsync(m => m.BookNameID == id);

            if (ocrbook == null)
            {
                return NotFound();
            }
            else 
            {
                OCRbook = ocrbook;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.OCRbook == null)
            {
                return NotFound();
            }
            var ocrbook = await _context.OCRbook.FindAsync(id);

            if (ocrbook != null)
            {
                OCRbook = ocrbook;
                _context.OCRbook.Remove(OCRbook);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
