using Microsoft.AspNetCore.Mvc;
using MovieRecommendation.Models;

namespace MovieRecommendation.Controllers
{
    public class MoviesRecommendController : Controller
    {
        private readonly MoviesContext _context;
        public MoviesRecommendController(MoviesContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
            public ActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(movie);
                _context.SaveChanges();
                return RedirectToAction("Index");

            }
            return View();
        }
        public ActionResult GetAllMovie()
        {
            var result = _context.Movies.ToList();
            return View(result);
        }

        public ActionResult GetSingleMovie(int id)
        {
            var data = _context.Movies.Where(x => x.Id == id).ToList();
            return View(data);
        }
        //update
     //   public ActionResult updateMovie(int id)
       // {
        //    Movie movie = _context.Movies.Find(id);

       // }
     /*  public Movie edit(int id)
        {
            var data = _context.Movies.Where(x=>x.Id ==id).ToList();
            return data;
        }*/


        public void edit(int id)
        {
            var movie = _context.Movies.FirstOrDefault(x => x.Id == id);
            if(movie != null)
            {
                EditFinal(id,movie);
            }

        }
        public ActionResult EditFinal(int id, Movie movie)
        {
            if (ModelState.IsValid)
            {
                var movie2 = _context.Movies.FirstOrDefault(x => x.Id == id);
                movie2.Title = movie.Title;
                movie2.DirectedBy = movie.DirectedBy;
                movie2.Rating = movie.Rating;
                movie2.releaseDate = movie.releaseDate;
                movie2.GenreId = movie.GenreId;
                movie2.LeadActor = movie.LeadActor;
                _context.Update(movie2);
                _context.SaveChanges();

                return RedirectToAction("GetAllMovie");
            }
           return View();

        }

    }
}
