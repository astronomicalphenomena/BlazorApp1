using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BlazorApp1.Data;

namespace BlazorApp1.Pages
{
    public class EditModel : PageModel
    {
        private readonly BlazorApp1.Data.BlazorApp1Context _context;

        public EditModel(BlazorApp1.Data.BlazorApp1Context context)
        {
            _context = context;
        }

        [BindProperty]
        public OCRbook OCRbook { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.OCRbook == null)
            {
                return NotFound();
            }

            var ocrbook =  await _context.OCRbook.FirstOrDefaultAsync(m => m.BookNameID == id);
            if (ocrbook == null)
            {
                return NotFound();
            }
            OCRbook = ocrbook;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(OCRbook).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OCRbookExists(OCRbook.BookNameID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool OCRbookExists(int id)
        {
          return _context.OCRbook.Any(e => e.BookNameID == id);
        }
    }
}
