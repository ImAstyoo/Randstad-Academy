using System.Diagnostics;
using EsercizioAutomobili.Models;
using Microsoft.AspNetCore.Mvc;

namespace EsercizioAutomobili.Controllers;

public class AutoMarche{
  public Automobile? Auto{ get; set; }
  public List<string> ElencoMarche{ get; set; }
}

public class AutomobileController : Controller{
  public IActionResult Index(){
    return RedirectToAction("AggiungiAutomobile");
  }


  [HttpGet]
  public IActionResult AggiungiAutomobile(){
    var auto = new AutoMarche{
      ElencoMarche = new List<string>{
        "Ford",
        "Alfa",
        "BMW",
        "Ferrari",
        "Audi"
      },
      Auto = new Automobile()
    };
    return View("AggiungiAutomobile", auto);
  }

  [HttpPost]
  public IActionResult AggiungiAutomobile(Automobile auto){
    return ModelState.IsValid ? RedirectToAction("Confirm") : View("AggiungiAutomobile");
  }

  public IActionResult Confirm(){
    throw new NotImplementedException();
  }
}