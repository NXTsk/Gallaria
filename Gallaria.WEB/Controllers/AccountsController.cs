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
        public async Task<ActionResult> Login(UserDto user)
        {
            var result = await authenticateClient.LoginAsync(user);
            
            if (!result.isUserAuthenticated)
                return Unauthorized("Wrong username or password!");

            CookieHelper.SaveJWTAsCookie("X-Access-Token", result, Response);

            HttpContext.Session.SetString("isAuthenticated", "true");


            return RedirectToAction(actionName: "AllArts", controllerName: "Art");
        }


        public IActionResult Logout()
        {
            CookieHelper.RemoveJWT("X-Access-Token", Response);
            HttpContext.Session.SetString("isAuthenticated", "false");

            return RedirectToAction(actionName: "Login", controllerName: "Accounts");
        }

        // POST: AuthorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAccount(AccountViewModel accountVM)
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
