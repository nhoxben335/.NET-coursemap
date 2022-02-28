using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace NSCCCourseMap.Models{

[Index(nameof(CourseId), nameof(DiplomaYearSectionId), nameof(SemesterId), IsUnique = true)]

public class CourseOffering {
        private const string V = "false";

        // SCALAR PROPERTIES
        public int Id { get; set; } //PK

[Required]
public int CourseId { get; set; } //FK

[Required]
public int? InstructorId { get; set; } //FK 

[Required]
public int DiplomaYearSectionId { get; set; } //FK 

[Required]
public int SemesterId { get; set; } //FK 

[DefaultValue(V)]
public bool IsDirectedElective { get; set; } // not sure this part 

// NAVIGATION PROPERTY 
public DiplomaYearSection? DiplomaYearSections { get; set; } // not sure if named this right
public Semester? Semesters { get; set; }
public Course? Course { get; set; }
public Instructor? Instructor { get; set; }
}
}
