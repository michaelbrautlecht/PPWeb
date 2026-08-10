using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPModel
{
    public enum PublicationType
    {
        Wareneingang172,
        Verteilung434,
        Personal
    }

    public class PublicationItem
    {
        public int PublicationId { get; set; }
        public DateTime? PublicationDate { get; set; }
        public PublicationType PublicationType { get; set; }
    }
}
