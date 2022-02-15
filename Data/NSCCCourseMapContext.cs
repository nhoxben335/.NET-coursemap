#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NSCCCourseMap.Models;

 public class NSCCCourseMapContext : DbContext //database
{
public NSCCCourseMapContext (DbContextOptions<NSCCCourseMapContext> options) //constructor
: base(options)
{
}

// Tables
// This will a set a a particular model and giving it a name 

public DbSet<AcademicYear> AcademicYears {get; set;}
public DbSet<AdvisingAssignment> AdvisingAssignments {get; set;}
public DbSet<Course> Courses {get; set;}
public DbSet<CourseOffering> CourseOfferings{get; set;}
public DbSet<CoursePrerequisite> CoursePrerequisites {get; set;}
public DbSet<DiplomaYear> DiplomaYears {get; set;}
public DbSet<DiplomaYearSection> DiplomaYearSections {get; set;}
public DbSet<Instructor> Instructors {get; set;}
public DbSet<Semester> Semesters {get; set;}

public DbSet<Diploma> Diplomas {get; set;}


 // CUSTOM CONFIGURATION WITH FLUENT API
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    // RECONCILE THE MANY TO MANY RECURSIVE (VERSION 1)
    modelBuilder.Entity<Course>()
        .HasMany(c => c.Prerequisites)
        .WithOne(cpr => cpr.Course)
        .HasForeignKey(cpr => cpr.CourseId);
    modelBuilder.Entity<Course>()
        .HasMany(c => c.IsPrerequisiteFor)
        .WithOne(cpr => cpr.Prerequisite)
        .HasForeignKey(cpr => cpr.PrerequisiteId);

    // // RECONCILE THE MANY TO MANY RECURSIVE (VERSION 2)
    // modelBuilder.Entity<Course>()
    // .HasMany(c => c.Prerequisites)
    // .WithMany(c => c.IsPrerequisiteFor);
 
    // TURN OFF CASCADE DELETE FOR ALL RELATIONSHIPS
    foreach(var entity in modelBuilder.Model.GetEntityTypes())
    {
        foreach(var fk in entity.GetForeignKeys()){
            fk.DeleteBehavior = DeleteBehavior.NoAction;
        }
    }
}
}