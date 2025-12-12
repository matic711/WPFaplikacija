using Microsoft.EntityFrameworkCore;
public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder o)
        => o.UseSqlite("Data Source=appdata.db");
}
public class User
{
    public int Id { get; set; }
    public string FullName { get; set; }   // tbName
    public string Email { get; set; }      // tbEmail
    public string Password { get; set; }   // tbgeslo1
    public DateTime BirthDate { get; set; }// DatumRD
}