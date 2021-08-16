using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using SimpleTelerikApp.Models;

namespace SimpleTelerikApp.Data
{
    public class FilmsInitializer : DropCreateDatabaseIfModelChanges<FilmsContext>
    {
        protected override void Seed(FilmsContext context)
        {
            var films = new List<Films>
            {
                new Films { Title = "IronMan", Description = "Pierwszy film o Iron Manie", Director = "Jon Favreau", ReleaseDate = DateTime.Parse("2008-04-14") },
                new Films { Title = "IronMan2", Description = "Drugi film o Iron Manie", Director = "Jon Favreau", ReleaseDate = DateTime.Parse("2010-04-26") },
                new Films { Title = "Jhon Wick", Description = "Film o Jhonie Wicku", Director = "David Leitch / Chad Stahelski", ReleaseDate = DateTime.Parse("2014-09-19") },
                new Films { Title = "Matrix", Description = "Pierwszy film Matrix", Director = "Lilly & Lana Wachowski", ReleaseDate = DateTime.Parse("2008-04-14") },
                new Films { Title = "Igrzyska śmierci: W pierścieniu ognia", Description = "Drugi film z serii Igrzysk Śmierci", Director = "Francis Lawrence", ReleaseDate = DateTime.Parse("2013-11-11") },
                new Films { Title = "Legion Samobójców", Description = "Film o złoczyńcach z DC", Director = "David Ayer", ReleaseDate = DateTime.Parse("2016-07-05") },
                new Films { Title = "After", Description = "Pierwszy film z serii After", Director = "Jenny Gage", ReleaseDate = DateTime.Parse("2019-04-11") },
                new Films { Title = "Obecność 3: Na rozkaz diabła", Description = "Trzeci film z serii Obecność", Director = "Michael Chaves", ReleaseDate = DateTime.Parse("2021-05-26") }
            };

            films.ForEach(s => context.Films.Add(s));
            context.SaveChanges();
        }
    }
}