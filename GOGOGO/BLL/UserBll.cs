using System.Collections.Generic;
using System.Linq;
using System.Web;
using GOGOGO.Commons;
using Newtonsoft.Json;

namespace GOGOGO.BLL
{
    public static class UserBll
    {
        public static string AddUser(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName))
            {
                return "用户名不能为空";
            }
            if (string.IsNullOrEmpty(password))
            {
                return "密码不能为空";
            }
            var users  = GetUsers();
            if (users.Any(x => x.UserName == userName))
            {
                return "用户已存在";
            }
            users.Add(new User{UserName = userName, Password = password});
            FileHelper.WriteNew(JsonConvert.SerializeObject(users),"user");
            return "注册成功";

        }

        public static List<User> GetUsers()
        {
            var users = JsonConvert.DeserializeObject<List<User>>(FileHelper.Read("user"));
            if (users == null || users.Count <= 0)
            {
                users = new List<User>();
            }
            return users;
        }

    }

    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}