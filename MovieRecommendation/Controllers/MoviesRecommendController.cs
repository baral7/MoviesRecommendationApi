using Microsoft.AspNetCore.Mvc;
using MovieRecommendation.Models;
using Microsoft.AspNetCore.Http;

namespace MovieRecommendation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesRecommendController : Controller
    {
        private readonly MoviesContext _context;
        public MoviesRecommendController(MoviesContext context)
        {
            _context = context;
        }

        




       /* [HttpGet]
        [Route("GetAllMovie")]
        public IEnumerable<Movie> GetAllMovie()
        {
            var result = _context.Movies.ToList();
            return result;
        }*/

         [HttpGet]
        [Route("GetAllMovie")]
        public IEnumerable<Movie> GetAllMovie()
        {
            var result = _context.Movies.ToList();
            return result;
        }

        [HttpPost]
        [Route("CreateMovie")]
        public void Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(movie);
                _context.SaveChanges();
               // return RedirectToAction("GetAllMovie");

            }
           // return View();
        }


        [HttpGet]
        [Route("GetOneMovie /{id}")]
        public IEnumerable<Movie> GetSingleMovie(int id)
        {
            var data = _context.Movies.Where(x => x.Id == id).ToList();
            return data;
        }



        [HttpGet]
        [Route("editMovie/{id}")]
        public void edit(int id)
        {
            var movie = _context.Movies.FirstOrDefault(x => x.Id == id);
            if(movie != null)
            {
                EditFinal(id,movie);
            }

        }

        [HttpPost]
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

        [HttpDelete]
        [Route("RemoveMovie/{id}")]
        public ActionResult removeMovie(int id)
        {
            var movie = _context.Movies.Find(id);
           // var movie = _context.Movies.FirstOrDefault(x => x.Id==id);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
                _context.SaveChanges();
                return RedirectToAction("GetAllMovie");
            }
            else
            {
                return RedirectToAction("GetAllMovie");
            }

        }

    }
}
