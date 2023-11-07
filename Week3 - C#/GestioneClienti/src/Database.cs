using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GestioneClienti;

public class Database : IdentityDbContext<IdentityUser>{
  public DbSet<Database> 
  public Database(DbContextOptions<Database> options) : base(options){
  }
  

  protected override void OnModelCreating(ModelBuilder builder){
    base.OnModelCreating(builder);
  }
}