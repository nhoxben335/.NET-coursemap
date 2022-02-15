namespace NSCCCourseMap.Models{
public class Course {

// SCALAR PROPERTIES
    public int Id { get; set; }

    public string CourseCode{ get; set; } = string.Empty;

    public string Title {get; set;} = string.Empty;
    

// NAVIGATION PROPERTIES 
    public ICollection<CoursePrerequisite>? Prerequisites { get; set; }

    public ICollection<CoursePrerequisite>? IsPrerequisiteFor { get; set; }

    public ICollection<CourseOffering>? CourseOfferings { get; set; }
}
}