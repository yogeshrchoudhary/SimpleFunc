using BookLib.Domain.DomainObjects;

namespace BookLib.Domain.Services
{
    public interface IBookSearchService
    {
        Book SearchIsbn(string isbn);
    }
}
