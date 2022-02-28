using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace NSCCCourseMap.Models{
  

public class Instructor{
// SCALAR PROPERTIES
public int Id { get; set; }
[Required]
public string FirstName{ get; set; } = string.Empty;
[Required]
public string LastName{ get; set; } = string.Empty;
// NAVIGATION PROPERTY 
public ICollection<CourseOffering>? CourseOfferings { get; set; }
public ICollection<AdvisingAssignment>? AdvisingAssignments { get; set; }
}
}