#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NSCCCourseMap.Models;

namespace nscccoursemap_nhoxben335.Pages.Semesters
{
    public class DeleteModel : PageModel
    {
        private readonly NSCCCourseMapContext _context;

        public DeleteModel(NSCCCourseMapContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Semester Semester { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Semester = await _context.Semesters
                .Include(s => s.AcademicYear).FirstOrDefaultAsync(m => m.Id == id);

            if (Semester == null)
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

            Semester = await _context.Semesters.FindAsync(id);

            if (Semester != null)
            {
                _context.Semesters.Remove(Semester);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
