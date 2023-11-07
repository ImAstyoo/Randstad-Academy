using System.Data.SqlClient;

namespace Lesson2{
  internal class DbConnection{
    private string GetCon(){
      return "Server=localhost;Initial Catalog=Negozio;Integrated Security=SSPI";
    }

    public void ClientiUpdate(){
      try{
        using var connection = new SqlConnection(GetCon());
        connection.Open();
        Console.WriteLine("Starting Transaction..");
        var tr = connection.BeginTransaction();
        try{
          {
            const string query = "UPDATE Clienti Set Nome='Fausto' where ClienteID = 1";
            var cmd = new SqlCommand(query, connection, tr);
            var i = cmd.ExecuteNonQuery();
            Console.WriteLine($"Number of rows affected: {i}");
          }
          {
            const string query = "UPDATE Clienti Set Nome='Ugo' where ClienteID = 3";
            var cmd = new SqlCommand(query, connection, tr);
            var i = cmd.ExecuteNonQuery();
            Console.WriteLine($"Number of rows affected: {i}");
          }
          tr.Commit();
          Console.WriteLine("Committing transaction..");
        }
        catch (Exception e){
          Console.WriteLine(e);
          Console.WriteLine("Rollback..");
          tr.Rollback();
        }
      }
      catch (Exception e){
        Console.WriteLine(e);
      }
    }

    public void ClientiRead(){
      try{
        using var connection = new SqlConnection(GetCon());
        connection.Open();
        const string query = "SELECT nome,Cognome,EMail FROM Clienti WHERE Cognome >='G' ORDER BY Cognome";

        using var cmd = new SqlCommand(query, connection);
        var reader = cmd.ExecuteReader();
        while (reader.Read()){
          var nome = reader["Nome"].ToString();
          var cognome = reader["Cognome"].ToString();
          var email = reader["email"].ToString();
          var output = $"Nome Cliente: {nome} Cognome: {cognome} email: {email}";
          Console.WriteLine(output);
        }
      }
      catch (Exception e){
        Console.WriteLine(e.Message);
      }
    }
  }
}