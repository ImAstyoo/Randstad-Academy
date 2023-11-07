using System.ComponentModel.DataAnnotations.Schema;

namespace EsercizioClienti;

[Table("Clienti")]
public class Cliente{
  public int Id{ get; set; }
  public string? Email{ get; set; }
  public string? Nome{ get; set; }
  public string? Cognome{ get; set; }
  public string? Cf{ get; set; }
  public string? PartitaIva{ get; set; }
  public string? Indirizzo{ get; set; }
  public string? Localita{ get; set; }
  public string? Provincia{ get; set; }
  public string? Cap{ get; set; }
  public int ZonaId{ get; set; }
  //public Zona Zona{ get; set; }
  
}