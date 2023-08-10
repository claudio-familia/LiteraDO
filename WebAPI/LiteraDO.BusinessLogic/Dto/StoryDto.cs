using System.Text.Json.Serialization;

namespace LiteraDO.BusinessLogic.Dto
{
    public class StoryDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("userId")]
        public int UserId { get; set; }

        [JsonPropertyName("literaryGenreId")]
        public int LiteraryGenreId { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("cover")]
        public string Cover { get; set; }

        [JsonPropertyName("publishedDate")]
        public DateTime? PublishedDate { get; set; }

        [JsonPropertyName("rating")]
        public decimal? Rating { get; set; }

        [JsonPropertyName("reads")]
        public decimal? Reads { get; set; }

        [JsonPropertyName("copyrightType")]
        public string CopyrightType { get; set; }

        [JsonPropertyName("tags")]
        public string Tags { get; set; }

        [JsonPropertyName("tagetAudience")]
        public string TagetAudience { get; set; }

        [JsonPropertyName("language")]
        public string Language { get; set; }

        [JsonPropertyName("hasAdultContent")]
        public bool HasAdultContent { get; set; }

        [JsonPropertyName("isPublish")]
        public string IsPublish => PublishedDate.HasValue && PublishedDate.Value > new DateTime(2000, 1, 1) ? "Esta publicada" : "No publicada";

        [JsonPropertyName("state")]
        public string State => PublishedDate.HasValue && PublishedDate.Value > new DateTime(2000, 1, 1) ? "PUBLICADA" : "BORRADOR";

        public UserDto? User { get; set; }

        public LiteraryGenreDto? LiteraryGenre { get; set; }

        public ICollection<StoryChapterDto>? Chapters { get; set; }
    }
}
