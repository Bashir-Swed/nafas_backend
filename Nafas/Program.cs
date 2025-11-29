using Nafas.BLL.Services;
using Nafas.DAL.DTOs.Medical;
using Nafas.DAL.DTOs.User;
using Nafas.DAL.Repositories;
using System; 

public class main
{
    public static void Main(string[] args)
    {
        NewUserDTO user = new NewUserDTO();
        userService userService = new userService();
        /*Console.WriteLine("user name :");
        user.UserName = Console.ReadLine();
        Console.WriteLine("password :");
        user.Password = Console.ReadLine();
        Console.WriteLine("email : ");
        user.Email = Console.ReadLine();
        Console.WriteLine("first name :");
        user.FirstName = Console.ReadLine();
        Console.WriteLine("weight :");
        user.Weight=float.Parse(Console.ReadLine());
        Console.WriteLine("height");
        user.Height=int.Parse(Console.ReadLine());
        Console.WriteLine("age :");
        user.Age=int.Parse(Console.ReadLine());
        Console.WriteLine("gender is male  :");
        user.GenderIsMale=bool.Parse(Console.ReadLine());
        Console.WriteLine("is admin :");
        user.IsAdmin=bool.Parse(Console.ReadLine());
        Console.WriteLine(userService.AddNewUser(user));*/


        /*ChangePasswordDTO changePasswordDTO = new ChangePasswordDTO();
        Console.WriteLine("enter userId");
        changePasswordDTO.UserId=int.Parse(Console.ReadLine());
        Console.WriteLine("Enter oldpassword");
        changePasswordDTO.OldPassword = Console.ReadLine();
        Console.WriteLine("Enter newpassword");
        changePasswordDTO.NewPassword = Console.ReadLine();
        Console.WriteLine(userService.ChangePassword(changePasswordDTO));*/

        /*MedicalNotesDTO note = new MedicalNotesDTO();
        MedicalService medicalService = new MedicalService();
        Console.WriteLine("enter userId");
        note.UserId = int.Parse(Console.ReadLine());
        Console.WriteLine("enter notes");
        note.Notes = Console.ReadLine();
        Console.WriteLine(medicalService.AddMedicalNotes(note));*/

        /*UserDTO userDTO = new UserDTO();
        Console.WriteLine("enter usert id:");
        userDTO.UserID = int.Parse(Console.ReadLine());
        Console.WriteLine("enter username :");
        userDTO.UserName = Console.ReadLine();
        Console.WriteLine("enter password :");
        userDTO.Password = Console.ReadLine();
        Console.WriteLine("enter email :");
        userDTO.Email = Console.ReadLine();
        Console.WriteLine(userService.UpdateUserName(userDTO));*/

        /*Console.WriteLine("enter id");
        int x = int.Parse(Console.ReadLine());
        Console.WriteLine(userService.CheckUser(x));*/

        UserRepo userRepo = new UserRepo();
        Console.WriteLine(userRepo.CheckUserByID(1));
        string name = Console.ReadLine();
        string password= Console.ReadLine();
        Console.WriteLine(userRepo.CheckUserbyname(name));
        Console.WriteLine(userRepo.AddNewUser(user));
        Console.WriteLine(userRepo.CheckUserbynameandID(name,1));
        Console.WriteLine(userRepo.CheckUserbynameandPassword(name, password));
     

    }
}