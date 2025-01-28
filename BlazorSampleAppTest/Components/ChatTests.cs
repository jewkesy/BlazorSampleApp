using BlazorSampleApp.Hubs;
using Microsoft.AspNetCore.SignalR;
using Telerik.JustMock.Helpers;

namespace BlazorSampleAppTest.Components
{
    public class ChatTests
    {
        //[Fact]
        //public async Task HubsAreMockableVia()
        //{
        //    Mock<IHubCallerClients> mockClients = new Mock<IHubCallerClients>();
        //    Mock<IClientProxy> mockClientProxy = new Mock<IClientProxy>();

        //    mockClients.Setup(clients => clients.All).Returns(mockClientProxy.Object);

        //    ChatHub testhub = new ChatHub()
        //    {
        //        Clients = mockClients.Object
        //    };

        //    await testhub.SendMessage("hello", "user");
        //    mockClients.Verify(clients => clients.All, Times.Once);

        //    //mockClientProxy.Verify(
        //    //clientProxy => clientProxy.SendAsync(
        //    //    "OnMessageReceived",

        //    //      It.Is<object[]>(o => o != null && o.Length == 2),

        //    //    default(CancellationToken)),
        //    //Times.Once);

        //}

        [Fact]
        public async void CanSendChatMessage()
        {
            var mockClients = Mock.Create<IHubCallerClients>();
            var mockClientProxy = Mock.Create<IClientProxy>();

            mockClients.Arrange(clients => clients.All).Returns(mockClientProxy).OccursOnce();

            ChatHub testhub = new ChatHub()
            {
                Clients = mockClients
            };

            await testhub.SendMessage("hello", "user");
            Mock.Assert(mockClients);
        }





        //[Fact]
        //public async void CanSendChatMessage()
        //{

        //    using var ctx = new TestContext();
        //    var cut = ctx.RenderComponent<BlazorSampleApp.Pages.Index>();

        //    bool sendCalled = false;
        //    var hub = new ChatHub();
        //    var mockClients = new Mock<IHubCallerConnectionContext<dynamic>>();
        //    hub.Clients = (IHubCallerClients)mockClients.Object;
        //    dynamic all = new ExpandoObject();
        //    all.broadcastMessage = new Action<string, string>((name, message) =>
        //    {
        //        sendCalled = true;
        //    });
        //    mockClients.Setup(m => m.All).Returns((ExpandoObject)all);
        //    hub.SendMessage("TestUser", "TestMessage");
        //    Assert.True(sendCalled);



        //    //bool sendCalled = false;
        //    //var hub = new ChatHub();
        //    //var mockClients = Mock.Create<IHubCallerConnectionContext<dynamic>>();
        //    //hub.Clients = mockClients;
        //    //dynamic all = new ExpandoObject();
        //    //all.broadcastMessage = new Action<string, string>((name, message) =>
        //    //{
        //    //    sendCalled = true;
        //    //});
        //    //mockClients.Arrange(m => m.All).Returns((ExpandoObject)all);
        //    //hub.SendMessage("TestUser", "TestMessage");
        //    //Assert.True(sendCalled);




        //    //ProjectsHub hub = new ProjectsHub();
        //    //var clients = Mock.Create<IHubCallerClients<ISignals>>();
        //    //var signals = Mock.Create<ISignals>();
        //    //hub.Clients = clients;

        //    //signals.Arrange(m => m.AddProject(Arg.IsAny<string>())).OccursOnce();
        //    //clients.Arrange(m => m.All).Returns(signals);



        //    //hub.AddProject("id");

        //    //// Assert
        //    //Mock.Assert(signals);

        //    //userInput
        //    //messageInput
        //    //sendButton

        //    var txtUser = cut.Find("#userInput");
        //    var txtMsg = cut.Find("#messageInput");
        //    var btnSend = cut.Find("#sendButton");

        //    txtUser.TextContent = "user";
        //    txtMsg.TextContent = "message";


        //    btnSend.Click();

        //    var list = cut.Find("#messagesList");
        //    var x = list.TextContent;
        //    Assert.Equal("daryl", list.TextContent);

        //    //var paraElmText = paraElm.TextContent;
        //    //paraElmText.MarkupMatches("Current count: 0");

        //    //cut.Find("button").Click();

        //    //paraElmText = paraElm.TextContent;
        //    //paraElmText.MarkupMatches("Current count: 1");


        //    Assert.True(false);
        //}
    }

    //public interface ISignals
    //{
    //    void AddProject(string id);
    //}

    //public class ProjectsHub : Hub<ISignals>
    //{
    //    public void AddProject(string id)
    //    {
    //        Clients.All.AddProject(id);
    //    }
    //}

}
