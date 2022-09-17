using AutoMapper;
using EGID.Test.API.Data.Dtos;
using EGID.Test.API.Data.Entities;

namespace EGID.Test.API.Data.Mapping
{

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Resource
            //CreateMap<Department, DepartmentResource>();
            CreateMap<Stock, StockResource>();
            CreateMap<Broker ,BrokerResource> ();
            CreateMap<Person, ClientResource>();
            CreateMap<Order, OrderResource>();

            // Resource to Domain
            //CreateMap<DepartmentResource, Department>();
            CreateMap<StockResource, Stock>();

            CreateMap<SaveOrderResource, Order>();
            //CreateMap<SaveEmployeeResource, Employee>();
        }
    }
}
