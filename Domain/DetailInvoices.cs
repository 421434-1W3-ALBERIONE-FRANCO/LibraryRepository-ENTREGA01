using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLibrery.Domaim
{
	public class Detailinvoices
	{
        public int IdDetalle { get; set; }
        public Book Book { get; set; }

        public decimal UnitPrice { get; set; }

        public int Count { get; set; }

    }
}