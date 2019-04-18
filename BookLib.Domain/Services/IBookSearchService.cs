using BookLib.Domain.DomainObjects;
using System.Threading.Tasks;

namespace BookLib.Domain.Services
{
    public interface IBookSearchService
    {
        Task<Book> SearchIsbn(string isbn);
    }
}
