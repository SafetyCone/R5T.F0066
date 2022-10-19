using System;

using Microsoft.AspNetCore.Builder;


namespace R5T.F0066
{
    public interface ISynchronousWebApplicationConfigurer
    {
        void ConfigureWebApplication(WebApplication webApplication);
    }
}
