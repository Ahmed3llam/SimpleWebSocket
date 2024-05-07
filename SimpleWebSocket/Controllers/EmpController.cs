using Microsoft.AspNetCore.Mvc;
using SimpleWebSocket.Models;

namespace SimpleWebSocket.Controllers
{
    public class EmpController : Controller
    {
        SignalRContext db;
        public EmpController(SignalRContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            List<Emp> emps = db.Emps.ToList();
            return View("Emps",emps);
        }

        public IActionResult AddEmp()
        {
            return View("AddEmp");
        }
    }
}
