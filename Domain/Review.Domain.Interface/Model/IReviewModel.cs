using System.ComponentModel.DataAnnotations;

namespace Review.Domain.Interface.Model
{
    public interface IReviewModel
    {
        [Required]
        int ID { get; set; }

        [StringLength(255)]
        string Description { get; set; }

        [Required]
        [Range(1, 5, ErrorMessage = "Rating must be between 1 to 5")]
        short Taste { get; set; }

        [Required]
        [Range(1, 5, ErrorMessage = "Rating must be between 1 to 5")]
        short Texture { get; set; }

        [Required]
        [Range(1, 5, ErrorMessage = "Rating must be between 1 to 5")]
        short VisualPresentation { get; set; }
    }
}
