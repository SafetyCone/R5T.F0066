using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Builder;

using R5T.F0066;

using Instances = R5T.F0066.Instances;



public static class WebApplicationExtensions
{
    public static WebApplication UseWebApplicationConfigurer_Synchronous<TWebApplicationConfigurer>(this WebApplication webApplication)
            where TWebApplicationConfigurer : class, ISynchronousWebApplicationConfigurer
    {
        return Instances.WebApplicationConfigurerOperator.UseWebApplicationConfigurer_Synchronous<TWebApplicationConfigurer>(webApplication);
    }

    public static Task<WebApplication> UseWebApplicationConfigurer<TWebApplicationConfigurer>(this WebApplication webApplication)
            where TWebApplicationConfigurer : class, IAsynchronousWebApplicationConfigurer
    {
        return Instances.WebApplicationConfigurerOperator.UseWebApplicationConfigurer<TWebApplicationConfigurer>(webApplication);
    }
}

