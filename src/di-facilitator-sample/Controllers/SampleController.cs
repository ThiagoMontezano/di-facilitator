using System.Collections.Generic;
using System.Linq;
using difacilitatorsample.Entities;
using difacilitatorsample.Entities.OtherImplementations;
using Microsoft.AspNetCore.Mvc;

namespace di_facilitator_sample.Controllers
{
    [Route("api/sample")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        readonly IEnumerable<ISampleSimpleText> samples;
        readonly OtherClass otherClass;

        public SampleController(IEnumerable<ISampleSimpleText> samples, OtherClass otherClass)
        {
            this.samples = samples;
            this.otherClass = otherClass;
        }

        [HttpGet("singleton")]
        public ActionResult<string> Get()
        {
            return samples.FirstOrDefault(s => s.GetType() == typeof(SingletonSample)).print();
        }

        [HttpGet("scoped")]
        public ActionResult<string> GetScoped()
        {
            return samples.FirstOrDefault(s => s.GetType() == typeof(ScopedSample)).print();
        }

        [HttpGet("transient")]
        public ActionResult<string> GetTransient()
        {
            return samples.FirstOrDefault(s => s.GetType() == typeof(TransientSample)).print();
        }

        [HttpGet("otherClass")]
        public ActionResult<string> GetOtherClass()
        {
            return otherClass.otherPrint();
        }
    }
}
