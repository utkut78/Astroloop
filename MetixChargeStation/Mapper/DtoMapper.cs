using AutoMapper;
using MetixChargeStation.Dtos;
using MetixChargeStation.Models;

namespace MetixChargeStation.Mapper
{
    public class DtoMapper : Profile
    {
        //AutoMapper'ın hangi sınıfın hangi dtoya veya dtonun hangi sınıfa dönüştürüleceğini bildiriyoruz
        public DtoMapper()
        {
            CreateMap<AccountDto,Account>().ReverseMap();
            CreateMap<AccountGroupDto,AccountGroup>().ReverseMap();
            CreateMap<CarModelDto, CarModel>().ReverseMap();
            CreateMap<CompanyDto,Company>().ReverseMap();
            CreateMap<LocationDto,Location>().ReverseMap();
            CreateMap<OpportunityDto,Opportunity>().ReverseMap();
            CreateMap<RoleDto,Role>().ReverseMap();
            CreateMap<SensorDto,Sensor>().ReverseMap();
            CreateMap<SensorTypeDto,SensorType>().ReverseMap();
            CreateMap<StationDto,Station>().ReverseMap();
            CreateMap<UserDto,User>().ReverseMap();
            CreateMap<UserRoleClaimDto,UserRoleClaim>().ReverseMap();
            CreateMap<UserToRoleDto,UserToRole>().ReverseMap();
        }
    }
}
