using System.ComponentModel.DataAnnotations;

namespace Lesson1.Models;

public class LoginAccountVw{
  [Required] public string Email{ get; set; }

  [Required]
  [DataType(DataType.Password)]
  public string Password{ get; set; }

  public bool Ricordami{ get; set; }
}