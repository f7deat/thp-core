namespace THPCore.Interfaces.IServices;

public interface INotificationService
{
    Task CreateAsync(string title, string content, IEnumerable<string> recipients);
    Task CreateAsync(string title, string content, string recipient);
}
