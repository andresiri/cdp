using api.ViewModel;
using AutoMapper;
using domain.Entities;

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
            CreateMap<PeladaEventViewModel, PeladaEvent>();
        }
    }
}
