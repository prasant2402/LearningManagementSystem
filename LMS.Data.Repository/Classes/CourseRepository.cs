using LMS.Data.Repository;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Data.BL
{
    public class CourseRepository : IRepository<Course>
    {
        private static CourseRepository instance = null;
        private Repository<Course> context;

        private CourseRepository()
        {
            context = new Repository<Course>();
        }

        public static CourseRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CourseRepository();
                }
                return instance;
            }
        }

        public Task<Acknowledgement<Course>> CreateRecord(Course Entity)
        {
            return context.CreateRecord(Entity);
        }

        public Task<Acknowledgement<Course>> UpdateRecord(string id, UpdateDefinition<Course> Entity)
        {
            return context.UpdateRecord(id, Entity);
        }

        public Task<Acknowledgement<Course>> DeleteRecord(IEnumerable<string> ids)
        {
            return context.DeleteRecord(ids);
        }

        public Task<Acknowledgement<Course>> GetItems(IEnumerable<string> ids)
        {
            return context.GetItems(ids);
        }

        public Task<Acknowledgement<Course>> GetAll()
        {
            return context.GetAll();
        }
    }
}
