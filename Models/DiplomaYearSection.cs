using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace NSCCCourseMap.Models{

    [Index(nameof(Title), nameof(DiplomaYearId), nameof(AcademicYearId), IsUnique = true)]

public class DiplomaYearSection{
// SCALAR PROPERTIES
public int Id { get; set; }
[Required]
public string Title{ get; set; } = string.Empty;

[Required]
public int DiplomaYearId{ get; set; }
[Required]
public int AcademicYearId{ get; set; }

// NAVIGATION PROPERTY 
public AcademicYear? AcademicYear { get; set; }
public DiplomaYear? DiplomaYear { get; set; }
public ICollection<CourseOffering>? CourseOfferings { get; set; } // not sure if named this right
public AdvisingAssignment? AdvisingAssignment { get; set; }
}
}
// Title must take the format -> "Section X" where X is a digit between 1 and 9