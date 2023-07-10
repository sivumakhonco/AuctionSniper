using AuctionSniper.Application.Features.Employees.Queries.GetEmployees;
using AuctionSniper.Application.Parameters;
using AuctionSniper.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuctionSniper.Application.Interfaces.Repositories;

public interface IEmployeeRepositoryAsync : IGenericRepositoryAsync<Employee>
{
	Task<(IEnumerable<Entity> data, RecordsCount recordsCount)> GetPagedEmployeeReponseAsync(GetEmployeesQuery requestParameter);
}