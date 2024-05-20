using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.MyEntities
{
    public class Worker
    {
        int id;
        string name, surname, patronymic;

        public Worker()
        {
            
            name = string.Empty;
            surname = string.Empty;
            patronymic = string.Empty;
            
        }

        public int ID { get { return id; } set { id = value; } }
        public string Name { get { return name; } set { name = value; } }
        public string Surname { get { return surname; } set { surname = value; } }
        public string Patronymic { get { return patronymic; } set { patronymic = value; } }
        public string FullName { get { return Surname + " " + Name + " " + Patronymic; } }
    }
}
