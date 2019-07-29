using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RefreshTokenWebApi.Data;
using RefreshTokenWebApi.Models;

namespace RefreshTokenWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class ValuesController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public ValuesController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetPersonalList()
        {
            var personalData = _dataContext.Personals.ToList();

             return  Ok(personalData);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPErsonalById(int id)
        {
            var data = _dataContext.Personals.FirstOrDefault(x => x.Id == id);
            return Ok(data);
        }
    
        [HttpPost]
        public async Task<IActionResult> AddPErsonal(Personal personal)
        {
             _dataContext.Personals.Add(personal);
              _dataContext.SaveChanges();

            return Ok();
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> UpdatePersonal(int id,Personal personal)
        {
            var data = _dataContext.Personals.FirstOrDefault(x => x.Id == id);
            data.Name = personal.Name;
            data.Surname = personal.Surname;
            data.PhoneNumber = personal.PhoneNumber;
            data.BrithDate = personal.BrithDate;
            _dataContext.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonal(int id)
        {
            var data = _dataContext.Personals.FirstOrDefault(x => x.Id == id);
            _dataContext.Remove(data);
            _dataContext.SaveChanges();
            return Ok();
        }
    }
}
