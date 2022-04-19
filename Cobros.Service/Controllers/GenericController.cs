using Cobros.Service.Intefaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cobros.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenericController<T> : ControllerBase where T : class, IEntity
    {
        private readonly IGenericRepository<T> _repo;
        public GenericController(IGenericRepository<T> repo) => _repo = repo;

        [HttpGet]
        public IQueryable<T> Get() => _repo.GetAll();
       

        [HttpGet("{id}")]
        public async Task<T> Get(int id) => await _repo.GetById(id);

        [HttpPost]
        public async Task Add(T value) => await _repo.Add(value);
        

        [HttpDelete("{id}")]
        public async void Delete(int id) => await _repo.Delete(id);

    }
}
