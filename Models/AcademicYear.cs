using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace NSCCCourseMap.Models{

   [Index(nameof(Title), IsUnique = true)]
public class AcademicYear{
// SCALAR PROPERTIES
public int Id { get; set; }

[Required]
[MinLength(5), MaxLength(20)]
[StringLength(20, MinimumLength = 5)]
public string Title{ get; set; } = string.Empty;

// NAVIGATION PROPERTY 
public ICollection<Semester>? Semesters { get; set; }
public ICollection<DiplomaYearSection>? DiplomaYearSections { get; set; }
}
}