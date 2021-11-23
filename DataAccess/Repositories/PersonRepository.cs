using Dapper;
using DataAccess.Authentication;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class PersonRepository : BaseRepository, IPersonRepository
    {
        public PersonRepository(string connectionstring) : base(connectionstring) { }

        public async Task<int> CreatePersonAsync(Person person, string password)
        {
            try
            {
                var query = "INSERT INTO Person (FirstName, LastName, email, hashPassword, phoneNumber, street, houseNumber, zipcode, city, country)" +
                    " OUTPUT INSERTED.Id VALUES (@FirstName, @LastName, @Email, @HashPassword, @PhoneNumber, @Street, @HouseNumber, @Zipcode, @City, @Country);";
                var hashPassword = BCryptTool.HashPassword(password);
                using var connection = CreateConnection();
                return await connection.QuerySingleAsync<int>(query, new {FirstName = person.FirstName, LastName = person.LastName, Email = person.Email, HashPassword = hashPassword, PhoneNumber = person.PhoneNumber,
                    Street = person.Address.Street,
                    HouseNumber = person.Address.HouseNumber,
                    Zipcode = person.Address.Zipcode,
                    City = person.Address.City,
                    Country = person.Address.Country,
                });
            }
            catch (Exception ex)
            {
                throw new Exception($"Error creating new Person: '{ex.Message}'.", ex);
            }
        }

        public async Task<bool> DeletePersonAsync(int id)
        {
            try
            {
                var query = "DELETE FROM Person WHERE Id=@Id";
                using var connection = CreateConnection();
                return await connection.ExecuteAsync(query, new { id }) > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting person with id {id}: '{ex.Message}'.", ex);
            }
        }

        public async Task<int> LoginAsync(string email, string password)
        {
            try
            {
                var query = "SELECT Id, hashPassword FROM Person WHERE Email=@Email";
                using var connection = CreateConnection();

                var personTuple = await connection.QueryFirstOrDefaultAsync<PersonTuple>(query, new { Email = email });
                if (personTuple != null && BCryptTool.ValidatePassword(password, personTuple.HashPassword))
                {
                    return personTuple.Id;
                }
                return -1;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error logging in for user with email {email}: '{ex.Message}'.", ex);
            }
        }
        public async Task<bool> UpdatePasswordAsync(string email, string oldPassword, string newPassword)
        {
            try
            {
                var query = "UPDATE Person SET HashPassword=@NewHashPassword WHERE Id=@Id;";
                var id = await LoginAsync(email, oldPassword);
                if (id > 0)
                {
                    var newHashPassword = BCryptTool.HashPassword(newPassword);
                    using var connection = CreateConnection();
                    return await connection.ExecuteAsync(query, new { Id = id, NewHashPassword = newHashPassword }) > 0;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating person: '{ex.Message}'.", ex);
            }
        }

        public async Task<int> CreateArtistAsync(Artist artist, string password)
        {
            int personId = await CreatePersonAsync((Person)artist, password);

            try
            {
                var query = "INSERT INTO Artist (artistId, profileDescription)" + "OUTPUT INSERTED.artistId VALUES(@artistId, @profileDescription);";
                using var connection = CreateConnection();
                return await connection.QuerySingleAsync<int>(query, new {
                    artistId = personId, profileDescription = artist.ProfileDescription
                });
            }
            catch (Exception ex)
            {
                throw new Exception($"Error creating new Artist: '{ex.Message}'.", ex);
            }
        }

        public async Task<bool> DeleteArtistAsync(int artistId)
        {
            try
            {
                var query = "DELETE FROM Artist WHERE artistId=@artistId";
                using var connection = CreateConnection();
                return await connection.ExecuteAsync(query, new { artistId }) > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting artist with id {artistId}: '{ex.Message}'.", ex);
            }
        }

        public async Task<bool> IsArtist(int artistId)
        {
            try
            {
                var query = "SELECT COUNT(*) FROM Artist WHERE artistId=@artistId";
                using var connection = CreateConnection();
                int resultNumber = await connection.ExecuteScalarAsync<int>(query, new { artistId }) ;
                return (resultNumber >= 1) ? true : false; 
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting artist with id {artistId}: '{ex.Message}'.", ex);
            }
        }
    }

    internal class PersonTuple
    {
        public int Id;
        public string HashPassword;
    }
}
