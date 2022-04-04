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
    public class IndexModel : PageModel
    {
        private readonly NSCCCourseMapContext _context;

        public IndexModel(NSCCCourseMapContext context)
        {
            _context = context;
        }

        public IList<DiplomaYearSection> DiplomaYearSection { get;set; }

        public async Task OnGetAsync()
        {
            DiplomaYearSection = await _context.DiplomaYearSections
                .Include(d => d.AcademicYear)
                .Include(d => d.DiplomaYear)
                .ThenInclude(dy => dy.Diploma)
                .OrderByDescending(dys => dys.AcademicYear)
                .ThenBy(dys => dys.DiplomaYear)
                .ThenBy(dys => dys.Title)
                .ToListAsync();
        }
    }
}
