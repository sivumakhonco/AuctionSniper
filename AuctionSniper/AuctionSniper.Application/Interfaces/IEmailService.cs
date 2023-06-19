using AuctionSniper.Application.DTOs.Email;
using System.Threading.Tasks;

namespace AuctionSniper.Application.Interfaces;

public interface IEmailService
{
	Task SendAsync(EmailRequest request);
}