namespace YJKBooks.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Synopsis { get; set; }
        public string PictureUrl { get; set; }
        public string Genre { get; set; }
    }
}