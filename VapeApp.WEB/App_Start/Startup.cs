﻿using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vape.BLL.Interfaces;
using Vape.BLL.Services;
[assembly: OwinStartup(typeof(VapeApp.WEB.App_Start.Startup))]
namespace VapeApp.WEB.App_Start
{
  
        public class Startup
        {
            IServiceCreator serviceCreator = new ServiceCreator();
            public void Configuration(IAppBuilder app)
            {
                app.CreatePerOwinContext<IUserService>(CreateUserService);
                app.UseCookieAuthentication(new CookieAuthenticationOptions
                {
                    AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                    LoginPath = new PathString("/Account/Login"),
                });
            }

            private IUserService CreateUserService()
            {
                return serviceCreator.CreateUserService("DefaultConnection");
            }
        }
    }