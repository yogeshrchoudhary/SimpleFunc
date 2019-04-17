namespace BookLib.Domain.DomainObjects
{
    public class Book
    {
        public int Id { get; set; }
        public string Isbn { get; set; }
        public string Summary { get; set; }
        public string Title { get; set; }
        public int? NumberOfPages { get; set; }
        public string Authors { get; set; }
        public string Publisher { get; set; }
        public bool? IsDeleted { get; set; }
        public string ImageURL { get; set; }
    }
}
