using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NSCCCourseMap.Models
{
    [Index(nameof(Title), IsUnique = true)]
    public class Diploma 
    {
        // SCALAR PROPERTIES
    public int Id { get; set; }

    [Required]
    [MinLength(10)]
    public string Title{ get; set; } = string.Empty;

    // NAVIGATION PROPERTY 
    public ICollection<DiplomaYear>? DiplomaYears { get; set; }
    }
}