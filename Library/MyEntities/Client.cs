using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.MyEntities
{
    public class Client
    {
        int id, age, experience, passport_number, educationID, streetID, specialtyID, payment, house;
        string name;
        string surname,passport_given_by;
        string? patronymic;
        DateOnly passport_receipt_date, register_date;
        Specialty? specialty;
        Education? education;
        Street? street;
        public Client() {
            
            name = string.Empty;
            surname = string.Empty;
            patronymic = string.Empty;
            passport_given_by = string.Empty;
            passport_receipt_date = new DateOnly();
            register_date = new DateOnly();
            //specialty = new Specialty();
            //education = new Education();
            //street = new Street();
        }

        public int ID { get { return id; } set { id = value; } }
        public int Age { get { return age; } set { age = value; } }
        public int Experience { get { return experience; } set { experience = value; } }
        public int Payment { get { return payment; } set { payment = value; } }
        public int House { get { return house; } set { house = value; } }
        public int Passport_Number { get { return passport_number; } set { passport_number = value; } }
        public int StreetID { get { return streetID; } set { streetID = value; } }
        public int SpecialtyID { get { return specialtyID; } set { specialtyID = value; } }
        public int EducationID { get { return educationID; } set { educationID = value; } }
        public string Name { get { return name; } set { name = value; } }
        public string Surname { get { return surname; } set { surname = value; } }
        public string? Patronymic { get { return patronymic; } set { patronymic = value; } }
        public string Passport_Given_By { get { return passport_given_by; } set { passport_given_by = value; } }
        public DateOnly Passport_Receipt_Date { get { return passport_receipt_date; } set { passport_receipt_date = value; } }
        public DateOnly Register_Date { get { return register_date; } set { register_date = value; } }
        public Specialty? Specialty { get { return specialty; } set { specialty = value; } }
        public Education? Education { get { return education; } set { education = value; } }
        public Street? Street { get { return street; } set { street = value; } }
    }
}
