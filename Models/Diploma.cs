using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NSCCCourseMap.Models{
[Index("Title", IsUnique = true)]
public class Diploma {
// SCALAR PROPERTIES
public int Id { get; set; }

[Required]
[StringLength(50, MinimumLength=10)]
public string Title{ get; set; } = string.Empty;

// NAVIGATION PROPERTY 
public ICollection<DiplomaYear>? DiplomaYears { get; set; }
}
}