using App202310_16.ModelsView;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace App202310_16.Controllers;

public class AccountController : Controller{
  private readonly RoleManager<IdentityRole> _roleManager;
  private readonly SignInManager<IdentityUser> _signInManager;
  private readonly UserManager<IdentityUser> _userManager;

  public AccountController(UserManager<IdentityUser> userManager,
    SignInManager<IdentityUser> signInManager,
    RoleManager<IdentityRole> roleManager){
    _userManager = userManager;
    _signInManager = signInManager;
    _roleManager = roleManager;
  }

  [HttpGet]
  public IActionResult Login(){
    return View();
  }

  [HttpPost]
  public async Task<IActionResult> Login(LoginAccountVw model){
    IdentityUser user = null;
    if (model.Email.Contains("@")) user = await _userManager.FindByNameAsync(model.Email);
    if (user == null){
      ModelState.AddModelError("", "Login o Password Errati");
      return View(model);
    }

    var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.Ricordami, true);

    if (result.IsLockedOut){
      ModelState.AddModelError("", "Login bloccato attendere alcuni minuti prima di riprovare");
      return View(model);
    }

    if (!result.Succeeded){
      ModelState.AddModelError("", "Login o Password Errati");
      return View(model);
    }

    return RedirectToAction("Index", "Home");
  }

  [HttpGet]
  public async Task<IActionResult> Registrazione(){
    await CreaRuolo("User");
    await CreaRuolo("Admin");
    return View();
  }

  [HttpPost]
  public async Task<IActionResult> Registrazione(RegistrazioneAccountVw model){
    if (ModelState.IsValid){
      var user = new IdentityUser{
        Email = model.Email,
        UserName = model.Email
      };

      var result = await _userManager.CreateAsync(user, model.Password);

      if (result.Succeeded){
        await _signInManager.SignInAsync(user, false);
        //---- attribuire un ruolo all'utente in questo caso sarà User
        await _userManager.AddToRoleAsync(user, "User");
        //---- in altre ruolo di tipo admin
        //---- in altre ruolo manager  oppure è anche uno sviluppatore un ruolo amministrazione
        return RedirectToAction("Index", "Home");
      }

      if (!result.Succeeded)
        foreach (var item in result.Errors)
          ModelState.AddModelError("", item.Description);
    }

    return View(model);
  }

  public async Task<IActionResult> Logout(){
    await _signInManager.SignOutAsync();
    return RedirectToAction("Index", "Home");
  }

  /// <summary>
  ///   Crea il Identity Role con nome passato come parametro
  /// </summary>
  /// <param name="nomeRuolo"></param>
  /// <returns></returns>
  private async Task CreaRuolo(string nomeRuolo){
    if (!await _roleManager.RoleExistsAsync(nomeRuolo)){
      var ruolo = new IdentityRole(nomeRuolo);
      var result = await _roleManager.CreateAsync(ruolo);
      if (result.Succeeded) return;
      //*** ruolo non è stato creato
      // c'è un errore lo gestisco nel modo che ritengo più opportuno
    }
  }
}