namespace NSCCCourseMap.Models{
public class AdvisingAssignment {
// SCALAR PROPERTIES
public int Id { get; set; } //PK

public int InstructorId { get; set; } //FK

public int PrerequisiteId { get; set; } //FK
}
}