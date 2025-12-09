using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab_02.Data;
using Lab_02.Models;

namespace Lab_02.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MoviesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // HÀM HỖ TRỢ: Lấy danh sách Category và đưa vào ViewBag
        private void PopulateCategoriesDropDownList(object? selectedCategory = null)
        {
            var categoriesQuery = from c in _context.Categories
                                  orderby c.Name
                                  select c;

            // ViewBag sẽ được sử dụng trong Create.cshtml và Edit.cshtml
            ViewBag.CategoryId = new SelectList(categoriesQuery.AsNoTracking(),
                "Id", "Name", selectedCategory);
        }

        // GET: Movies (Đã thêm Include Category cho hiển thị)
        public async Task<IActionResult> Index(string movieGenre, string searchString)
        {
            IQueryable<string> genreQuery = from m in _context.Movie orderby m.Genre select m.Genre;

            // Lấy Movie và cả Category của nó
            var movies = from m in _context.Movie.Include(m => m.Category) select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.Title!.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(movieGenre))
            {
                movies = movies.Where(x => x.Genre == movieGenre);
            }

            var movieGenreVM = new MovieGenreViewModel
            {
                Genres = new SelectList(await genreQuery.Distinct().ToListAsync()),
                Movies = await movies.ToListAsync()
            };

            return View(movieGenreVM);
        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Movie == null) return NotFound();

            var movie = await _context.Movie
                .Include(m => m.Category)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (movie == null) return NotFound();

            return View(movie);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            PopulateCategoriesDropDownList();
            return View();
        }

        // POST: Movies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "<Pending>")]
        public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Genre,Price,Rating,CategoryId")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            PopulateCategoriesDropDownList(movie.CategoryId);
            return View(movie);
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var movie = await _context.Movie.FindAsync(id);
            if (movie == null) return NotFound();

            PopulateCategoriesDropDownList(movie.CategoryId);
            return View(movie);
        }

        // POST: Movies/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "<Pending>")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Genre,Price,Rating,CategoryId")] Movie movie)
        {
            if (id != movie.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            PopulateCategoriesDropDownList(movie.CategoryId);
            return View(movie);
        }

        // Các hàm khác giữ nguyên...
    }
}