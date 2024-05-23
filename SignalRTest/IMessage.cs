namespace SignalRTest;

public interface IMessage
{
    public  Task SendMessage(string message);
}