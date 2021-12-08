using DataAccess.Model;
using Gallaria.API.DTOs;
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

        #region Artist conversion methods
        public static ArtistDto ToDto(this Artist artistToConvert)
        {
            var artistDto = new ArtistDto();
            artistDto.Address = new AddressDto();
            artistToConvert.CopyPropertiesTo(artistDto);
            artistToConvert.Address.CopyPropertiesTo(artistDto.Address);
            return artistDto;
        }

        public static Artist FromDto(this ArtistDto artistDtoToConvert)
        {
            var artist = new Artist();
            artist.Address = new Address();
            artistDtoToConvert.CopyPropertiesTo(artist);
            artistDtoToConvert.Address.CopyPropertiesTo(artist.Address);
            return artist;
        }

        public static IEnumerable<ArtistDto> ToDtos(this IEnumerable<Artist> artistsToConvert)
        {
            foreach (var artist in artistsToConvert)
            {
                yield return artist.ToDto();
            }
        }

        public static IEnumerable<Artist> FromDtos(this IEnumerable<ArtistDto> artistDtosToConvert)
        {
            foreach (var artistDto in artistDtosToConvert)
            {
                yield return artistDto.FromDto();
            }
        }
        #endregion

        #region Art conversion methods

        public static ArtDto ToDto(this Art artToConvert)
        {
            var artDto = new ArtDto();
            artToConvert.CopyPropertiesTo(artDto);
            return artDto;
        }

        public static Art FromDto(this ArtDto artDtoToConvert)
        {
            var art = new Art();
            artDtoToConvert.CopyPropertiesTo(art);
            return art;
        }

        public static IEnumerable<ArtDto> ToDtos(this IEnumerable<Art> artsToConvert)
        {
            foreach (var art in artsToConvert)
            {
                yield return art.ToDto();
            }
        }

        public static IEnumerable<Art> FromDtos(this IEnumerable<ArtDto> artDtosToConvert)
        {
            foreach (var artDto in artDtosToConvert)
            {
                yield return artDto.FromDto();
            }
        }

        #endregion

        #region Order conversion methods

        public static OrderDto ToDto(this Order orderToConvert)
        {
            var orderDto = new OrderDto();
            var orderLineItemDto = new OrderLineItemDto();
            orderToConvert.CopyPropertiesTo(orderDto);
            orderToConvert.OrderLineItems.CopyPropertiesTo(orderLineItemDto);
            return orderDto;
        }

        public static Order FromDto(this OrderDto orderDtoToConvert)
        {
            var order = new Order();
            var orderLineItem = new OrderLineItem();
            orderDtoToConvert.CopyPropertiesTo(order);
            orderDtoToConvert.CopyPropertiesTo(orderLineItem);
            return order;
        }

        public static IEnumerable<OrderDto> ToDtos(this IEnumerable<Order> ordersToConvert)
        {
            foreach (var order in ordersToConvert)
            {
                yield return order.ToDto();
            }
        }

        public static IEnumerable<Order> FromDtos(this IEnumerable<OrderDto> orderDtosToConvert)
        {
            foreach (var orderDto in orderDtosToConvert)
            {
                yield return orderDto.FromDto();
            }
        }

        #endregion

        #region OrderLineItem conversion methods
        public static OrderLineItemDto ToDto(this OrderLineItem orderLineItemToConvert)
        {
            var orderLineItemDto = new OrderLineItemDto();
            orderLineItemToConvert.CopyPropertiesTo(orderLineItemDto);
            return orderLineItemDto;
        }

        public static OrderLineItem FromDto(this OrderLineItemDto orderLineItemDtoToConvert)
        {
            var orderLineItem = new OrderLineItem();
            orderLineItemDtoToConvert.CopyPropertiesTo(orderLineItem);
            return orderLineItem;
        }

        public static IEnumerable<OrderLineItemDto> ToDtos(this ICollection<OrderLineItem> orderLineItemsToConvert)
        {
            foreach (var orderLineItem in orderLineItemsToConvert)
            {
                yield return orderLineItem.ToDto();
            }
        }

        public static IEnumerable<OrderLineItem> FromDtos(this ICollection<OrderLineItemDto> orderLineItemDtosToConvert)
        {
            foreach (var orderLineItemDto in orderLineItemDtosToConvert)
            {
                yield return orderLineItemDto.FromDto();
            }
        }

        #endregion
    }
}
