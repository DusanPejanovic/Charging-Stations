using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
namespace Login
{
    public class User
    {
        private string username;
        private string password;
        private string role;

        public string Username
        {
            get => username;
            set => username = value ?? throw new ArgumentNullException(nameof(value));
        }

        public string Password
        {
            get => password;
            set => password = value ?? throw new ArgumentNullException(nameof(value));
        }
        public string Role
        {
            get => role;
            set => role = value ?? throw new ArgumentNullException(nameof(value));
        }

        public User (string username, string password, string role)
        {
            this.username = username;
            this.password = password;
            this.role = role;
        }
        public static User? Login(string username, string password)
        {
            List<User> users = User.Deserialize();
            foreach(User user in users)
            {
                if (user.username == username && user.password == password)
                {
                    return user;
                }
            }
            return null;
        }
        public static void Serialize(List<User> medications)
        {
            File.WriteAllText("../../Data/Users.json", JsonSerializer.Serialize(medications));
        }

        public static List<User> Deserialize()
        {
            string filepath = "../../Data/Users.json";
            string jsonText = File.ReadAllText(filepath);
            List<User> deserializedUsers= JsonSerializer.Deserialize<List<User>>(jsonText);
            return deserializedUsers;
        }
    }
}
