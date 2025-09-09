using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RepositoryLibrery.Domaim
{
    public class Invoice
    {
        public int Codigo { get; set; }
        public DateTime Date { get; set; }

        public string Client { get; set; }
        public int expiration { get; set; }

        public List<Invoice> Invoices { get; set; }
        public IEnumerable<object> DetailInvoices { get; internal set; }
        public object Seller { get; internal set; }
    }
}

