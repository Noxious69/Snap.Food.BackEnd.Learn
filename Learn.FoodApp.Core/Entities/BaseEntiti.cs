using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.FoodApp.Core.Entities
{
    public class BaseEntiti
    {
        public virtual int Id { get; set; }
        public DateTime CreationTime { get; set; }

        public BaseEntiti()
        {
            CreationTime = DateTime.Now;
        }
    }
}
