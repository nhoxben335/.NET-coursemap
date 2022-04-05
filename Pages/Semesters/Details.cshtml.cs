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
    public class DetailsModel : PageModel
    {
        private readonly NSCCCourseMapContext _context;

        public DetailsModel(NSCCCourseMapContext context)
        {
            _context = context;
        }

        public Semester Semester { get; set; }
        public IEnumerable<CourseOffering> CourseOfferings {get;set;}


        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Semester = await _context.Semesters
                                    .FirstOrDefaultAsync(m => m.Id == id);


            CourseOfferings = await _context.CourseOfferings
                                        .Include(co => co.Semester)
                                            .ThenInclude(s=>s.AcademicYear)
                                        .Include(co=>co.Instructor)
                                        .Include(co=>co.Course)
                                        .Include(co=>co.DiplomaYearSection)
                                                .ThenInclude(dys=>dys.DiplomaYear)
                                                    .ThenInclude(dy=>dy.Diploma)
                                        .OrderBy(co=>co.DiplomaYearSection.DiplomaYear.Diploma.Title)
                                            .ThenBy(co=>co.DiplomaYearSection.DiplomaYear.Title)
                                                .ThenBy(co=>co.Course.CourseCode)
                                        .Where(co=>co.Semester.Id == id)
                                        .ToListAsync();

            if (Semester == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
