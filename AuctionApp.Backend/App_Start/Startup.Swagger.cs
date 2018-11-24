using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.Azure.Mobile.Server;
using Microsoft.Azure.Mobile.Server.Swagger;
using Swashbuckle.Application;

namespace AuctionApp.Backend.App_Start
{
    public class Startup
    {
        public static void ConfigureSwagger(HttpConfiguration config)
        {
            // Use the custom ApiExplorer that applies constraints. This prevents
            // duplicate routes on /api and /tables from showing in the Swagger doc.
            config.Services.Replace(typeof(IApiExplorer), new MobileAppApiExplorer(config));
            config
                .EnableSwagger(c =>
                {
                    c.SingleApiVersion("v1", "myService");
                    c.OperationFilter<MobileAppHeaderFilter>();
                    c.SchemaFilter<MobileAppSchemaFilter>();

                    // 1. Adds an OAuth implicit flow description that points to App Service Auth with the specified provdier
                    // 2. Adds a Swashbuckle filter that applies this Oauth description to any Action with [Authorize]
                    //c.AppServiceAuthentication("https://{mysite}.azurewebsites.net/", "{provider}");
                })
                .EnableSwaggerUi();
        }
    }
}