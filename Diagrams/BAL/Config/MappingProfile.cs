using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Models.DTOs;
using Models.Entities;

namespace BAL.Config
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserDiagram, UserDiagramsPageDTO>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.DiagramId));
            //CreateMap<List<UserDiagram>, List<UserDiagramsPageDTO>>();
            CreateMap<Diagram, DiagramBasicInfoDTO>().ReverseMap();
            CreateMap<UserDiagram, NewDiagramDTO>().ReverseMap();
            CreateMap<UserDiagram, DiagramUpdateDTO>().ReverseMap();
            CreateMap<Diagram, DiagramCreateDTO>().ReverseMap();
            CreateMap<User, UserBasicInfoDTO>();
            CreateMap<Diagram, DiagramUpdateDTO>().ReverseMap();

        }
    }
}
