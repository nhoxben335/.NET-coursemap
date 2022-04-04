#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NSCCCourseMap.Models;

namespace nscccoursemap_nhoxben335.Pages.DiplomaYearSections
{
    public class DetailsModel : PageModel
    {
        private readonly NSCCCourseMapContext _context;

        public DetailsModel(NSCCCourseMapContext context)
        {
            _context = context;
        }

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
            return Page();
        }
    }
}
