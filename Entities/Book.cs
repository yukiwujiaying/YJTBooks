﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace YJKBooks.Entities
{
    public class Book
    {
        //Entities is ORM you can query and manipultr data from a database using OOP
        //what you want to pass in to the data base
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Author { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public long Price { get; set; }
        public string PictureUrl { get; set; }
        public ICollection<Reviews> BookReviews { get; set; }
        public enum Genre
        {
            Fiction,
            Action_and_adventure,
            Classic,
            Horror

        }

    }
}
