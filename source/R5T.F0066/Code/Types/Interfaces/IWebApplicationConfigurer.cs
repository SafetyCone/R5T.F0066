using System;


namespace R5T.F0066
{
    /// <summary>
    /// Chooses <see cref="IAsynchronousWebApplicationConfigurer"/> as the default web application configurer.
    /// </summary>
    public interface IWebApplicationConfigurer : IAsynchronousWebApplicationConfigurer
    {
    }
}
