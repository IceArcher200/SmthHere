using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.MyEntities
{
    public class Employer
    {
        int id, phone, house, streetID;
        string name;
        Street? street;
        //List<Vacancy> vacancy = new List<Vacancy>();

        public Employer()
        {
            name = string.Empty;
            //street = new Street();
        }

        public int ID { get { return id; } set { id = value; } }
        public int StreetID { get { return streetID; } set { streetID = value; } }
        public int Phone { get { return phone; } set { phone = value; } }
        public int House { get { return house; } set { house = value; } }
        public string Name { get { return name; } set { name = value; } }
        public Street? Street { get { return street; } set { street = value; } }
        //public List<Vacancy> Vacancy { get { return vacancy; } set { vacancy = value; } }
    }
}
