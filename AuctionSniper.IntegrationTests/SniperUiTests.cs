using AuctionSniper.IntegrationTests.Helpers;
using Microsoft.Playwright.NUnit;

namespace AuctionSniper.IntegrationTests;

public class SniperUiTests: PageTest, IClassFixture<BlazorApplicationFactory>
{
	private readonly string _serverAddress;
	public SniperUiTests(BlazorApplicationFactory applicationFactory)
	{
		_serverAddress = applicationFactory.ServerAddress;
	}

	[Fact]
	public async Task SampleTest()
	{
		//Arrange  
		using var playwright = await Microsoft.Playwright.Playwright.CreateAsync();
		await using var browser = await playwright.Chromium.LaunchAsync();
		var page = await browser.NewPageAsync();

		//Act  
		await page.GotoAsync(_serverAddress);
		await page.ClickAsync("[class='nav-link']");
		await page.ClickAsync("[class='btn btn-primary']");

		//Assert  
		await Expect(page.Locator("[role='status']")).ToHaveTextAsync("Current count: 1");
	}
}