using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsNewCSharp
{
    public struct Address
    {
        public string City { get; init; } = "Bilinmiyor";

        public Address()
        {

        }
    }

    public record struct Person(string firstName, string lastName);

}
