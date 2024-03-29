#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NSCCCourseMap.Models;

namespace nscccoursemap_nhoxben335.Pages.CourseOfferings
{
    public class EditModel : PageModel
    {
        private readonly NSCCCourseMapContext _context;

        public EditModel(NSCCCourseMapContext context)
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
           ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "CourseCode");
           ViewData["DiplomaYearSectionId"] = new SelectList(_context.DiplomaYearSections, "Id", "Title");
           ViewData["InstructorId"] = new SelectList(_context.Instructors, "Id", "FirstName");
           ViewData["SemesterId"] = new SelectList(_context.Semesters, "Id", "Name");
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

            _context.Attach(CourseOffering).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseOfferingExists(CourseOffering.Id))
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

        private bool CourseOfferingExists(int id)
        {
            return _context.CourseOfferings.Any(e => e.Id == id);
        }
    }
}
