using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.MyEntities
{
    public class Archival_Vacancy
    {
        int id;
        int clientID;
        int workerID;
        int vacancyID;
        Client? client;
        Worker? worker;
        Vacancy? vacancy;
        DateTime date;

        public Archival_Vacancy()
        {
            
           //client = new Client();
           //worker = new Worker();
           //vacancy = new Vacancy();
           date = DateTime.Now;

        }

        public int ID { get { return id; } set { id = value; } }
        public Client? Client { get { return client; } set { client = value; } }
        public int ClientID { get { return clientID; } set { clientID = value; } }
        public Worker? Worker { get { return worker; } set { worker = value; } }
        public int WorkerID { get { return workerID; } set { workerID = value; } }
        public Vacancy? Vacancy { get { return vacancy; } set { vacancy = value; } }
        public int VacancyID { get { return vacancyID; } set { vacancyID = value; } }
        public DateTime Date { get { return date; } set { date = value; } }
    }
}
