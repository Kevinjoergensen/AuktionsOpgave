using AuktionsOpgave.Models;
using AuktionsOpgave.Storage;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuktionsOpgave.Controllers
{
    public class HomeController : Controller
    {
        private AuctionContext db = new AuctionContext();
        private static int sellerid;
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Index(Person req)
        {
            var sel = db.People.Where(s => s.Email.Equals(req.Email) && s.Password.Equals(req.Password)).FirstOrDefault();

            if (sel != null)
            {
                sellerid = sel.Id;
                return RedirectToAction("Overview");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        public ActionResult Overview()
        {
            if(sellerid != 0)
            {
                List<Item> items = (from i in db.Items
                                    where i.Seller.Id == sellerid
                                    select i).ToList();
            return View(items);
            } else
            {
                return RedirectToAction("Index");
            }
        }
        
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Item req)
        {
            if(req != null)
            {
                Item item = req;
                item.Seller = db.People.Where(s => s.Id == sellerid).First();
                db.People.Attach(item.Seller);
                db.Items.Add(item);
                db.SaveChanges();
                return RedirectToAction("Overview");

            } else
            {
                return RedirectToAction("Create");
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}