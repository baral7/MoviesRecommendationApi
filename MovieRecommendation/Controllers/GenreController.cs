using Microsoft.AspNetCore.Mvc;
using MovieRecommendation.Models;

namespace MovieRecommendation.Controllers
{
    public class GenreController : Controller
    {
        private readonly MoviesContext _context;
        public GenreController(MoviesContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("GetAllGenre")]
        public IEnumerable<Genre> GetGenre()
        {
            var data = _context.Genres.ToList();
            return data;
        }

        [HttpGet]
        [Route("GetSingleGenre/{id}")]
        public IEnumerable<Genre> GetSingleGenre(int id)
        {
            var result = _context.Genres.Where(x => x.Id == id).ToList();
            return result;
        }

        [HttpPost]
        [Route("CreateGenre")]
        public IActionResult CreateGenre(Genre genre)
        {
            if (genre != null)
            {
                _context.Genres.Add(genre);
                _context.SaveChanges();
                return RedirectToAction("GetGenre");

            }
            return RedirectToAction("GetGenre");
        }
        [HttpDelete]
        [Route("DeleteGenre/{id}")]
        public IActionResult DeleteGenre(int id)
        {
           // var genre = _context.Genres.FirstOrDefault(x => x.Id == id);
            var genre2 = _context.Genres.Where(x => x.Id == id).FirstOrDefault();
            if(genre2!= null)
            {
                _context.Genres.Remove(genre2);
                _context.SaveChanges();

                return RedirectToAction("GetGenre");
            }
            return RedirectToAction("GetGenre");
        }

        [HttpGet]
        [Route("editGenre/{id}")]
        public IActionResult editGenre(Genre genre)
        {
            var genrees = _context.Genres.Find(genre.Id);
            if (genrees!= null)
            {
                genrees.Name=genre.Name;
                _context.Genres.Update(genrees);
                _context.SaveChanges();
                return RedirectToAction("GetGenre");

            }

            return RedirectToAction("GetGenre");
        }


    }

}
