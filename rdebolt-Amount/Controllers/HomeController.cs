using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using rdebolt_Amount.Data;
using rdebolt_Amount.Models;

namespace rdebolt_Amount.Controllers
{
    public class HomeController : Controller
    {
        private AppDbContext db;

        public HomeController(AppDbContext context)
        {
            db = context;
        }
        
        // Get: /Index/
        public IActionResult Index()
        {
            return View(db.Loan.ToList());
            
            /*var loans = from item in db.Loans
                        where item.Id != null
                        select item;
            return View(loans);*/
        }
    }
}
