using Lesson4.@interface;

namespace Lesson4.@class;

public class Docente : IPersona, IDocente{
  public Docente(){
    Nome = "";
    Cognome = "";
    Eta = 0;
    Sesso = IPersona.ESex.None;
    Collegato = false;
  }


  public Docente(string? nome, string? cognome, int? eta, IPersona.ESex sesso, bool collegato){
    Nome = nome;
    Cognome = cognome;
    Eta = eta;
    Sesso = sesso;
    Collegato = collegato;
  }

  public string? Nome{ get; set; }
  public string? Cognome{ get; set; }
  public int? Eta{ get; set; }
  public IPersona.ESex Sesso{ get; set; }
  public bool Collegato{ get; set; }

  public void CollegatoSw(){
    Collegato = !Collegato;
  }
  
}