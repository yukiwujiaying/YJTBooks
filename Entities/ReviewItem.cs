//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.Linq;
//using System.Threading.Tasks;

//namespace YJKBooks.Entities
//{
//    public class ReviewItem
//    {
//        public int Id{get; set;}
        
//        [Required]
//        [MaxLength(1000)]
//        public string Description { get; set; }

//        public string Title{get; set;}

//        [Required]
//        public int Rating { get; set; }

//        public DateTime PublishedDate{get; set;}

//        public User User{get; set;}
//        public int UserId{get; set;}

//        public int ReviewsId{get; set;}
//        public Reviews Reviews{get; set;}
//    }
//}