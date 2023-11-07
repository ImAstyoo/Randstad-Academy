namespace Lesson2WebApp.Models;

public class Prodotti{
  private int _id;
  private string? _nome;
  private decimal? _unitaMisura;
  private string? _categoria;
  private decimal _peso;
  private decimal _prezzo;
  private decimal _giacenza;


  public Prodotti(int id, string? nome, decimal? unitaMisura, string? categoria, decimal peso, decimal prezzo, decimal giacenza){
    _id = id;
    _nome = nome;
    _unitaMisura = unitaMisura;
    _categoria = categoria;
    _peso = peso;
    _prezzo = prezzo;
    _giacenza = giacenza;
  }

  public int Id{
    get => _id;
    set => _id = value;
  }

  public string? Nome{
    get => _nome;
    set => _nome = value;
  }

  public decimal? UnitaMisura{
    get => _unitaMisura;
    set => _unitaMisura = value;
  }

  public string? Categoria{
    get => _categoria;
    set => _categoria = value;
  }

  public decimal Peso{
    get => _peso;
    set => _peso = value;
  }

  public decimal Prezzo{
    get => _prezzo;
    set => _prezzo = value;
  }

  public decimal Giacenza{
    get => _giacenza;
    set => _giacenza = value;
  }
}