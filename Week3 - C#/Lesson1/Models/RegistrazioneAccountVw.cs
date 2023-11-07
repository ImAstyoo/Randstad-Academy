using System.ComponentModel.DataAnnotations;

namespace Lesson1.Models;

public class RegistrazioneAccountVw{
  [Required]
  [DataType(DataType.EmailAddress)]
  public string Email{ get; set; }

  [Required]
  [DataType(DataType.Password)]
  public string Password{ get; set; }

  [DataType(DataType.Password)]
  [Compare(nameof(Password))]
  public string ConfermaPassword{ get; set; }

  public bool Ricordami{ get; set; }
}