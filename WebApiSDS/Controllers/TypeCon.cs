using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entity;
using Microsoft.AspNetCore.Mvc;
using SDS.Core.ApplicationService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiSDS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeCon : ControllerBase
    {
        private readonly ITypeService _typeService;

        public TypeCon(ITypeService typeService)
        {
            _typeService = typeService;
        }
        // GET: api/<TypeCon>
        [HttpGet]
        public IEnumerable<AvatarType> Get()
        {
            return _typeService.GetTypes();
        }

        // GET api/<TypeCon>/5
        [HttpGet("{id}")]
        public ActionResult<AvatarType> GetAvatarType(int id)
        {
            return _typeService.ReadTypeById(id);
        }

        // POST api/<TypeCon>
        [HttpPost]
        public ActionResult<AvatarType> Post([FromBody] AvatarType aType)
        {
            return _typeService.CreateType(aType);
        }

        // PUT api/<TypeCon>/5
        [HttpPut("{id}")]
        public ActionResult<AvatarType> Put(int id, [FromBody] AvatarType aType)
        {
            return _typeService.UpdateAvatarType(aType);
        }

        // DELETE api/<TypeCon>/5
        [HttpDelete("{id}")]
        public ActionResult<AvatarType> Delete(int id)
        {
            return _typeService.DeleteType(id);
        }
    }
}
