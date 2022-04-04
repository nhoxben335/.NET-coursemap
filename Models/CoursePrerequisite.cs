using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace NSCCCourseMap.Models{

[Index(nameof(CourseId), nameof(PrerequisiteId), IsUnique = true)]
public class CoursePrerequisite {
// SCALAR PROPERTIES
public int Id { get; set; } //PK

[Required]
public int CourseId { get; set; } //FK

[Required]
public int PrerequisiteId { get; set; } //FK 

// NAVIGATION PROPERTY 
public Course? Course {get; set;}
public Course? Prerequisite {get; set;}

    }
}