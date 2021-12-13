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

namespace Gallaria.WEB.Controllers
{
    public class AccountsController : Controller
    {
        private IAuthenticateClient authenticateClient;
        private IPersonClient personClient;
        public AccountsController(IAuthenticateClient _authenticateClient, IPersonClient _personClient)
        {
            authenticateClient = _authenticateClient;
            personClient = _personClient;
        }

        public IActionResult Account()
        {
            int id = int.Parse(HttpContext.Request.Cookies["userId"]);
            bool isArtist = personClient.IsArtistAsync(id).Result;

            ViewBag.IsArtist = isArtist;

            if (isArtist)
            {
                ArtistDto artist = personClient.GetArtistByIdAsync(id).Result;
                return View(artist);
            }
            else
            {
                PersonDto person = personClient.GetPersonByIdAsync(id).Result;
                return View(person); 

            }
        }

        public IActionResult Index()
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
            var result = await authenticateClient.LoginAsync(user);
            
            if (!result.isUserAuthenticated)
                return Unauthorized("Wrong username or password!");

            CookieHelper.SaveJWTAsCookie("X-Access-Token", result, Response);
            HttpContext.Session.SetString("isAuthenticated", "true");

            HttpContext.Response.Cookies.Append("userId", result.UserId.ToString());

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
            CookieHelper.RemoveJWT("X-Access-Token", Response);
            HttpContext.Session.SetString("isAuthenticated", "false");
            HttpContext.Session.Remove("cart");
            HttpContext.Response.Cookies.Delete("userId");

            return Redirect(Request.Headers["Referer"].ToString());
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
                bool isUserArtist = accountVM.isPersonArtist;
                if (isUserArtist)
                {
                    try
                    {
                        ArtistDto artist = accountVM.Person.ConvertIntoArtist();
                        artist.ProfileDescription = accountVM.Artist.ProfileDescription;

                        int response = await personClient.CreateArtistAsync(artist);
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
                        int response = await personClient.CreatePersonAsync(accountVM.Person);
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



    }
}
