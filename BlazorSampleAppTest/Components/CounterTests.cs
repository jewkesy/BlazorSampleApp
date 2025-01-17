namespace BlazorSampleAppTest.Components
{
    public class CounterTests
    {
        [Fact]
        public void CounterShouldIncrementWhenClicked()
        {
            using var ctx = new TestContext();
            var cut = ctx.RenderComponent<Counter>();
            var paraElm = cut.Find("p");
            var paraElmText = paraElm.TextContent;
            paraElmText.MarkupMatches("Current count: 0");

            cut.Find("button").Click();

            paraElmText = paraElm.TextContent;
            paraElmText.MarkupMatches("Current count: 1");
        }
    }
}
