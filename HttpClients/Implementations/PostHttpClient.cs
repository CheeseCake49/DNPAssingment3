using System.Net.Http.Json;
using System.Text.Json;
using Shared.DTOs;
using Shared.Models;

namespace HttpClients.ClientInterfaces.Implementations;

public class PostHttpClient : IPostService
{
    private readonly HttpClient client;
    
    public PostHttpClient(HttpClient client)
    {
        this.client = client;
    }


    public async Task CreateAsync(DTOs.PostCreationDTO dto)
    { 
        HttpResponseMessage response = await client.PostAsJsonAsync("/post",dto);
        if (!response.IsSuccessStatusCode)
        {
            string content = await response.Content.ReadAsStringAsync();
            throw new Exception(content);
        }
    }

    public async Task<ICollection<Post>> GetAsync(string? userName, string? title, string? body)
    {
        HttpResponseMessage response = await client.GetAsync("/post");
        string content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        ICollection<Post> posts = JsonSerializer.Deserialize<ICollection<Post>>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return posts;
    }
}