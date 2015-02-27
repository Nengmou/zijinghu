using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ZiJingHu.Models;
using PagedList;

namespace ZiJingHu.Controllers
{
    public class ClientController : Controller
    {
        private ZiJingHuContext db = new ZiJingHuContext();

        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            //search
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var clients = from c in db.Clients
                          select c;

            if (!String.IsNullOrEmpty(searchString))
            {
                clients = clients.Where(o => o.Name.Contains(searchString));
            }

            //sort
            ViewBag.CurrentSort = sortOrder;
            ViewBag.ClientNameSortParm = (String.IsNullOrEmpty(sortOrder) || sortOrder == "client_name_desc") ? "client_name_desc" : "client_name";
            ViewBag.ProductNameSortParm = sortOrder == "pruduct_name" ? "pruduct_name_desc" : "pruduct_name";

            switch (sortOrder)
            {
                case "pruduct_name":
                    clients = clients.OrderBy(c => c.ProductId);
                    break;
                case "pruduct_name_desc":
                    clients = clients.OrderByDescending(c => c.ProductId);
                    break;
                case "client_name":
                    clients = clients.OrderBy(c => c.Name);
                    break;
                case "client_name_desc":
                    clients = clients.OrderByDescending(c => c.Name);
                    break;
                default:
                    clients = clients.OrderBy(c => c.Sequence);
                    break;
            }

            //page list
            int pageSize = int.Parse(System.Configuration.ConfigurationManager.AppSettings["PageSize"]);
            int pageNumber = (page ?? 1);
            return View(clients.ToPagedList(pageNumber, pageSize));
        }

        // GET: /Client/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // GET: /Client/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name");
            return View();
        }

        // POST: /Client/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "Id,Name,HeadQuarter,Description,Feedback,ImageName,ProductId,Sequence")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Clients.Add(client);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", client.ProductId);
            return View(client);
        }

        // GET: /Client/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", client.ProductId);
            return View(client);
        }

        // POST: /Client/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "Id,Name,HeadQuarter,Description,Feedback,ImageName,ProductId,Sequence")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Entry(client).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", client.ProductId);
            return View(client);
        }

        // GET: /Client/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: /Client/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            Client client = db.Clients.Find(id);
            db.Clients.Remove(client);
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
