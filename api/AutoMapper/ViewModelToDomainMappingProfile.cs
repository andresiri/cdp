using api.ViewModel;
using domain.Entities;
using AutoMapper;
namespace api.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ArenaViewModel, Arena>();
            CreateMap<UserViewModel, User>();
            CreateMap<PeladaViewModel, Pelada>();
            CreateMap<PeladaUserViewModel, PeladaUser>();
        }
    }
}
