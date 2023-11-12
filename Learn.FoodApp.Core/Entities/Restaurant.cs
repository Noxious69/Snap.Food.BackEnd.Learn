 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.FoodApp.Core.Entities
{
    public class Restaurant : BaseEntiti
    {
        public string Title { get; set; }
        public ApplicationUsers Owner { get; set; }
        public string? OwnerUsername { get; set; }
        public bool IsApproved { get; set; }
        public ApplicationUsers Approver { get; set; }
        public string? ApproverUsername { get; set; }
        public DateTime? ApprowedTime { get; set; }
        public bool IsActive { get; set; }
    }
}
