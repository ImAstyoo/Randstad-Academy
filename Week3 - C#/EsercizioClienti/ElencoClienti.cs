namespace EsercizioClienti;

public class ElencoClienti{
  private List<Cliente> _elencoClienti = new();


  public void AggiungiCliente(Cliente cli){
    _elencoClienti.Add(cli);
  }
  
  public void RimuoviCliente(Cliente cli){
    _elencoClienti.Remove(cli);
  }

  
  public void UpdateCliente(Cliente cli){
   // todo: implement
  }
  
}