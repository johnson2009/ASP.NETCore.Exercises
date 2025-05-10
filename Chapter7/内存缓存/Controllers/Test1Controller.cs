using BookEFCore;
using Jx.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace 内存缓存.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class Test1Controller : ControllerBase
    {
        private readonly ILogger<Test1Controller> _logger;
        private readonly MyDbContext _myDbContext;
        private readonly IMemoryCache memCache;
        private readonly IMemoryCacheHelper _memoryCacheHelper;
        public Test1Controller(ILogger<Test1Controller> logger, MyDbContext myDbContext, IMemoryCache memCache, IMemoryCacheHelper memoryCacheHelper)
        {
            _logger = logger;
            _myDbContext = myDbContext;
            this.memCache = memCache;
            _memoryCacheHelper = memoryCacheHelper;
        }

        [HttpGet]
        public async Task<Book[]> GetBooks()
        {
            _logger.LogInformation("开始执行GetBooks方法");
            var items = await memCache.GetOrCreateAsync("AllBooks", async (e) =>
                {
                    e.SlidingExpiration = TimeSpan.FromSeconds(10);
                    
                    _logger.LogInformation("从数据库中获取数据");
                    return await _myDbContext.Books.ToArrayAsync();
                });
            _logger.LogInformation("获取到数据");
            return items;
        }

        [HttpGet]
        public async Task<Book[]> GetBooks2()
        {
            _logger.LogInformation("开始执行GetBooks2方法");
            var items = await _memoryCacheHelper.GetOrCreateAsync<Book[]>("AllBooks", async (e) =>
                {
                    _logger.LogInformation("从数据库中获取数据");
                    return await _myDbContext.Books.ToArrayAsync();
                });
            _logger.LogInformation("获取到数据");
            return items;
        }
    }
}
