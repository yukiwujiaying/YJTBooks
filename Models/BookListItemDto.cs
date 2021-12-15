namespace YJKBooks.Models
{
    public class BookListItemDto
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Link { get; set; }
        public double Price { get; set; }
        public string PictureUrl { get; set; }
        public int Quantity { get; set; }
    }
}