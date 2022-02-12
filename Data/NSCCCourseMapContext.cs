#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

 public class NSCCCourseMapContext : DbContext //database
{
public NSCCCourseMapContext (DbContextOptions<NSCCCourseMapContext> options) //constructor
: base(options)
{
}
// Tables
// This will a set a a particular model and giving it a name 
// public DbSet<AcademicYear> AcademicYears {get; set;}
// public DbSet<Instructor> Instructors {get; set;}
// public DbSet<Diploma> Diplomas {get; set;}

// public DbSet<DiplomaYear> DiplomaYears{get; set;}
// public DbSet<Semester> Semesters {get; set;}
// public DbSet<Course> Courses {get; set;}

}