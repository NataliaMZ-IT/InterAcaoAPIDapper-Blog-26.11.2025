using System.Text.Json.Serialization;

namespace Blog.API.Models.DTOs.Tag
{
    public class TagFoundDTO
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Slug { get; private set; }

        [JsonConstructor]
        public TagFoundDTO(int id, string name, string slug)
        {
            Id = id;
            Name = name;
            Slug = slug;
        }
    }
}
