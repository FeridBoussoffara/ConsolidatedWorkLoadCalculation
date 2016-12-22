using CWC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWC.Services
{
    public interface IProviderServices
    {
        Provider MostActiveProvider();
        List<Provider> GetProviderByRegion(String Adresse);

        List<Product> GetProductByProviderRegion(String Adresse);

        Product GetMostProductByProvider(Provider p);
    }
}
