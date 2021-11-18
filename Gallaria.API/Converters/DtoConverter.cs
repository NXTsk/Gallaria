using DataAccess.Model;
using Gallaria.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gallaria.API.Converters
{
    public static class DtoConverter
    {
        #region Person conversion methods
        public static PersonDto ToDto(this Person personToConvert)
        {
            var personDto = new PersonDto();
            personDto.Address = new AddressDto();
            personToConvert.CopyPropertiesTo(personDto);
            personToConvert.Address.CopyPropertiesTo(personDto.Address);
            return personDto;
        }

        public static Person FromDto(this PersonDto personDtoToConvert)
        {
            var person = new Person();
            person.Address = new Address();
            personDtoToConvert.CopyPropertiesTo(person);
            personDtoToConvert.Address.CopyPropertiesTo(person.Address);
            return person;
        }

        public static IEnumerable<PersonDto> ToDtos(this IEnumerable<Person> personsToConvert)
        {
            foreach (var person in personsToConvert)
            {
                yield return person.ToDto();
            }
        }

        public static IEnumerable<Person> FromDtos(this IEnumerable<PersonDto> personDtosToConvert)
        {
            foreach (var personDto in personDtosToConvert)
            {
                yield return personDto.FromDto();
            }
        }
        #endregion
    }
}
