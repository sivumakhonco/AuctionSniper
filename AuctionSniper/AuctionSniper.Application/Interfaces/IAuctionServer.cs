using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionSniper.Application.Interfaces
{
	public interface IAuctionServer
	{
		public ValueTask StartSellingItem();
		public ValueTask HasReceivedJoinRequestFromSniper();
		public ValueTask AnnounceClosed();
	}
}
