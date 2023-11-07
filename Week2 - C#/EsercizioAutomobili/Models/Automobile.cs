using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EsercizioAutomobili.Models;

public enum EColore{
  None,
  Verde,
  Giallo,
  Rosso,
  Blu,
  Arancione,
  Lilla
}

public class Automobile{
  [DisplayName("ID")] public int? AutomobileId{ get; set; }
  public string? Nome{ get; set; }
  public List<string> ElencoMarche{ get; set; }
  public string? Marca{ get; set; }
  public EColore Colore{ get; set; }
  public int NrPosti{ get; set; }
  public decimal Peso{ get; set; }

  [DisplayFormat(DataFormatString = "dd/MM/yyyy")]
  public DateTime? DataImmatricolazione{ get; set; }


  public Automobile(){
   
  }
}