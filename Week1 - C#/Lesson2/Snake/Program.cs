using System.Windows.Input;
using static System.String;

namespace lesson2{
  internal class Program{
    private static void Main(string[] args){
      var program = new Program();
      Console.WriteLine(ReverseString("hello"));
      string[]? targhe = new string[100];

      AddTarga("hello");
      AddTarga(ReverseString("hello"));
      AddTarga("lalalalla");

      return;

      string ReverseString(string input){
        var reversed = new char[input.Length];
        var copy = input.ToCharArray();
        var j = 0;
        for (var i = copy.Length - 1; i >= 0; i--){
          reversed[j] = copy[i];
          j++;
        }

        return reversed.ToString();
      }

      int AddTarga(string targa){
        for (int i = 0; i < targhe.Length; i++){
          if (targhe[i] == Empty){
            targhe[i] = targa;
            return i;
          }
        }

        return targhe.Length;
      }
    }

    internal class Automobile{
      private EModel Model;

      enum EModel{
        fiat = 0,
        audi = 1,
        mercedes = 2,
        ferrari = 3,
        lancia = 4
      }

      Automobile(EModel model){
        this.Model = model;
      }
    }
  }
}