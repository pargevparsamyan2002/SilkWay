using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.IO;

namespace NewSilkWay
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
           
            app.Map("/themes", themes);
            app.Map("/api", api);
            app.Run(async (context) =>
            {
                wwwroot.Controls.PageControls PageControls = new wwwroot.Controls.PageControls();
                  await context.Response.WriteAsync(PageControls.HomePage(context));
            });
        }
        
        private void themes(IApplicationBuilder app)
        {
            wwwroot.Controls.PageControls PageControls = new wwwroot.Controls.PageControls();
            app.Run(async (context) =>
            {
                PageControls.Themes(context);
                if (PageControls._ResponseType == "text")
                {
                    await context.Response.WriteAsync(PageControls._ResponseText);
                }
                else if (PageControls._ResponseType == "path")
                {
                    await context.Response.SendFileAsync(PageControls._ResponseFilePath);
                }
            });
        }
        
        private void api(IApplicationBuilder app)
        {
            
            wwwroot.Controls.ControlApi ControlApi = new wwwroot.Controls.ControlApi();
            app.Run(async (context) =>
            {
                (string,string) Response = ControlApi.Response(context);
                string _ResponseType = Response.Item1;
                if (_ResponseType == "SendFile")
                {
                    await context.Response.SendFileAsync(Response.Item2);
                }
                else if (_ResponseType  == "WriteText")
                {
                    await context.Response.WriteAsync(Response.Item2);
                }
                else if(_ResponseType == "empty")
                {

                }
            });
        }

    }
}
