using System.Net.Http.Json;
using System.Text.Json;
using HttpClient.ClientInterfaces;
using Shared.DTOs;
using Shared.Models;

namespace HttpClient.Implementations;

public class PostHttpClient : IPostService
{
    private readonly System.Net.Http.HttpClient client;
    
    public PostHttpClient(System.Net.Http.HttpClient client)
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

    public async Task<ICollection<Post>> GetPostAsync(string? userName, string? title, string? body)
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