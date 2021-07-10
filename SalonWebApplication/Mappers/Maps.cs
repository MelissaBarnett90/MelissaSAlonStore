using AutoMapper;
using SalonWebApplication.Data;
using SalonWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SalonWebApplication.Mappers
{
    public class Maps : Profile
    { 
        public Maps()
        {
            CreateMap<Appointment, AppointmentViewModel>().ReverseMap();
            CreateMap<Customer, CustomerViewModel>().ReverseMap();
            CreateMap<Employee, EmployeeViewModel>().ReverseMap();
            ////  CreateMap<Supplier, CalcationViewModel>().ReverseMap();

            CreateMap<Order, OrderViewModel>().ReverseMap();
            CreateMap<OrdersDetails, OrdersDetailsViewModel>().ReverseMap();
            CreateMap<PaymentType, PaymentTypeViewModel>().ReverseMap();

            CreateMap<Product, ProductViewModel>().ReverseMap();
            CreateMap<ServiceAppointment, ServiceAppointmentViewModel>().ReverseMap();
            CreateMap<Service, ServiceViewModel>().ReverseMap();
       



        }

    }
}
