using Dapper;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class ArtRepository : BaseRepository, IArtRepository
    {
        public ArtRepository(string connectionstring) : base(connectionstring) { }

        public async Task<int> CreateArtAsync(Art art)
        {
            try
            {
                var query = "INSERT INTO Art (Title, Description, Image, Price, AvailableQuantity, Category, CreationDate, AuthorId)" +
                    " OUTPUT INSERTED.Id VALUES (@Title, @Description, @Image, @Price, @AvailableQuantity, @Category, @CreationDate, @AuthorId);";
                using var connection = CreateConnection();
                return await connection.QuerySingleAsync<int>(query, new
                {
                    Title = art.Title,
                    Description = art.Description,
                    Image = art.Image,
                    Price = art.Price,
                    AvailableQuantity = art.AvailableQuantity,
                    Category = art.Category,
                    CreationDate = art.CreationDate,
                    AuthorId = art.AuthorId
                }) ;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error creating new Art: '{ex.Message}'.", ex);
            }
        }
        public async Task<bool> DeleteArtAsync(int id)
        {
            try
            {
                var query = "DELETE FROM Art WHERE Id=@Id";
                using var connection = CreateConnection();
                return await connection.ExecuteAsync(query, new { id }) > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting art with id {id}: '{ex.Message}'.", ex);
            }
        }

        public async Task<IEnumerable<Art>> GetAllArtsAsync()
        {
            try
            {
                var query = "SELECT * FROM Art";
                using var connection = CreateConnection();
                return (await connection.QueryAsync<Art>(query)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting all arts: '{ex.Message}'.", ex);
            }

        }

        public async Task<Art> GetArtByIDAsync(int id)
        {
            try
            {
                var query = "SELECT * FROM Art WHERE Id=@Id";
                using var connection = CreateConnection();
                return await connection.QuerySingleAsync<Art>(query, new { id });
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting art with id {id}: '{ex.Message}'.", ex);
            }
        }

        public async Task<int> UpdateArtQuantityById(int id, int updatedQuantity)
        {
            try
            {
                var query = "UPDATE dbo.[Art] SET AvailableQuantity=@updatedQuantity WHERE Id=@id";
                using var connection = CreateConnection();
                return await connection.ExecuteAsync(query, new {
                    updatedQuantity = updatedQuantity,
                    Id = id
                });
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting art with id {id}: '{ex.Message}'.", ex);
            }
        }
    }

}
