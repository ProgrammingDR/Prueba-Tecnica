using BookAPI.Interfaces;
using BookAPI.Models;

namespace BookAPI.Services
{
    public class BookService : IBookService
    {
        private readonly HttpClient _httpClient;
        private readonly string uri = "https://fakerestapi.azurewebsites.net/api/v1/Books";

        public BookService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            var result = await _httpClient.GetFromJsonAsync<List<Book>>(uri);
            return result;
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Book>($"{uri}/{id}");
        }

        public async Task CreateBookAsync(Book book)
        {
            await _httpClient.PostAsJsonAsync(uri, book);
        }

        public async Task UpdateBookAsync(int id, Book book)
        {
            await _httpClient.PutAsJsonAsync($"{uri}/{id}", book);
        }

        public async Task DeleteBookAsync(int id)
        {
            await _httpClient.DeleteAsync($"{uri}/{id}");
        }
    }
}
