using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using MVCLabb.Data.Repositories;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;

namespace MVCLabb.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app) // IAppBuilder fungerar som en entrypoint för request pipelinen.
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "ApplicationCookie",
                LoginPath = new PathString("/Authentication/Login")
            });

        }


    }
}