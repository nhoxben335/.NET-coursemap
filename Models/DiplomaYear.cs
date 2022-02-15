namespace NSCCCourseMap.Models{
public class DiplomaYear{
// SCALAR PROPERTIES
public int Id { get; set; }
public string Title{ get; set; } = string.Empty;
public int DiplomaId{ get; set; }
// NAVIGATION PROPERTY 
public Diploma? Diploma { get; set; } 
public ICollection<DiplomaYearSection>? DiplomasYearSections { get; set; }
}
}