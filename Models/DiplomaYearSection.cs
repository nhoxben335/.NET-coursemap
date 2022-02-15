namespace NSCCCourseMap.Models{
public class DiplomaYearSection{
// SCALAR PROPERTIES
public int Id { get; set; }
public string Title{ get; set; } = string.Empty;
public int DiplomaYearId{ get; set; }
public int AcademicYearId{ get; set; }

// NAVIGATION PROPERTY 
public AcademicYear? AcademicYear { get; set; }
public DiplomaYear? DiplomaYear { get; set; }
public ICollection<CourseOffering>? CourseOfferings { get; set; } // not sure if named this right
public AdvisingAssignment? AdvisingAssignment { get; set; }
}
}