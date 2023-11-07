namespace Lesson3.cProdotti;

public class Archiviazione : Prodotto{
  private int? _capacita;

  public Archiviazione(string? marca, decimal? prezzo, int qta, bool accendi, int? capacita) : base(marca, prezzo, qta,
    accendi){
    _capacita = capacita;
  }
}