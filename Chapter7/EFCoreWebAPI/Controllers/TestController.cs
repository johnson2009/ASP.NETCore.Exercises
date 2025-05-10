using BookEFCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly MyDbContext _context;
        public TestController(MyDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Index()
        {
            _context.Add(new Book { Id = Guid.NewGuid(), Name = "零基础趣学C语言", Price = 59 });
            await _context.SaveChangesAsync();
            var book = _context.Books.First();
            return Content(book.ToString());
        }
    }
}
