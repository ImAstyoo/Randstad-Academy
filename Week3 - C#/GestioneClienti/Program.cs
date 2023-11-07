using GestioneClienti;
using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
  .AddNegotiate();

builder.Services.AddAuthorization(options => { options.FallbackPolicy = options.DefaultPolicy; });
builder.Services.AddRazorPages();
var connectionString = builder.Configuration.GetConnectionString("SQLServerConnection");
builder.Services.AddDbContext<Database>(options => options.UseSqlServer(connectionString));

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
  .AddEntityFrameworkStores<Database>()
  .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(opt => {
  opt.Password.RequiredLength = 6;
  opt.Password.RequireNonAlphanumeric = false;
  opt.Password.RequireDigit = true;
  opt.Password.RequireLowercase = true;
  opt.Password.RequireUppercase = false;
  opt.User.RequireUniqueEmail = true;
  opt.Lockout.MaxFailedAccessAttempts = 3;
  opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);
});

var app = builder.Build();

if (!app.Environment.IsDevelopment()){
  app.UseExceptionHandler("/Home/Error");
  app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
  name: "default",
  pattern: "{controller=Registrazione}/{action=Index}/{id?}");

app.Run();