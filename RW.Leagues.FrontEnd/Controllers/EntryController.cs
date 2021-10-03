using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using RW.Leagues.FrontEnd.Models;

namespace RW.Leagues.FrontEnd.Controllers
{
    public class EntryController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [HttpPost]
        public async Task<ActionResult> Create([Bind(Include = "PlayerId,EventId,AgeGroupId")] Entry entry)
        {
            if (ModelState.IsValid)
            {
                db.Entries.Add(entry);
                await db.SaveChangesAsync();
            }

            return RedirectToAction("Details", "Event", new { @id = entry.EventId });
        }

        [HttpPost]
        public async Task<ActionResult> Delete([Bind(Include = "Id")] Entry entry)
        {
            entry = await db.Entries.FindAsync(entry.Id);

            if (entry == null)
                return HttpNotFound();

            db.Entries.Remove(entry);
            await db.SaveChangesAsync();

            return RedirectToAction("Details", "Event", new { @id = entry.EventId });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
