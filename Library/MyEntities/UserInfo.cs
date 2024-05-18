using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.MyEntities
{
    public class UserInfo
    {
        int userId;
        User? user;
        int menuInfoId;
        MenuInfo? menuInfo;
        bool read = false;
        bool write = false;
        bool edit = false;
        bool delete = false;
        public UserInfo() { }
        public int UserId { get { return userId; } set { userId = value; } }
        public int MenuInfoId { get { return menuInfoId; } set { menuInfoId = value; } }

        public MenuInfo? MenuInfo { get {  return menuInfo; } set { menuInfo = value; } }

        public User? User { get { return user; } set {  user = value; } }
        public bool Read { get { return read; } set { read = value; } }
        public bool Write { get { return write; } set { write = value; } }
        public bool Edit { get { return edit; } set { edit = value; } }
        public bool Delete { get { return delete; } set { delete = value; } }

    }
}
