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

namespace nscccoursemap_nhoxben335.Pages.DiplomaYearSections
{
    public class EditModel : PageModel
    {
        private readonly NSCCCourseMapContext _context;

        public EditModel(NSCCCourseMapContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DiplomaYearSection DiplomaYearSection { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DiplomaYearSection = await _context.DiplomaYearSections
                .Include(d => d.AcademicYear)
                .Include(d => d.DiplomaYear).FirstOrDefaultAsync(m => m.Id == id);

            if (DiplomaYearSection == null)
            {
                return NotFound();
            }
           ViewData["AcademicYearId"] = new SelectList(_context.AcademicYears, "Id", "Title");
           ViewData["DiplomaYearId"] = new SelectList(_context.DiplomaYears, "Id", "Title");
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

            _context.Attach(DiplomaYearSection).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiplomaYearSectionExists(DiplomaYearSection.Id))
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

        private bool DiplomaYearSectionExists(int id)
        {
            return _context.DiplomaYearSections.Any(e => e.Id == id);
        }
    }
}
