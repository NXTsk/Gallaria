using Gallaria.ApiClient;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gallaria.ApiClient.ApiResponses;
using Gallaria.ApiClient.DTOs;

namespace Gallaria.WEB.Controllers
{
    public class AccountsController : Controller
    {
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

        // POST: AuthorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAccount(PersonDto person)
        {
            ModelState.Remove("NewPassword");
            if (!ModelState.IsValid)
            {
                ViewBag.ErrorMessage = "User not created - error in submitted data!";
            }
            else
            {
                try
                {
                    var response = await PersonController.CreatePersonAsync(person);
                    if (response.hasBeenCreated)
                    {
                        return RedirectToAction(nameof(Login), "Accounts");
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.ErrorMessage = ex.Message;
                }
            }
            return View();
        }
    }
}
