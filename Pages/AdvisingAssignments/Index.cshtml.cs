#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NSCCCourseMap.Models;

namespace nscccoursemap_nhoxben335.Pages.AdvisingAssignments
{
    public class IndexModel : PageModel
    {
        private readonly NSCCCourseMapContext _context;

        public IndexModel(NSCCCourseMapContext context)
        {
            _context = context;
        }

        public IList<AdvisingAssignment> AdvisingAssignment { get;set; }

        public async Task OnGetAsync()
        {
            AdvisingAssignment = await _context.AdvisingAssignments
                .Include(aa => aa.Instructor)
                .Include(aa => aa.DiplomaYearSection)
                .ThenInclude(dys => dys.DiplomaYear)
                .ThenInclude(dy => dy.Diploma)
                .OrderBy(aa => aa.DiplomaYearSection.DiplomaYear.Diploma.Title)
                .ThenBy(aa => aa.DiplomaYearSection.DiplomaYear.Title)
                .ThenBy(aa => aa.DiplomaYearSection.Title)
                .ToListAsync();
        }
    }
}
