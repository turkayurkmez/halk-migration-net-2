using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsNewCSharp
{
    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public Vendor Vendor { get; set; }

    }

    public class Vendor
    {
        public string CompanyName { get; set; }
    }
}
