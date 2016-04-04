using LMS.Data.BL;
using LMS.Data.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace LMS.Web.UI
{
    public class ModulesAPIController : ApiController
    {
        IModule _module;

        [HttpGet]
        [ActionName("GetAllModules")]
        public async Task<Acknowledgement<Module>> GetAllModules()
        {
            _module = new ModuleBLC();
            return await _module.GetAll();
        }

        // GET api/<controller>/5
        public string Get(string id)
        {
            return "value";
        }

        [HttpPost]
        [ActionName("AddModule")]
        public async Task<Acknowledgement<Module>> Post(Module module)
        {
            _module = new ModuleBLC();
            return await _module.CreateRecord(module);
        }

        [HttpGet]
        [ActionName("DeleteModule")]
        public async Task<Acknowledgement<Module>> Delete(List<string> ids)
        {
            _module = new ModuleBLC();
            return await _module.DeleteRecord(ids);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}