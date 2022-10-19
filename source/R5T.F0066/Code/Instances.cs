using System;

using R5T.F0036.F000;


namespace R5T.F0066
{
    public static class Instances
    {
        public static IServiceProviderBuilderOperator ServiceProviderBuilderOperator { get; } = F0036.F000.ServiceProviderBuilderOperator.Instance;
        public static IWebApplicationBuilderConfigurerOperator WebApplicationBuilderConfigurerOperator { get; } = F0066.WebApplicationBuilderConfigurerOperator.Instance;
        public static IWebApplicationConfigurerOperator WebApplicationConfigurerOperator { get; } = F0066.WebApplicationConfigurerOperator.Instance;
    }
}