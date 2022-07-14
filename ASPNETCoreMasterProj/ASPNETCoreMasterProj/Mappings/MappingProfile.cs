using AutoMapper;
using DomainModels.BindingModels;
using DomainModels.Entity;

namespace Repositories.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<StudentViewModel, Student>().ReverseMap();
            CreateMap<ClassNameViewModel, ClassName>().ReverseMap();
        }
    }
}
