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
    public class IndexModel : PageModel
    {
        private readonly NSCCCourseMapContext _context;

        public IndexModel(NSCCCourseMapContext context)
        {
            _context = context;
        }

        public IList<Instructor> Instructors { get;set; }

        public async Task OnGetAsync()
        {
            Instructors = await _context.Instructors
            .OrderBy(i => i.LastName)
            .ToListAsync();
        }
    }
}
