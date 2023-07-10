using AuctionSniper.Application.Features.Employees.Queries.GetEmployees;
using AuctionSniper.Application.Features.Positions.Commands.CreatePosition;
using AuctionSniper.Application.Features.Positions.Queries.GetPositions;
using AuctionSniper.Domain.Entities;
using AutoMapper;

namespace AuctionSniper.Application.Mappings;

public class GeneralProfile : Profile
{
	public GeneralProfile()
	{
		CreateMap<Position, GetPositionsViewModel>().ReverseMap();
		CreateMap<Employee, GetEmployeesViewModel>().ReverseMap();
		CreateMap<CreatePositionCommand, Position>();
	}
}