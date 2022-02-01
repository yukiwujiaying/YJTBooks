using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YJKBooks.Models;

namespace YJKBooks.Entities
{
    public class Reviews
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("BookId")]
        public Book Book { get; set; }
        public int BookId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
        public string UserId { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }

        public string Title { get; set; }

        [Required]
        public int Rating { get; set; }

        public DateTime PublishedDate { get; set; }
 


    }
}
