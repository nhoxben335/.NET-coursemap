using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace NSCCCourseMap.Models{

[Index(nameof(InstructorId), nameof(DiplomaYearSectionId), IsUnique = true)]



public class AdvisingAssignment {
// SCALAR PROPERTIES

[Required]
public int Id { get; set; } 

[Required]
public int InstructorId { get; set; } 

[Required]
public int DiplomaYearSectionId { get; set; } 
// NAVIGATION PROPERTIES
public Instructor? Instructor { get; set; }
public DiplomaYearSection? DiplomaYearSection { get; set; }

}
}