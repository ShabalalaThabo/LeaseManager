﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LeaseManager.Startup))]
namespace LeaseManager
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
