using SalonWebApplication.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalonWebApplication.Contracts
{
    interface IServiceAppointmentRepository : IRepositoryBase<ServiceAppointment>
    {
        ICollection<ServiceAppointment> GetServiceAppointmentsByID(int id);
    }
}


