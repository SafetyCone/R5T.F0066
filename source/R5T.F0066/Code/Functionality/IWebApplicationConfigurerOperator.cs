using System;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;

using Microsoft.AspNetCore.Builder;

using R5T.T0132;


namespace R5T.F0066
{
	[FunctionalityMarker]
	public partial interface IWebApplicationConfigurerOperator : IFunctionalityMarker
	{
		/// <summary>
		/// Add the synchronous web application builder configurer as a service.
		/// </summary>
		public void AddWebApplicationConfigurer_Sychronous<TWebApplicationConfigurer>(IServiceCollection services)
			where TWebApplicationConfigurer : class, ISynchronousWebApplicationConfigurer
		{
			// Choose transient, since services configurer instance will only be used once.
			services.AddTransient<TWebApplicationConfigurer>();
		}

		/// <summary>
		/// Add the asynchronous web application builder configurer as a service.
		/// </summary>
		public void AddWebApplicationConfigurer<TWebApplicationConfigurer>(IServiceCollection services)
			where TWebApplicationConfigurer : class, IAsynchronousWebApplicationConfigurer
		{
			// Choose transient, since services configurer instance will only be used once.
			services.AddTransient<TWebApplicationConfigurer>();
		}

		/// <summary>
		/// Get the action that will add the synchronous web application builder configurer as a service.
		/// </summary>
		public Action<IServiceCollection> GetAddWebApplicationConfigurer_Synchronous<TWebApplicationConfigurer>()
			where TWebApplicationConfigurer : class, ISynchronousWebApplicationConfigurer
		{
			return services => this.AddWebApplicationConfigurer_Sychronous<TWebApplicationConfigurer>(services);
		}

		/// <summary>
		/// Get the action that will add the asynchronous web application builder configurer as a service.
		/// </summary>
		public Action<IServiceCollection> GetAddWebApplicationConfigurer<TWebApplicationConfigurer>()
			where TWebApplicationConfigurer : class, IAsynchronousWebApplicationConfigurer
		{
			return services => this.AddWebApplicationConfigurer<TWebApplicationConfigurer>(services);
		}

		public Action<IServiceProvider> GetUseWebApplicationConfigurer_Synchronous_ForServiceProvider<TWebApplicationConfigurer>(WebApplication webApplication)
			where TWebApplicationConfigurer : ISynchronousWebApplicationConfigurer
		{
			return servicesConfigurerServiceProvider =>
			{
				var webApplicationConfigurer = servicesConfigurerServiceProvider.GetRequiredService<TWebApplicationConfigurer>();

				this.UseWebApplicationConfigurerInstance_Synchronous(
					webApplication,
					webApplicationConfigurer);
			};
		}

		public Func<IServiceProvider, Task> GetUseWebApplicationConfigurer_ForServiceProvider<TWebApplicationConfigurer>(WebApplication webApplication)
			where TWebApplicationConfigurer : IAsynchronousWebApplicationConfigurer
		{
			return async servicesConfigurerServiceProvider =>
			{
				var webApplicationConfigurer = servicesConfigurerServiceProvider.GetRequiredService<TWebApplicationConfigurer>();

				await this.UseWebApplicationConfigurerInstance(
					webApplication,
					webApplicationConfigurer);
			};
		}

		public WebApplication UseWebApplicationConfigurerInstance_Synchronous<TWebApplicationConfigurer>(
			WebApplication webApplication,
			TWebApplicationConfigurer webApplicationConfigurer)
			where TWebApplicationConfigurer : ISynchronousWebApplicationConfigurer
		{
			webApplicationConfigurer.ConfigureWebApplication(webApplication);

			return webApplication;
		}

		public async Task<WebApplication> UseWebApplicationConfigurerInstance<TWebApplicationConfigurer>(
			WebApplication webApplication,
			TWebApplicationConfigurer webApplicationConfigurer)
			where TWebApplicationConfigurer : IAsynchronousWebApplicationConfigurer
		{
			await webApplicationConfigurer.ConfigureWebApplication(webApplication);

			return webApplication;
		}

		public WebApplication UseWebApplicationConfigurer_Synchronous<TWebApplicationConfigurer>(
			WebApplication webApplication)
			where TWebApplicationConfigurer : class, ISynchronousWebApplicationConfigurer
		{
			var webApplicationConfigurerServices = F0028.ServicesOperator.Instance.GetEmptyServiceCollection();

			return this.UseWebApplicationConfigurer_Synchronous<TWebApplicationConfigurer>(
				webApplication,
				webApplicationConfigurerServices);
		}

		public Task<WebApplication> UseWebApplicationConfigurer<TWebApplicationConfigurer>(
			WebApplication webApplication)
			where TWebApplicationConfigurer : class, IAsynchronousWebApplicationConfigurer
		{
			var webApplicationConfigurerServices = F0028.ServicesOperator.Instance.GetEmptyServiceCollection();

			return this.UseWebApplicationConfigurer<TWebApplicationConfigurer>(
				webApplication,
				webApplicationConfigurerServices);
		}

		public WebApplication UseWebApplicationConfigurer_Synchronous<TWebApplicationConfigurer>(
			WebApplication webApplication,
			IServiceCollection webApplicationConfigurerServices)
			where TWebApplicationConfigurer : class, ISynchronousWebApplicationConfigurer
		{
			var servicesConfigurerServices = F0028.ServicesOperator.Instance.GetEmptyServiceCollection();

			Instances.ServiceProviderBuilderOperator.New(webApplicationConfigurerServices)
				.ConfigureServices(this.GetAddWebApplicationConfigurer_Synchronous<TWebApplicationConfigurer>())
				.InServiceProviderContext(this.GetUseWebApplicationConfigurer_Synchronous_ForServiceProvider<TWebApplicationConfigurer>(webApplication))
				;

			return webApplication;
		}

		public async Task<WebApplication> UseWebApplicationConfigurer<TWebApplicationConfigurer>(
			WebApplication webApplication,
			IServiceCollection webApplicationConfigurerServices)
			where TWebApplicationConfigurer : class, IAsynchronousWebApplicationConfigurer
		{
			var servicesConfigurerServices = F0028.ServicesOperator.Instance.GetEmptyServiceCollection();

			await Instances.ServiceProviderBuilderOperator.New(webApplicationConfigurerServices)
				.ConfigureServices(this.GetAddWebApplicationConfigurer<TWebApplicationConfigurer>())
				.InServiceProviderContext(this.GetUseWebApplicationConfigurer_ForServiceProvider<TWebApplicationConfigurer>(webApplication))
				;

			return webApplication;
		}
	}
}