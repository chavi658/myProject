using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestFull.Entities;

namespace RestFull.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestController : Controller
    {
        private DataContex data;
        public GuestController(DataContex contex)
        {
            data = contex;
        }


        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<Guest> Get() => data.GuestList;


        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public ActionResult<Guest> Get(int id)
        {
            var x = data.GuestList.Find(x => x.Id == id);
            if (x==null)
            {
              return  NotFound();
            }

            return x;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] Guest value)
        {
            data.GuestList.Add(value);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public ActionResult<Guest> Put(int id, [FromBody] Guest value)
        {
            var guest = data.GuestList.Find(e => e.Id == id);
            guest.Status = value.Status;
            if (guest == null)
            {
               return  NotFound();
            }

            return guest;
        }
        [HttpPut("{id}/status")]
        public Guest Put(int id, [FromBody] string status)
        {
            //find the object by id
            var guest = data.GuestList.Find(e => e.Id == id);
            //udpate properties
            //eve.Title = updateEvent.Title;
            return guest;
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var guest = data.GuestList.Find(e => e.Id == id);
            if (guest == null)
            {
                NotFound();
            }
         else data.GuestList.Remove(guest);
        }
    }
}
