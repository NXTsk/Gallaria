using Gallaria.ApiClient;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gallaria.ApiClient.DTOs;
using Gallaria.WEB.ViewModels;
using Gallaria.ApiClient.Helpers;
using Gallaria.WEB.Helpers;
using Microsoft.AspNetCore.Http;
using Gallaria.ApiClient.Interfaces;
using System.Net;
using System.Dynamic;

namespace Gallaria.WEB.Controllers
{
    public class AccountsController : Controller
    {
        private IHttpContextAccessor _httpContextAccessor;

        private IAuthenticateClient _authenticateClient;
        private IPersonClient _personClient;
        private IArtClient _artClient;
        private IOrderClient _orderClient;
        public AccountsController(IAuthenticateClient authenticateClient, IPersonClient personClient,
            IArtClient artClient, IOrderClient orderClient, IHttpContextAccessor contextAccessor)
        {
            _authenticateClient = authenticateClient;
            _personClient = personClient;
            _artClient = artClient;
            _orderClient = orderClient;

            _httpContextAccessor = contextAccessor;

        }

        public async Task<IActionResult> Account()
        {
            int personId = 0;
            bool parsing = int.TryParse(CookieHelper.ReadCookie("userId", _httpContextAccessor), out personId);

            if (!parsing)
            {
                // If anything happens with the cookie, the user is redirected to Home page
                return RedirectToAction("Index", "Home");
            }

            string token = CookieHelper.ReadJWT(_httpContextAccessor);

            // Retrieving the orders from database
            IEnumerable<OrderDto> orderDtos = await _orderClient.GetAllOrdersByPersonIdAsync(personId, token);

            // Creating a new list of orders, where newly altered orders will go into
            ICollection<OrderDto> newOrderDtos = new List<OrderDto>();

            // Looping through orders from the database
            foreach (OrderDto order in orderDtos)
            {
                OrderDto orderDto = new OrderDto();

                // Assigning the values from variables from the database order into new orderDto object
                orderDto.Id = order.Id;
                orderDto.Person = order.Person;
                orderDto.FinalPrice = order.FinalPrice;
                orderDto.Date = order.Date;
                orderDto.OrderLineItems = new List<OrderLineItemDto>();

                // Looping through each orderlineitem 
                foreach (OrderLineItemDto orderLineItemDto in order.OrderLineItems)
                {
                    OrderLineItemDto orderLineItem = orderLineItemDto;
                    // Converting byte array int of stored image into string and assigning that value to Img64 property in Art object
                    orderLineItem.Art.Img64 = ArtHelper.GetImageSourceFromByteArray(orderLineItem.Art.Image);
                    orderDto.OrderLineItems.Add(orderLineItem);
                }

                newOrderDtos.Add(orderDto);
            }
            orderDtos = null;

            bool isArtist = _personClient.IsArtistAsync(personId).Result;
            ViewBag.IsArtist = isArtist;

            if (isArtist)
            {
                ArtistDto artist = _personClient.GetArtistByIdAsync(personId).Result;

                // Creating Expando object, so we can pass it in parameter to the view
                // View then works with dynamic object
                dynamic obj = new ExpandoObject();
                obj.Person = artist;
                obj.Orders = newOrderDtos;

                return View(obj);
            }
            else
            {
                PersonDto person = _personClient.GetPersonByIdAsync(personId).Result;

                // Creating Expando object, so we can pass it in parameter to the view
                // View then works with dynamic object
                dynamic obj = new ExpandoObject();
                obj.Person = person;

                return View(obj);

            }
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ChangePassword()
        {
            if(HttpContext.Session.GetString("changedPassword") == "false")
            {
                HttpContext.Session.Remove("changedPassword");
                ViewBag.passwordChange = false;
            }
            return View();
        }

        public IActionResult PasswordChangedSuccessfully()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult CreateAccount()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(UserDto user, string returnUrl)
        {
            var result = await _authenticateClient.LoginAsync(user);

            if (!result.IsUserAuthenticated)
                return Unauthorized("Wrong username or password!");

            // Setting up Session and cookies
            CookieHelper.SaveJWTAsCookie(result, Response);
            CookieHelper.SaveCookie("userId", result.UserId.ToString(), Response);
            HttpContext.Session.SetString("isAuthenticated", "true");

            if (!string.IsNullOrEmpty(returnUrl))
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                return RedirectToAction(actionName: "AllArts", controllerName: "Art");
            }
        }
        public IActionResult Logout()
        {
            CookieHelper.RemoveJWT(Response);
            CookieHelper.RemoveCookie("userId", Response);
            HttpContext.Session.Remove("cart");
            HttpContext.Session.SetString("isAuthenticated", "false");
            
            return RedirectToAction("Index", "Home");
        }

        // POST: AuthorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAccount(AccountViewModel accountVM, string returnUrl)
        {

            if (accountVM.Person == null)
            {
                ViewBag.ErrorMessage = "User not created - error in submitted data!";
            }
            else
            {
                bool isUserArtist = accountVM.IsPersonArtist;
                if (isUserArtist)
                {
                    try
                    {
                        ArtistDto artist = accountVM.Person.ConvertIntoArtist();
                        artist.ProfileDescription = accountVM.Artist.ProfileDescription;

                        int response = await _personClient.CreateArtistAsync(artist);
                        if (response != -1)
                        {
                            return RedirectToAction(nameof(Login), "Accounts");
                        }
                    }
                    catch (Exception ex)
                    {
                        ViewBag.ErrorMessage = ex.Message;
                    }

                }
                else
                {
                    try
                    {
                        int response = await _personClient.CreatePersonAsync(accountVM.Person);
                        if (response != -1)
                        {
                            return RedirectToAction(nameof(Login), "Accounts");
                        }
                    }
                    catch (Exception ex)
                    {
                        ViewBag.ErrorMessage = ex.Message;
                    }
                }
            }

            return View();
        }


        /*
         * This method is still under development and does not work properly
         */
        [HttpPost]
        public async Task<ActionResult> UpdatePassword([FromBody] PersonDto personDto)
        {

            int userId = int.Parse(CookieHelper.ReadCookie("userId", _httpContextAccessor));
            string token = CookieHelper.ReadJWT(_httpContextAccessor);
            personDto.Id = userId;
            PersonDto person = await _personClient.GetPersonByIdAsync(userId);
            person.NewPassword = personDto.NewPassword;

            bool response = await _personClient.UpdatePasswordAsync(person, token);

            if (!response)
            {
                HttpContext.Session.SetString("changedPassword", "false");
                return RedirectToAction("ChangePassword", "Accounts");
            }

            return RedirectToAction("PasswordChangedSuccessfully", "Accounts");
        }
    }
}
