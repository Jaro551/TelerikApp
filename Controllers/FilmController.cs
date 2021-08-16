using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using SimpleTelerikApp.Data;
using SimpleTelerikApp.Models;

namespace SimpleTelerikApp.Controllers
{
    public class FilmController : Controller
    {
        private FilmsContext db = new FilmsContext();

        // GET: Film
        public ActionResult Index([DataSourceRequest] DataSourceRequest request)
        {
            var films = db.Films;
            DataSourceResult result = films.ToDataSourceResult(request);
            return Json(result);
            //return View(db.Films.ToList());
        }

        // GET: Film/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Films films = db.Films.Find(id);
            if (films == null)
            {
                return HttpNotFound();
            }
            return View(films);
        }

        // GET: Film/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Film/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Title,Description,Director,ReleaseDate")] Films films)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Films.Add(films);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Nie można zapisać zmian. Spróbuj ponownie.");
            }

            return View(films);
        }

        // GET: Film/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Films films = db.Films.Find(id);
            if (films == null)
            {
                return HttpNotFound();
            }
            return View(films);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Update ([DataSourceRequest]DataSourceRequest request, Films film)
        {
            if (ModelState.IsValid)
            {
                var updatedfilm = new Films
                {
                    Title = film.Title,
                    Description = film.Description,
                    Director = film.Director,
                    ReleaseDate = film.ReleaseDate
                };
                db.Films.Attach(updatedfilm);
                db.Entry(updatedfilm).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return Json(new[] { film }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Destroy([DataSourceRequest] DataSourceRequest request, Films film)
        {
            if (ModelState.IsValid)
            {
                var entity = new Films
                {
                    Title = film.Title,
                    Description = film.Description,
                    Director = film.Director,
                    ReleaseDate = film.ReleaseDate
                };

                db.Films.Attach(entity);
                db.Films.Remove(entity);
                db.SaveChanges();
            }
            return Json(new[] { film }.ToDataSourceResult(request, ModelState));
        }
        /*[HttpPost]
        public ActionResult Edit([DataSourceRequest]DataSourceRequest request, Films film)
        {
            if(film != null && ModelState.IsValid)
            {

            }
        }*/

        // POST: Film/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        /*[HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditFilm(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var filmToUpdate = db.Films.Find(id);
            if(TryUpdateModel(filmToUpdate, "", new string[] { "Title", "Description", "Director", "ReleaseDate"}))
            {
                try
                {
                    db.SaveChanges();
                    return RedirectToAction("Home", "Index");
                }
                catch (DataException)
                {
                    ModelState.AddModelError("", "Nie można zapisać zmian. Spróbuj ponownie");
                }
            }
            return View(filmToUpdate);
            *//*if (ModelState.IsValid)
            {
                db.Entry(films).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(films);
        }*/

        // GET: Film/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Films films = db.Films.Find(id);
            if (films == null)
            {
                return HttpNotFound();
            }
            return View(films);
        }

        // POST: Film/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            Films films = db.Films.Find(id);
            db.Films.Remove(films);
            db.SaveChanges();
            var result = db.Films.ToList();
            
            return RedirectToAction("Index", "Home");
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
