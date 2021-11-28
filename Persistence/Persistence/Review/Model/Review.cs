using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Persistence.Review.Model
{
    [Table(name: "Review")]
    public class Review
    {
        [Key]
        [Column(name: "ID")]
        public int ID { get; set; }
        [Column(name: "Description")]
        public string Description { get; set; }
        [Column(name: "Taste")]
        public Int16 Taste { get; set; }
        [Column(name: "Texture")]
        public Int16 Texture { get; set; }
        [Column(name: "VisualPresentation")]
        public Int16 VisualPresentation { get; set; }
    }
}