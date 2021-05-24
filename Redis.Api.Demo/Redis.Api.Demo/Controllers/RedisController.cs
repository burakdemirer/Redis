using Microsoft.AspNetCore.Mvc;
using Redis.Api.Demo.Models;
using Redis.Api.Demo.Services.CacheService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Redis.Api.Demo.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class RedisController : ControllerBase
    {
        private readonly ICacheService _cacheService;
        public RedisController(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }

        [HttpGet]
        public async Task<IActionResult> GetSetCache()
        {
            var response =_cacheService.Add("name", "burak", DateTimeOffset.Now.AddMinutes(2));
            var result = await _cacheService.Get<string>("name");
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetSetObjectCache()
        {
            var student = new StudentDto
            {
                Id = 1,
                Name = "burak",
                ContactDetail = new ContactDetailDto
                {
                    Email = "burak@gmail.com",
                    Phone = "1234567890"
                }
            };

            var response = _cacheService.Add("my_student", student, DateTimeOffset.Now.AddHours(1));
            var result = await _cacheService.Get<StudentDto>("my_student");
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetSetMultiCache()
        {
            var contact1 = new ContactDetailDto
            {
                Email = "burak@gmail.com",
                Phone = "1234567890"
            };
            var contact2 = new ContactDetailDto
            {
                Email = "demo@gmail.com",
                Phone = "0987654321"
            };

            var items = new List<Tuple<string, ContactDetailDto>>();
            items.Add(new Tuple<string, ContactDetailDto>("contact_1", contact1));
            items.Add(new Tuple<string, ContactDetailDto>("contact_2", contact2));

            var response = await _cacheService.AddAll(items, DateTimeOffset.Now.AddHours(1));
            var result = await _cacheService.GetAll<ContactDetailDto>(new List<string> { "contact_1", "contact_2" });
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> SearchKeys(string pattern)
        {
            //("*") ("*con*") ("*contact*")
            var result = await _cacheService.Search(pattern);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Remove(string key)
        {
            var result = await _cacheService.Remove(key);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> RemoveMultiple(string pattern)
        {
            //("contact*")
            var allKeys = await _cacheService.Search(pattern);
            var result = await _cacheService.RemoveAll(allKeys);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Clear()
        {
            await _cacheService.Clear();
            return Ok();
        }

    }
}
