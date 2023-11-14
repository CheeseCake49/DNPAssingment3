using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Shared.DTOs;
using Shared.Models;

namespace Application.Logic;

public class PostLogic : IPostLogic
{

    private readonly IPostDao _postDao;
    private readonly IUserDao _userDao;

    public PostLogic(IPostDao postDao, IUserDao userDao)
    {
        _postDao = postDao;
        _userDao = userDao;
    }
    
    public async Task<Post> CreateAsync(DTOs.PostCreationDTO postToCreate)
    {
        User? user = await _userDao.GetByUsernameAsync(postToCreate.OwnerUsername);
        if (user == null)
            throw new Exception($"User with username {postToCreate.OwnerUsername} was not found.");

        ValidateData(postToCreate);
        Post post = new Post(postToCreate.Title, postToCreate.Body, user);
        return await _postDao.CreateAsync(post);
    }

    public async Task<IEnumerable<Post>> GetAllPostsAsync()
    {
        return await _postDao.GetAllPostsAsync();
    }

    public async Task<Post> GetByIdAsync(int Id)
    {
        return await _postDao.GetByIdAsync(Id);
    }

    private void ValidateData(DTOs.PostCreationDTO dto)
    {
        if (string.IsNullOrEmpty(dto.Title) || string.IsNullOrEmpty(dto.Body))
            throw new Exception("Invalid");
    }
}