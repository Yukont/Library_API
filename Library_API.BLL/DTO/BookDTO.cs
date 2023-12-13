using System.ComponentModel.DataAnnotations;
using System;

namespace Library_API.BLL.DTO
{
    public class BookDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Isbn is required")]
        [RegularExpression(@"^\d{13}$", ErrorMessage = "Invalid ISBN format. Should be 13 digits.")]
        public string Isbn { get; set; }

        [StringLength(60, ErrorMessage = "Description length can't exceed 500 characters")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = null!;

        [StringLength(50, ErrorMessage = "Description length can't exceed 500 characters")]
        [Required(ErrorMessage = "Genre is required")]
        public string Genre { get; set; } = null!;

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; } = null!;

        [StringLength(50, ErrorMessage = "Description length can't exceed 50 characters")]
        [Required(ErrorMessage = "Author is required")]
        public string Author { get; set; } = null!;

        [Required(ErrorMessage = "TakingTime is required")]
        [Range(typeof(DateTime), "1900-01-01", "9999-12-31", ErrorMessage = "Invalid taking time")]
        public DateTime TakingTime { get; set; }

        [Required(ErrorMessage = "ReturnTime is required")]
        [Range(typeof(DateTime), "1900-01-01", "9999-12-31", ErrorMessage = "Invalid return time")]
        public DateTime ReturnTime { get; set; }
    }
}
