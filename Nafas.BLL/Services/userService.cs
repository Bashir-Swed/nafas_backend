using Nafas.DAL.DTOs.User;
using Nafas.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

namespace Nafas.BLL.Services
{
    public class userService
    {
    private readonly UserRepo _userRepo=new UserRepo();
        public int? AddNewUser(NewUserDTO user)
        {

            return _userRepo.AddNewUser(user);


        }
        public bool ChangePassword(ChangePasswordDTO user)
        {
            return _userRepo.ChangePassword(user);
        }
    }
}
