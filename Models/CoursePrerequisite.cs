namespace NSCCCourseMap.Models{
public class CoursePrerequisite {
// SCALAR PROPERTIES
public int Id { get; set; } //PK

public int CourseId { get; set; } //FK

public int PrerequisiteId { get; set; } //FK 


// NAVIGATION PROPERTY 
public Course? Course {get; set;}
public Course? Prerequisite {get; set;}
// not sure if this right or not 
}
}