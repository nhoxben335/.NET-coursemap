namespace NSCCCourseMap.Models{
public class Instructor{
// SCALAR PROPERTIES
public string FirstName{ get; set; } = string.Empty;
public string LastName{ get; set; } = string.Empty;
// NAVIGATION PROPERTY 
public ICollection<CourseOffering>? CourseOfferings { get; set; }
public ICollection<AdvisingAssignment>? AdvisingAssignments { get; set; }
}
}