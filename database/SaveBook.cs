using System;
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

            string stm = @"INSERT INTO books(title, author, genre, numAvlb, isbn, length, cover, cwid) VALUES(@title, @author, @genre, @numAvlb, @isbn, @length, @cover, @cwid)";

            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@title", myBook.Title);
            cmd.Parameters.AddWithValue("@author", myBook.Author);
            cmd.Parameters.AddWithValue("@genre", myBook.Genre);
            cmd.Parameters.AddWithValue("@numAvlb", myBook.NumAvlb);
            cmd.Parameters.AddWithValue("@isbn", myBook.Isbn);
            cmd.Parameters.AddWithValue("@length", myBook.Length);
            cmd.Parameters.AddWithValue("@cover", myBook.Cover);
            cmd.Parameters.AddWithValue("@cwid", myBook.Cwid);

            cmd.Prepare();

            cmd.ExecuteNonQuery();

        }

        public void Save(Book myBook)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"UPDATE books SET title = @title, author = @author, genre = @genre, ";
            stm += @"numAvlb = @numAvlb, isbn = @isbn, length = @length, cover = @cover ";
            stm += @"WHERE id = @id";

            using var cmd = new MySqlCommand();
            cmd.Connection = con;
            cmd.CommandText = stm;

            cmd.Parameters.AddWithValue("@id", myBook.Id);
            cmd.Parameters.AddWithValue("@title", myBook.Title);
            cmd.Parameters.AddWithValue("@author", myBook.Author);
            cmd.Parameters.AddWithValue("@genre", myBook.Genre);
            cmd.Parameters.AddWithValue("@numAvlb", myBook.NumAvlb);
            cmd.Parameters.AddWithValue("@isbn", myBook.Isbn);
            cmd.Parameters.AddWithValue("@length", myBook.Length);
            cmd.Parameters.AddWithValue("@cover", myBook.Cover);

            cmd.Prepare();

            cmd.ExecuteNonQuery();


        }

    }
}