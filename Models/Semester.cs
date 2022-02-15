namespace NSCCCourseMap.Models{
public class Semester{
// SCALAR PROPERTIES
public int Id { get; set; }
public string Name{ get; set; } = string.Empty;

public DateTime StartDate{ get; set; } // Date time

public DateTime EndDate{ get; set; }

public int AcademicYearId{ get; set; }

// NAVIGATION PROPERTY 
public AcademicYear? AcademicYear { get; set; }
public ICollection<CourseOffering>? CourseOfferings { get; set; } // not sure if named this right 
}
}