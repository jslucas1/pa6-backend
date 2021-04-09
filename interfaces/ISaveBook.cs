using api.models;

namespace api.interfaces
{
    public interface ISaveBook
    {
        public void CreateBook(Book myBook);
        public void Save(Book myBook);
    }
}