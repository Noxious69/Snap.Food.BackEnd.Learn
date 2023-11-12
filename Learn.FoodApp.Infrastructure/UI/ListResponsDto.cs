using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.FoodApp.Infrastructure.UI
{
    public class ListResponsDto<T>
    {
        public int TotalCount { get; set; }
        public List<T>? Data { get; set; }

    }
}
