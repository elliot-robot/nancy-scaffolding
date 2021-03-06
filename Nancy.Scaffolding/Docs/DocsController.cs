﻿using Nancy.Scaffolding.Docs.Redoc;
using Nancy.Scaffolding.Modules;
using Nancy.Serilog.Simple.Extensions;

namespace Nancy.Scaffolding.Docs
{
    public class DocsController : BaseModule
    {
        public DocsController() : base("docs")
        {
            if (Api.DocsSettings.Enabled == true)
            {
                this.Get("", args => this.Docs());
            }
        }

        public object Docs()
        {
            this.DisableLogging();

            var content = RedocContent.GetHtml();
            content = content.Replace("{title}", Api.ApiSettings.Application);
            content = content.Replace("{version}", Api.ApiSettings.Version);

            var response = (Response) content;
            response.StatusCode = HttpStatusCode.OK;
            response.ContentType = "text/html";

            return response;
        }
    }
}
