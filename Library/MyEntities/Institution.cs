using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.MyEntities
{
    public class Institution
    {
        int id;
        string name;

        public Institution()
        {
            name = string.Empty;
        }

        public int ID { get { return id; } set { id = value; } }
        public string Name { get { return name; } set { name = value; } }
    }
}
