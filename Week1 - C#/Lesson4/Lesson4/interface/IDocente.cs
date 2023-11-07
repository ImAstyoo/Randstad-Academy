namespace Lesson4.@interface;

public interface IDocente{
  
  public int RilevazionePresenze(string[] presenti){
    var rand = new Random();
    return rand.Next(2, 20);
  }
}