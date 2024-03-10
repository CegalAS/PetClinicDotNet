using AutoMapper;
using PetClinic.Common;
using PetClinic.Dto;
using PetClinic.Model;

namespace PetClinic.Mapper
{
    public class ClientAutoMapperProfile : Profile
    {
        public ClientAutoMapperProfile()
        {
            CreateMap<DateTimeOffset, DateTime>().ConstructUsing((src, ctx) => src.UtcDateTime);

            CreateMap<DateTime, DateTimeOffset>()
                .ConstructUsing((src, ctx) => src.GetDateTimeOffset());

            CreateMap<PostClientDto, Client>()
                .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate))
                .ForMember(dest => dest.Sex, opt => opt.MapFrom(src => src.Sex));

            //TODO: Add mapping for pets and appointments
            CreateMap<Client, GetClientDto>()
                .ForMember(
                    dest => dest.BirthDate,
                    opt => opt.MapFrom(src => src.BirthDate.GetDateTimeOffset())
                )
                .ForMember(
                    dest => dest.Address,
                    opt => opt.MapFrom(src => $"{src.StreetAddress}, {src.ZipCode} {src.City}")
                );
        }
    }
}
