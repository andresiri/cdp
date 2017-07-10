using api.ViewModel;
using AutoMapper;
using domain.Entities;

namespace api.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<User, UserViewModel>();
            CreateMap<Arena, ArenaViewModel>();
            CreateMap<Pelada, PeladaViewModel>();
            CreateMap<PeladaUser, PeladaUserViewModel>();
            CreateMap<PeladaEvent, PeladaEventViewModel>();
        }
    }
}
