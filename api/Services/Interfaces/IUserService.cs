﻿using api.Data.Models;
using api.Models.Dtos;
using api.Models.Requests;

namespace api.Services.Interfaces;

public interface IUserService
{
    public Task<(bool, User?)> GetUserByGuidAsync(string userGuid);
    public Task<(bool, string)> UpdateAvatarAsync(IFormFile avatar);
    public Task<List<ConnectionDto>> GetConnectionsAsync();
}
