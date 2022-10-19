using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Builder;


namespace R5T.F0066
{
    public interface IAsynchronousWebApplicationBuilderConfigurer
    {
        Task ConfigureWebApplicationBuilder(WebApplicationBuilder webApplicationBuilder);
    }
}
