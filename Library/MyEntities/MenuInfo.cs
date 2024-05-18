using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.MyEntities
{
    public class MenuInfo
    {
        int id;
        int parentId;
        string title;
        string nameOfFunc;
        List<User> users = new List<User>();
        List<UserInfo> userInfos = new List<UserInfo>();
        public MenuInfo()
        {
            title = string.Empty;
            nameOfFunc = string.Empty;
        }
        public int Id { get { return id; } set { id = value; } }
        public int ParentId { get { return parentId; } set { parentId = value; } }
        public string Title { get { return title; } set { title = value; } }
        public string NameOfFunc { get { return nameOfFunc; } set { nameOfFunc = value; } }
        public List<UserInfo> UserInfos { get {  return userInfos; } set {  userInfos = value; } }
        public List<User> Users { get { return users; } set { users = value; } }
    }
}
