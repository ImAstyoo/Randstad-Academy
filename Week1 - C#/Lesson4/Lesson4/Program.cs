using Lesson4.@class;

namespace Lesson4{
  internal class Program{
    private static void Main(string[] args){
      var registroPresenze = new List<string?>();
      var logs = new Exception[100];
      var rand = new Random();
      var maxAlunni = rand.Next(2, 20);
      for (var i = 0; i < maxAlunni; i++){
        // Fill Reg
        var name = "Francesco" + i;
        if (i % 2 == 0) AulaVirtuale.IngressoAlunno(name); 
        else logs[logs.GetLength(100) - 1] = new AulaVirtuale.NotConnectedException("Alunno non trovato");
      }
      foreach (var log in logs){
        Console.WriteLine(log);
      }
    }
  }
}