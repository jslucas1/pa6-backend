using api.database;
using api.interfaces;

namespace api.models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public int NumAvlb { get; set; }
        public string Isbn { get; set; }
        public int Length { get; set; }
        public string Cover { get; set; }
        public string Cwid { get; set; }

        public ISaveBook SaveAction { get; set; }

        public Book()
        {
            SaveAction = new SaveBook();
        }

        public override string ToString()
        {
            string text = $"{Id} {Title} {Author} {Genre} {NumAvlb} {Isbn} {Length} {Cover}";
            return text;
        }
    }
}