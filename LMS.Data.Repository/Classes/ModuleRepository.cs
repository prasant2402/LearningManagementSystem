using LMS.Data.Repository;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Data.BL
{
    public class ModuleRepository : IRepository<Module>
    {
        private static ModuleRepository instance = null;
        private Repository<Module> context;

        private ModuleRepository()
        {
            context = new Repository<Module>();
        }

        public static ModuleRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ModuleRepository();
                }
                return instance;
            }
        }

        public Task<Acknowledgement<Module>> CreateRecord(Module Entity)
        {
            return context.CreateRecord(Entity);
        }

        public Task<Acknowledgement<Module>> UpdateRecord(string id, UpdateDefinition<Module> Entity)
        {
            return context.UpdateRecord(id, Entity);
        }

        public Task<Acknowledgement<Module>> DeleteRecord(IEnumerable<string> ids)
        {
            return context.DeleteRecord(ids);
        }

        public Task<Acknowledgement<Module>> GetItems(IEnumerable<string> ids)
        {
            return context.GetItems(ids);
        }

        public Task<Acknowledgement<Module>> GetAll()
        {
            return context.GetAll();
        }
    }
}
