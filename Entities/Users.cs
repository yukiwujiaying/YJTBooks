using System;
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

        [ForeignKey("CityId")]
        //navigation properties( navigate the point of interest to the parent city
        public Book favouritebooks { get; set; }
        public int BookId { get; set; }

        //A primary key constrain is a column that uniquely identifies every row in the table of the relational database management system, 
        //while foreign key is a column that creates a relationship between two tables.


    }
}
