namespace Lesson4.@interface;

public interface IPersona{
  public string? Nome{ get; set; }
  public string? Cognome{ get; set; }
  public int? Eta{ get; set; }
  public ESex Sesso{ get; set; }
  public bool Collegato{ get; set; }
  void CollegatoSw();
  
  public enum ESex{
    None,
    Maschio,
    Femmina,
    Altro
  }
}