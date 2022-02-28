using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NSCCCourseMap.Models{
[Index(nameof(Title), nameof(DiplomaId), IsUnique = true)]

public class DiplomaYear{
// SCALAR PROPERTIES

[Required]
public int Id { get; set; }

[Required]
public string Title{ get; set; } = string.Empty;
public int DiplomaId{ get; set; }
// NAVIGATION PROPERTY 
public Diploma? Diploma { get; set; } 
public ICollection<DiplomaYearSection>? DiplomasYearSections { get; set; }
}
}

//Title must take the format -> "Year X" where X is a digit between 1 and 4
