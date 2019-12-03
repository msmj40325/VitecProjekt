using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VitecProjekt.Models
{
    public class Subscription
    {
        //private Enum SubscriptionType { Monthly, Yearly };

        //public SubscriptionType Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int DeviceLimit { get; set; }
    }
}
