using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using YJKBooks.Contexts;
using YJKBooks.Entities;
using YJKBooks.Models;

namespace YJKBooks.Controllers
{

    public class ReviewController : BaseApiController
    {
        private readonly ApplicationDbContext _context;

        public ReviewController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("addreview/{bookId}/{userId}")]
        //string title, string description, int rating, string userId, int bookId
        public async Task<ActionResult<ReviewDto>> AddReview([FromBody]AddReviewDto Review, int bookId, string userId)
        {
            var review = new Reviews
            {
                Title = Review.Title,
                Description = Review.Description,
                Rating = Review.Rating,
                PublishedDate = DateTime.Now,
                UserId = userId,
                BookId = bookId,
            };

            //condition
            var userReview = await _context.Reviews.FirstOrDefaultAsync(r => r.UserId == userId && r.BookId == bookId);
            if (userReview != null) return BadRequest(new ProblemDetails { Title = "You have already wrote a review for this book" });
            //save changes
            await _context.Reviews.AddAsync(review);
            var result = await _context.SaveChangesAsync() > 0;
            if (!result) return BadRequest(new ProblemDetails { Title = "Problem saving your review" });

            var saveReview = await _context.Reviews.Include(r => r.User).Include(r=>r.Book).FirstOrDefaultAsync(r => r.UserId == userId && r.BookId == bookId);
            return Ok(MapReviewToDto(saveReview));

        }

        [HttpPost("modifyreview/{id}")]
        //string title, string description, int rating, int Id
        public async Task<ActionResult> ModifyReview(UpdateReviewDto review, int id)
        {
            //get review
            var currentReview = await _context.Reviews.FindAsync(id);
            if(currentReview==null) return BadRequest(new ProblemDetails { Title = "Problem fetching your review" });

            //update review
            currentReview.Title = review.Title;
            currentReview.Description = review.Description;
            currentReview.Rating = review.Rating;
            currentReview.PublishedDate = DateTime.Now;

            //save changes
            var result = await _context.SaveChangesAsync() > 0;
            if (!result) return BadRequest(new ProblemDetails { Title = "Problem saving your review" });
            
            var saveReview = await _context.Reviews.Include(r => r.User).Include(r => r.Book).FirstOrDefaultAsync(r => r.UserId == currentReview.UserId && r.BookId == currentReview.BookId);
            return Ok(MapReviewToDto(saveReview));
             
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteReview(int Id)
        {
            //get review
            var currentReview = await _context.Reviews.FindAsync(Id);
            if (currentReview == null) return BadRequest(new ProblemDetails { Title = "Problem fetching your review" });

            //delete review
            _context.Reviews.Remove(currentReview);

            //save change 
            var result = await _context.SaveChangesAsync() > 0;
            if (!result) return BadRequest(new ProblemDetails { Title = "Problem saving your review" });
            return Ok();

        }



        private ReviewDto MapReviewToDto(Reviews review)
        {
            return new ReviewDto
            {
                Id = review.Id,
                PublishedDate = review.PublishedDate,
                Title = review.Title,
                UserId = review.UserId,
                Description = review.Description,
                BookId = review.BookId,
                Rating = review.Rating,                
                BookTitle = review.Book.Title,
                UserName = review.User.UserName,
                PictureUrl=review.Book.PictureUrl,
            };
        }





    }
}