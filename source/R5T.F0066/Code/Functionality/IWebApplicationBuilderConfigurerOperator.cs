using System;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;

using Microsoft.AspNetCore.Builder;

using R5T.T0132;


namespace R5T.F0066
{
	[FunctionalityMarker]
	public partial interface IWebApplicationBuilderConfigurerOperator : IFunctionalityMarker
	{
		/// <summary>
		/// Add the synchronous web application builder configurer as a service.
		/// </summary>
		public void AddWebApplicationBuilderConfigurer_Synchronous<TWebApplicationBuilderConfigurer>(IServiceCollection services)
			where TWebApplicationBuilderConfigurer : class, ISynchronousWebApplicationBuilderConfigurer
		{
			// Choose transient, since services configurer instance will only be used once.
			services.AddTransient<TWebApplicationBuilderConfigurer>();
		}

		/// <summary>
		/// Add the asynchronous web application builder configurer as a service.
		/// </summary>
		public void AddWebApplicationBuilderConfigurer<TWebApplicationBuilderConfigurer>(IServiceCollection services)
			where TWebApplicationBuilderConfigurer : class, IAsynchronousWebApplicationBuilderConfigurer
		{
			// Choose transient, since services configurer instance will only be used once.
			services.AddTransient<TWebApplicationBuilderConfigurer>();
		}

		/// <summary>
		/// Get the action that will add the synchronous web application builder configurer as a service.
		/// </summary>
		public Action<IServiceCollection> GetAddWebApplicationBuilderConfigurer_Synchronous<TWebApplicationBuilderConfigurer>()
			where TWebApplicationBuilderConfigurer : class, ISynchronousWebApplicationBuilderConfigurer
		{
			return services => this.AddWebApplicationBuilderConfigurer_Synchronous<TWebApplicationBuilderConfigurer>(services);
		}

		/// <summary>
		/// Get the action that will add the ssynchronous web application builder configurer as a service.
		/// </summary>
		public Action<IServiceCollection> GetAddWebApplicationBuilderConfigurer<TWebApplicationBuilderConfigurer>()
			where TWebApplicationBuilderConfigurer : class, IAsynchronousWebApplicationBuilderConfigurer
		{
			return services => this.AddWebApplicationBuilderConfigurer<TWebApplicationBuilderConfigurer>(services);
		}

		public Action<IServiceProvider> GetUseWebApplicationBuilderConfigurer_Synchronous_ForServiceProvider<TWebApplicationBuilderConfigurer>(WebApplicationBuilder webApplicationBuilder)
			where TWebApplicationBuilderConfigurer : ISynchronousWebApplicationBuilderConfigurer
		{
			return servicesConfigurerServiceProvider =>
			{
				var webApplicationBuilderConfigurer = servicesConfigurerServiceProvider.GetRequiredService<TWebApplicationBuilderConfigurer>();

				this.UseWebApplicationBuilderConfigurerInstance_Synchronous(
					webApplicationBuilder,
					webApplicationBuilderConfigurer);
			};
		}

		public Func<IServiceProvider, Task> GetUseWebApplicationBuilderConfigurer_ForServiceProvider<TWebApplicationBuilderConfigurer>(WebApplicationBuilder webApplicationBuilder)
			where TWebApplicationBuilderConfigurer : IAsynchronousWebApplicationBuilderConfigurer
		{
			return async servicesConfigurerServiceProvider =>
			{
				var webApplicationBuilderConfigurer = servicesConfigurerServiceProvider.GetRequiredService<TWebApplicationBuilderConfigurer>();

				await this.UseWebApplicationBuilderConfigurerInstance(
					webApplicationBuilder,
					webApplicationBuilderConfigurer);
			};
		}

		public WebApplicationBuilder UseWebApplicationBuilderConfigurerInstance_Synchronous<TWebApplicationBuilderConfigurer>(
			WebApplicationBuilder webApplicationBuilder,
			TWebApplicationBuilderConfigurer webApplicationBuilderConfigurer)
			where TWebApplicationBuilderConfigurer : ISynchronousWebApplicationBuilderConfigurer
		{
			webApplicationBuilderConfigurer.ConfigureWebApplicationBuilder(webApplicationBuilder);

			return webApplicationBuilder;
		}

