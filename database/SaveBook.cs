using api.interfaces;
using api.models;
using MySql.Data.MySqlClient;

namespace api.database
{
    public class SaveBook : ISaveBook
    {
        public void CreateBook(Book myBook)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"INSERT INTO books(title, author) VALUES(@title, @author, @genre, @numAvlb, @isbn, @length)";

            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@title", myBook.Title);
            cmd.Parameters.AddWithValue("@author", myBook.Author);
            cmd.Parameters.AddWithValue("@genre", myBook.Genre);
            cmd.Parameters.AddWithValue("@numAvlb", myBook.NumAvlb);
            cmd.Parameters.AddWithValue("@isbn", myBook.Isbn);
            cmd.Parameters.AddWithValue("@length", myBook.Length);

            cmd.Prepare();

            cmd.ExecuteNonQuery();

            con.Close();
        }

        public void Save(Book myBook)
        {
            throw new System.NotImplementedException();
        }
        
    }
}