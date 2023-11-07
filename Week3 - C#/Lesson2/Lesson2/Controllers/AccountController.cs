using Lesson2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lesson2.Controllers;

public class AccountController : Controller{

  public IActionResult Index(){
    return View("RegisterVW");
  }
  
  [HttpPost]
  public IActionResult Register(AccountModel account){
    
    return View(!ModelState.IsValid ? "Error" : "RegisterVW");
  }
  
}