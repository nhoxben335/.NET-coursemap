namespace NSCCCourseMap.Models{
public class CourseOffering {
// SCALAR PROPERTIES
public int Id { get; set; } //PK

public int CourseId { get; set; } //FK

public int InstructorId { get; set; } //FK 

public int DiplomaYearSectionId { get; set; } //FK 

public int SemesterId { get; set; } //FK 

public bool IsDirectedElective { get; set; } // not sure this part 

// NAVIGATION PROPERTY 
public DiplomaYearSection? DiplomaYearSections { get; set; } // not sure if named this right
public Semester? Semesters { get; set; }
public Course? Course { get; set; }
public Instructor? Instructor { get; set; }
}
}