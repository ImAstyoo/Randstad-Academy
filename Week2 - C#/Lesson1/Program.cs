using Lesson1;

namespace ADOes01
{
  internal class Program
  {
    static void Main(string[] args)
    {
      AdoDb ado = new AdoDb();
      ado.ClientiRead();
      Console.WriteLine("*****************************************************");
      ado.ClientiUpdate();
      Console.WriteLine("*****************************************************");
      ado.ClientiRead();
      Console.WriteLine();
      Console.WriteLine("*****************************************************");
      Console.WriteLine("Applicazione Terminata");

    }
  }
}