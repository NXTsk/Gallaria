using Dapper;
using DataAccess.Model;
using System;
using System.Collections.Generic;
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
                var query = "INSERT INTO Art (AuthorName, Title, Description, Image, Price, AvailableQuantity, Category, CreationDate)" +
                    " OUTPUT INSERTED.Id VALUES (@AuthorName, @Title, @Description, @Image, @Price, @AvailableQuantity, @Category, @CreationDate);";
                using var connection = CreateConnection();
                return await connection.QuerySingleAsync<int>(query, new
                {
                    AuthorName = art.AuthorName,
                    Title = art.Title,
                    Description = art.Description,
                    Image = art.Image,
                    Price = art.Price,
                    AvailableQuantity = art.AvailableQuantity,
                    Category = art.Category,
                    CreationDate = art.CreationDate

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

    }

}
