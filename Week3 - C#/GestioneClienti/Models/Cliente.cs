using System.ComponentModel.DataAnnotations;

namespace GestioneClienti.Models;

public class Cliente{
  public int Id{ get; }
  [Required]
  [DataType(DataType.EmailAddress)]
  public string Email{ get; set; }
  [Required]
  [DataType(DataType.Password)]
  public string Password{ get; set; }
  public string? Nome{ get; set; }
  public string? Cognome{ get; set; }
  public string? Cap{ get; set; }
  public string? CodiceFiscale{ get; set; }
  public int Eta{ get; set; }


  //Essential Constructor
  public Cliente(string email, string password){
    Email = email;
    Password = password;
  }

  //Partial Constructor
  public Cliente(string email, string password, string? nome, string? cognome, string? codiceFiscale){
    Email = email;
    Password = password;
    Nome = nome;
    Cognome = cognome;
    CodiceFiscale = codiceFiscale;
  }


  //Extended Constructior
  public Cliente(string email, string password, string? nome, string? cognome, string? cap,
    string? codiceFiscale, int eta){
    Email = email;
    Password = password;
    Nome = nome;
    Cognome = cognome;
    Cap = cap;
    CodiceFiscale = codiceFiscale;
    Eta = eta;
  }
}