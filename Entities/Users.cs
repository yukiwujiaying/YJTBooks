﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace YJKBooks.Entities
{
    public class Users
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "You should provide a name value.")]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "You should provide a valid email")]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required(ErrorMessage = "You should provide a valid address.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "You should set a password!")]
        public string Password { get; set; }

        public ICollection<Book> FavouriteBooks { get; set; }

        public ICollection<Reviews> UserReviews { get; set; }


    }
}