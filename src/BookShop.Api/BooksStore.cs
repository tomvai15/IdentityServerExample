namespace BookShop.Api
{
    public interface IBooksStore
    {
        IEnumerable<Book> GetBooks();
    }

    public class BooksStore : IBooksStore
    {
        private readonly List<Book> _books = new List<Book>()
        {
            new Book
            {
                Id = 1,
                Author = "Some Man",
                Title = "Ea sports"
            },
            new Book
            {
                Id = 2,
                Author = "Some Woman",
                Title = "Bruz"
            },
        };

        public IEnumerable<Book> GetBooks()
        {
            return _books;
        }
    }
}
