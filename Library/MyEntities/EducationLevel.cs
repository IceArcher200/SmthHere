﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.MyEntities
{
    public class EducationLevel
    {
        int id;
        string name;

        public EducationLevel()
        {
            name = string.Empty;
        }

        public int ID { get { return id; } set { id = value; } }
        public string Name { get { return name; } set { name = value; } }
    }
}
