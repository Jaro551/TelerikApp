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
        public ActionResult Index([DataSourceRequest] DataSourceRequest request)
        {
            return View();
        }

        public ActionResult Films_Read([DataSourceRequest] DataSourceRequest request)
        {
            using (var db = new FilmsDataBase2Entities())
            {
                var films = db.Films;
                DataSourceResult result = films.ToDataSourceResult(request);
                return Json(result);
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Films_Create([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models[0]")]Films film)
        {
            if (ModelState.IsValid)
            {
                using (var db = new FilmsDataBase2Entities())
                {
                    var entity = new Films
                    {
                        Title = film.Title,
                        Description = film.Description,
                        Director = film.Director,
                        ReleaseDate = film.ReleaseDate
                    };
                    db.Films.Add(entity);
                    db.SaveChanges();
                    film.ID = entity.ID;
                }
            }
            return Json(new[] { film }.ToDataSourceResult(request, ModelState));
        }



        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Films_Update([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models[0]")]Films film)
        {
            if (film.Title.Length < 3)
            {
                ModelState.AddModelError("Title", "Title should be at least three characters long.");
            }
            if (ModelState.IsValid)
            {
                using (var db = new FilmsDataBase2Entities())
                {
                    var updatedfilm = new Films
                    {
                        ID = film.ID,
                        Title = film.Title,
                        Description = film.Description,
                        Director = film.Director,
                        ReleaseDate = film.ReleaseDate
                    };
                    db.Films.Attach(updatedfilm);
                    db.Entry(updatedfilm).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            return Json(new[] { film }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Films_Destroy([DataSourceRequest] DataSourceRequest request, [Bind(Prefix ="models[0]")]Films film)
        {
            if (ModelState.IsValid)
            {
                using (var db = new FilmsDataBase2Entities())
                {
                    db.Films.Attach(film);
                    db.Films.Remove(film);
                    db.SaveChanges();
                }
            }
            return Json(new[] { film }.ToDataSourceResult(request, ModelState));
        }
    }
}
