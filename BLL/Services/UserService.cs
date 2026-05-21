using AutoMapper;
using BLL.DTOs;
using DAL.EF.Tables;
using DAL.Repos;

namespace BLL.Services
{
    public class UserService(UserRepo userRepo)
    {
        Mapper mapper = MapperConfig.GetMapper();

        public bool Register(UserDTO user)
        {
            var mapped = mapper.Map<User>(user);
            mapped.Role = "Customer";
            return userRepo.Create(mapped);
        }

        public UserDTO? Login(string email, string password)
        {
            return mapper.Map<UserDTO>(userRepo.Get(email, password));
        }

        public UserDTO? CheckExistingEmail(string email)
        {
            return mapper.Map<UserDTO>(userRepo.Get().FirstOrDefault(u => u.Email == email));
        }
    }
}
