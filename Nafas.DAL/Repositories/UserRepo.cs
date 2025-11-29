using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;
using Nafas.DAL.DTOs.User;
using System.Security.AccessControl;

namespace Nafas.DAL.Repositories
{
    public class UserRepo
    {
        //NewUserDTO user=new NewUserDTO();
        public int? AddNewUser(NewUserDTO user)

        {
            string query = "SP_User_AddNewUser";
            try
            {
                using (SqlConnection connection = new SqlConnection(Global.connectionstring))

                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@UserName", user.UserName);

                        
                        command.Parameters.AddWithValue("@Password", user.Password);
                        
                        command.Parameters.AddWithValue("@Email", user.Email);
                        
                        command.Parameters.AddWithValue("@FirstName", user.FirstName);
                        
                        command.Parameters.AddWithValue("@Weight", user.Weight);
                        command.Parameters.AddWithValue("@Height", user.Height);
                        command.Parameters.AddWithValue("@Age", user.Age);
                        command.Parameters.AddWithValue("@GenderIsMale", user.GenderIsMale);
                        command.Parameters.AddWithValue("@IsAdmin", user.IsAdmin);

                        int? id = (int)command.ExecuteScalar();
                        return id;

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
        public bool CheckUserByID(int userId)
        {
            string query =
                @"if exists(select f=1 from Users where UserID=@UserID)
	                    select cast(1 as bit)
                    else 
	                    select cast (0 as bit)";
            try
            {
                using (SqlConnection connection = new SqlConnection(Global.connectionstring))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", userId);

                        bool ok =(bool) command.ExecuteScalar();
                        if (ok)
                        {
                            return true;
                        }
                        else return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }

            return false;
        }
        public bool ChangePassword(ChangePasswordDTO user)
        {
            string query = "SP_User_ChangePassword";
            try
            {
                using (SqlConnection connection = new SqlConnection(Global.connectionstring))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@UserId", user.UserId);
                        command.Parameters.AddWithValue("@OldPassword", user.OldPassword);
                        command.Parameters.AddWithValue("@NewPassword", user.NewPassword);

                        int rowsAffected = (int)command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            return true;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        public bool UpdateUserName(UserDTO user)
        {
            string query = @"Update Users set UserName=@UserName where UserID=@UserID and Password=@Password and Email=@Email";
            try
            {
                using(SqlConnection connection = new SqlConnection(Global.connectionstring))
                {
                    using (SqlCommand command=new SqlCommand(query, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@UserID", user.UserID);
                        command.Parameters.AddWithValue("@Password", user.Password);
                        command.Parameters.AddWithValue("@Email", user.Email);
                        command.Parameters.AddWithValue("@UserName", user.UserName);

                        int rowsAffected= (int)command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            return true;
                        }

                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return false;

        }
        public UserProfileDTO? GetUserProfile(int UserID)
        {
            string query = "select UserName,Email,FirstName,[Weight],Height,Age,GenderIsMale from Users where UserID=@UserID";
            try
            {
                using (SqlConnection connection = new SqlConnection(Global.connectionstring))
                {
                    using(SqlCommand command=new SqlCommand(query, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@UserID", UserID);
                        SqlDataReader reader = command.ExecuteReader();
                        UserProfileDTO userProfile = new UserProfileDTO();
                        if (reader.Read())
                        {
                            Console.WriteLine((string)reader["UserName"]);
                            userProfile.Email =(string) reader["Email"];
                            userProfile.UserName =(string) reader["UserName"];
                            userProfile.FirstName =(string) reader["FirstName"];
                            userProfile.Age =(int) reader["Age"];
                            userProfile.GenderIsMale =(bool) reader["GenderIsMale"];
                            userProfile.Weight =(decimal) reader["Weight"];
                            userProfile.Height =(int) reader["Height"];
                        }
                        return userProfile;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
                return null;
        }
    }
}
