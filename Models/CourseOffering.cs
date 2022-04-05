using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace NSCCCourseMap.Models{

[Index(nameof(CourseId), nameof(DiplomaYearSectionId), nameof(SemesterId), IsUnique = true)]

public class CourseOffering {

// SCALAR PROPERTIES
public int Id { get; set; } //PK

[Required]
public int CourseId { get; set; } //FK

public int? InstructorId { get; set; } //FK 

[Required]
public int DiplomaYearSectionId { get; set; } //FK 

[Required]
public int SemesterId { get; set; } //FK 

public bool IsDirectedElective { get; set; } // not sure this part 

// NAVIGATION PROPERTY 
public DiplomaYearSection? DiplomaYearSection { get; set; } // not sure if named this right
public Semester? Semester { get; set; }
public Course? Course { get; set; }
public Instructor? Instructor { get; set; }
}
}
