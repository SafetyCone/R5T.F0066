using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Builder;

using R5T.F0066;


public static class WebApplicationBuilderExtensions
{
    public static WebApplicationBuilder UseWebApplicationBuilderConfigurer_Synchronous<TWebApplicationBuilderConfigurer>(this WebApplicationBuilder webApplicationBuilder)
        where TWebApplicationBuilderConfigurer : class, ISynchronousWebApplicationBuilderConfigurer
    {
        return Instances.WebApplicationBuilderConfigurerOperator.UseWebApplicationBuilderConfigurer_Synchronous<TWebApplicationBuilderConfigurer>(
            webApplicationBuilder);
    }

    public static Task<WebApplicationBuilder> UseWebApplicationBuilderConfigurer<TWebApplicationBuilderConfigurer>(this WebApplicationBuilder webApplicationBuilder)
        where TWebApplicationBuilderConfigurer : class, IAsynchronousWebApplicationBuilderConfigurer
    {
        return Instances.WebApplicationBuilderConfigurerOperator.UseWebApplicationBuilderConfigurer<TWebApplicationBuilderConfigurer>(
            webApplicationBuilder);
    }
}

