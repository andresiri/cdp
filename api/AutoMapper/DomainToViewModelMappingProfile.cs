using AutoMapper;
using domain.Entities;
using api.ViewModel;
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
        }
    }
}
