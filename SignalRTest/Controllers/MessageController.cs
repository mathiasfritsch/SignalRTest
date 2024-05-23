using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace SignalRTest.Controllers;

[ApiController]
[Route("[controller]")]
public class MessageController : ControllerBase
{
    private readonly ILogger<MessageController> _logger;
    private readonly IHubContext<MessageHub,IMessage> _messageHubContext;

    public MessageController(ILogger<MessageController> logger, IHubContext<MessageHub,IMessage> messageHubContext)
    {
        _logger = logger;
        _messageHubContext = messageHubContext;
    }
   

    [HttpGet(Name = "SendMessage")]
    public string Get()
    {
        
        _messageHubContext.Clients.All.SendMessage("Some message from controller1");

        return @"ok";
    }
}