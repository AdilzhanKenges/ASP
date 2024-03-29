﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookMart2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookMart2.Controllers
{

             [AllowAnonymous]
        public class AccountController : Controller
        {
            private readonly UserManager<IdentityUser> userManager;
            private readonly SignInManager<IdentityUser> signInManager;
        
        public AccountController(UserManager<IdentityUser> userManager,
                SignInManager<IdentityUser> signInManager)
            {
                this.userManager = userManager;
                this.signInManager = signInManager;
            }

            [HttpGet]
            public IActionResult Login()
            {
                return View();
            }

            [HttpPost]
            [AllowAnonymous]
            public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
            {
                if (ModelState.IsValid)
                {
                    var result = await signInManager.PasswordSignInAsync(model.Email,
                        model.Password, model.RememberMe, false);

                    if (result.Succeeded)
                    {
                        HttpContext.Session.SetString("MyEmail",model.Email);
                        HttpContext.Session.SetInt32("MyAge", 20);
                   
                    if (!string.IsNullOrEmpty(returnUrl))
                        {
                            return Redirect(returnUrl);
                        }
                        else
                        {
                            return RedirectToAction("index", "home");
                        }
                    }

                    ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
                }

                return View(model);
            }


            [HttpGet]
            public IActionResult Register()
            {
                return View();
            }

            [HttpPost]
            public async Task<IActionResult> Register(RegisterViewModel model)
            {
                if (ModelState.IsValid)
                {

                    var user = new IdentityUser
                    {
                        UserName = model.Email,
                        Email = model.Email
                    };


                    var result = await userManager.CreateAsync(user, model.Password);


                    if (result.Succeeded)
                    {
                        await signInManager.SignInAsync(user, isPersistent: false);
                        return RedirectToAction("index", "users");
                    }


                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }

                return View(model);
            }

            [HttpPost]
            public async Task<IActionResult> Logout()
            {
                await signInManager.SignOutAsync();
            ViewBag.Name = HttpContext.Session.GetString("MyAge");
            HttpContext.Session.Remove("MyAge");
            return RedirectToAction("index", "users");
            }
        }
    }
