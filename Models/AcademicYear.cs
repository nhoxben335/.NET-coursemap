namespace NSCCCourseMap.Models{
public class AcademicYear{
// SCALAR PROPERTIES
public int Id { get; set; }
public string Title{ get; set; } = string.Empty;

// NAVIGATION PROPERTY 
public ICollection<Semester>? Semesters { get; set; }
public ICollection<DiplomaYearSection>? DiplomaYearSections { get; set; }
}
}