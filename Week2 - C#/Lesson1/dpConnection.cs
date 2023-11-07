namespace Lesson1
{
    internal class AdoDb
    {
        private string GetCon()
        {
            string con = "Data Source=WIN10-2023-08-2; Initial Catalog=Negozio; Integrated Security=True;";
            //string con  = "Data Source=WIN10-2023-08-2;Initial Catalog=Negozio;Integrated Security=True;";
            return con;
        }
        public void ClientiUpdate()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(GetCon()))
                {
                    connection.Open();
                    SqlTransaction tr =connection.BeginTransaction();
                    Console.WriteLine("Avvia Transaction");
                    try
                    {
                        {
                            string query = "UPDATE Clienti Set Nome='Fausto' where ClienteID = 1";
                            SqlCommand cmd = new SqlCommand(query, connection);
                            int i = cmd.ExecuteNonQuery();
                        }

                        {
                            string query = "UPDATE Clienti Set ZonaID='14' where ClienteID = 4";
                            SqlCommand cmd = new SqlCommand(query, connection);
                            int i = cmd.ExecuteNonQuery();
                        }


                        {
                            string query = "UPDATE Clienti Set Nome='Ugo' where ClienteID = 3";
                            SqlCommand cmd = new SqlCommand(query, connection);
                            int i = cmd.ExecuteNonQuery();
                        }
                        tr.Commit();
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Intervcetta errore, esegue Rollback");
                        tr.Rollback();

                    }


                }
            }
            catch (Exception e)
            {

                //throw;
            }

        }
        public void ClientiRead()
        {
            try
            {
                using (SqlConnection connection  =new SqlConnection(GetCon()))
                {
                    connection.Open();
                    string query = "SELECT nome,Cognome,EMail FROM Clienti WHERE Cognome >='G' ORDER BY Cognome";
                    
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                       SqlDataReader  reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            string nome = reader["Nome"].ToString();
                            string cognome = reader["Cognome"].ToString();
                            string email = reader["email"].ToString();
                            //-- costruzione stringa da mandare in stampa
                            //string s = "Nome Cliente: " + nome + " Cognome: " + cognome;
                            string output = $"Nome Cliente: {nome} Cognome: {cognome} email: {email}";
                            Console.WriteLine(output);
                        }
                    }
                    
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }
        public void ClientiRead_Normale()
        {
            //* Creazione oggetto di Connessione
            SqlConnection con = new SqlConnection(GetCon());
            try
            {
                //* Apertura Connessione
                con.Open();
                /*
                 * codice per lettra dati du Db
                */

            }
            catch (Exception e )
            {

            }
            finally
            {
                con.Close();
            }
            
        }
    }
}
