using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using SignalRExample.WebUI.Dtos.CategoryDtos;
using SignalRExample.WebUI.Dtos.ProductDtos;
using System.Text;

namespace SignalRExample.WebUI.Controllers
{
	public class AdminProductController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public AdminProductController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7030/api/Product/ProductListWithCategory");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<ICollection<ResultProductDtos>>(jsonData);
				return View(values);
			}
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> Create()
		{
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7030/api/Category/GetAll");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<ICollection<ResultCategoryDtos>>(jsonData);
            ICollection<SelectListItem> categories = (from x in values
                                            select new SelectListItem
                                            {
                                                Text = x.Name,
                                                Value = x.Id.ToString()
                                            }).ToList();
            ViewBag.v = categories;
			return View();
        }

		[HttpPost]
		public async Task<IActionResult> Create(CreateProductDtos createProductDtos)
		{
            createProductDtos.Status = true;
            var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createProductDtos);
			StringContent stringContent = new(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:7030/api/Product/Create", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}

		public async Task<IActionResult> Delete(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"https://localhost:7030/api/Product/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				return View();
			}
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> Update(int id)
		{
            var client1 = _httpClientFactory.CreateClient();
            var responseMessage1 = await client1.GetAsync("https://localhost:7030/api/Category/GetAll");
            var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
            var values1 = JsonConvert.DeserializeObject<ICollection<ResultCategoryDtos>>(jsonData1);
            ICollection<SelectListItem> categories = (from x in values1
                                            select new SelectListItem
                                            {
                                                Text = x.Name,
                                                Value = x.Id.ToString()
                                            }).ToList();
            ViewBag.v = categories;

            var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7030/api/Product/GetById/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var value = JsonConvert.DeserializeObject<UpdateProductDtos>(jsonData);
				return View(value);
			}
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Update(UpdateProductDtos updateProductDtos)
		{
            updateProductDtos.Status = true;
            var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updateProductDtos);
			StringContent stringContent = new(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("https://localhost:7030/api/Product/Update", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
	}
}
