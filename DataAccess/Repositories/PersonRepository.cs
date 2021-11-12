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

        public int CreatePerson(Person person, string password)
        {
            try
            {
                var query = "INSERT INTO Person (FirstName, LastName, email, hashPassword, phoneNumber, street, houseNumber, zipcode, city, country)" +
                    " OUTPUT INSERTED.Id VALUES (@FirstName, @LastName, @Email, @HashPassword, @PhoneNumber, @Street, @HouseNumber, @Zipcode, @City, @Country);";
                var hashPassword = BCryptTool.HashPassword(password);
                using var connection = CreateConnection();
                return connection.QuerySingle<int>(query, new {FirstName = person.FirstName, LastName = person.LastName, Email = person.Email, HashPassword = hashPassword, PhoneNumber = person.PhoneNumber, Street = person.Address.Street,
                    HouseNumber = person.Address.HouseNumber,
                    Zipcode = person.Address.Street,
                    City = person.Address.City,
                    Country = person.Address.Country,
                });
            }
            catch (Exception ex)
            {
                throw new Exception($"Error creating new Person: '{ex.Message}'.", ex);
            }
        }
        public bool DeletePerson(int id)
        {
            try
            {
                var query = "DELETE FROM Person WHERE Id=@Id";
                using var connection = CreateConnection();
                return connection.Execute(query, new { id }) > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting person with id {id}: '{ex.Message}'.", ex);
            }
        }
        public  int Login(string email, string password)
        {
            try
            {
                var query = "SELECT Id, hashPassword FROM Person WHERE Email=@Email";
                using var connection = CreateConnection();

                var personTuple = connection.QueryFirstOrDefault<PersonTuple>(query, new { Email = email });
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
        public bool UpdatePassword(string email, string oldPassword, string newPassword)
        {
            try
            {
                var query = "UPDATE Person SET HashPassword=@NewHashPassword WHERE Id=@Id;";
                var id = Login(email, oldPassword);
                if (id > 0)
                {
                    var newHashPassword = BCryptTool.HashPassword(newPassword);
                    using var connection = CreateConnection();
                    return connection.Execute(query, new { Id = id, NewHashPassword = newHashPassword }) > 0;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating person: '{ex.Message}'.", ex);
            }
        }
    }

    internal class PersonTuple
    {
        public int Id;
        public string HashPassword;
    }
}
