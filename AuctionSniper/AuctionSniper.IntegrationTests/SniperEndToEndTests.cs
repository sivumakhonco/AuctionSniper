global using Microsoft.Playwright;
using AuctionSniper.IntegrationTests.Helpers;
using Microsoft.Playwright.NUnit;
using Bogus;
using FluentAssertions;

namespace AuctionSniper.IntegrationTests;

public class SniperEndToEndTests: PageTest, IClassFixture<BlazorApplicationFactory>
{
	private readonly string _serverAddress;
	private readonly Faker _faker;
	public SniperEndToEndTests(BlazorApplicationFactory applicationFactory)
	{
		_serverAddress = applicationFactory.ServerAddress;
		_faker = new Faker();
	}

	[Fact]
	public async Task SniperCanJoinAuctionUntilAuctionCloses()
	{
		//Arrange  
		using var playwright = await Microsoft.Playwright.Playwright.CreateAsync();
		await using var browser = await playwright.Chromium.LaunchAsync();
		var page = await browser.NewPageAsync();
		var itemCode = _faker.Commerce.ProductAdjective();
		var maxPrice = _faker.Commerce.Price();
		var expectedStatus = "Bidding";

		//Act  
		await page.GotoAsync(_serverAddress);
		await page.GetByRole(AriaRole.Button, new() { Name = "New Sniper" }).ClickAsync();
		var dialog = page.Locator("[role='new-sniper-dialog']");
		await Expect(dialog).ToBeVisibleAsync();
		await dialog.GetByLabel("Item Code").FillAsync(itemCode);
		await dialog.GetByRole(AriaRole.Button, new() { Name = "Snipe"}).ClickAsync();

		//Assert
		var lastRow = page.Locator(".auction-row").Last;
		lastRow.Should().NotBeNull();
		await Expect(lastRow).ToHaveTextAsync(itemCode);
		await Expect(lastRow).ToHaveTextAsync(maxPrice.ToString());
		await Expect(lastRow).ToHaveTextAsync(expectedStatus);
	}
}