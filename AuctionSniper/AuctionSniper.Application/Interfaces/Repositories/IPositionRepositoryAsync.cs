using AuctionSniper.Application.Features.Positions.Queries.GetPositions;
using AuctionSniper.Application.Parameters;
using AuctionSniper.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuctionSniper.Application.Interfaces.Repositories;

public interface IPositionRepositoryAsync : IGenericRepositoryAsync<Position>
{
	Task<bool> IsUniquePositionNumberAsync(string positionNumber);

	Task<bool> SeedDataAsync(int rowCount);

	Task<(IEnumerable<Entity> data, RecordsCount recordsCount)> GetPagedPositionReponseAsync(GetPositionsQuery requestParameters);
}