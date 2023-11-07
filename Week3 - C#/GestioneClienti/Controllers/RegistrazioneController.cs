using GestioneClienti.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GestioneClienti.Controllers;

public class RegistrazioneController : Controller{
  private UserManager<IdentityUser> _userManager;
  private SignInManager<IdentityUser> _signInManager;
  private RoleManager<IdentityRole> _roleManager;
  
  public IActionResult Index(){
    return View("RegistrazioneVW");
  }

  /*[HttpPost]
  public async Task<IActionResult> Login(LoginAccountVw model){
    IdentityUser user = null;
    if (model.Email.Contains("@")){
      user = await _userManager.FindByNameAsync(model.Email);
    }

    if (user == null){
      ModelState.AddModelError("", "Login o Password Errati");
      return View(model);
    }

    var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.Ricordami, true);

    if (result.IsLockedOut){
      ModelState.AddModelError("", "Login bloccato attendere alcuni minuti prima di riprovare");
      return View(model);
    }
    else if (!result.Succeeded){
      ModelState.AddModelError("", "Login o Password Errati");
      return View(model);
    }

    return RedirectToAction("Index", "Home");
  }*/

  [HttpGet]
  public async Task<IActionResult> Registrazione(){
    await CreaRuolo("User");
    await CreaRuolo("Admin");
    return View("_Layout");
  }

  [HttpPost]
  public async Task<IActionResult> Registrazione(Cliente model){
    if (!ModelState.IsValid) return View(model);
    var user = new IdentityUser(){
      Email = model.Email,
      UserName = model.Email
    };

    var result = await _userManager.CreateAsync(user, model.Password);

    switch (result.Succeeded){
      case true:
        await _signInManager.SignInAsync(user, isPersistent: false);
        await _userManager.AddToRoleAsync(user, "User");
        return RedirectToAction("Index", "Home");
      case false:{
        foreach (var item in result.Errors){
          ModelState.AddModelError("", item.Description);
        }

        break;
      }
    }

    return View(model);
  }

  public async Task<IActionResult> Logout(){
    await _signInManager.SignOutAsync();
    return RedirectToAction("Index", "Home");
  }

  private async Task CreaRuolo(string nomeRuolo){
    if (!await _roleManager.RoleExistsAsync(nomeRuolo)){
      var ruolo = new IdentityRole(nomeRuolo);
      var result = await _roleManager.CreateAsync(ruolo);
    }
  }
}