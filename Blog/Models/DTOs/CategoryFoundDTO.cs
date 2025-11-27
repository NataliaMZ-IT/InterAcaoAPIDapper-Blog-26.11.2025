using System.Text.Json.Serialization;

namespace Blog.API.Models.DTOs
{
    public class CategoryFoundDTO
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Slug { get; private set; }

        [JsonConstructor]
        public CategoryFoundDTO(int id, string name, string slug) 
        {
            Id = id;
            Name = name;
            Slug = slug;
        }
    }
}
