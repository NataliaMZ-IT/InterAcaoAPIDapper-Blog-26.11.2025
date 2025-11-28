using Blog.API.Data;
using Blog.API.Models;
using Blog.API.Models.DTOs.Role;
using Blog.API.Models.DTOs.User;
using Blog.API.Repositories.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Blog.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SqlConnection _connection;

        public UserRepository(ConnectionDB connection)
        {
            _connection = connection.GetConnection();
        }

        public async Task CreateUserAsync(User user)
        {
            var sql = @"INSERT INTO [User] (Name, Email, PasswordHash, Bio, Image, Slug) 
                            VALUES (@Name, @Email, @PasswordHash, @Bio, @Image, @Slug)";

            await _connection.ExecuteAsync(sql, new {
                user.Name, user.Email, user.PasswordHash, user.Bio, user.Image, user.Slug }
            );
        }

        public async Task<List<UserResponseDTO>> GetAllUsersAsync()
        {
            var sql = "SELECT Name, Email, Bio, Image, Slug FROM [User]";

            return (await _connection.QueryAsync<UserResponseDTO>(sql)).ToList();
        }

        public async Task<UserFoundDTO?> GetUserByIdAsync(int id)
        {
            var sql = "SELECT * FROM [User] WHERE Id = @Id";

            return await _connection.QuerySingleOrDefaultAsync<UserFoundDTO>(sql, new { Id = id });
        }

        public async Task UpdateUserAsync(User user, int id)
        {
            var sql = @"UPDATE [User] 
                            SET [Name] = @Name, 
                                Email = @Email, 
                                PasswordHash = @PasswordHash, 
                                Bio = @Bio, 
                                [Image] = @Image, 
                                Slug = @Slug
                            WHERE Id = @Id";

            await _connection.ExecuteAsync(sql, new { 
                user.Name, user.Email, user.PasswordHash, user.Bio, user.Image, user.Slug, Id = id }
            );
        }

        public async Task DeleteUserAsync(int id)
        {
            var sql = "DELETE FROM [User] WHERE Id = @Id";

            await _connection.ExecuteAsync(sql, new { Id = id });
        }

        public async Task<List<UserResponseDTO>> GetAllUserRolesAsync()
        {
            var sql = @"SELECT u.Name, u.Email, u.Bio, u.Image, u.Slug, r.Name, r.Slug
                        FROM [User] u
                        JOIN [UserRole] ur ON u.id = ur.UserId
                        JOIN [Role] r ON r.Id = ur.RoleId";

            try
            {
                var userRoles = await _connection.QueryAsync<UserResponseDTO, RoleResponseDTO, UserResponseDTO>(
                    sql,
                    (user, role) => 
                    { 
                        user.Roles.Add(role);
                        return user;
                    },
                    splitOn: "Name"
                );

                userRoles = userRoles.GroupBy(u => u.Email).Select(gu =>
                {
                    var groupedUser = gu.First();
                    groupedUser.Roles = gu.Select(u => u.Roles.Single()).ToList();
                    return groupedUser;
                });

                return userRoles.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.StackTrace);
            }
        }

        public async Task<UserResponseDTO> GetUserRolesByIdAsync(int id)
        {
            var sql = @"SELECT u.Name, u.Email, u.Bio, u.Image, u.Slug, r.Name, r.Slug
                        FROM [User] u
                        JOIN [UserRole] ur ON u.Id = ur.UserId
                        JOIN [Role] r ON r.Id = ur.RoleId
                        WHERE u.Id = @Id";

            try
            {
                var userRole = await _connection.QueryAsync<UserResponseDTO, RoleResponseDTO, UserResponseDTO>(
                    sql,
                    (user, role) =>
                    {
                        user.Roles.Add(role);
                        return user;
                    },
                    param: new { Id = id },
                    splitOn: "Name"
                    );

                userRole = userRole.GroupBy(u => u.Email).Select(gu =>
                {
                    var groupedUser = gu.First();
                    groupedUser.Roles = gu.Select(u => u.Roles.Single()).ToList();
                    return groupedUser;
                });

                return userRole.First();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.StackTrace);
            }
        }
    }
}
