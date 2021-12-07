using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace YJKBooks.Entities
{
    public partial class Book
    {
        //Entities is ORM you can query and manipultr data from a database using OOP
        //what you want to pass in to the data base
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }
        public string Link { get; set; }
        public string Synopsis { get; set; }
        public double Price { get; set; }
        public string PictureUrl { get; set; }
        public ICollection<Reviews> BookReviews { get; set; }
        public Genre BookGenre { get; set; }
        

        

    }
}
