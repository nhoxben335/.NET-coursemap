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
    public class IndexModel : PageModel
    {
        private readonly NSCCCourseMapContext _context;

        public IndexModel(NSCCCourseMapContext context)
        {
            _context = context;
        }

        public IList<AcademicYear> AcademicYear { get;set; }

        public async Task OnGetAsync()
        {
            AcademicYear = await _context.AcademicYears
            .OrderByDescending(ay => ay.Title)
            .ToListAsync();
        }
    }
}
