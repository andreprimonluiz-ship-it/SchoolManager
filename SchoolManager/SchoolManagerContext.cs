using Microsoft.EntityFrameworkCore;

public class SchoolManagerContext(DbContextOptions<SchoolManagerContext> options) : DbContext(options)
{
    public DbSet<SchoolManager.Models.Classroom> Classroom { get; set; } = default!;
}
