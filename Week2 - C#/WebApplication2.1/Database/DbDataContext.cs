using Microsoft.EntityFrameworkCore;
using WebApplication2._1.Model;

namespace WebApplication2._1.Database;

public class DbDataContext : DbContext{
  private const string CnnString = "'Server=localhost;Database=Registro;Trusted_connection=true";
  public DbSet<Cliente> Clienti{ get; set; }


  protected override void OnConfiguring(DbContextOptionBuilder optionsBuilder){
    optionsBuilder.UseSqlServer(CnnString);
    base.OnConfiguring(optionsBuilder);
  }
}