namespace Application.Interface.Review.Model
{
    public class ReviewWriteDto
    {
        public string Description { get; set; }
        public short Taste { get; set; }
        public short Texture { get; set; }
        public short VisualPresentation { get; set; }
    }
}