using DataIdentity;
using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

BuildBuilder(builder);
BuildApp(app);
app.Run();

void BuildBuilder(WebApplicationBuilder _builder){
  _builder.Services.AddControllersWithViews();
  var cnn = builder.Configuration.GetConnectionString("SqlServerIdentityConnection");
  _builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<IdentityDb>()
    .AddDefaultTokenProviders();
  _builder.Services.AddDbContext<IdentityDb>(options => options.UseSqlServer(cnn));
  _builder.Services.Configure<IdentityOptions>(opt => {
    opt.Password.RequiredLength = 6;
    opt.Password.RequireNonAlphanumeric = false;
    opt.Password.RequireDigit = true;
    opt.Password.RequireLowercase = true;
    opt.Password.RequireUppercase = true;
    opt.User.RequireUniqueEmail = true;
    opt.Lockout.MaxFailedAccessAttempts = 3;
    opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);
  });
  _builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme).AddNegotiate();

  _builder.Services.AddAuthorization(options => { options.FallbackPolicy = options.DefaultPolicy; });
  _builder.Services.AddRazorPages();
}

void BuildApp(WebApplication _app){
  if (!_app.Environment.IsDevelopment()){
    _app.UseExceptionHandler("/Home/Error");
    _app.UseHsts();
  }

  _app.UseHttpsRedirection();
  _app.UseStaticFiles();

  _app.UseRouting();

  _app.UseAuthorization();

  _app.MapControllerRoute(
    "default",
    "{controller=Home}/{action=Index}/{id?}");
}