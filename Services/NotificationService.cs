using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using THPCore.Interfaces.IServices;

namespace THPCore.Services;

public class NotificationService : INotificationService
{
    private readonly HttpClient _client;
    public NotificationService(HttpClient client, IHttpContextAccessor httpContextAccessor)
    {
        client.BaseAddress = new Uri("https://dhhp.edu.vn/api/notification/");
        var context = httpContextAccessor.HttpContext;
        if (context != null)
        {
            context.Request.Headers.TryGetValue("Authorization", out var token);
            token = token.ToString().Replace("Bearer ", "");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
        _client = client;
    }

    public async Task CreateAsync(string title, string content, IEnumerable<string> recipients)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, "create-private")
        {
            Content = new StringContent(JsonSerializer.Serialize(new
            {
                Title = title,
                Content = content,
                Recipients = recipients
            }), Encoding.UTF8, "application/json")
        };
        await _client.SendAsync(request);
    }

    public async Task CreateAsync(string title, string content, string recipient)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, "create-private")
        {
            Content = new StringContent(JsonSerializer.Serialize(new
            {
                Title = title,
                Content = content,
                Recipients = new List<string> { recipient }
            }), Encoding.UTF8, "application/json")
        };
        await _client.SendAsync(request);
    }
}
