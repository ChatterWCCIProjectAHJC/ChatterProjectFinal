using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ChatterProjects.Models;

namespace ChatterProjects.Controllers
{
    [Authorize]
    public class ChatModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ChatModels
        public ActionResult Index()
        {
            return View(db.ChatModels.ToList());
        }

        // GET: ChatModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChatModels chatModels = db.ChatModels.Find(id);
            if (chatModels == null)
            {
                return HttpNotFound();
            }
            return View(chatModels);
        }

        // GET: ChatModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ChatModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ChatID,ChatInput,ChatDate,Email")] ChatModels chatModels)
        {
            if (ModelState.IsValid)
            {
                db.ChatModels.Add(chatModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(chatModels);
        }

        // GET: ChatModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (db.ChatModels.Find(id).Email!=User.Identity.Name.ToString())
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChatModels chatModels = db.ChatModels.Find(id);
            if (chatModels == null)
            {
                return HttpNotFound();
            }
            return View(chatModels);
        }

        // POST: ChatModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ChatID,ChatInput,ChatDate,Email")] ChatModels chatModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chatModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(chatModels);
        }

        // GET: ChatModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChatModels chatModels = db.ChatModels.Find(id);
            if (chatModels == null)
            {
                return HttpNotFound();
            }
            return View(chatModels);
        }

        // POST: ChatModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChatModels chatModels = db.ChatModels.Find(id);
            db.ChatModels.Remove(chatModels);
            db.SaveChanges();
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
