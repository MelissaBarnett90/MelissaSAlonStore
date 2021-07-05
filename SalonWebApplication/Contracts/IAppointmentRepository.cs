using SalonWebApplication.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalonWebApplication.Contracts
{
    interface IAppointmentRepository : IRepositoryBase<Appointment>
    {
        ICollection<Appointment> GetAppointmentsByID(int id);
    }
}


