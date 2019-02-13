﻿using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Vape.BLL.DTO;
using Vape.BLL.Infrastructure;
using Vape.BLL.Interfaces;
using VapeApp.WEB.Models;

namespace VapeApp.WEB.Controllers
{

        // GET: Account
        public class AccountController : Controller
        {
            private IUserService UserService
            {
                get
                {
                    return HttpContext.GetOwinContext().GetUserManager<IUserService>();
                }
            }

            private IAuthenticationManager AuthenticationManager
            {
                get
                {
                    return HttpContext.GetOwinContext().Authentication;
                }
            }

            public ActionResult Login()
            {
                return View();
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<ActionResult> Login(LoginModel model)
            {
                await SetInitialDataAsync();
                if (ModelState.IsValid)
                {
                    UserDTO userDto = new UserDTO { Email = model.Email, Password = model.Password };
                    ClaimsIdentity claim = await UserService.Authenticate(userDto);
                    if (claim == null)
                    {
                        ModelState.AddModelError("", "Неверный логин или пароль.");
                    }
                    else
                    {
                        AuthenticationManager.SignOut();
                        AuthenticationManager.SignIn(new AuthenticationProperties
                        {
                            IsPersistent = true
                        }, claim);
                        return RedirectToAction("Index", "Home");
                    }
                }
                return View(model);
            }

            public ActionResult Logout()
            {
                AuthenticationManager.SignOut();
                return RedirectToAction("Index", "Home");
            }

            public ActionResult Register()
            {
                return View();
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<ActionResult> Register(RegisterModel model)
            {
                await SetInitialDataAsync();
                if (ModelState.IsValid)
                {
                    UserDTO userDto = new UserDTO
                    {
                        Email = model.Email,
                        Password = model.Password,
                        Address = model.Address,
                        Name = model.Name,
                        Role = "user"
                    };
                    OperationDetails operationDetails = await UserService.Create(userDto);
                    if (operationDetails.Succedeed)
                        return View("SuccessRegister");
                    else
                        ModelState.AddModelError(operationDetails.Property, operationDetails.Message);
                }
                return View(model);
            }

            private async Task SetInitialDataAsync()
            {
                await UserService.SetInitialData(new UserDTO
                {
                    Email = "admin@mail.ru",
                    UserName = "admin@mail.ru",
                    Password = "admin1",
                    Name = "admin",
                    Address = "ул. Спортивная, д.30, кв.75",
                    Role = "admin",
                }, new List<string> { "user", "admin" });
            }
        }
    }