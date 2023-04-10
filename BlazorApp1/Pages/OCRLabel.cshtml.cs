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
    public class IndexModel : PageModel
    {
        private readonly BlazorApp1Context _context;

        public IndexModel(BlazorApp1Context context)
        {
            _context = context;
        }

        public IList<OCRbook> OCRbook { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.OCRbook != null)
            {
                OCRbook = await _context.OCRbook.ToListAsync();
               await _context.BookName.ToListAsync();
            }
        }
    }
}
