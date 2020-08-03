using System.Collections.Generic;
using JessieProvider;
using JessieProvider.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ViewpointWebServiceCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JessieController : ControllerBase
    {
        // GET: api/<JessieController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<JessieController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<JessieController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<JessieController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<JessieController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }


        ///api/Jessie/surfboard
        [HttpGet("surfboard")]
        public List<SurfboardDataModel> GetSurfboards()
        {
            JessieItemsProvider jessieItemsProvider = new JessieItemsProvider();
            return jessieItemsProvider.GetSurfboards();
        }

        ///api/Jessie/movie
        [HttpGet("movie")]
        public List<MovieDataModel> GetMovies()
        {
            JessieItemsProvider jessieItemsProvider = new JessieItemsProvider();
            return jessieItemsProvider.GetMovies();
        }
    }
}
