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
            CreateMap<PeladaTeam, PeladaTeamViewModel>();

            CreateMap<PeladaUser, PeladaUserViewModel>()
                .ForMember(viewModel => viewModel.PeladaName, opt => opt.MapFrom(model => model.Pelada.Name));
            
            CreateMap<PeladaEvent, PeladaEventViewModel>();
        }
    }
}
