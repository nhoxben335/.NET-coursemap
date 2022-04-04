using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NSCCCourseMap.Models
{
   [Index(nameof(Title), nameof(DiplomaId), IsUnique = true)]
    public class DiplomaYear
    {
    public int Id { get; set; }
    [Required]
    [RegularExpression(@"^Year\s[1-4]{1}$", ErrorMessage = "Incorrect Formatting")]
    public string Title{ get; set; } = string.Empty;
    [Required]
    public int DiplomaId{ get; set; }
    // NAVIGATION PROPERTY 
    public Diploma? Diploma { get; set; } 
    public ICollection<DiplomaYearSection>? DiplomasYearSections { get; set; }
    }
}
