using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Data.Repository
{
    public class Acknowledgement<TEntity>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public IEnumerable<TEntity> Entities { get; set; }
        public int ErrorCode { get; set; }
        public Acknowledgement()
        {
            Success = false;
            Message = "";
            Entities = null;
            ErrorCode = 500;
        }
    }
}
