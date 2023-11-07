using Lesson4.@interface;

namespace Lesson4.@class;

public class Alunno : IPersona, IAlunno{
  public string? Nome{ get; set; }
  public string? Cognome{ get; set; }
  public int? Eta{ get; set; }
  public IPersona.ESex Sesso{ get; set; }
  public bool Collegato{ get; set; }
  public bool Presenza{ get; set; }


  public Alunno(string name){
    Nome = name;
    Cognome = "";
    Sesso = IPersona.ESex.None;
    Eta = 0;
    Collegato = false;
  }

  public Alunno(string? nome, string? cognome, int? eta, IPersona.ESex sesso, bool collegato, bool presenza){
    Nome = nome;
    Cognome = cognome;
    Eta = eta;
    Sesso = sesso;
    Collegato = collegato;
    Presenza = presenza;
  }


  public void CollegatoSw(){
    Collegato = !Collegato;
  }

  public void IngressoAlunno(){
    Collegato = true;
  }

  public void UscitaAlunno(){
    Collegato = false;
  }
}