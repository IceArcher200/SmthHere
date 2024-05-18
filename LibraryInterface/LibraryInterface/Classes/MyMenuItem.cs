using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace LibraryInterface.Classes
{
    internal class MyMenuItem : MenuItem
    {
        int id;
        public MyMenuItem()
        {

        }
        public int Id { get { return id; } set { id = value; } }
    }
}
