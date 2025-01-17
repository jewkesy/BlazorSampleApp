using BlazorSampleApp.Components;
using Microsoft.Extensions.DependencyInjection;
using Telerik.JustMock;

namespace BlazorSampleAppTest.Components
{
    public class WeatherForecastTests
    {
        [Fact]
        public void TestFetchDataHandlesForecast()
        {
            var forecasts = new[] { new WeatherForecast { Date = DateTime.Now, Summary = "Mock", TemperatureC = 1 } };

            var weatherForecastServiceMock = Mock.Create<IWeatherForecastService>();
            Mock.Arrange(() => weatherForecastServiceMock.GetForecastAsync(Arg.IsAny<DateTime>()))
                .Returns(Task.FromResult<WeatherForecast[]>(forecasts));

            var ctx = new TestContext();
            ctx.Services.AddSingleton<IWeatherForecastService>(weatherForecastServiceMock);

            var cut = ctx.RenderComponent<FetchData>();
            var actualForcastDataTable = cut.FindComponent<ForecastDataTable>();

            var expectedDataTable = ctx.RenderComponent<ForecastDataTable>((nameof(ForecastDataTable.Forecasts), forecasts));
            actualForcastDataTable.MarkupMatches(expectedDataTable.Markup);
        }

        [Fact]
        public void TestFetchDataHandlesEmptyForecast()
        {
            var forecasts = Array.Empty<WeatherForecast>();

            var weatherForecastServiceMock = Mock.Create<IWeatherForecastService>();
            Mock.Arrange(() => weatherForecastServiceMock.GetForecastAsync(Arg.IsAny<DateTime>()))
                .Returns(Task.FromResult<WeatherForecast[]>(forecasts));

            var ctx = new TestContext();
            ctx.Services.AddSingleton<IWeatherForecastService>(weatherForecastServiceMock);

            var cut = ctx.RenderComponent<FetchData>();
            var actualForcastDataTable = cut.FindComponent<ForecastDataTable>();

            var expectedDataTable = ctx.RenderComponent<ForecastDataTable>((nameof(ForecastDataTable.Forecasts), forecasts));
            actualForcastDataTable.MarkupMatches(expectedDataTable.Markup);
        }

        [Fact]
        public void TestFetchDataHandlesNullForecast()
        {
            var weatherForecastServiceMock = Mock.Create<IWeatherForecastService>();
            Mock.Arrange(() => weatherForecastServiceMock.GetForecastAsync(Arg.IsAny<DateTime>()))
                .Returns(new TaskCompletionSource<WeatherForecast[]>().Task);

            var ctx = new TestContext();
            ctx.Services.AddSingleton<IWeatherForecastService>(weatherForecastServiceMock);

            var cut = ctx.RenderComponent<FetchData>();

            var initialExpectedHtml =
                        @"<h1>Weather forecast</h1>
                <p>This component demonstrates fetching data from a service.</p>
                <p><em>Loading...</em></p>";
            cut.MarkupMatches(initialExpectedHtml);
        }
    }
}
