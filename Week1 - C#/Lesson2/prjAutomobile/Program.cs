namespace prjAutomobile{
  internal class Program{
    private class Automobile{
      private EModello Modello;


      public Automobile(EModello modello){
        this.Modello = modello;
      }

      public void StampaModello(){
        Console.WriteLine(this.Modello);
        Console.WriteLine((int)this.Modello!);
      }
    }

    private static void Main(string[] args){
      var a1 = new Automobile(EModello.audi);

      a1.StampaModello();
    }
  }

  public enum EModello{
    fiat = 0,
    audi = 1,
    mercedes = 2,
    ferrari = 3,
    lancia = 4
  }
}