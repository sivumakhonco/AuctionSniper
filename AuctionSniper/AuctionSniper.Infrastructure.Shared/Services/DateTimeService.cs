using AuctionSniper.Application.Interfaces;
using System;

namespace AuctionSniper.Infrastructure.Shared.Services;

public class DateTimeService : IDateTimeService
{
	public DateTime NowUtc => DateTime.UtcNow;
}