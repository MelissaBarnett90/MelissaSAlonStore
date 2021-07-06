using SalonWebApplication.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalonWebApplication.Contracts
{
    interface IOrdersDetailsRepository : IRepositoryBase<OrdersDetails>
    {
        ICollection<OrdersDetails> GetOrdersDetailsByID (int id);
        
    }
}


