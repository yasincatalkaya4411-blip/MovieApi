using Microsoft.AspNetCore.Mvc;
using MovieApi.Dto.Dtos.MovieDtos;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Movie.Api.WebUI.Controllers
{
    public class MovieController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;

        public MovieController(IHttpClientFactory httpClientFactory, IConfiguration configuration, IWebHostEnvironment env)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _env = env;
        }

        public async Task<IActionResult> MovieList()
        {
            ViewBag.V1 = "Film Listesi";
            ViewBag.V2 = "Ana Sayfa";
            ViewBag.V3 = "Tüm Filmler";
            ViewBag.ApiError = (string?)null;

            try
            {
                var client = _httpClientFactory.CreateClient("MovieApi");
                var responseMessage = await client.GetAsync("/api/Movies");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsondata = await responseMessage.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<List<ResultMovieDto>>(jsondata) ?? new List<ResultMovieDto>();
                    for (var i = 0; i < values.Count; i++)
                    {
                        string dosyaYolu = Path.Combine(
                            _env.WebRootPath,
                            "Film-Review-Movie-Database",
                            "images",
                            "uploads",
                            values[i].CoverImageUrl
                        );

                        if (!System.IO.File.Exists(dosyaYolu))
                        {
                            values[i].CoverImageUrl = "default-movie.jpg";
                        }
                    }
                    return View(values);
                }
            }
            catch (Exception ex)
            {
                ViewBag.ApiError = $"API'ye bağlanılamadı. Lütfen MovieApi.WebApi projesinin çalıştığından emin olun. (Hata: {ex.Message})";
            }

            return View(new List<ResultMovieDto>());
        }

        [HttpPost]
        public async Task<IActionResult> RemoveDuplicates()
        {
            try
            {
                var client = _httpClientFactory.CreateClient("MovieApi");
                var response = await client.GetAsync("/api/Movies");
                if (!response.IsSuccessStatusCode)
                {
                    TempData["ImportError"] = "Film listesi alınamadı. API'nin çalıştığından emin olun.";
                    return RedirectToAction(nameof(MovieList));
                }

                var jsonData = await response.Content.ReadAsStringAsync();
                var allMovies = JsonConvert.DeserializeObject<List<ResultMovieDto>>(jsonData) ?? new List<ResultMovieDto>();
                var groups = allMovies
                    .GroupBy(m => new { m.Title, m.CreatedYear })
                    .Where(g => g.Count() > 1)
                    .ToList();

                var deleted = 0;
                foreach (var group in groups)
                {
                    var toDelete = group.OrderBy(m => m.MovieId).Skip(1).ToList();
                    foreach (var movie in toDelete)
                    {
                        try
                        {
                            var deleteResponse = await client.DeleteAsync($"/api/Movies?id={movie.MovieId}");
                            if (deleteResponse.IsSuccessStatusCode) deleted++;
                        }
                        catch { }
                    }
                }

                TempData["ImportSuccess"] = $"{deleted} tekrarlayan film silindi.";
            }
            catch (Exception ex)
            {
                TempData["ImportError"] = $"Tekrarları silme hatası: {ex.Message}";
            }

            return RedirectToAction(nameof(MovieList));
        }

        [HttpPost]
        public async Task<IActionResult> ImportMovies()
        {
            ViewBag.ImportResult = "";
            var imported = 0;
            var failed = 0;

            try
            {
                var allMovies = new List<CreateMovieDto>();
                var moviePath = Path.Combine(_env.ContentRootPath, "requirements", "MovieChatGptJsonExample.txt");
                var seriesPath = Path.Combine(_env.ContentRootPath, "requirements", "SeriesChatGptJsonExample.txt");

                if (System.IO.File.Exists(moviePath))
                {
                    var movieContent = await System.IO.File.ReadAllTextAsync(moviePath);
                    var movies = JsonConvert.DeserializeObject<List<CreateMovieDto>>(movieContent);
                    if (movies != null) allMovies.AddRange(movies);
                }

                if (System.IO.File.Exists(seriesPath))
                {
                    var seriesContent = await System.IO.File.ReadAllTextAsync(seriesPath);
                    var series = JsonConvert.DeserializeObject<List<CreateMovieDto>>(seriesContent);
                    if (series != null) allMovies.AddRange(series);
                }

                if (allMovies.Count == 0)
                {
                    TempData["ImportError"] = "Film veya dizi dosyası bulunamadı veya boş.";
                    return RedirectToAction(nameof(MovieList));
                }

                var client = _httpClientFactory.CreateClient("MovieApi");
                foreach (var movie in allMovies)
                {
                    try
                    {
                        var content = new StringContent(JsonConvert.SerializeObject(movie), System.Text.Encoding.UTF8, "application/json");
                        var response = await client.PostAsync("/api/Movies", content);
                        if (response.IsSuccessStatusCode)
                            imported++;
                        else
                            failed++;
                    }
                    catch { failed++; }
                }

                TempData["ImportSuccess"] = $"{imported} film veritabanına eklendi. Başarısız: {failed}";
            }
            catch (Exception ex)
            {
                TempData["ImportError"] = $"İçe aktarma hatası: {ex.Message}. API'nin çalıştığından emin olun.";
            }

            return RedirectToAction(nameof(MovieList));
        }
        public async Task<IActionResult> MovieDetail(int id)
        {
            id = 0;
            return View();
        }
    }
}