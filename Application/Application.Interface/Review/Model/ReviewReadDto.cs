namespace Application.Interface.Review.Model
{
    public class ReviewReadDto : ReviewWriteDto
    {
        public int ID { get; set; }

        public int Rating { get; set; }
    }
}