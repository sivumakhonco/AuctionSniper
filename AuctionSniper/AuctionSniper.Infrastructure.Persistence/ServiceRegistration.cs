﻿using AuctionSniper.Application.Interfaces;
using AuctionSniper.Application.Interfaces.Repositories;
using AuctionSniper.Infrastructure.Persistence.Contexts;
using AuctionSniper.Infrastructure.Persistence.Repositories;
using AuctionSniper.Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AuctionSniper.Infrastructure.Persistence;

public static class ServiceRegistration
{
	public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
	{
		if (configuration.GetValue<bool>("UseInMemoryDatabase"))
		{
			services.AddDbContext<ApplicationDbContext>(options =>
				options.UseInMemoryDatabase("ApplicationDb"));
		}
		else
		{
			services.AddDbContext<ApplicationDbContext>(options =>
		   options.UseSqlServer(
			   configuration.GetConnectionString("DefaultConnection"),
			   b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
		}

		#region Repositories

		services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
		services.AddTransient<IPositionRepositoryAsync, PositionRepositoryAsync>();
		services.AddTransient<IEmployeeRepositoryAsync, EmployeeRepositoryAsync>();

		#endregion Repositories
	}
}