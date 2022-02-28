using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace NSCCCourseMap.Models{

[Index("Title", IsUnique = true)]
public class AcademicYear{
// SCALAR PROPERTIES
public int Id { get; set; }

[Required]
[StringLength(100, MinimumLength = 5)]
public string Title{ get; set; } = string.Empty;

// NAVIGATION PROPERTY 
public ICollection<Semester>? Semesters { get; set; }
public ICollection<DiplomaYearSection>? DiplomaYearSections { get; set; }
}
}