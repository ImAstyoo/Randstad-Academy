namespace Lesson3.cProdotti;

public class Computer : Prodotto{
  private int? _capacita;

  public Computer(int? capacita){
    _capacita = capacita;
  }

  public Computer(string? marca, decimal? prezzo, int qta, bool accendi, int? capacita) : base(marca, prezzo, qta, accendi){
    _capacita = capacita;
  }
  
}