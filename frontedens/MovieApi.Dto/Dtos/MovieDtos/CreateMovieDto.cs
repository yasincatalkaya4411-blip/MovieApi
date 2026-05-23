namespace MovieApi.Dto.Dtos.MovieDtos
{
    public class CreateMovieDto
    {
        public string Title { get; set; } = string.Empty;
        public string CoverImageUrl { get; set; } = string.Empty;
        public decimal Rating { get; set; }
        public string Description { get; set; } = string.Empty;
        public int Duration { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string CreatedYear { get; set; } = string.Empty;
        public bool Status { get; set; }
    }
}
