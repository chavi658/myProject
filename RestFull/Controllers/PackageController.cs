using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestFull.Entities;

namespace RestFull.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageController : Controller
    {

        private DataContex data;
        public PackageController(DataContex contex)
        {
            data = contex;
        }


        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<Employee> Get() => employees;


        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public ActionResult<Employee> Get(string id)
        {

            var x = data.PackageList.Find(x => x.Id == id);
            if (x == null)
            {
                return NotFound();
            }

            return x;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] Package value)
        {
            data.PackageList.Add(value);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public ActionResult<Employee> Put(string id, [FromBody] Package value)
        {
            var package = data.PackageList.Find(e => e.Id == id);
            if (package == null)
            {
                return NotFound();
            }
            package.Status = value.Status;
            package.Salary = value.Salary;
            return package;
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            var package = data.PackageList.Find(e => e.Id == id);
            if (package == null)
            {
                NotFound();
            }
            data.PackageList.Remove(package);
        }
    }
}

