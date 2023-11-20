using Microsoft.AspNetCore.Mvc;
using ProgRecords.Class;
using ProgRecords.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProgRecords.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicRecordsController : ControllerBase
    {

        MusicRecordsRepository _Repo;
        public MusicRecordsController(MusicRecordsRepository records_repo)
        {
            _Repo = records_repo;
        }


        // GET: api/<MusicRecordsController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<List<MusicRecord>> Get()
        {
            return Ok(_Repo.Get());
        }

        // GET api/<MusicRecordsController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<MusicRecord> Get(int id)
        {
            return Ok(_Repo.GetById(id));
        }


        // POST api/<MusicRecordsController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public void Post([FromBody] MusicRecord value)
        {
            _Repo.Add(value);
        }

        // PUT api/<MusicRecordsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MusicRecordsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
