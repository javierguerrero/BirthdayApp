using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapper
{
    public class ContactMapperProfile : Profile
    {
        public ContactMapperProfile()
        {
            CreateMap<Contact, ContactDto>()
                .ForMember(dest => dest.FullName, source => source.MapFrom(source => source.Name + " " + source.LastName))
                .ReverseMap();
        }
    }
}