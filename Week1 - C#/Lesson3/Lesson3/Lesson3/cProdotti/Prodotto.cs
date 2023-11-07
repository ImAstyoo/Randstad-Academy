namespace Lesson3.cProdotti;

public abstract class Prodotto{
  private string? _marca;
  private decimal? _prezzo;
  private int _qta = 0;
  private bool _accendi;


  public string? Marca{
    get => _marca;
    set => _marca = value;
  }

  public decimal? Prezzo{
    get => _prezzo;
    set => _prezzo = value;
  }

  public int Qta{
    get => _qta;
    set => _qta = value;
  }

  protected Prodotto(){
    _marca = "";
    _prezzo = 0;
    _qta = 0;
    _accendi = false;
  }
  
  
  protected Prodotto(string? marca, decimal? prezzo, int qta, bool accendi){
    _marca = marca;
    _prezzo = prezzo;
    _qta = qta;
    _accendi = accendi;
  }

  public bool Accendi{
    get => _accendi;
    set => _accendi = true;
  }

  public bool Spegni{
    get => _accendi;
    set => _accendi = false;
  }

  public void AggiungiQuantita(int qta){
    _qta += qta;
  }

  public void TogliQuantita(int qta){
    _qta -= qta;
  }
}