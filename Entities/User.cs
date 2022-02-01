using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YJKBooks.Entities
{
    public class User : IdentityUser
    {
         public ICollection<Reviews> BookReviews { get; set; }
    }
}