		public async Task<WebApplicationBuilder> UseWebApplicationBuilderConfigurerInstance<TWebApplicationBuilderConfigurer>(
			WebApplicationBuilder webApplicationBuilder,
			TWebApplicationBuilderConfigurer webApplicationBuilderConfigurer)
			where TWebApplicationBuilderConfigurer : IAsynchronousWebApplicationBuilderConfigurer
		{
			await webApplicationBuilderConfigurer.ConfigureWebApplicationBuilder(webApplicationBuilder);

			return webApplicationBuilder;
		}

		public WebApplicationBuilder UseWebApplicationBuilderConfigurer_Synchronous<TWebApplicationBuilderConfigurer>(
			WebApplicationBuilder webApplicationBuilder)
			where TWebApplicationBuilderConfigurer : class, ISynchronousWebApplicationBuilderConfigurer
		{
			var webApplicationBuilderConfigurerServices = F0028.ServicesOperator.Instance.GetEmptyServiceCollection();

			return this.UseWebApplicationBuilderConfigurer_Synchronous<TWebApplicationBuilderConfigurer>(
				webApplicationBuilder,
				webApplicationBuilderConfigurerServices);
		}

		public Task<WebApplicationBuilder> UseWebApplicationBuilderConfigurer<TWebApplicationBuilderConfigurer>(
			WebApplicationBuilder webApplicationBuilder)
			where TWebApplicationBuilderConfigurer : class, IAsynchronousWebApplicationBuilderConfigurer
		{
			var webApplicationBuilderConfigurerServices = F0028.ServicesOperator.Instance.GetEmptyServiceCollection();

			return this.UseWebApplicationBuilderConfigurer<TWebApplicationBuilderConfigurer>(
				webApplicationBuilder,
				webApplicationBuilderConfigurerServices);
		}

		public WebApplicationBuilder UseWebApplicationBuilderConfigurer_Synchronous<TWebApplicationBuilderConfigurer>(
			WebApplicationBuilder webApplicationBuilder,
			IServiceCollection webApplicationBuilderConfigurerServices)
			where TWebApplicationBuilderConfigurer : class, ISynchronousWebApplicationBuilderConfigurer
		{
			var servicesConfigurerServices = F0028.ServicesOperator.Instance.GetEmptyServiceCollection();

			Instances.ServiceProviderBuilderOperator.New(webApplicationBuilderConfigurerServices)
				.ConfigureServices(this.GetAddWebApplicationBuilderConfigurer_Synchronous<TWebApplicationBuilderConfigurer>())
				.InServiceProviderContext(this.GetUseWebApplicationBuilderConfigurer_Synchronous_ForServiceProvider<TWebApplicationBuilderConfigurer>(webApplicationBuilder))
				;

			return webApplicationBuilder;
		}

		public async Task<WebApplicationBuilder> UseWebApplicationBuilderConfigurer<TWebApplicationBuilderConfigurer>(
			WebApplicationBuilder webApplicationBuilder,
			IServiceCollection webApplicationBuilderConfigurerServices)
			where TWebApplicationBuilderConfigurer : class, IAsynchronousWebApplicationBuilderConfigurer
		{
			var servicesConfigurerServices = F0028.ServicesOperator.Instance.GetEmptyServiceCollection();

			await Instances.ServiceProviderBuilderOperator.New(webApplicationBuilderConfigurerServices)
				.ConfigureServices(this.GetAddWebApplicationBuilderConfigurer<TWebApplicationBuilderConfigurer>())
				.InServiceProviderContext(this.GetUseWebApplicationBuilderConfigurer_ForServiceProvider<TWebApplicationBuilderConfigurer>(webApplicationBuilder))
				;

			return webApplicationBuilder;
		}
	}
}