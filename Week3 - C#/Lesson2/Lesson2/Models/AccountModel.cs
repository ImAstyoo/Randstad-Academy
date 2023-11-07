using System.ComponentModel.DataAnnotations;

namespace Lesson2.Models;

public class AccountModel{

  [Required]
  [DataType(DataType.EmailAddress)]
  public string Email;
  [Required]
  [DataType(DataType.Password)]
  public string Password;

}