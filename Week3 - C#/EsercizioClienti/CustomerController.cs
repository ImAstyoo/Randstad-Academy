using Microsoft.AspNetCore.Mvc;

namespace EsercizioClienti;

public class CustomerController : Controller{

  public IActionResult Index(){
    return View();
  }

}