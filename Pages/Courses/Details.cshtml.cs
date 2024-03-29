#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NSCCCourseMap.Models;

namespace nscccoursemap_nhoxben335.Pages.Courses
{
    public class DetailsModel : PageModel
    {
        private readonly NSCCCourseMapContext _context;

        public DetailsModel(NSCCCourseMapContext context)
        {
            _context = context;
        }

        public Course Course { get; set; }

        public IEnumerable<CoursePrerequisite> Prerequisites {get; set;}

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Course = await _context.Courses
                                    .FirstOrDefaultAsync(m => m.Id == id);

          Prerequisites = await _context.CoursePrerequisites
                .Include(c => c.Course)
                .Include(c => c.Prerequisite)
                .Where(c=>c.Course.Id == id)             
                .ToListAsync();
            if (Course == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
