#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NSCCCourseMap.Models;

namespace nscccoursemap_nhoxben335.Pages.AdvisingAssignments
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
        ViewData["DiplomaYearSectionId"] = new SelectList(_context.DiplomaYearSections, "Id", "Title");
        ViewData["InstructorId"] = new SelectList(_context.Instructors, "Id", "FirstName");
            return Page();
        }

        [BindProperty]
        public AdvisingAssignment AdvisingAssignment { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.AdvisingAssignments.Add(AdvisingAssignment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
