using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using rdebolt_Amount.Data;
using rdebolt_Amount.Models;

namespace rdebolt_Amount.Controllers
{
    public class LoanController : Controller
    {
        private readonly AppDbContext db;

        public LoanController(AppDbContext context)
        {
            db = context;
        }

        public ActionResult Index(double searchAmt)
        {
            if (!(searchAmt <= 0 || searchAmt == null))
            {
                var searchRes = db.Loan.Where(x => x.amount.Equals(searchAmt)).ToList();
                if(searchRes.Count <= 0)
                {
                    return View(db.Loan.ToList());
                }
                else
                {
                    return View(searchRes);
                }
            }
            return View(db.Loan.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Amount,Apr,Duration")] Business business)
        {
            if (ModelState.IsValid)
            {
                db.Add(business);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(business);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loan = db.Loan.Find(id);
            if (loan == null)
            {
                return NotFound();
            }

            return View(loan);
        }

        // POST: Demographic/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var loan = db.Loan.Find(id);
            db.Loan.Remove(loan);
            db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public ActionResult GetBusinessId(int id)
        {
            var businessId = db.Businesses.Where(x => x.Loan_Id == id);
            return View(businessId);

        }
        public ActionResult Edit(int id)
        {
            var loan = db.Loan.Where(x => x.Id == id).FirstOrDefault();
            return View(loan);
        }

        [HttpPost]
        public ActionResult Edit(Loan std)
        {
            var amount = std.amount;
            var age = std.apr;
            var duration = std.duration;

            return RedirectToAction("Index");
        }
    }
}
