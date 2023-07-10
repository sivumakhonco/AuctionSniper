using AuctionSniper.Application.Interfaces;
using AuctionSniper.Domain.Settings;
using AuctionSniper.Infrastructure.Shared.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AuctionSniper.Infrastructure.Shared;

public static class ServiceRegistration
{
	public static void AddSharedInfrastructure(this IServiceCollection services, IConfiguration _config)
	{
		services.Configure<MailSettings>(_config.GetSection("MailSettings"));
		services.AddTransient<IDateTimeService, DateTimeService>();
		services.AddTransient<IEmailService, EmailService>();
		services.AddTransient<IMockService, MockService>();
	}
}