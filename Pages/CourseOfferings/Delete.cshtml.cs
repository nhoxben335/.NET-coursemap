#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NSCCCourseMap.Models;

namespace nscccoursemap_nhoxben335.Pages.CourseOfferings
{
    public class DeleteModel : PageModel
    {
        private readonly NSCCCourseMapContext _context;

        public DeleteModel(NSCCCourseMapContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CourseOffering CourseOffering { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CourseOffering = await _context.CourseOfferings
                .Include(c => c.Course)
                .Include(c => c.DiplomaYearSection)
                .Include(c => c.Instructor)
                .Include(c => c.Semester).FirstOrDefaultAsync(m => m.Id == id);

            if (CourseOffering == null)
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

            CourseOffering = await _context.CourseOfferings.FindAsync(id);

            if (CourseOffering != null)
            {
                _context.CourseOfferings.Remove(CourseOffering);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
