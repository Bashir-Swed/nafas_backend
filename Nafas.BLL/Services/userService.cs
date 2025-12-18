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
        
        public bool UpdateUserName(UserDTO user)
        {
            return _userRepo.UpdateUserName(user);
        }
        public bool CheckUserByID(int userID)
        {
            return _userRepo.CheckUserByID(userID);
        }
        public bool? CheckUserByName(string user)
        {

            return _userRepo.CheckUserByName(user);


        }
        public bool? CheckUserByNameAndID(string user,int Id)
        {

            return _userRepo.CheckUserByNameAndID(user,Id);


        }
        public bool? CheckUserByNameAndPassword(string username, string password)
        {

            return _userRepo.CheckUserByNameAndPassword(username, password);


        }
        public UserProfileDTO? GetUserProfile(int userID)
        {
            if(!_userRepo.CheckUserByID(userID)) throw new Exception("not found this user ");
            return _userRepo.GetUserProfile(userID);
        }


    }
}
