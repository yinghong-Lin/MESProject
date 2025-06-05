using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDM.Model.UserEntities
{
    public class Durable
    {
        public string DurableId { get; set; }
        public string SpecDescription { get; set; }
        public string DurableType { get; set; }
        public int ExpectedLife { get; set; }
        public int CurrentUsage { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public string Supplier { get; set; }
    }
}
