using System;

namespace AuctionSniper.Application.Interfaces;

public interface IDateTimeService
{
	DateTime NowUtc { get; }
}