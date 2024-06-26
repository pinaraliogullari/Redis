﻿using Microsoft.AspNetCore.Http;
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

		//[HttpGet("set/{name}")]
		//public void SetName(string name)
		//{
		//	_memoryCache.Set("name", name); 
		//}

		//[HttpGet]
		//public string GetName()
		//{
		//	//_memoryCache.Get("name"); //cachlenen veriyi okuma. sonuç object tipinde döner.
		//	//return _memoryCache.Get<string>("name"); //cachlenen veriyi okuma. sonuç generic olarak verilen tip türünde döner.

		//	//In memoryden çektiğimiz veriler üzerinde çeşitli çalışmalar yapabiliriz. Ancak uygulama kapandıktan sonra veriler bellekten silinir ve tekrar okumak istediğimizde veriye erişemez durumda oluruz , üzerinde gerçekleştireeğimiz işlem adımları sebebiyle de çalışma zamanı hataları alabiliriz. Bunu önlemek adına veriyi korunaklı bir şekilde elde etmek için aşağıdaki davranışı sergilemeliyiz. 
		//	if(_memoryCache.TryGetValue<string>("name", out string name))
		//		return name;

		//	return "";

		//}

		[HttpGet("setDate")]
		public void SetDate()
		{
			_memoryCache.Set<DateTime>("date", DateTime.Now, options: new()
			{
				AbsoluteExpiration = DateTime.Now.AddSeconds(30),
				SlidingExpiration=TimeSpan.FromSeconds(5)
			});
		}

		[HttpGet("getDate")]
		public DateTime GetDate()
		{
			return _memoryCache.Get<DateTime>("date");
		}
		
	}
}
