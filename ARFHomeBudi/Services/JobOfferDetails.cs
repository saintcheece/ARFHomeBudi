using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARFHomeBudi.Services
{
    public class JobOfferDetails
    {
        public string JobTitle { get; set; }
        public string Location { get; set; }
        public string CatName { get; set; }
        public string JobDesc { get; set; }
        public DateTime JobSched { get; set; }
        public decimal JobAddPay { get; set; }
    }
}
