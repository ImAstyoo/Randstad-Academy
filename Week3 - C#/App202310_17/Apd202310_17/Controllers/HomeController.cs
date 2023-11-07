using System.Diagnostics;
using Apd202310_14.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Apd202310_14.Controllers;

//[Authorize(Roles = "User")]
public class HomeController : Controller{
  private readonly ILogger<HomeController> _logger;

  public HomeController(ILogger<HomeController> logger){
    _logger = logger;
  }

  [AllowAnonymous]
  public IActionResult Index(){
    ViewBag.Username = "Antonio Ippolito";
    ViewBag.ID = 12345;

    TempData["NomeUtente"] = "Luca Lamberti";
    TempData["UtenteId"] = 123;
    //return RedirectToAction("Privacy");

    Response.Cookies.Append("EMail", "pippo.pluto@gmail.com");

    return View();
  }


  public IActionResult Privacy(){
    ViewBag.EMail = Request.Cookies["EMail"];
    Response.Cookies.Delete("EMail");


    //string nome = @ViewBag.Username;
    //int? id = (int?)@ViewBag.ID;


    //ViewBag.Username = TempData.Peek("NomeUtente");
    //ViewBag.UtenteID = TempData.Peek("UtenteId");

    //string nomeUtente = TempData["NomeUtente"].ToString();
    //int? idUtente = (int?)TempData["UtenteId"];
    return View();
  }

  public IActionResult About(){
    return View();
  }

  //[AllowAnonymous]
  //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
  //public IActionResult Error()
  //{
  //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
  //}

  //[AllowAnonymous]
  //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
  //public IActionResult Errore (int? StatusCode = null)
  //{
  //    ErrorViewModel error= new ErrorViewModel();
  //    error.StatusCode = statusCode;
  //    error.RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier; 

  //    if (StatusCode.HasValue  && StatusCode == 404) 
  //    {
  //        return View("PageNotFound");
  //    }
  //    return View("Error", error);
  //}

  [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
  public IActionResult Error(int? statusCode = null){
    var error = new ErrorViewModel();
    error.StatusCode = statusCode;
    error.RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
    //er.ShowRequestId
    if (statusCode.HasValue && statusCode.Value == 404) return View("PageNotFound");
    // Puoi creare una vista "Error.cshtml" per gestire altri tipi di errori.
    return View("Error", error);
  }
}