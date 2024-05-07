using Microsoft.AspNetCore.SignalR;
using SimpleWebSocket.Models;

namespace SimpleWebSocket.Hubs
{
    public class EmpsHub:Hub
    {
        SignalRContext db;
        public EmpsHub(SignalRContext db)
        {
            this.db = db;
        }
        public void addemp(Emp emp)
        {
            Clients.All.SendAsync("newemp", emp);
            db.Emps.Add(emp);
            db.SaveChanges();
        }
    }
}
