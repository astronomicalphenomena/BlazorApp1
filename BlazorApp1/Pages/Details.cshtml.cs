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
    public class DetailsModel : PageModel
    {
        private readonly BlazorApp1.Data.BlazorApp1Context _context;

        public DetailsModel(BlazorApp1.Data.BlazorApp1Context context)
        {
            _context = context;
        }

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
    }
}
