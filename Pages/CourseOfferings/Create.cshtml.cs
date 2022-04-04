#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NSCCCourseMap.Models;

namespace nscccoursemap_nhoxben335.Pages.CourseOfferings
{
    public class CreateModel : PageModel
    {
        private readonly NSCCCourseMapContext _context;

        public CreateModel(NSCCCourseMapContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "CourseCode");
        ViewData["DiplomaYearSectionId"] = new SelectList(_context.DiplomaYearSections, "Id", "Title");
        ViewData["InstructorId"] = new SelectList(_context.Instructors, "Id", "FirstName");
        ViewData["SemesterId"] = new SelectList(_context.Semesters, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public CourseOffering CourseOffering { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.CourseOfferings.Add(CourseOffering);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
