using AutoMapper;
using EpiConnectAPI.Core.Model;
using EpiConnectAPI.Core.ViewModel;

namespace EpiConnectAPI.Core.MapConfiguration {
    public class MapConfig {
        public MapConfig() { }

        public static MapperConfiguration RegisterMaps() {
            var mappingConfig = new MapperConfiguration(c => {
                c.CreateMap<EmployeeRequestView, Employee>()
               .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
               .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone));
                c.CreateMap<Employee, EmployeeRequestView>();

                c.CreateMap<Phone, PhoneRequestView>();
                c.CreateMap<PhoneRequestView, Phone>();

                c.CreateMap<Address, AddressRequestView>();
                c.CreateMap<AddressRequestView, Address>();
                
                c.CreateMap<Epi, EpiRequestView>();
                c.CreateMap<EpiRequestView, Epi>();


            });
            return mappingConfig;
        }
    }
}
