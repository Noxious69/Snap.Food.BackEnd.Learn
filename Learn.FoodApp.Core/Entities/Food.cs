using Learn.FoodApp.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.FoodApp.Core.Entities
{
    public class Food : BaseEntiti
    {
        public string Name { get; set; }
        public FoodTypes Type { get; set; }
        public string Count { get; set; }
        public string? CustomerName { get; set; }
        public ApplicationUsers? Customer { get; set; }
        public ApplicationUsers? RestaurantSender { get; set; }
        public DateTime Ordered { get; set; }
    }
}
