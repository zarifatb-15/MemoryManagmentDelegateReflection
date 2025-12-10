using HomeWork.Models;
namespace HomeWork.Services;

public class AuthService
{
    private UserService _userService=new UserService();

    public AuthService()
    {
        
    }

    public void Register()
    {
        Console.Write("Ad: ");
        string name = Console.ReadLine();
        
        Console.Write("Soyad: ");
        string surname = Console.ReadLine();

        Console.Write("Username(3-16 simvol): ");
        string username=Console.ReadLine();
        
        Console.Write("Parol: ");
        string password = Console.ReadLine();

        if (username.Length < 3 || username.Length > 16)
        {   
            Console.WriteLine("Username simvol sayı doğru deyil!");
            return;
        }

        if (password.Length < 6 || password.Length > 16)
        {
            Console.WriteLine("Parol 6-16 simvol arası olmalıdır!");
            return;
        }

        if (!password.Any(char.IsUpper))
        {
            Console.WriteLine("Parolda ən az 1 böyük hərf olaamlıdır!");
            return;
        }

        if (!password.Any(char.IsLower))
        {
            Console.WriteLine("parolda ən az 1 kiçik hərf olmalıdı!");
            return;
        }

        if (!password.Any(char.IsDigit))
        {
            Console.WriteLine("Parolda ən az 1 rəqəm olamlıdır!");
            return;
        }

        if (_userService.GetByUsername(username) != null)
        {
            Console.WriteLine("Bu username artıq istifadə olunub!");
            return;
        }

        User newUser = new User
        {
            Name = name,
            Surname = surname,
            Username = username,
            Password = password
        };
        _userService.Add(newUser);
        
        Console.WriteLine("Qeydiyyat uğurla tamamlandı!");
    }
    

    public void Login()
    {
        Console.Write("Username: ");
        string username = Console.ReadLine();
        Console.Write("Password: ");
        string password = Console.ReadLine();
        
        User user = _userService.GetByUsername(username);
        if (user == null)
        {
            Console.WriteLine("Bu istifadəçi tapılmadı!");
            return;
        }
            
        if (user.Password != password)
        {
            Console.WriteLine("Parol yanlışdır!");
            return;
        }

        Console.WriteLine("Xoş gəldiniz {user.Name} {user.Surname}");
            
        
    }
}