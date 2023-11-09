using Microsoft.AspNetCore.Mvc;
using RestFull.Entities;

namespace RestFull.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : Controller
    {

        private DataContex data;
        public RoomController(DataContex contex)
        {
            data = contex;
        }




        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<Room> Get() => data.RoomList;


        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public ActionResult<Room> Get(int id)
        {
            var x = data.RoomList.Find(x => x.Id == id);
            if (x == null)
            {
                return NotFound();
            }

            return x;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] Room value)
        {
            data.RoomList.Add(value);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public ActionResult<Room> Put(int id, [FromBody] Room value)
        {
            var room = data.RoomList.Find(e => e.Id == id);
            if (room == null)
            {
                return NotFound();
            }
            room.Avialable = value.Avialable;
            room.Id=id;
            
            return room;
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var room = data.RoomList.Find(e => e.Id == id);
            if (room==null)
            {
                NotFound();
            }
            data.RoomList.Remove(room);
        }
    }
}
