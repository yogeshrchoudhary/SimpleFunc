using BookLib.Domain.DomainObjects;

namespace BookLib.Domain.Services.Implementation
{
    internal class BookSearchService : IBookSearchService
    {
        public Book SearchIsbn(string isbn)
        {
            return new Book
            {
                Id = 1,
                Authors = "J.K. Rowling",
                ImageURL = "{imgUrl}",
                Isbn = isbn,
                IsDeleted = false,
                NumberOfPages = 450,
                Publisher = "Penguin",
                Summary = "A popular childrens book",
                Title = "Harry Potter and the Philosophers Stone"
            };
        }
    }
}
