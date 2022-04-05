#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NSCCCourseMap.Models;

namespace nscccoursemap_nhoxben335.Pages.AcademicYears
{
    public class DetailsModel : PageModel
    {
        private readonly NSCCCourseMapContext _context;

        public DetailsModel(NSCCCourseMapContext context)
        {
            _context = context;
        }

        public AcademicYear AcademicYear { get; set; }
        public IEnumerable<string> Semesters {get; set;}
        public IEnumerable<DiplomaYearSection> AdvisingAssignment {get; set;}

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

             AcademicYear = await _context.AcademicYears
                                        .Include(ay => ay.Semesters)
                                        .Include(ay => ay.DiplomaYearSections)
                                            .ThenInclude(dys=>dys.AdvisingAssignment)
                                                .ThenInclude(co=>co.Instructor)
                                        .Include(ay => ay.DiplomaYearSections)
                                            .ThenInclude(dys => dys.AdvisingAssignment)
                                         .Include(ay => ay.DiplomaYearSections)
                                            .ThenInclude(dys => dys.DiplomaYear)
                                                .ThenInclude(dys => dys.Diploma)
                                        .FirstOrDefaultAsync(m => m.Id == id);

            Semesters = AcademicYear.Semesters
                                    .OrderBy(s=> s.Name)
                                    .Select(s => s.Name);
                                    
            AdvisingAssignment = await _context.DiplomaYearSections
                                            .Include(dys=> dys.AdvisingAssignment)
                                                .ThenInclude(aa=>aa.Instructor)
                                            .Include(dys => dys.DiplomaYear)
                                                .ThenInclude(dy => dy.Diploma)
                                            .Where(dys=>dys.AcademicYear.Id == id)
                                            .ToListAsync();

            if (AcademicYear == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
