using RepositoryLibrery.Data.Implementations;
using RepositoryLibrery.Data.Interface;
using RepositoryLibrery.Domaim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLibrery.Services
{
    internal class InvoicesService
    {
        private IInvoiceRepository _invoiceRepository;
    

        public InvoicesService ()
        {
            _invoiceRepository = new InvoiceRepository();
        }

        public List<Invoice> GetAll()
        {
            return _invoiceRepository.GetAll();
        }
        public bool Save(Invoice invoice)
        {
            return _invoiceRepository.Save(invoice);
        }
    }
}
