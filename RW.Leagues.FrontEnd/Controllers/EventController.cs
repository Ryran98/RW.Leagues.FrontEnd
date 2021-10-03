using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using RW.Leagues.FrontEnd.Models;
using RW.Leagues.FrontEnd.ViewModels.Event;

namespace RW.Leagues.FrontEnd.Controllers
{
    public class EventController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Event
        public async Task<ActionResult> Index()
        {
            List<Event> events = await db.Events.ToListAsync();
            events.ForEach(e => e.Type = db.EventTypes.Find(e.TypeId));

            return View(events);
        }

        // GET: Event/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Event @event = await db.Events.FindAsync(id);

            if (@event == null)
            {
                return HttpNotFound();
            }

            @event.Type = await db.EventTypes.FindAsync(@event.TypeId);
            @event.Entries = await db.Entries.Where(e => e.EventId == @event.Id).ToListAsync();

            List<AgeGroup> ageGroups = await db.AgeGroups.ToListAsync();

            ViewBag.PlayerId = new SelectList(db.Players, "Id", "FullName");
            ViewBag.AgeGroupId = new SelectList(ageGroups, "Id", "Name");

            Detail model = new Detail
            {
                Event = @event,
                AgeGroups = ageGroups
            };

            if (Session["EntriesAgeGroupTab"] == null)
                Session["EntriesAgeGroupTab"] = "U11";

            return View(model);
        }

        // GET: Event/Create
        public ActionResult Create()
        {
            ViewBag.TypeId = new SelectList(db.EventTypes, "Id", "Name");
            return View();
        }

        // POST: Event/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,TypeId")] Event @event)
        {
            if (ModelState.IsValid)
            {
                db.Events.Add(@event);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.TypeId = new SelectList(db.EventTypes, "Id", "Name", @event.TypeId);
            return View(@event);
        }

        // GET: Event/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Event @event = await db.Events.FindAsync(id);

            if (@event == null)
            {
                return HttpNotFound();
            }

            ViewBag.TypeId = new SelectList(db.EventTypes, "Id", "Name", @event.TypeId);
            return View(@event);
        }

        // POST: Event/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,TypeId")] Event @event)
        {
            if (ModelState.IsValid)
            {
                db.Entry(@event).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.TypeId = new SelectList(db.EventTypes, "Id", "Name", @event.TypeId);
            return View(@event);
        }

        // GET: Event/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Event @event = await db.Events.FindAsync(id);

            if (@event == null)
            {
                return HttpNotFound();
            }

            @event.Type = await db.EventTypes.FindAsync(@event.TypeId);

            return View(@event);
        }

        // POST: Event/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Event @event = await db.Events.FindAsync(id);
            db.Events.Remove(@event);
            await db.SaveChangesAsync();

            return RedirectToAction("Index");
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
