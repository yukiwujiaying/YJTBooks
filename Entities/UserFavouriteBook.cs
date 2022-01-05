using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YJKBooks.Entities
{
    public class UserFavouriteBook
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("BookId")]
        public Book Book { get; set; }
        public int BookId { get; set; }

        [ForeignKey("UserId")]
        public Users User { get; set; }
        public int UserId { get; set; }
    }
}
