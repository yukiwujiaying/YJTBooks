using System.ComponentModel.DataAnnotations.Schema;

namespace YJKBooks.Entities
{
    public class Review
    {
        public int ReviewId { get; set; }
        public string Text { get; set; }
        public int Rating { get; set; }
        [ForeignKey("Book")]
        public int BookId { get; set; }
        public Book Book { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }
       

    }
}