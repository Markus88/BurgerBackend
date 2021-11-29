using Review.Domain.Interface.Model;

namespace Review.Domain.Implementation.Model
{
    public class ReviewModel : IReviewModel
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public short Taste { get; set; }
        public short Texture { get; set; }
        public short VisualPresentation { get; set; }
    }
}