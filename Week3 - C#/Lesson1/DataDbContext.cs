using Microsoft.EntityFrameworkCore;

namespace Lesson1;

public class DataDbContext : DbContext{
  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
    base.OnConfiguring(optionsBuilder);
  }
}