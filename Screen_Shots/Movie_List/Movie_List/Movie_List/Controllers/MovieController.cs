using Microsoft.AspNetCore.Mvc;
using Movie_List.Models;
namespace Movie_List.Controllers
{
    public class MovieController : Controller
    {
        private MovieContext context { get; set; }
        public MovieController(MovieContext ctx)
        {
            context = ctx;
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Genres = context.Genres.OrderBy(g => g.Name).ToList();
            var movie = new Movie();
            return View("Edit", movie);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Genres = context.Genres.OrderBy(g => g.Name).ToList();
            var movie = context.Movies
                .Find(id);
            return View(movie);
        }
        [HttpPost]
        public IActionResult Edit(Movie movie)
        {
            if (string.IsNullOrEmpty(movie.GenreId))
            {
                ModelState.AddModelError("GenreId", "Please select a genre.");
            }

            if (ModelState.IsValid)
            {
                if (movie.MovieId == 0)
                {
                    context.Movies.Add(movie);
                }
                else
                {
                    context.Movies.Update(movie);
                }
                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Action = (movie.MovieId == 0) ? "Add" : "Edit";
            ViewBag.Genres = context.Genres.OrderBy(g => g.Name).ToList();
            return View(movie);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var movie = context.Movies.Find(id);
            return View(movie);
        }
        [HttpPost]
        public IActionResult Delete(Movie movie)
        {
            context.Movies.Remove(movie);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}