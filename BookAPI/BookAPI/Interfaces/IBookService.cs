using BookAPI.Models;

namespace BookAPI.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task<Book> GetBookByIdAsync(int id);
        Task CreateBookAsync(Book book);
        Task UpdateBookAsync(int id, Book book);
        Task DeleteBookAsync(int id);
    }
}
