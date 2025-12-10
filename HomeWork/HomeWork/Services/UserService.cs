using HomeWork.Helpers;
using HomeWork.Models;

namespace HomeWork.Services
{
    public class UserService
    {
        private string path = "Database/Users.json";
        private List<User> users;

        public UserService()
        {
            users = JsonHelper<User>.Read(path);

            if (users.Count == 0)
            {
                users.Add(new User
                {
                    Id = 1,
                    Name = "Super",
                    Surname = "Admin",
                    Username = "admin",
                    Password = "Admin123",
                    Role = UserRole.Admin
                });

                Save();
            }
        }

        private void Save()
        {
            JsonHelper<User>.Write(path, users);
        }

        public List<User> GetAll() => users;

        public User? GetByUsername(string username)
        {
            return users.FirstOrDefault(x => x.Username == username);
        }

        public void Add(User user)
        {
            user.Id=users.Count==0?1:users.Max(x => x.Id) + 1;
            users.Add(user);
            Save();
        }
        
        
    }
}