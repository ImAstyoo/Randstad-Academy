using Microsoft.AspNetCore.Mvc;

namespace GestioneClienti.Models;

public class ElencoClienti{
  private static List<Cliente> _elencoClienti{ get; set; } = new();
  
  public static void InserisciCliente(Cliente cli){
    _elencoClienti.Add(cli);
  }
  
  public void RimuoviCliente(Cliente cli){
    _elencoClienti.Remove(cli);
  }
  //todo: Update Cliente
  //todo: Dettaglio Cliente
  
}