using AuctionSniper.Application.Interfaces;
using AuctionSniper.Domain.Entities;
using AuctionSniper.Infrastructure.Shared.Mock;
using System.Collections.Generic;

namespace AuctionSniper.Infrastructure.Shared.Services;

public class MockService : IMockService
{
	public List<Position> GetPositions(int rowCount)
	{
		var positionFaker = new PositionInsertBogusConfig();
		return positionFaker.Generate(rowCount);
	}

	public List<Employee> GetEmployees(int rowCount)
	{
		var positionFaker = new EmployeeBogusConfig();
		return positionFaker.Generate(rowCount);
	}

	public List<Position> SeedPositions(int rowCount)
	{
		var seedPositionFaker = new PositionSeedBogusConfig();
		return seedPositionFaker.Generate(rowCount);
	}
}