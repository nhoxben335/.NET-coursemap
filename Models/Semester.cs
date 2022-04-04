using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace NSCCCourseMap.Models{

   [Index(nameof(Name), IsUnique = true)]
public class Semester{
// SCALAR PROPERTIES
public int Id { get; set; }

[Required]
public string Name{ get; set; } = string.Empty;

[Required]
[DataType(DataType.Date)]
public DateTime StartDate{ get; set; } // Date time

[Required]
[DataType(DataType.Date)]
public DateTime EndDate{ get; set; }

[Required]
public int AcademicYearId{ get; set; }

// NAVIGATION PROPERTY 
public AcademicYear? AcademicYear { get; set; }
public ICollection<CourseOffering>? CourseOfferings { get; set; } // not sure if named this right 
}
}

//EndDate must be later than the StartDate

