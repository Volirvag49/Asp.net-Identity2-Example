﻿//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Entity;
//using System.Linq;
//using System.Threading.Tasks;
//using System.Net;
//using System.Web;
//using System.Web.Mvc;
//using Identity2Example.Models;

//namespace Identity2Example.Controllers
//{
//    public class ApplicationUsersController : Controller
//    {
//        private ApplicationDbContext db = new ApplicationDbContext();

//        // GET: ApplicationUsers
//        public async Task<ActionResult> Index()
//        {
//            return View(await db.ApplicationUsers.ToListAsync());
//        }

//        // GET: ApplicationUsers/Details/5
//        public async Task<ActionResult> Details(string id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            ApplicationUser applicationUser = await db.ApplicationUsers.FindAsync(id);
//            if (applicationUser == null)
//            {
//                return HttpNotFound();
//            }
//            return View(applicationUser);
//        }

//        // GET: ApplicationUsers/Create
//        public ActionResult Create()
//        {
//            return View();
//        }

//        // POST: ApplicationUsers/Create
//        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
//        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<ActionResult> Create([Bind(Include = "Id,FirstName,LastName,Gender,About,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName")] ApplicationUser applicationUser)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Users.Add(applicationUser);
//                await db.SaveChangesAsync();
//                return RedirectToAction("Index");
//            }

//            return View(applicationUser);
//        }

//        // GET: ApplicationUsers/Edit/5
//        public async Task<ActionResult> Edit(string id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            ApplicationUser applicationUser = await db.ApplicationUsers.FindAsync(id);
//            if (applicationUser == null)
//            {
//                return HttpNotFound();
//            }
//            return View(applicationUser);
//        }

//        // POST: ApplicationUsers/Edit/5
//        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
//        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<ActionResult> Edit([Bind(Include = "Id,FirstName,LastName,Gender,About,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName")] ApplicationUser applicationUser)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Entry(applicationUser).State = EntityState.Modified;
//                await db.SaveChangesAsync();
//                return RedirectToAction("Index");
//            }
//            return View(applicationUser);
//        }

//        // GET: ApplicationUsers/Delete/5
//        public async Task<ActionResult> Delete(string id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            ApplicationUser applicationUser = await db.ApplicationUsers.FindAsync(id);
//            if (applicationUser == null)
//            {
//                return HttpNotFound();
//            }
//            return View(applicationUser);
//        }

//        // POST: ApplicationUsers/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<ActionResult> DeleteConfirmed(string id)
//        {
//            ApplicationUser applicationUser = await db.ApplicationUsers.FindAsync(id);
//            db.ApplicationUsers.Remove(applicationUser);
//            await db.SaveChangesAsync();
//            return RedirectToAction("Index");
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }
//    }
//}
