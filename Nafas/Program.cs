using Nafas.BLL.Services;
using Nafas.DAL.DTOs.User;
using System; 

public class main
{
    public static void Main(string[] args)
    {
        NewUserDTO user = new NewUserDTO();
        userService userService = new userService();
        Console.WriteLine("user name :");
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

        Console.WriteLine(userService.AddNewUser(user));

    }
}