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
    public class IndexModel : PageModel
    {
        private readonly NSCCCourseMapContext _context;

        public IndexModel(NSCCCourseMapContext context)
        {
            _context = context;
        }

        public IList<DiplomaYear> DiplomaYear { get;set; }

        public async Task OnGetAsync()
        {
            DiplomaYear = await _context.DiplomaYears
                .Include(dy => dy.Diploma)
                .OrderBy(dy => dy.Title)
                .ThenBy(dy => dy.Diploma.Title)
                .ToListAsync();
        }
    }
}
