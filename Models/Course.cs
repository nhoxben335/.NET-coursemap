using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace NSCCCourseMap.Models{
   [Index(nameof(CourseCode), IsUnique = true)]
public class Course {

// SCALAR PROPERTIES
    public int Id { get; set; }
    
    [Required]
    [RegularExpression(@"^[A-Z]{4}\s[0-9]{4}$", ErrorMessage = "Incorrect Formatting")]   
    public string CourseCode{ get; set; } = string.Empty;
    
    [Required]
    [MinLength(5), MaxLength(100)]
    [StringLength(100, MinimumLength = 5)]
    public string Title {get; set;} = string.Empty;
    

// NAVIGATION PROPERTIES 
    public ICollection<CoursePrerequisite>? Prerequisites { get; set; }

    public ICollection<CoursePrerequisite>? IsPrerequisiteFor { get; set; }

    public ICollection<CourseOffering>? CourseOfferings { get; set; }
}
}