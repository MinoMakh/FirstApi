using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstApi.Dtos.Users;
using FirstApi.Models;

namespace FirstApi.Mappers
{
    // Maps the data from entity to DTO
    public static class UserMappers
    {
        // Extension Function
        public static UserDto ToUserDto(this User userModel)
        {
            return new UserDto
            {
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                DateOfBirth = userModel.DateOfBirth,
                DateCreated = userModel.DateCreated,
                Id = userModel.Id
            };
        }

        // Extension Function
        public static User ToUserFromCreateDTO(this CreateUserRequestDto userDto)
        {
            return new User{
                 DateCreated = userDto.DateCreated,
                 DateOfBirth = userDto.DateOfBirth,
                 Email = userDto.Email,
                 FirstName = userDto.FirstName,
                 LastName = userDto.LastName
            };
        }
    }
}