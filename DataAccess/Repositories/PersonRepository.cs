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
    }
}
