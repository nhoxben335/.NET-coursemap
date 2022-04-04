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

namespace nscccoursemap_nhoxben335.Pages.DiplomaYears
{
    public class EditModel : PageModel
    {
        private readonly NSCCCourseMapContext _context;

        public EditModel(NSCCCourseMapContext context)
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
           ViewData["DiplomaId"] = new SelectList(_context.Diplomas, "Id", "Title");
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

            _context.Attach(DiplomaYear).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiplomaYearExists(DiplomaYear.Id))
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

        private bool DiplomaYearExists(int id)
        {
            return _context.DiplomaYears.Any(e => e.Id == id);
        }
    }
}
