using DataIdentity.IdentityData;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace App202310_17;

public class Program{
  public static void Main(string[] args){
    var builder = WebApplication.CreateBuilder(args);

    //--- righe aggiunte per Identity utilizzando Scafolding
    var connectionString = builder.Configuration.GetConnectionString("SQLServerIdentityConnection") ??
                           throw new InvalidOperationException(
                             "Connection string 'LoginIdentityContextConnection' not found.");
    //--- righe aggiunte per Gestione Identity 
    builder.Services.AddDbContext<IdentityDb>(options => options.UseSqlServer(connectionString));

    //builder.Services.AddIdentityCore<AccountUser>(options => options.SignIn.RequireConfirmedAccount = true)
    //    .AddEntityFrameworkStores<IdentityDb>();

    builder.Services.AddIdentity<IdentityUser, IdentityRole>()
      .AddEntityFrameworkStores<IdentityDb>()
      .AddDefaultTokenProviders();

    builder.Services.Configure<IdentityOptions>(opt => {
      // Altri settaggi Identity
      //opt.SignIn.RequireConfirmedAccount = false; // Puoi personalizzare questa opzione
      //opt.SignIn.RequireConfirmedEmail = false; // Puoi personalizzare questa opzione
      //opt.SignIn.RequireConfirmedPhoneNumber = false; // Puoi personalizzare questa opzione

      opt.Password.RequiredLength = 6;
      opt.Password.RequireNonAlphanumeric = false;
      opt.Password.RequireDigit = true;
      opt.Password.RequireLowercase = true;
      opt.Password.RequireUppercase = false;
      opt.User.RequireUniqueEmail = true;
      opt.Lockout.MaxFailedAccessAttempts = 3;
      opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);
    });
    //*************************************************************************************************
    builder.Services.ConfigureApplicationCookie(options => {
      options.Cookie.Name = ".AspNetCore.Identity.Application";
      options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
      options.SlidingExpiration = true;
      options.LoginPath = "/Account/Login"; //percorso di default per logine
      options.AccessDeniedPath = "/Account/AccessDenied"; // Percorso per l'accesso negato
    });

    //*************************************************************************************************
    //*************************************************************************************************
    // Add services to the container.
    builder.Services.AddControllersWithViews();
    //builder.Services.AddControllersWithViews().AddRazorPagesOptions(options => {
    //    options.Conventions.AddAreaPageRoute("Identity", "/Account/Login2", "");
    //});

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment()){
      app.UseExceptionHandler("/Home/Error");
      // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
      app.UseHsts();
    }
    else{
      app.UseExceptionHandler("/Home/Error");
      app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();


    app.UseAuthentication(); //** aggiunto  prima di UseAuthorization();
    app.UseAuthorization();


    app.UseStatusCodePagesWithReExecute("/Home/Error", "?statusCode={0}");

    app.MapControllerRoute(
      "default",
      "{controller=Home}/{action=Index}/{id?}");


    app.Run();
  }
}
//using DataIdentity.IdentityData;
//using Microsoft.AspNetCore.Authentication.Cookies;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Options;

//namespace gbiIdentity
//{
//    public class Program
//    {
//        public static void Main(string[] args)
//        {
//            var builder = WebApplication.CreateBuilder(args);

//            //--- righe aggiunte per Identity utilizzando Scafolding
//            var connectionString = builder.Configuration.GetConnectionString("SQLServerIdentityConnection") ?? throw new InvalidOperationException("Connection string 'LoginIdentityContextConnection' not found.");
//            //--- righe aggiunte per Gestione Identity 
//            builder.Services.AddDbContext<IdentityDb>(options => options.UseSqlServer(connectionString));

//            //builder.Services.AddIdentityCore<AccountUser>(options => options.SignIn.RequireConfirmedAccount = true)
//            //    .AddEntityFrameworkStores<IdentityDb>();

//            builder.Services.AddIdentity<IdentityUser, IdentityRole>()
//                .AddEntityFrameworkStores<IdentityDb>()
//                .AddDefaultTokenProviders();
//            builder.Services.Configure<IdentityOptions>(opt => {

//                // Altri settaggi Identity
//                //opt.SignIn.RequireConfirmedAccount = false; // Puoi personalizzare questa opzione
//                //opt.SignIn.RequireConfirmedEmail = false; // Puoi personalizzare questa opzione
//                //opt.SignIn.RequireConfirmedPhoneNumber = false; // Puoi personalizzare questa opzione

//                opt.Password.RequiredLength = 6;
//                opt.Password.RequireNonAlphanumeric = false;
//                opt.Password.RequireDigit = true;
//                opt.Password.RequireLowercase = true;
//                opt.Password.RequireUppercase = false;
//                opt.User.RequireUniqueEmail = true;
//                opt.Lockout.MaxFailedAccessAttempts = 3;
//                opt.Lockout.DefaultLockoutTimeSpan = System.TimeSpan.FromMinutes(3);
//            });
//            //*************************************************************************************************
//            builder.Services.ConfigureApplicationCookie(options =>
//            {
//                options.Cookie.Name = ".AspNetCore.Identity.Application";
//                options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
//                options.SlidingExpiration = true;
//                options.LoginPath = "/Account/Login";
//            });
//            //*************************************************************************************************
//            // Add services to the container.
//            builder.Services.AddControllersWithViews();
//            //builder.Services.AddControllersWithViews().AddRazorPagesOptions(options => {
//            //    options.Conventions.AddAreaPageRoute("Identity", "/Account/Login2", "");
//            //});

//            var app = builder.Build();

//            // Configure the HTTP request pipeline.
//            if (!app.Environment.IsDevelopment())
//            {
//                app.UseExceptionHandler("/Home/Error");
//                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//                app.UseHsts();
//            }
//            else
//            {
//                app.UseExceptionHandler("/Home/error");
//                app.UseHsts();
//            }

//            app.UseHttpsRedirection();
//            app.UseStaticFiles();

//            app.UseRouting();

//            app.UseAuthentication();//** aggiunto  prima di UseAuthorization();
//            app.UseAuthorization();

//            app.UseStatusCodePagesWithReExecute("/Home/Error", "?StatusCode={0}");

//            app.MapControllerRoute(
//                name: "default",
//                pattern: "{controller=Home}/{action=Index}/{id?}");


//            app.Run();
//        }


//    }
//}