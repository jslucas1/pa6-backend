using api.interfaces;
using MySql.Data.MySqlClient;
namespace api.database
{
    public class DeleteBook : IDeleteBook
    {
        public void Delete(int id)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);

            con.Open();
            using var cmd = new MySqlCommand();
            cmd.Connection = con;

            cmd.CommandText = @"DELETE FROM books WHERE id=@id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Prepare();

            cmd.ExecuteNonQuery();
        }
    }
}