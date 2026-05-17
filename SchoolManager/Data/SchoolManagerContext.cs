using Microsoft.EntityFrameworkCore;
using SchoolManager.Models;
using System.Reflection.Metadata.Ecma335;



public class SchoolManagerContext(DbContextOptions<SchoolManagerContext> options) : DbContext(options)
{
    public DbSet<Classroom> Classrooms { get; set; } = default!;
    public DbSet<Student> Students { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
}



