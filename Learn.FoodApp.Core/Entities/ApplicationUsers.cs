using Learn.FoodApp.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Learn.FoodApp.Core.Entities
{
    public class ApplicationUsers
    {
        public string? Username { get; set; }

        [JsonIgnore]
        public string? Password { get; set; }
        public string? AgainPass { get; set; }
        public string? Fullname { get; set; }
        public ApplicationUserType Type { get; set; }
        public string? Email { get; set; }
        public string? phone { get; set; }

        public bool Verifide { get; set; } = false;

        public string UserType
        {
            get
            {
                switch (this.Type)
                {
                    case ApplicationUserType.SystemAdmin:
                        return "مدیریت";
                        break;

                    case ApplicationUserType.Customer:
                        return "مشتری";
                        break;

                    case ApplicationUserType.RestaurantOwner:
                        return "رستوران دار";
                        break;
                }
                return "ناشناخته";
            }
        }
    }
}
