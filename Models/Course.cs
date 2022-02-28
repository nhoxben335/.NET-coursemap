using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace NSCCCourseMap.Models{
    
[Index("CourseCode", IsUnique = true)]
public class Course {

// SCALAR PROPERTIES
    public int Id { get; set; }

    
    [Required]
    [RegularExpression(@"/^[A-Za-z]{4}\d{4}$/")]
    public string CourseCode{ get; set; } = string.Empty;
    
    [Required]
    [StringLength(100, MinimumLength = 5)]
    public string Title {get; set;} = string.Empty;
    

// NAVIGATION PROPERTIES 
    public ICollection<CoursePrerequisite>? Prerequisites { get; set; }

    public ICollection<CoursePrerequisite>? IsPrerequisiteFor { get; set; }

    public ICollection<CourseOffering>? CourseOfferings { get; set; }
}
}