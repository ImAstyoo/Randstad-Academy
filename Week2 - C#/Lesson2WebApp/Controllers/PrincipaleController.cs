using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Lesson2WebApp.Models;

namespace Lesson2WebApp.Controllers;

public class PrincipaleController : Controller{
  private readonly ILogger<PrincipaleController> _logger;

  public PrincipaleController(ILogger<PrincipaleController> logger){
    _logger = logger;
  }

  public IActionResult Index(){
    return View();
  }

  public IActionResult Privacy(){
    return View();
  }

  [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
  public IActionResult Error(){
    return View(new ErrorViewModel{ RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
  }
}