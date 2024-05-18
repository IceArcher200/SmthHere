using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace LibraryInterface.Classes
{
    public class DataGridWidget : DataGrid
    {
        bool isLocked = false;
        public DataGridWidget() { }
        public bool IsLocked { get { return isLocked; } set { isLocked = value; } }
    }
}
