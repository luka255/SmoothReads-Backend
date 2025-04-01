using SmoothReads_Backend.DTOs.User;
using SmoothReads_Backend.Models;

namespace SmoothReads_Backend.Mappers
{
    public static class UserMappers
    {
        public static UserDto ToUserDto(this User userModel)
        {
            return new UserDto
            {
                Id = userModel.Id,
                Name = userModel.Name,
                Email = userModel.Email,
            };
        }

        public static User ToUserFromCreateDto(this CreateUserDto userModel)
        {
            return new User
            {
                Name = userModel.Name,
                Email = userModel.Email,
                Password = userModel.Password,
            };
        }
    }
}
