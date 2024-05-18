using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.MyEntities
{
    
    public class Education
    {
        int id, documentIndex, institutionID;
        string level;
        Institution? institution;
        
        
        public Education()
        {
            level = string.Empty;
            
        }

        public int ID { get { return id; } set { id = value; } }
        public int InstitutionID { get { return institutionID; } set { institutionID = value; } }
        public int DocumentIndex { get { return documentIndex; } set { documentIndex = value; } }
        public string Level { get { return level; } set { level = value; } }
        public Institution? Institution { get { return institution; } set { institution = value; } }
        
    }
}
