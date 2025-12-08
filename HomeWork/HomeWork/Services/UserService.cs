using HomeWork.Models;
using HomeWork.Helpers;

namespace HomeWork.Services;

public class UserService
{
    private string path= "Database/Users.json";
    private List<User> users;

    public UserService()
    {
        users=JsonHelper<User>.Read(path);
    }
    
    
    private void Save()
    {
        JsonHelper<User>.Write(path, users);
    }
    
    public List<User> GetAll()=>users;

    public User? GetByUsername(string username)
    {
        return users.FirstOrDefault(x => x.Username == username);
    }

    public UserService()
    {
        users=JsonHelper<User>.Read(path);
         if 
    }
    
    
    
    
}