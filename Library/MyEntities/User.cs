using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.MyEntities
{
    public class User
    {
        int id;
        string name;
        string password;
        List<MenuInfo> menuInfos = new List<MenuInfo>();
        List<UserInfo> userInfos = new List<UserInfo>();
        public User() {
        name = string.Empty;
        password = string.Empty;
        }
        public int Id { get { return id; } set {  id = value; } }
        public string Name { get { return name; } set { name = value; } }
        public string Password { get { return password; } set { password = value; } }

        public List<MenuInfo> MenuInfos { get {  return menuInfos; } set { menuInfos = value; } }
        public List<UserInfo> UserInfos { get { return userInfos; } set {  userInfos = value; } }
    }
}
