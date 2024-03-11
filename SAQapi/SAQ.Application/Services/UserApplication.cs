﻿using AutoMapper;

using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

using SAQ.Application.Commons.Bases;
using SAQ.Application.Dtos.Request;
using SAQ.Application.Dtos.Response;
using SAQ.Application.Interfaces;
using SAQ.Domain.Entities;
using SAQ.Infrastructure.Persistence.Interfaces;
using SAQ.Utilities.Statics;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using BC = BCrypt.Net.BCrypt;

namespace SAQ.Application.Services
{
    public class UserApplication : IUserApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;


        public UserApplication(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration config)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _config = config;
        }

        public async Task<BaseResponse<bool>> RegisterUser(UserRequestDto requestDto)
        {
            var response = new BaseResponse<bool>();
            var account = _mapper.Map<User>(requestDto);

            account.Password = BC.HashPassword(account.Password);

            response.Data = await _unitOfWork.User.RegisterAsync(account);

            if (response.Data)
            {
                response.IsSuccess = true;

                response.Message = ReplyMessage.MESSAGE_SAVE;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_FAILED;
            }

            return response;
        }

        private string GenerateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("Jwt:SecretKey").Get<string>() ?? string.Empty));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim("userMail", user.UserName),
                new Claim("firstName", user.FirstName!),
                new Claim("lastName", user.LastName!),
                new Claim("userId", user.UserId.ToString())
            };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Issuer"],
                claims: claims,
                expires: DateTime.Now.AddDays(int.Parse(_config["Jwt:Expires"]!)),
                //notBefore: DateTime.UtcNow,
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<BaseResponse<string>> GenerateToken(TokenRequestDto requestDto)
        {
            var response = new BaseResponse<string>();
            var account = await _unitOfWork.User.AccountByUserName(requestDto.UserName!);

            if (account is not null)
            {
                if (BC.Verify(requestDto.Password, account.Password))
                {
                    response.IsSuccess = true;
                    response.Data = GenerateToken(account);
                    response.Message = ReplyMessage.MESSAGE_TOKEN;
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = ReplyMessage.MESSAGE_TOKEN_ERROR;
                }

            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_TOKEN_ERROR;
            }




            return response;
        }

        public async Task<BaseResponse<bool>> EditUser(Guid userId, UserRequestDto requestUser)
        {
            var response = new BaseResponse<bool>();
            var userEdit = await _unitOfWork.User.GetByIdAsync(userId);

            if (userEdit is null)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
                return response;
            }

            _unitOfWork.User.DetachUser(userEdit);

            var usernew = _mapper.Map<User>(requestUser);
            usernew.UserId = userId;

            response.Data = await _unitOfWork.User.EditAsync(usernew);

            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = ReplyMessage.MESSAGE_UPDATE;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_FAILED;
            }

            return response;

        }

        public async Task<BaseResponse<bool>> RemoveUser(Guid userId)
        {
            var response = new BaseResponse<bool>();
            var userEdit = await GetUserById(userId);
            Console.WriteLine(userEdit);
            if (userEdit.Data is null)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
                return response;
            }


            response.Data = await _unitOfWork.User.RemoveAsync(userId);

            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = ReplyMessage.MESSAGE_DELETE;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_FAILED;
            }

            return response;
        }

        public async Task<BaseResponse<IEnumerable<User>>> GetAllUsers(StatusType status = StatusType.active)
        {
            var response = new BaseResponse<IEnumerable<User>>();
            var users = await _unitOfWork.User.GetAllAsync(status);

            if (users is not null)
            {
                response.IsSuccess = true;
                response.Data = users;
                //response.Data = _mapper.Map<IEnumerable<UserResponseDto>>(users);
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            else
            {
                response.IsSuccess = false;
                response.Message += ReplyMessage.MESSAGE_QUERY_EMPTY;
            }

            return response;
        }

        public async Task<BaseResponse<UserResponseDto>> GetUserById(Guid userId)
        {
            var response = new BaseResponse<UserResponseDto>();
            var user = await _unitOfWork.User.GetByIdAsync(userId);
            var permisos = await getPermissonsUser(userId);

            if (user is not null)
            {
                response.IsSuccess = true;
                response.Data = _mapper.Map<UserResponseDto>(user);
                response.Data.Permisson = permisos;
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            else
            {
                response.IsSuccess = false;
                response.Message += ReplyMessage.MESSAGE_QUERY_EMPTY;
            }

            return response;
        }

        public async Task<BaseResponse<bool>> GetUserByMail(string email)
        {
            var response = new BaseResponse<bool>();
            var user = await _unitOfWork.User.AccountByUserName(email!);

            if (user is not null)
            {
                response.IsSuccess = true;
                response.Data = true;
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            else
            {
                response.IsSuccess = false;
                response.Data = false;
                response.Message += ReplyMessage.MESSAGE_QUERY_EMPTY;
            }

            return response;
        }

        private async Task<ICollection<int>> getPermissonsUser(Guid userId)
        {
            List<int> permisos = (List<int>)await _unitOfWork.User.GetPermissonsByUser(userId);

            return permisos;
        }
    }
}