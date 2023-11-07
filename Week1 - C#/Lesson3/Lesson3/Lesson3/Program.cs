using Lesson3.cProdotti;

namespace Lesson3{
  internal class Program{
    private static void Main(string[] args){
      Console.WriteLine("Hello world!");

      var c1 = new Computer("dalwd", 32, 23, false, 30);
      Console.WriteLine(c1.ToString());
    }
  }
}