namespace NSCCCourseMap.Models{
public class AdvisingAssignment {
// SCALAR PROPERTIES
public int Id { get; set; } //PK

public int InstructorId { get; set; } //FK

public int DiplomaYearSectionId { get; set; } 
// NAVIGATION PROPERTIES
public Instructor? Instructor { get; set; }
public DiplomaYearSection? DiplomaYearSection { get; set; }

}
}