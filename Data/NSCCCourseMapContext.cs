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
}