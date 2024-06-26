﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Library.MyEntities
{
    public class Vacancy
    {
        int id, positionID, employerID, typeID;
        int? aproximate_salary, minAge, maxAge;
        VacancyType? type;
        Position? position;
        Employer? employer;
        string preferGender;
        public Vacancy()
        {
            preferGender = string.Empty;
            //type = string.Empty;
            //position = new Position();
            //employer = new Employer();
            
        }

        public int ID { get { return id; } set { id = value; } }
        public int? MinAge { get { return minAge; } set { minAge = value; } }
        public int? MaxAge { get { return maxAge; } set { maxAge = value; } }
        public string PreferGender { get { return preferGender; } set { preferGender = value; } }
        public int TypeID { get { return typeID; } set { typeID = value; } }
        public VacancyType? Type { get { return type; } set { type = value; } }
        public int? Salary { get { return aproximate_salary; } set { aproximate_salary = value; } }
        public Position? Position { get { return position; } set { position = value; } }
        public int PositionID { get { return positionID; } set { positionID = value; } }
        public Employer? Employer { get { return employer; } set { employer = value; } }
        public int EmployerID { get { return employerID; } set { employerID = value; } }
    }
}
