using Lesson1.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Lesson1.Controllers;

public class AccountController : Controller{
  private RoleManager<IdentityRole> _roleManager;
  private readonly SignInManager<IdentityUser> _signInManager;
  private readonly UserManager<IdentityUser> _userManager;

  public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager,
    RoleManager<IdentityRole> roleManager){
    _userManager = userManager;
    _signInManager = signInManager;
    _roleManager = roleManager;
  }

  [HttpPost]
  public async Task<IActionResult> Registrazione(RegistrazioneAccountVw model){
    var user = await _userManager.FindByNameAsync(model.Email);
    if (!ModelState.IsValid) return View();

    var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.Ricordami, true);
    return RedirectToAction("Index", "Home");
  }
}