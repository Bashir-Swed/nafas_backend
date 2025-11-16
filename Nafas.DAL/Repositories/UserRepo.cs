using Nafas.DAL.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;

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

                        int? id= (int)command.ExecuteScalar();
                        return id;

                    }
                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }

            return null;
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
                        command.Parameters.AddWithValue("@Passwordfdfd", user.Password);
                        command.Parameters.AddWithValue("@Email", user.Email);

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
    }
}
