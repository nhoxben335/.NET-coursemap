#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NSCCCourseMap.Models;

namespace nscccoursemap_nhoxben335.Pages.DiplomaYears
{
    public class DeleteModel : PageModel
    {
        private readonly NSCCCourseMapContext _context;

        public DeleteModel(NSCCCourseMapContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DiplomaYear DiplomaYear { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DiplomaYear = await _context.DiplomaYears
                .Include(d => d.Diploma).FirstOrDefaultAsync(m => m.Id == id);

            if (DiplomaYear == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DiplomaYear = await _context.DiplomaYears.FindAsync(id);

            if (DiplomaYear != null)
            {
                _context.DiplomaYears.Remove(DiplomaYear);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
