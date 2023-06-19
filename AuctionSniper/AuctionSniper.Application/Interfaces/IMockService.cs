using AuctionSniper.Domain.Entities;
using System.Collections.Generic;

namespace AuctionSniper.Application.Interfaces;

public interface IMockService
{
	List<Position> GetPositions(int rowCount);

	List<Employee> GetEmployees(int rowCount);

	List<Position> SeedPositions(int rowCount);
}