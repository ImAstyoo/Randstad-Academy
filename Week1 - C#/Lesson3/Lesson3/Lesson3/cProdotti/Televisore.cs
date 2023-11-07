namespace Lesson3.cProdotti;

public class Televisore : Prodotto{
  private double? _pollici;

  public Televisore(string? marca, decimal? prezzo, int qta, bool accendi, double? pollici) : base(marca, prezzo, qta,
    accendi){
    this._pollici = pollici;
  }
}