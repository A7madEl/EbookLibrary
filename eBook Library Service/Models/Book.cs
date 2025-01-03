﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eBook_Library_Service.Models
{
    public class Book
    {
        public Book()
        {
            Stock = 3;
            BookAuthors = new List<BookAuthor>();
        }
      
        public int BookId { get; set; }

        // Book title
        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        // Publisher of the book
        [Required]
        [StringLength(200)]
        public string Publisher { get; set; }
        public string Description { get; set; }

        // Year the book was published
        public int YearPublished { get; set; }

        // Price to borrow the book (must be lower than BuyPrice)
        [Range(0, double.MaxValue, ErrorMessage = "Borrow price must be a positive value.")]
        public decimal BorrowPrice { get; set; }

        // Price to buy the book
        [Range(0, double.MaxValue, ErrorMessage = "Buy price must be a positive value.")]
        public decimal BuyPrice { get; set; }

        // Discount price for limited time
        public decimal? DiscountPrice { get; set; }

        // The date when the discount ends
        public DateTime? DiscountEndDate { get; set; }

        // The stock available for borrowing (maximum of 3)
        [Range(0, 3, ErrorMessage = "Only 3 copies can be borrowed.")]
        public int Stock { get; set; }

        // Age limit for the book (e.g., 18+, 8+, etc.)
        [StringLength(50)]
        public string AgeLimit { get; set; }

        [StringLength(100)]
        public string Category { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        public string ImageUrl { get; set; }= "images/BookDefult.png";


        // Navigation property for authors of the book (Many-to-many relation with Author)
        public virtual ICollection<BookAuthor> BookAuthors { get; set; }=new List<BookAuthor>();

        
       
       
    }
}

