using SalonWebApplication.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalonWebApplication.Contracts
{
    interface IPaymentTypeRepository : IRepositoryBase<PaymentType>
    {
        ICollection<PaymentType> GetPaymentTypesByID(int id);
    }
}



