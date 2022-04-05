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
    public class DetailsModel : PageModel
    {
        private readonly NSCCCourseMapContext _context;

        public DetailsModel(NSCCCourseMapContext context)
        {
            _context = context;
        }

        public DiplomaYear DiplomaYear { get; set; }
        public IEnumerable<CourseOffering> CourseOfferings {get; set;}

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DiplomaYear = await _context.DiplomaYears
                .Include(d => d.Diploma).FirstOrDefaultAsync(m => m.Id == id);

            CourseOfferings = await _context.CourseOfferings
                                            .Include(co => co.Semester)
                                            .Include(co=> co.DiplomaYearSection)
                                                .ThenInclude(dys=>dys.DiplomaYear)
                                                    .ThenInclude(dy=>dy.Diploma)
                                            .Include(co=>co.Course)
                                            .Include(co=>co.Instructor)
                                            .Where(co=>co.DiplomaYearSection.DiplomaYear.Id == id)
                                            .OrderByDescending(co => co.Semester.StartDate)
                                                .ThenBy(co=>co.DiplomaYearSection.DiplomaYear.Diploma.Title)
                                            .ToListAsync();

            if (DiplomaYear == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
