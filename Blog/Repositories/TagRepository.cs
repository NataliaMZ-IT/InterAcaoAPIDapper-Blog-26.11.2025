using Blog.API.Data;
using Blog.API.Models;
using Blog.API.Models.DTOs.Category;
using Blog.API.Models.DTOs.Tag;
using Blog.API.Repositories.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Blog.API.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly SqlConnection _connection;

        public TagRepository(ConnectionDB connection)
        {
            _connection = connection.GetConnection();
        }

        public async Task CreateTagAsync(Tag tag)
        {
            var sql = "INSERT INTO Tag (Name, Slug) VALUES (@Name, @Slug)";

            await _connection.ExecuteAsync(sql, new { tag.Name, tag.Slug } );
        }

        public async Task<List<TagResponseDTO>> GetAllTagAsync()
        {
            var sql = "SELECT Name, Slug FROM Tag";

            return (await _connection.QueryAsync<TagResponseDTO>(sql)).ToList();
        }

        public async Task<TagFoundDTO?> FindTagAsync(string name)
        {
            var sql = "SELECT * FROM Tag WHERE Name = @Name";

            return await _connection.QueryFirstOrDefaultAsync<TagFoundDTO>(sql, new { Name = name });
        }

        public async Task UpdateTagAsync(Tag tag, int id)
        {
            var sql = "UPDATE Tag SET Name = @Name, Slug = @Slug WHERE Id = @Id";

            await _connection.ExecuteAsync(sql, new { tag.Name, tag.Slug, Id = id });
        }

        public async Task DeleteTagAsync(int id)
        {
            var sql = "DELETE FROM Tag WHERE Id = @Id";

            await _connection.ExecuteAsync(sql, new { Id = id });
        }
    }
}
