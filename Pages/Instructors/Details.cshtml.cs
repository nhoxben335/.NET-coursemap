#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NSCCCourseMap.Models;

namespace nscccoursemap_nhoxben335.Pages.Instructors
{
    public class DetailsModel : PageModel
    {
        private readonly NSCCCourseMapContext _context;

        public DetailsModel(NSCCCourseMapContext context)
        {
            _context = context;
        }

        public Instructor Instructor { get; set; }
        public IEnumerable<AdvisingAssignment> AdvisingAssignments {get;set;}

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Instructor = await _context.Instructors
                                        
                                        .FirstOrDefaultAsync(m => m.Id == id);



            AdvisingAssignments = await _context.AdvisingAssignments
                                             .Include(aa=>aa.DiplomaYearSection)
                                                .ThenInclude(dys=>dys.DiplomaYear)
                                                    .ThenInclude(dy=>dy.Diploma)
                                            .Include(aa=>aa.DiplomaYearSection)
                                                .ThenInclude(dys=>dys.AcademicYear)
                                            .OrderByDescending(aa => aa.DiplomaYearSection.AcademicYear.Title)
                                            .Where(aa => aa.Instructor.Id == id)
                                            .ToListAsync();

            if (Instructor == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
