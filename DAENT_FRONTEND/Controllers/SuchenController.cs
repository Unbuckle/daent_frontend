using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAENT_FRONTEND.Models;

namespace DAENT_FRONTEND.Controllers
{
    public class SuchenController : Controller
    {
        private Model1 db = new Model1();

     

        // GET: Suchen/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Suchen/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "suchnr,searchstring")] suche suche)
        {
           string suchstring = suche.searchstring;


            
            return View("Index", db.artikel.Where(x => x.bezeichnung.Contains(suchstring)
                                             || x.artikelgruppen.grtext.Contains(suchstring)
                                           //  || x.aktiv.ToString().Contains(suchstring)
                                             || x.aktiv.ToString().Contains(suchstring)
                                           //  || x.lieferanten.firma1.Contains(searching)
                                             || x.vkpreis.ToString().Contains(suchstring)
                                             || x.ekpreis.ToString().Contains(suchstring)
                                             || x.lieferzeit.ToString().Contains(suchstring)
                                             || x.mindbestand.ToString().Contains(suchstring)
                                             || x.hinweis.Contains(suchstring)
                                             || x.mengebestellt.ToString().Contains(suchstring)
                                             || x.mwst.ToString().Contains(suchstring)
                                             || x.inaktivvon.ToString().Contains(suchstring)
                                             || x.inaktivam.ToString().Contains(suchstring)
                                             || suchstring == null).ToList());
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
