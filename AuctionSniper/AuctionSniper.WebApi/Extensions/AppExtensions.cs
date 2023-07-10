using AuctionSniper.WebApi.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace AuctionSniper.WebApi.Extensions
{
	public static class AppExtensions
	{
		public static void UseSwaggerExtension(this IApplicationBuilder app)
		{
			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "CleanArchitecture.AuctionSniper.WebApi");
			});
		}

		public static void UseErrorHandlingMiddleware(this IApplicationBuilder app)
		{
			app.UseMiddleware<ErrorHandlerMiddleware>();
		}
	}
}