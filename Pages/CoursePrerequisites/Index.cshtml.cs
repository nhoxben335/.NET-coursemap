#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NSCCCourseMap.Models;

namespace nscccoursemap_nhoxben335.Pages.CoursePrerequisites
{
    public class IndexModel : PageModel
    {
        private readonly NSCCCourseMapContext _context;

        public IndexModel(NSCCCourseMapContext context)
        {
            _context = context;
        }

        public IList<CoursePrerequisite> CoursePrerequisite { get;set; }

        public async Task OnGetAsync()
        {
            CoursePrerequisite = await _context.CoursePrerequisites
                .Include(c => c.Course)
                .Include(c => c.Prerequisite)
                .OrderBy(c => c.Course.CourseCode)
                .ThenBy(c => c.Prerequisite.CourseCode)
                .ToListAsync();
        }
    }
}
