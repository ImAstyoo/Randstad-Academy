namespace Lesson2
{
  internal class Program
  {
    private static void Main(string[] args)
    {
      var cnn = new DbConnection();
      cnn.ClientiRead();
      cnn.ClientiUpdate();
      cnn.ClientiRead();
    }
  }
}