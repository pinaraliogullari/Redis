using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace InMemory.Caching.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ValuesController : ControllerBase
	{
		readonly IMemoryCache _memoryCache;

		public ValuesController(IMemoryCache memoryCache)
		{
			_memoryCache = memoryCache;
		}

		[HttpGet("set/{name}")]
		public void Set(string name)
		{
			_memoryCache.Set("name", name); //veri cachleme
		}

		[HttpGet]
		public string Get()
		{
			//_memoryCache.Get("name"); //cachlenen veriyi okuma. sonuç object tipinde döner.
			return _memoryCache.Get<string>("name"); //cachlenen veriyi okuma. sonuç generic olarak verilen tip türünde döner.
		}
		
	}
}
